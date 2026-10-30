using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PingWIN
{
    /// <summary>
    /// Okno z informacjami o aplikacji i jej autorze.
    /// </summary>
    internal sealed class AboutForm : Form
    {
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const string Author = "Filip Dąbrowski";
        private const string Nick = "filipdab";

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public AboutForm()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Theme.Background;
            ForeColor = Theme.Text;
            Font = new Font("Segoe UI", 9.75F);
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "O autorze";

            // Okno dopasowuje się do zawartości, więc nic nie jest ucinane
            // ani nie nachodzi na siebie przy skalowaniu ekranu (125%, 150%...).
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(24, 16, 24, 20);

            var lblTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
                ForeColor = Theme.Text,
                Margin = new Padding(0, 0, 0, 2),
                Text = "PingWIN"
            };

            var lblVersion = MutedLabel("Wersja " + version.ToString(3));
            var lblDescription = MutedLabel("Monitor dostępności hostów w czasie rzeczywistym");

            var separator = new Panel
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Theme.Border,
                Height = 1,
                Margin = new Padding(0, 10, 0, 12)
            };

            var lblAuthorCaption = MutedLabel("Autor:");
            lblAuthorCaption.Anchor = AnchorStyles.Left;
            lblAuthorCaption.Margin = new Padding(0, 0, 8, 0);

            var lblAuthor = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Theme.Accent,
                Margin = Padding.Empty,
                Text = Author
            };

            var lblNick = MutedLabel(Nick);

            // Dwie kolumny: "Autor:" | imię i nazwisko, pod spodem nick.
            var authorTable = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 2,
                Margin = new Padding(0, 0, 0, 12)
            };
            authorTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            authorTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            authorTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            authorTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            authorTable.Controls.Add(lblAuthorCaption, 0, 0);
            authorTable.Controls.Add(lblAuthor, 1, 0);
            authorTable.Controls.Add(lblNick, 1, 1);

            var lblCopyright = MutedLabel("© " + DateTime.Now.Year + " " + Author + ". Wszelkie prawa zastrzeżone.");
            lblCopyright.Margin = new Padding(0, 0, 0, 16);

            var btnOk = new Button
            {
                Anchor = AnchorStyles.Right,
                AutoSize = true,
                BackColor = Theme.Accent,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.White,
                Margin = Padding.Empty,
                MinimumSize = new Size(100, 34),
                Text = "OK",
                UseVisualStyleBackColor = false
            };
            btnOk.FlatAppearance.BorderSize = 0;

            var root = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                Location = new Point(Padding.Left, Padding.Top),
                Margin = Padding.Empty
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            foreach (Control c in new Control[]
            {
                lblTitle, lblVersion, lblDescription, separator,
                authorTable, lblCopyright, btnOk
            })
            {
                root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                root.Controls.Add(c);
            }
            root.RowCount = root.Controls.Count;

            Controls.Add(root);

            AcceptButton = btnOk;
            CancelButton = btnOk;
        }

        private static Label MutedLabel(string text)
        {
            return new Label
            {
                AutoSize = true,
                ForeColor = Theme.MutedText,
                Margin = new Padding(0, 0, 0, 2),
                Text = text
            };
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            int useDark = 1;
            try { DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int)); }
            catch (DllNotFoundException) { }
        }
    }
}
