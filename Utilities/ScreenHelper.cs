using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightCsharp.Utilities
{
    internal class ScreenHelper
    {
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private const int LOGPIXELSX = 88; // DPI X-axis

        /// Gets full screen resolution (ignoring scaling)
        public static ViewportSize GetScreenViewport()
        {
            int width = GetSystemMetrics(SM_CXSCREEN);
            int height = GetSystemMetrics(SM_CYSCREEN);

            return new ViewportSize
            {
                Width = width,
                Height = height
            };
        }

        /// Gets actual DPI (dots per inch)
        public static int GetDpiX()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int dpi = GetDeviceCaps(hdc, LOGPIXELSX);
            ReleaseDC(IntPtr.Zero, hdc);
            return dpi;
        }

        /// Gets scale factor relative to standard 96 DPI
        public static double GetScaleFactor()
        {
            int dpiX = GetDpiX();
            return dpiX / 96.0;
        }

        /// Gets adjusted viewport scaled down by system display factor
        public static ViewportSize GetScaledViewport()
        {
            var size = GetScreenViewport();
            double scale = GetScaleFactor();

            return new ViewportSize
            {
                Width = (int)(size.Width / scale),
                Height = (int)(size.Height / scale)
            };
        }
    }
}
