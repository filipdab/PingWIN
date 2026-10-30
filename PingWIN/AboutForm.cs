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
        private const string Author = "filipdab";

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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(420, 250);
            Text = "O autorze";

            var lblTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
                ForeColor = Theme.Text,
                Location = new Point(24, 18),
                Text = "PingWIN"
            };

            var lblVersion = new Label
            {
                AutoSize = true,
                ForeColor = Theme.MutedText,
                Location = new Point(28, 60),
                Text = "Wersja " + version.ToString(3)
            };

            var lblDescription = new Label
            {
                AutoSize = true,
                ForeColor = Theme.MutedText,
                Location = new Point(28, 82),
                Text = "Monitor dostępności hostów w czasie rzeczywistym"
            };

            var separator = new Panel
            {
                BackColor = Theme.Border,
                Location = new Point(28, 114),
                Size = new Size(364, 1)
            };

            var lblAuthorCaption = new Label
            {
                AutoSize = true,
                ForeColor = Theme.MutedText,
                Location = new Point(28, 128),
                Text = "Autor:"
            };

            var lblAuthor = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Theme.Accent,
                Location = new Point(80, 125),
                Text = Author
            };

            var lblCopyright = new Label
            {
                AutoSize = true,
                ForeColor = Theme.MutedText,
                Location = new Point(28, 156),
                Text = "© " + DateTime.Now.Year + " " + Author + ". Wszelkie prawa zastrzeżone."
            };

            var btnOk = new Button
            {
                BackColor = Theme.Accent,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(292, 198),
                Size = new Size(100, 34),
                Text = "OK",
                UseVisualStyleBackColor = false
            };
            btnOk.FlatAppearance.BorderSize = 0;

            Controls.AddRange(new Control[]
            {
                lblTitle, lblVersion, lblDescription, separator,
                lblAuthorCaption, lblAuthor, lblCopyright, btnOk
            });

            AcceptButton = btnOk;
            CancelButton = btnOk;
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
