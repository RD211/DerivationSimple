using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivationSimple.Drawer
{
    public static class DrawingHelpers
    {
        public static Font globalFont = new Font("Arial", 16);
        public static Color globalColor = Color.FromName("white");
        public static int Padding = 2;
        public static SizeF GetSizeOfText(string text, Font font)
        {
            using(Bitmap bmp = new Bitmap(100,100))
            {
                Graphics g = Graphics.FromImage(bmp);
                var size = g.MeasureString(text, font);
                g.Dispose();
                return size;
            }
        }
        public static Bitmap DrawSingularFunction(Bitmap parameterBmp, string functionName)
        {
            var sizeFunctionStart = DrawingHelpers.GetSizeOfText($"{functionName}(", DrawingHelpers.globalFont);
            var sizeFunctionEnd = DrawingHelpers.GetSizeOfText(")", DrawingHelpers.globalFont);

            var brush = new SolidBrush(DrawingHelpers.globalColor);

            var bmp = new Bitmap((int)sizeFunctionStart.Width + parameterBmp.Width + (int)sizeFunctionEnd.Width + 2 * DrawingHelpers.Padding, Math.Max((int)sizeFunctionStart.Height, parameterBmp.Height));
            Graphics g = Graphics.FromImage(bmp);

            g.DrawString($"{functionName}(", DrawingHelpers.globalFont, brush, new PointF(0, (bmp.Height - (int)sizeFunctionStart.Height)/2));
            g.DrawImage(parameterBmp, new Point((int)sizeFunctionStart.Width + DrawingHelpers.Padding, (bmp.Height - parameterBmp.Height)/2));
            g.DrawString(")",
                DrawingHelpers.globalFont,
                brush,
                new PointF((int)sizeFunctionStart.Width + 2 * DrawingHelpers.Padding + parameterBmp.Width,
                (bmp.Height - (int)sizeFunctionEnd.Height)/2));

            g.Dispose();
            parameterBmp.Dispose();
            brush.Dispose();
            return bmp;
        }
        public static Bitmap DrawSimpleOperation(Bitmap leftBmp, Bitmap rightBmp, string operatorSymbol)
        {
            var sizeSymbol = DrawingHelpers.GetSizeOfText($" {operatorSymbol} ", DrawingHelpers.globalFont);

            var brush = new SolidBrush(DrawingHelpers.globalColor);

            var bmp = new Bitmap((int)(leftBmp.Width + rightBmp.Width + sizeSymbol.Width), (int)Math.Max(leftBmp.Height, rightBmp.Height));
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(leftBmp, new Point(0, (bmp.Height - leftBmp.Height) / 2));
            g.DrawString($" {operatorSymbol} ", DrawingHelpers.globalFont, brush, new PointF(leftBmp.Width, (bmp.Height - (int)sizeSymbol.Height) / 2));
            g.DrawImage(rightBmp, new Point(leftBmp.Width + (int)sizeSymbol.Width, (bmp.Height - rightBmp.Height) / 2));

            g.Dispose();
            leftBmp.Dispose();
            rightBmp.Dispose();
            brush.Dispose();
            return bmp;
        }
    }
}
