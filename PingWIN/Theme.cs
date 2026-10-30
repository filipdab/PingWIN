using System.Drawing;
using System.Windows.Forms;

namespace PingWIN
{
    /// <summary>
    /// Paleta kolorów ciemnego motywu aplikacji.
    /// </summary>
    internal static class Theme
    {
        public static readonly Color Background = Color.FromArgb(30, 30, 46);
        public static readonly Color Panel = Color.FromArgb(37, 37, 56);
        public static readonly Color Surface = Color.FromArgb(45, 45, 68);
        public static readonly Color Border = Color.FromArgb(58, 58, 84);
        public static readonly Color Text = Color.FromArgb(230, 230, 240);
        public static readonly Color MutedText = Color.FromArgb(150, 150, 180);
        public static readonly Color Accent = Color.FromArgb(124, 92, 255);

        public static readonly Color Online = Color.FromArgb(61, 220, 132);
        public static readonly Color Slow = Color.FromArgb(255, 183, 77);
        public static readonly Color Offline = Color.FromArgb(255, 92, 108);
        public static readonly Color Unknown = Color.FromArgb(110, 110, 140);

        public static Color ForState(HostState state)
        {
            switch (state)
            {
                case HostState.Online: return Online;
                case HostState.Slow: return Slow;
                case HostState.Offline: return Offline;
                default: return Unknown;
            }
        }
    }

    /// <summary>
    /// Kolory menu kontekstowego dopasowane do ciemnego motywu.
    /// </summary>
    internal sealed class DarkColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground => Theme.Panel;
        public override Color ImageMarginGradientBegin => Theme.Panel;
        public override Color ImageMarginGradientMiddle => Theme.Panel;
        public override Color ImageMarginGradientEnd => Theme.Panel;
        public override Color MenuBorder => Theme.Border;
        public override Color MenuItemBorder => Theme.Accent;
        public override Color MenuItemSelected => Theme.Surface;
        public override Color SeparatorDark => Theme.Border;
        public override Color SeparatorLight => Theme.Border;
    }
}
