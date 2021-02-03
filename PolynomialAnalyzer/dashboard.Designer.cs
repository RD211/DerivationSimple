namespace PolynomialAnalyzer
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_input = new System.Windows.Forms.TextBox();
            this.pbox_function = new System.Windows.Forms.PictureBox();
            this.lbl_function = new System.Windows.Forms.Label();
            this.lbl_derivative = new System.Windows.Forms.Label();
            this.txt_derivative = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_function)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_input
            // 
            this.txt_input.Font = new System.Drawing.Font("Adobe Heiti Std R", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_input.Location = new System.Drawing.Point(220, 12);
            this.txt_input.Multiline = true;
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(727, 55);
            this.txt_input.TabIndex = 1;
            this.txt_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_input.TextChanged += new System.EventHandler(this.txt_input_TextChanged);
            // 
            // pbox_function
            // 
            this.pbox_function.Location = new System.Drawing.Point(20, 134);
            this.pbox_function.Name = "pbox_function";
            this.pbox_function.Size = new System.Drawing.Size(927, 582);
            this.pbox_function.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_function.TabIndex = 7;
            this.pbox_function.TabStop = false;
            this.pbox_function.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbox_function_MouseDown);
            this.pbox_function.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_function_MouseMove);
            this.pbox_function.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbox_function_MouseUp);
            // 
            // lbl_function
            // 
            this.lbl_function.AutoSize = true;
            this.lbl_function.Font = new System.Drawing.Font("Adobe Heiti Std R", 26.25F, System.Drawing.FontStyle.Bold);
            this.lbl_function.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbl_function.Location = new System.Drawing.Point(12, 15);
            this.lbl_function.Name = "lbl_function";
            this.lbl_function.Size = new System.Drawing.Size(188, 44);
            this.lbl_function.TabIndex = 8;
            this.lbl_function.Text = "Function: ";
            this.lbl_function.Click += new System.EventHandler(this.lbl_function_Click);
            // 
            // lbl_derivative
            // 
            this.lbl_derivative.AutoSize = true;
            this.lbl_derivative.Font = new System.Drawing.Font("Adobe Heiti Std R", 26.25F, System.Drawing.FontStyle.Bold);
            this.lbl_derivative.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbl_derivative.Location = new System.Drawing.Point(12, 76);
            this.lbl_derivative.Name = "lbl_derivative";
            this.lbl_derivative.Size = new System.Drawing.Size(202, 44);
            this.lbl_derivative.TabIndex = 10;
            this.lbl_derivative.Text = "Derivative:";
            // 
            // txt_derivative
            // 
            this.txt_derivative.Font = new System.Drawing.Font("Adobe Heiti Std R", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_derivative.Location = new System.Drawing.Point(220, 73);
            this.txt_derivative.Multiline = true;
            this.txt_derivative.Name = "txt_derivative";
            this.txt_derivative.ReadOnly = true;
            this.txt_derivative.Size = new System.Drawing.Size(727, 55);
            this.txt_derivative.TabIndex = 9;
            this.txt_derivative.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(959, 728);
            this.Controls.Add(this.lbl_derivative);
            this.Controls.Add(this.txt_derivative);
            this.Controls.Add(this.lbl_function);
            this.Controls.Add(this.pbox_function);
            this.Controls.Add(this.txt_input);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_function)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.PictureBox pbox_function;
        private System.Windows.Forms.Label lbl_function;
        private System.Windows.Forms.Label lbl_derivative;
        private System.Windows.Forms.TextBox txt_derivative;
    }
}

