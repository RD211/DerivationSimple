using DerivationSimple.Drawer;
using PolynomialAnalyzer.Expression_Tree.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialAnalyzer.Expression_Tree.Functions
{
    class FunctionLog : IFunctionDual
    {
        public IExpressionNode FirstParameter { get; set; }
        public IExpressionNode SecondParameter { get; set; }

        public FunctionLog() { }
        public IExpressionNode Simplify()
        {           
            FirstParameter = FirstParameter.Simplify();
            SecondParameter = SecondParameter.Simplify();
            if (!FirstParameter.ContainsVariable() && !SecondParameter.ContainsVariable())
                return new Constant(this.Evaluate(null));
 
            return this;
        }
        public FunctionLog(IExpressionNode firstParam, IExpressionNode secondParam)
        {
            this.FirstParameter = firstParam;
            this.SecondParameter = secondParam;
        }
        public bool ContainsVariable()
        {
            return FirstParameter.ContainsVariable() || SecondParameter.ContainsVariable();
        }

        public IExpressionNode DeepCopy()
        {
            return new FunctionLog(FirstParameter.DeepCopy(), SecondParameter.DeepCopy());
        }

        public IExpressionNode Derivate()
        {
            return new OperationDivision(
                new FunctionLn(SecondParameter),
                new FunctionLn(FirstParameter)).Derivate();
        }

        public double Evaluate(Dictionary<string, double> input)
        {
            return Math.Log(SecondParameter.Evaluate(input)) / Math.Log(FirstParameter.Evaluate(input));
        }

        public string GetInFixNotation()
        {
            return $"log({FirstParameter.GetInFixNotation()}, {SecondParameter.GetInFixNotation()}) ";
        }

        public string GetPostFixNotation()
        {
            return $"{FirstParameter.GetInFixNotation()} {SecondParameter.GetInFixNotation()} log ";
        }

        public string GetPreFixNotation()
        {
            return $"log {FirstParameter.GetInFixNotation()} {SecondParameter.GetInFixNotation()} ";
        }
        public Bitmap Render()
        {
            var parameterLeftBmp = this.FirstParameter.Render();
            var parameterRightBmp = this.SecondParameter.Render();

            var sizeFunctionStart = DrawingHelpers.GetSizeOfText("log(", DrawingHelpers.globalFont);
            var sizeFunctionMiddle = DrawingHelpers.GetSizeOfText(", ", DrawingHelpers.globalFont);
            var sizeFunctionEnd = DrawingHelpers.GetSizeOfText(")", DrawingHelpers.globalFont);

            var brush = new SolidBrush(DrawingHelpers.globalColor);

            var bmp = new Bitmap(
                (int)sizeFunctionStart.Width + parameterLeftBmp.Width + (int)sizeFunctionMiddle.Width + parameterRightBmp.Width + (int)sizeFunctionEnd.Width, 
                Math.Max(parameterRightBmp.Height,
                Math.Max((int)sizeFunctionStart.Height, parameterLeftBmp.Height)));

            Graphics g = Graphics.FromImage(bmp);

            g.DrawString("log(", DrawingHelpers.globalFont, brush, new PointF(0, bmp.Height - (int)sizeFunctionStart.Height));
            g.DrawImage(parameterLeftBmp, new Point((int)sizeFunctionStart.Width + DrawingHelpers.Padding, bmp.Height - parameterLeftBmp.Height));
            g.DrawString(", ",
                DrawingHelpers.globalFont,
                brush,
                new PointF((int)sizeFunctionStart.Width + DrawingHelpers.Padding + parameterLeftBmp.Width,
                bmp.Height - (int)sizeFunctionMiddle.Height));
            g.DrawImage(parameterRightBmp, 
                new Point((int)sizeFunctionStart.Width + DrawingHelpers.Padding + (int)sizeFunctionMiddle.Width, bmp.Height - parameterRightBmp.Height));
            g.DrawString(")",
                DrawingHelpers.globalFont,
                brush,
                new PointF((int)sizeFunctionStart.Width +2*DrawingHelpers.Padding + parameterRightBmp.Width + parameterLeftBmp.Width + (int)sizeFunctionMiddle.Width,
                bmp.Height - (int)sizeFunctionEnd.Height));
            g.Dispose();
            parameterLeftBmp.Dispose();
            parameterRightBmp.Dispose();
            brush.Dispose();
            return bmp;
        }
    }
}
