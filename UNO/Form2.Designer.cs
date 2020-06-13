namespace UNO
{
    partial class Form2
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
            this.RedButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BlueButton = new System.Windows.Forms.Button();
            this.YellowButton = new System.Windows.Forms.Button();
            this.GreenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RedButton
            // 
            this.RedButton.BackColor = System.Drawing.Color.Red;
            this.RedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RedButton.ForeColor = System.Drawing.Color.White;
            this.RedButton.Location = new System.Drawing.Point(106, 146);
            this.RedButton.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(293, 122);
            this.RedButton.TabIndex = 1;
            this.RedButton.Text = "RED";
            this.RedButton.UseVisualStyleBackColor = false;
            this.RedButton.Click += new System.EventHandler(this.RedButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "ColorRequest";
            // 
            // BlueButton
            // 
            this.BlueButton.BackColor = System.Drawing.Color.Blue;
            this.BlueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlueButton.ForeColor = System.Drawing.Color.White;
            this.BlueButton.Location = new System.Drawing.Point(428, 146);
            this.BlueButton.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.BlueButton.Name = "BlueButton";
            this.BlueButton.Size = new System.Drawing.Size(307, 122);
            this.BlueButton.TabIndex = 6;
            this.BlueButton.Text = "BLUE";
            this.BlueButton.UseVisualStyleBackColor = false;
            this.BlueButton.Click += new System.EventHandler(this.BlueButton_Click);
            // 
            // YellowButton
            // 
            this.YellowButton.BackColor = System.Drawing.Color.Yellow;
            this.YellowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YellowButton.ForeColor = System.Drawing.Color.White;
            this.YellowButton.Location = new System.Drawing.Point(106, 288);
            this.YellowButton.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.YellowButton.Name = "YellowButton";
            this.YellowButton.Size = new System.Drawing.Size(293, 139);
            this.YellowButton.TabIndex = 7;
            this.YellowButton.Text = "Yellow";
            this.YellowButton.UseVisualStyleBackColor = false;
            this.YellowButton.Click += new System.EventHandler(this.YellowButton_Click);
            // 
            // GreenButton
            // 
            this.GreenButton.BackColor = System.Drawing.Color.Lime;
            this.GreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GreenButton.ForeColor = System.Drawing.Color.White;
            this.GreenButton.Location = new System.Drawing.Point(428, 288);
            this.GreenButton.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.GreenButton.Name = "GreenButton";
            this.GreenButton.Size = new System.Drawing.Size(307, 139);
            this.GreenButton.TabIndex = 8;
            this.GreenButton.Text = "Green";
            this.GreenButton.UseVisualStyleBackColor = false;
            this.GreenButton.Click += new System.EventHandler(this.GreenButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(25F, 51F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 521);
            this.Controls.Add(this.GreenButton);
            this.Controls.Add(this.YellowButton);
            this.Controls.Add(this.BlueButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RedButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RedButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BlueButton;
        private System.Windows.Forms.Button YellowButton;
        private System.Windows.Forms.Button GreenButton;
    }
}