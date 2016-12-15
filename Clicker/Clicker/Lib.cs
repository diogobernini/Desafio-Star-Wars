using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clicker
{
    public static class Lib
    {
        [DllImport("user32.dll",
       CharSet = CharSet.Auto,
       CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags,
                              uint dx,
                              uint dy,
                              uint cButtons,
                              uint dwExtraInfo);

        private const int ESQUERDA = 0x02;
        private const int DIREITA = 0x04;

        public static void Click(Point pt)
        {
            Cursor.Position = pt;
            mouse_event(ESQUERDA | DIREITA, (uint)pt.X, (uint)pt.Y, 0, 0);
        }

        public static NormalizedPoint Normalize(Point point, Rectangle resolution = new Rectangle())
        {
            var res = resolution.Equals(new Rectangle()) ? Screen.PrimaryScreen.Bounds : resolution;
            double xn = double.Parse(point.X.ToString()) / double.Parse(res.Width.ToString());
            double yn = double.Parse(point.Y.ToString()) / double.Parse(res.Height.ToString());
            return new NormalizedPoint(xn, yn);
        }

        public static Point DeNormalize(NormalizedPoint np, Rectangle resolution = new Rectangle())
        {
            var res = resolution.Equals(new Rectangle()) ? Screen.PrimaryScreen.Bounds : resolution;
            var x = np.xn * res.Width;
            var y = np.yn * res.Height;
            return new Point((int) x,(int)y);
        }
    }
}