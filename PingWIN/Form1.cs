using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingWIN
{
    public partial class Form1 : Form
    {
        private const int SlowThresholdMs = 150;
        private const int EM_SETCUEBANNER = 0x1501;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static readonly Color StartColor = Color.FromArgb(46, 160, 98);
        private static readonly Color StopColor = Color.FromArgb(214, 69, 85);

        private readonly List<HostEntry> hosts = new List<HostEntry>();
        private const string PortableHostsFileName = "PingWIN.hosts.txt";

        // Dawna lokalizacja listy – używana, gdy folderu programu nie da się zapisać.
        private static readonly string LegacyHostsFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PingWIN", "hosts.txt");

        private readonly string hostsFile = ResolveHostsFile();

        private bool running;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public Form1()
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            gridMenu.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable());
            EnableDoubleBuffering(grid);
            LoadHosts();
            UpdateButtons();
        }

        #region Cykl życia formularza

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Ciemny pasek tytułu w Windows 10 (20H1+) i Windows 11.
            int useDark = 1;
            try { DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int)); }
            catch (DllNotFoundException) { }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SendMessage(txtAddress.Handle, EM_SETCUEBANNER, (IntPtr)1, "Adres IP lub nazwa hosta");
            SendMessage(txtName.Handle, EM_SETCUEBANNER, (IntPtr)1, "Nazwa (opcjonalnie)");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Skalowanie DPI zmienia szerokości kolumn, a tym samym ich wagi – przywracamy proporcje.
            colStatus.FillWeight = 20;
            colName.FillWeight = 15;
            colAddress.FillWeight = 15;
            colRtt.FillWeight = 8;
            colAvg.FillWeight = 8;
            colMinMax.FillWeight = 10;
            colLoss.FillWeight = 7;
            colSentReceived.FillWeight = 9;
            colHistory.FillWeight = 22;

            grid.ClearSelection();
            txtAddress.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            pingTimer.Stop();
            SaveHosts();
            base.OnFormClosing(e);
        }

        #endregion

        #region Dodawanie i usuwanie hostów

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HostEntry entry = AddHost(txtAddress.Text, txtName.Text, showErrors: true);
            if (entry == null)
                return;

            txtAddress.Clear();
            txtName.Clear();
            txtAddress.Focus();
            SaveHosts();

            if (running)
                _ = PingHostAsync(entry);
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAdd.PerformClick();
            }
        }

        private HostEntry AddHost(string address, string name, bool showErrors)
        {
            address = (address ?? string.Empty).Trim();
            name = (name ?? string.Empty).Trim();

            string error = null;
            if (address.Length == 0)
                error = "Podaj adres IP lub nazwę hosta.";
            else if (Uri.CheckHostName(address) == UriHostNameType.Unknown)
                error = $"„{address}” nie jest prawidłowym adresem IP ani nazwą hosta.";
            else if (hosts.Any(h => string.Equals(h.Address, address, StringComparison.OrdinalIgnoreCase)))
                error = $"Adres „{address}” jest już na liście.";

            if (error != null)
            {
                if (showErrors)
                {
                    MessageBox.Show(this, error, "PingWIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    txtAddress.SelectAll();
                }
                return null;
            }

            var entry = new HostEntry(name.Length > 0 ? name : address, address);
            hosts.Add(entry);

            int index = grid.Rows.Add();
            DataGridViewRow row = grid.Rows[index];
            row.Tag = entry;
            UpdateRow(row);
            UpdateButtons();
            lblSummary.Invalidate();
            return entry;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && !grid.IsCurrentCellInEditMode)
            {
                e.Handled = true;
                RemoveSelected();
            }
        }

        private void RemoveSelected()
        {
            List<DataGridViewRow> rows = grid.SelectedRows.Cast<DataGridViewRow>().ToList();
            if (rows.Count == 0)
                return;

            if (rows.Count > 1 &&
                MessageBox.Show(this, $"Usunąć {rows.Count} zaznaczonych hostów?", "PingWIN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in rows)
            {
                hosts.Remove((HostEntry)row.Tag);
                grid.Rows.Remove(row);
            }

            grid.ClearSelection();
            SaveHosts();
            UpdateButtons();
            lblSummary.Invalidate();
        }

        #endregion

        #region Pingowanie

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            running = !running;

            if (running)
            {
                pingTimer.Interval = (int)numInterval.Value;
                pingTimer.Start();
                PingAll(hosts);
            }
            else
            {
                pingTimer.Stop();
            }

            btnStartStop.Text = running ? "■  Stop" : "▶  Start";
            btnStartStop.BackColor = running ? StopColor : StartColor;
            lblSubtitle.Text = running
                ? "Monitorowanie aktywne…"
                : "Monitor dostępności hostów w czasie rzeczywistym";
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            pingTimer.Interval = (int)numInterval.Value;
        }

        private void pingTimer_Tick(object sender, EventArgs e)
        {
            PingAll(hosts);
        }

        private void btnPingNow_Click(object sender, EventArgs e)
        {
            PingAll(SelectedOrAllHosts());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog(this);
            }
        }

        private void PingAll(IEnumerable<HostEntry> targets)
        {
            foreach (HostEntry entry in targets.ToList())
            {
                if (!entry.Busy)
                    _ = PingHostAsync(entry);
            }
        }

        private async Task PingHostAsync(HostEntry entry)
        {
            entry.Busy = true;
            try
            {
                using (var ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(entry.Address, (int)numTimeout.Value);
                    entry.RecordReply(reply.Status, reply.RoundtripTime, SlowThresholdMs);
                }
            }
            catch (PingException ex) when (ex.InnerException is SocketException)
            {
                entry.RecordError("Nie znaleziono hosta", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                entry.RecordError("Błąd", (ex.InnerException ?? ex).Message);
            }
            finally
            {
                entry.Busy = false;
            }

            // Host mógł zostać usunięty w trakcie oczekiwania na odpowiedź.
            DataGridViewRow row = FindRow(entry);
            if (row != null)
            {
                UpdateRow(row);
                lblSummary.Invalidate();
            }
        }

        #endregion

        #region Pozostałe akcje

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (HostEntry entry in SelectedOrAllHosts())
            {
                entry.ResetStatistics();
                DataGridViewRow row = FindRow(entry);
                if (row != null)
                    UpdateRow(row);
            }
            lblSummary.Invalidate();
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            List<HostEntry> selected = SelectedHosts().ToList();
            if (selected.Count > 0)
                Clipboard.SetText(string.Join(Environment.NewLine, selected.Select(h => h.Address)));
        }

        private void gridMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = grid.SelectedRows.Count == 0;
        }

        private void grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Prawy przycisk zaznacza wiersz pod kursorem, by menu dotyczyło właściwego hosta.
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && !grid.Rows[e.RowIndex].Selected)
            {
                grid.ClearSelection();
                grid.Rows[e.RowIndex].Selected = true;
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.BackColor = Theme.Surface;
            e.Control.ForeColor = Theme.Text;
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colName.Index)
                return;

            DataGridViewRow row = grid.Rows[e.RowIndex];
            var entry = (HostEntry)row.Tag;
            string newName = Convert.ToString(row.Cells[colName.Index].Value)?.Trim();

            entry.Name = string.IsNullOrEmpty(newName) ? entry.Address : newName;
            row.Cells[colName.Index].Value = entry.Name;
            SaveHosts();
        }

        private void UpdateButtons()
        {
            bool hasSelection = grid.SelectedRows.Count > 0;
            btnRemove.Enabled = hasSelection;
            btnReset.Text = hasSelection ? "↺  Resetuj zaznaczone" : "↺  Resetuj statystyki";
            btnPingNow.Text = hasSelection ? "⚡  Pinguj zaznaczone" : "⚡  Pinguj teraz";
        }

        private IEnumerable<HostEntry> SelectedHosts()
        {
            return grid.SelectedRows.Cast<DataGridViewRow>().Select(r => (HostEntry)r.Tag);
        }

        private IEnumerable<HostEntry> SelectedOrAllHosts()
        {
            return grid.SelectedRows.Count > 0 ? SelectedHosts().ToList() : hosts.ToList();
        }

        private DataGridViewRow FindRow(HostEntry entry)
        {
            return grid.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Tag == entry);
        }

        #endregion

        #region Prezentacja

        private void UpdateRow(DataGridViewRow row)
        {
            var h = (HostEntry)row.Tag;
            bool hasData = h.Received > 0;

            row.Cells[colStatus.Index].Value = h.StatusText;
            row.Cells[colStatus.Index].ToolTipText = h.ErrorMessage ?? string.Empty;
            if (!row.Cells[colName.Index].IsInEditMode)
                row.Cells[colName.Index].Value = h.Name;
            row.Cells[colAddress.Index].Value = h.Address;
            row.Cells[colRtt.Index].Value = h.LastRtt.HasValue ? h.LastRtt + " ms" : "—";
            row.Cells[colAvg.Index].Value = hasData ? $"{h.AverageRtt:0} ms" : "—";
            row.Cells[colMinMax.Index].Value = hasData ? $"{h.MinRtt} / {h.MaxRtt} ms" : "—";
            row.Cells[colLoss.Index].Value = h.Sent > 0 ? $"{h.LossPercent:0.#}%" : "—";
            row.Cells[colSentReceived.Index].Value = $"{h.Sent} / {h.Received}";

            Color lossColor = h.Sent == 0 || h.LossPercent == 0 ? Theme.Text
                : h.LossPercent < 50 ? Theme.Slow : Theme.Offline;
            row.Cells[colLoss.Index].Style.ForeColor = lossColor;
            row.Cells[colLoss.Index].Style.SelectionForeColor = lossColor;

            Color rttColor = !h.LastRtt.HasValue ? Theme.MutedText
                : h.LastRtt > SlowThresholdMs ? Theme.Slow : Theme.Online;
            row.Cells[colRtt.Index].Style.ForeColor = rttColor;
            row.Cells[colRtt.Index].Style.SelectionForeColor = rttColor;

            grid.InvalidateCell(colHistory.Index, row.Index);
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var entry = grid.Rows[e.RowIndex].Tag as HostEntry;
            if (entry == null)
                return;

            if (e.ColumnIndex == colStatus.Index)
                PaintStatusCell(e, entry);
            else if (e.ColumnIndex == colHistory.Index)
                PaintHistoryCell(e, entry);
        }

        private static void PaintStatusCell(DataGridViewCellPaintingEventArgs e, HostEntry entry)
        {
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color color = Theme.ForState(entry.State);
            const int size = 10;
            var dot = new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y + (e.CellBounds.Height - size) / 2, size, size);

            using (var glow = new SolidBrush(Color.FromArgb(55, color)))
                g.FillEllipse(glow, Rectangle.Inflate(dot, 4, 4));
            using (var brush = new SolidBrush(color))
                g.FillEllipse(brush, dot);

            var textBounds = new Rectangle(dot.Right + 12, e.CellBounds.Y,
                e.CellBounds.Right - dot.Right - 14, e.CellBounds.Height);
            bool selected = (e.State & DataGridViewElementStates.Selected) != 0;
            TextRenderer.DrawText(g, entry.StatusText, e.CellStyle.Font, textBounds,
                selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        private static void PaintHistoryCell(DataGridViewCellPaintingEventArgs e, HostEntry entry)
        {
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle area = Rectangle.Inflate(e.CellBounds, -10, -8);
            if (area.Width <= 0 || area.Height <= 0)
            {
                e.Handled = true;
                return;
            }

            using (var basePen = new Pen(Theme.Border))
                g.DrawLine(basePen, area.Left, area.Bottom, area.Right, area.Bottom);

            long?[] history = entry.History.ToArray();
            if (history.Length > 0)
            {
                long peak = history.Where(v => v.HasValue).Select(v => v.Value).DefaultIfEmpty(0).Max();
                double scale = Math.Max(100, peak);
                float slot = area.Width / (float)HostEntry.HistorySize;
                float barWidth = Math.Max(1f, slot - 2f);

                for (int i = 0; i < history.Length; i++)
                {
                    float x = area.Right - (history.Length - i) * slot + (slot - barWidth) / 2f;
                    long? value = history[i];

                    float height;
                    Color color;
                    if (value.HasValue)
                    {
                        // Skala pierwiastkowa – niskie czasy (kilka ms) nadal są dobrze widoczne.
                        height = Math.Max(3f, (float)(area.Height * Math.Sqrt(value.Value / scale)));
                        color = value.Value > SlowThresholdMs ? Theme.Slow : Theme.Online;
                    }
                    else
                    {
                        height = area.Height;
                        color = Color.FromArgb(170, Theme.Offline);
                    }

                    using (var brush = new SolidBrush(color))
                        g.FillRectangle(brush, x, area.Bottom - height, barWidth, height);
                }
            }

            e.Handled = true;
        }

        private void lblSummary_Paint(object sender, PaintEventArgs e)
        {
            var parts = new List<Tuple<string, Color?>>
            {
                Tuple.Create($"Hostów: {hosts.Count}", (Color?)null),
                Tuple.Create($"Online: {hosts.Count(h => h.State == HostState.Online)}", (Color?)Theme.Online),
                Tuple.Create($"Wolne: {hosts.Count(h => h.State == HostState.Slow)}", (Color?)Theme.Slow),
                Tuple.Create($"Offline: {hosts.Count(h => h.State == HostState.Offline)}", (Color?)Theme.Offline),
            };

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = lblSummary.Font;
            const int dotSize = 8, dotGap = 6, partGap = 22;
            int x = lblSummary.ClientSize.Width;
            int midY = lblSummary.ClientSize.Height / 2;

            for (int i = parts.Count - 1; i >= 0; i--)
            {
                string text = parts[i].Item1;
                Color? dotColor = parts[i].Item2;
                Size textSize = TextRenderer.MeasureText(g, text, font, Size.Empty, TextFormatFlags.NoPadding);

                x -= textSize.Width;
                TextRenderer.DrawText(g, text, font, new Point(x, midY - textSize.Height / 2),
                    dotColor.HasValue ? Theme.Text : Theme.MutedText, TextFormatFlags.NoPadding);

                if (dotColor.HasValue)
                {
                    x -= dotGap + dotSize;
                    using (var brush = new SolidBrush(dotColor.Value))
                        g.FillEllipse(brush, x, midY - dotSize / 2, dotSize, dotSize);
                }

                x -= partGap;
            }
        }

        private static void EnableDoubleBuffering(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, true, null);
        }

        #endregion

        #region Zapis i odczyt listy

        /// <summary>
        /// Lista hostów trzymana jest obok pliku exe, dzięki czemu przenosi się razem z programem.
        /// Gdy folderu programu nie da się zapisać (np. Program Files), używany jest %APPDATA%.
        /// </summary>
        private static string ResolveHostsFile()
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            string portable = Path.Combine(folder, PortableHostsFileName);

            if (File.Exists(portable) || IsFolderWritable(folder))
                return portable;

            return LegacyHostsFile;
        }

        private static bool IsFolderWritable(string folder)
        {
            try
            {
                string probe = Path.Combine(folder, Path.GetRandomFileName());
                using (File.Create(probe, 1, FileOptions.DeleteOnClose)) { }
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        private void LoadHosts()
        {
            string source = hostsFile;
            bool migrate = false;

            if (!File.Exists(source) && File.Exists(LegacyHostsFile))
            {
                // Przeniesienie listy zapisanej przez starsze wersje w %APPDATA%.
                source = LegacyHostsFile;
                migrate = true;
            }

            if (!File.Exists(source))
            {
                // Pierwsze uruchomienie – kilka przykładowych adresów.
                AddHost("8.8.8.8", "Google DNS", showErrors: false);
                AddHost("1.1.1.1", "Cloudflare DNS", showErrors: false);
                AddHost("127.0.0.1", "Localhost", showErrors: false);
                SaveHosts();
                return;
            }

            try
            {
                foreach (string line in File.ReadAllLines(source, Encoding.UTF8))
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length == 2)
                        AddHost(parts[1], parts[0], showErrors: false);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "Nie udało się wczytać listy hostów:\n" + ex.Message, "PingWIN",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (migrate)
                SaveHosts();
        }

        private void SaveHosts()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(hostsFile));
                File.WriteAllLines(hostsFile,
                    hosts.Select(h => h.Name.Replace('\t', ' ') + "\t" + h.Address), Encoding.UTF8);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show(this, "Nie udało się zapisać listy hostów:\n" + ex.Message, "PingWIN",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
