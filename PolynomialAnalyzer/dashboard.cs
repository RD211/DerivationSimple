using PolynomialAnalyzer.Drawer;
using PolynomialAnalyzer.Expression_Tree;
using System;
using System.Windows.Forms;

namespace PolynomialAnalyzer
{
    public partial class Dashboard : Form
    {
        double cameraX = 0, cameraY = 0;
        double zoom = 1;
        public Dashboard()
        {
            InitializeComponent();
        }

        public void DisplayGraphic()
        {
            try
            {
                ExpressionTree tree = new ExpressionTree(txt_input.Text);
                if (pbox_function.Image != null) pbox_function.Image.Dispose();
                pbox_function.Image = GraphDrawer.Draw(tree, zoom, cameraX, cameraY, pbox_function.Width/4, pbox_function.Height/4);
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayGraphic();
        }

        private void txt_input_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExpressionTree tree = new ExpressionTree(txt_input.Text);
                txt_derivative.Text = tree.GetDerivative().GetInFixNotation();
                DisplayGraphic();
            }
            catch {
            }
        }

        int lastX = 0, lastY = 0;
        bool mouseDown = false;

        private void pbox_function_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void pbox_function_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastX = e.X;
            this.lastY = e.Y;
            mouseDown = true;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.pbox_function.MouseWheel += Pbox_function_MouseWheel;
        }

        private void lbl_function_Click(object sender, EventArgs e)
        {

        }

        private void Pbox_function_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom -= (float)e.Delta/2000;
            txt_derivative.Text = zoom.ToString();
            zoom = Math.Max(0.1, Math.Min(10, zoom));
            DisplayGraphic();

        }

        private void pbox_function_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                cameraX += (lastX - e.X)/3;
                cameraY += (lastY - e.Y)/3;
                lastX = e.X;
                lastY = e.Y;
                DisplayGraphic();
            }
        }
    }
}
