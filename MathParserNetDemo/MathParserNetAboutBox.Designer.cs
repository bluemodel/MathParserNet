namespace MathParserNetDemo
{
    partial class MathParserNetAboutBox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.wbPacman = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MathParserNetDemo.Properties.Resources.calculator_icon;
            this.pictureBox1.Location = new System.Drawing.Point(-57, -41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(502, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 164);
            this.label1.TabIndex = 1;
            this.label1.Text = "Math Parser .NET Demo was created by Alan Bryan to showcase the Math Parser .NET " +
    "library. Use at your own risk and I hope you enjoy it!";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(480, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 115);
            this.label2.TabIndex = 2;
            this.label2.Text = "If you have any issues or questions or comments, feel free to email me at icemani" +
    "nd9@gmail.com";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(812, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // wbPacman
            // 
            this.wbPacman.Location = new System.Drawing.Point(13, 559);
            this.wbPacman.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPacman.Name = "wbPacman";
            this.wbPacman.ScrollBarsEnabled = false;
            this.wbPacman.Size = new System.Drawing.Size(582, 220);
            this.wbPacman.TabIndex = 4;
            // 
            // MathParserNetAboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 552);
            this.Controls.Add(this.wbPacman);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MathParserNetAboutBox";
            this.ShowInTaskbar = false;
            this.Text = "About Math Parser .NET Demo";
            this.Load += new System.EventHandler(this.MathParserNetAboutBoxLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser wbPacman;
    }
}