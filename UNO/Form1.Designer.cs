namespace UNO
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.pnlPlayer3 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.NoCurrentCardButton = new System.Windows.Forms.Button();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.pnlPlayer1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlTable
            // 
            resources.ApplyResources(this.pnlTable, "pnlTable");
            this.pnlTable.Name = "pnlTable";
            // 
            // pnlDeck
            // 
            resources.ApplyResources(this.pnlDeck, "pnlDeck");
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDeck_Paint);
            // 
            // pnlPlayer3
            // 
            resources.ApplyResources(this.pnlPlayer3, "pnlPlayer3");
            this.pnlPlayer3.Name = "pnlPlayer3";
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Name = "lblMessage";
            // 
            // NoCurrentCardButton
            // 
            resources.ApplyResources(this.NoCurrentCardButton, "NoCurrentCardButton");
            this.NoCurrentCardButton.Name = "NoCurrentCardButton";
            this.NoCurrentCardButton.UseVisualStyleBackColor = true;
            this.NoCurrentCardButton.Click += new System.EventHandler(this.NoCurrentCardButton_Click);
            // 
            // pnlPlayer2
            // 
            resources.ApplyResources(this.pnlPlayer2, "pnlPlayer2");
            this.pnlPlayer2.Name = "pnlPlayer2";
            // 
            // pnlPlayer1
            // 
            resources.ApplyResources(this.pnlPlayer1, "pnlPlayer1");
            this.pnlPlayer1.Name = "pnlPlayer1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlPlayer1);
            this.Controls.Add(this.pnlPlayer2);
            this.Controls.Add(this.NoCurrentCardButton);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlPlayer3);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.Panel pnlPlayer3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button NoCurrentCardButton;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Panel pnlPlayer1;
    }
}

