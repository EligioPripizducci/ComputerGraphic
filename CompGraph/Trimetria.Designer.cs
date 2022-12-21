namespace CompGraph
{
    partial class Trimetria
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
            this.phi_tb = new System.Windows.Forms.TextBox();
            this.tetta_tb = new System.Windows.Forms.TextBox();
            this.Zc_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Build = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phi_tb
            // 
            this.phi_tb.Location = new System.Drawing.Point(122, 30);
            this.phi_tb.Name = "phi_tb";
            this.phi_tb.Size = new System.Drawing.Size(143, 23);
            this.phi_tb.TabIndex = 0;
            // 
            // tetta_tb
            // 
            this.tetta_tb.Location = new System.Drawing.Point(122, 68);
            this.tetta_tb.Name = "tetta_tb";
            this.tetta_tb.Size = new System.Drawing.Size(143, 23);
            this.tetta_tb.TabIndex = 1;
            // 
            // Zc_tb
            // 
            this.Zc_tb.Location = new System.Drawing.Point(122, 108);
            this.Zc_tb.Name = "Zc_tb";
            this.Zc_tb.Size = new System.Drawing.Size(143, 23);
            this.Zc_tb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(68, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "φ = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(70, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "θ = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(61, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zc = ";
            // 
            // Build
            // 
            this.Build.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Build.Location = new System.Drawing.Point(68, 152);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(197, 31);
            this.Build.TabIndex = 6;
            this.Build.Text = "Построить";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // Trimetria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 203);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zc_tb);
            this.Controls.Add(this.tetta_tb);
            this.Controls.Add(this.phi_tb);
            this.Name = "Trimetria";
            this.Text = "Trimetria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox phi_tb;
        private TextBox tetta_tb;
        private TextBox Zc_tb;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button Build;
    }
}