using DerivationSimple.Drawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialAnalyzer.Expression_Tree
{
    class Variable : IExpressionNode
    {
        private readonly string variableName;
        
        public Variable(string name)
        {
            variableName = name;
        }
        public IExpressionNode Simplify()
        {
            return this;
        }
        public double Evaluate(Dictionary<string, double> input)
        {
            if(input.Keys.Contains(variableName))
            {
                return input[variableName];
            }
            else
            {
                throw new Exception($"Variable name could not be found in dictionary:{variableName}");
            }
        }

        public IExpressionNode Derivate() => new Constant(1);

        public IExpressionNode DeepCopy() => new Variable(this.variableName);

        public string GetPostFixNotation()
            => this.variableName;

        public string GetPreFixNotation() 
            => this.variableName;

        public string GetInFixNotation() 
            => variableName;

        public bool ContainsVariable()
            => true;

        public Bitmap Render()
        {
            var txt = GetInFixNotation();
            var size = DrawingHelpers.GetSizeOfText(txt, DrawingHelpers.globalFont);
            Bitmap bmp = new Bitmap((int)size.Width, (int)size.Height);
            Graphics g = Graphics.FromImage(bmp);
            var brush = new SolidBrush(DrawingHelpers.globalColor);
            g.DrawString(txt, DrawingHelpers.globalFont, brush, new PointF(0, 0));
            g.Dispose();
            brush.Dispose();
            return bmp;
        }
    }
}
