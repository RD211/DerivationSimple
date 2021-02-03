using PolynomialAnalyzer.Expression_Tree;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PolynomialAnalyzer.Drawer
{
    public static class GraphDrawer
    {
        public static Bitmap Draw(ExpressionTree function, double zoom, double cameraX, double cameraY, double width = 300, double height = 300)
        {
            Bitmap graphic = new Bitmap((int)width, (int)height);
            Graphics g = Graphics.FromImage(graphic);
            g.FillRectangle(new SolidBrush(Color.Gray), 0, 0, (int)width, (int)height);
            double graphWidth = (double)width / zoom;
            double graphHeight = (double)height / zoom;



            List<PointF> functionPoints = new List<PointF>();
            for(double sampler = cameraX - graphWidth/2; sampler <= cameraX + graphWidth/2; sampler+=0.5)
            {
                try
                {
                    functionPoints.Add(new PointF(
                        (float)sampler - (float)cameraX + (float)graphWidth / 2,
                        (float)Math.Min(height+50, Math.Max(-50, 
                        
                        ((float)graphHeight-((float)function.Evaluate(
                            new Dictionary<string, double>() {
                            {"x", sampler }
                            }) + (float)graphHeight/ 2+cameraY)) ))));
                }
                catch {
                }
            }

            List<PointF> derivativePoints = new List<PointF>();
            var derivative = function.GetDerivative();
            for (double sampler = cameraX - graphWidth / 2; sampler <= cameraX + graphWidth / 2; sampler += 0.6)
            {
                try
                {
                    derivativePoints.Add(new PointF(
                        (float)sampler - (float)cameraX + (float)graphWidth / 2,
                        (float)Math.Min(height + 50, Math.Max(-50,

                        ((float)graphHeight - ((float)derivative.Evaluate(
                            new Dictionary<string, double>() {
                            {"x", sampler }
                            }) + (float)graphHeight / 2 + cameraY))))));
                }
                catch
                {
                }
            }

            g.DrawCurve(new Pen(Color.Red, 2), functionPoints.ToArray());
            g.DrawCurve(new Pen(Color.Blue, 2), derivativePoints.ToArray());

            g.DrawLine(
                new Pen(Color.Black, 2),
                new Point((int)(graphWidth / 2 - cameraX), 0),
                new Point((int)(graphWidth / 2 - cameraX), (int)height-1));
            g.DrawLine(
                new Pen(Color.Black, 2),
                new Point(0, (int)(graphHeight / 2 - cameraY)),
                new Point((int)width-1, (int)(graphHeight / 2 - cameraY)));
            g.Dispose();
            return graphic;
        }
    }
}
