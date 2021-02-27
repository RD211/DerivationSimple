using DerivationSimple.Drawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialAnalyzer.Expression_Tree
{
    class Constant : IExpressionNode
    {
        double value;
        public Constant(double value)
        {
            this.value = value;
        }
        public IExpressionNode Simplify()
        {
            return this;
        }
        public bool ContainsVariable() => false;

        public IExpressionNode DeepCopy() => new Constant(this.value);

        public IExpressionNode Derivate() => new Constant(0);

        public double Evaluate(Dictionary<string, double> input) => value;

        public string GetInFixNotation() => value.ToString();

        public string GetPostFixNotation()=> value.ToString();

        public string GetPreFixNotation()=> value.ToString();

        public Bitmap Render()
        {
            var txt = GetInFixNotation();
            var size = DrawingHelpers.GetSizeOfText(txt, DrawingHelpers.globalFont);
            Bitmap bmp = new Bitmap((int)size.Width, (int)size.Height);
            Graphics g = Graphics.FromImage(bmp);
            var brush = new SolidBrush(DrawingHelpers.globalColor);
            g.DrawString(txt, DrawingHelpers.globalFont, brush, new PointF(0, 0));
            brush.Dispose();
            g.Dispose();
            return bmp;
        }
    }
}
