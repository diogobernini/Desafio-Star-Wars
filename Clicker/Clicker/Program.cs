using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    class Program
    {
        static void Main(string[] args)
        {
            // var pintar = Lib.Normalize(new Point(335, 69)); // 335, 69 aponta para pintar na resolução original
            // que resulta em 0.2452415812591508, 0.08984375 em números normalizados
            // var verde = Lib.Normalize(new Point(871, 64));
            // que resulta em 0.637628111273792, 0.083333333333333329
            // var canvas = Lib.Normalize(new Point(445, 233));
            // que resulta em 0.32576866764275259, 0.30338541666666669
            var pintarLocal = Lib.DeNormalize(new NormalizedPoint(0.2452415812591508, 0.08984375));
            var verdeLocal = Lib.DeNormalize(new NormalizedPoint(0.637628111273792, 0.083333333333333329));
            var canvasLocal = Lib.DeNormalize(new NormalizedPoint(0.32576866764275259, 0.30338541666666669));
            Thread.Sleep(10000);
            Lib.Click(pintarLocal);
            Lib.Click(verdeLocal);
            Lib.Click(canvasLocal);
        }
    }
}
