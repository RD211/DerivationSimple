using DerivationSimple.Drawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialAnalyzer.Expression_Tree.Operations
{
    public class OperationDivision : IOperation
    {
        public IExpressionNode LeftOperand { get; set; }
        public IExpressionNode RightOperand { get; set; }

        public OperationDivision(IExpressionNode leftOperand, IExpressionNode rightOperand)
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }
        public OperationDivision() { }
        public IExpressionNode Simplify()
        {
            LeftOperand = LeftOperand.Simplify();
            RightOperand = RightOperand.Simplify();
            if (!LeftOperand.ContainsVariable() && !RightOperand.ContainsVariable())
            {
                return new Constant(this.Evaluate(null));
            }
            else if (!LeftOperand.ContainsVariable() && RightOperand.ContainsVariable())
            {
                if (LeftOperand.Evaluate(null) == 0)
                    return new Constant(0);
            }
            else if (LeftOperand.ContainsVariable() && !RightOperand.ContainsVariable())
            {
                if (RightOperand.Evaluate(null) == 0)
                    throw new DivideByZeroException();

                if (RightOperand.Evaluate(null) == 1)
                    return LeftOperand.DeepCopy();
            }

            return this;
        }
        public IExpressionNode Derivate()
        {
            var leftDerivative = LeftOperand.Derivate();
            var rightDerivative = RightOperand.Derivate();

            return new OperationDivision(
                new OperationSubtraction(
                    new OperationMultiplication(LeftOperand.DeepCopy(), rightDerivative),
                    new OperationMultiplication(leftDerivative, RightOperand.DeepCopy())
                    ),
                new OperationPower(RightOperand.DeepCopy(), new Constant(2)));
        }

        public double Evaluate(Dictionary<string, double> input)
        {
            if (Math.Abs(RightOperand.Evaluate(input)) < 0.001)
                return LeftOperand.Evaluate(input) * 1000;
            return LeftOperand.Evaluate(input) / RightOperand.Evaluate(input);
        }
        public string GetPostFixNotation()=> $"{LeftOperand.GetPostFixNotation()} {RightOperand.GetPostFixNotation()} / ";

        public string GetPreFixNotation()=> $"/ {LeftOperand.GetPreFixNotation()} {RightOperand.GetPreFixNotation()} ";

        public string GetInFixNotation() => $"({LeftOperand.GetInFixNotation()} / {RightOperand.GetInFixNotation()}) ";

        public IExpressionNode DeepCopy() => new OperationDivision(LeftOperand.DeepCopy(), RightOperand.DeepCopy());
        public bool ContainsVariable() => LeftOperand.ContainsVariable() || RightOperand.ContainsVariable();

        public Bitmap Render()
        {
            var leftBmp = this.LeftOperand.Render();
            var rightBmp = this.RightOperand.Render();


            var pen = new Pen(DrawingHelpers.globalColor);

            var bmp = new Bitmap(Math.Max(leftBmp.Width, rightBmp.Width) + DrawingHelpers.Padding, leftBmp.Height + rightBmp.Height + DrawingHelpers.Padding) ;
            Graphics g = Graphics.FromImage(bmp);

            g.DrawImage(leftBmp, new Point((bmp.Width-leftBmp.Width)/2, 0));
            g.DrawLine(pen, 0, leftBmp.Height+(int)(DrawingHelpers.Padding/2), bmp.Width, leftBmp.Height + (int)(DrawingHelpers.Padding / 2));
            g.DrawImage(rightBmp, new Point((bmp.Width - rightBmp.Width) / 2, leftBmp.Height + DrawingHelpers.Padding));

            g.Dispose();
            leftBmp.Dispose();
            rightBmp.Dispose();
            pen.Dispose();
            return bmp;
        }
    }
}
