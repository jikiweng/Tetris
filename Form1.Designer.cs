namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bestScoreLabel = new System.Windows.Forms.Label();
            this.finalScoreLabel = new System.Windows.Forms.Label();
            this.newRecordLabel = new System.Windows.Forms.Label();
            this.retryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.White;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.Location = new System.Drawing.Point(430, 500);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(136, 41);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Score: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(430, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Next Tetris";
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameOverLabel.ForeColor = System.Drawing.Color.Maroon;
            this.gameOverLabel.Location = new System.Drawing.Point(34, 215);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(328, 71);
            this.gameOverLabel.TabIndex = 2;
            this.gameOverLabel.Text = "Game Over";
            this.gameOverLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(430, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 185);
            this.label2.TabIndex = 3;
            this.label2.Text = "   操作說明\r\n→：向右移動\r\n←：向左移動\r\n↓：加速往下\r\nSpace：旋轉";
            // 
            // bestScoreLabel
            // 
            this.bestScoreLabel.AutoSize = true;
            this.bestScoreLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bestScoreLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bestScoreLabel.Location = new System.Drawing.Point(50, 346);
            this.bestScoreLabel.Name = "bestScoreLabel";
            this.bestScoreLabel.Size = new System.Drawing.Size(221, 46);
            this.bestScoreLabel.TabIndex = 4;
            this.bestScoreLabel.Text = "Best Score : ";
            this.bestScoreLabel.Visible = false;
            // 
            // finalScoreLabel
            // 
            this.finalScoreLabel.AutoSize = true;
            this.finalScoreLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.finalScoreLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finalScoreLabel.Location = new System.Drawing.Point(50, 466);
            this.finalScoreLabel.Name = "finalScoreLabel";
            this.finalScoreLabel.Size = new System.Drawing.Size(229, 46);
            this.finalScoreLabel.TabIndex = 5;
            this.finalScoreLabel.Text = "Final Score : ";
            this.finalScoreLabel.Visible = false;
            this.finalScoreLabel.Click += new System.EventHandler(this.finalScoreLabel_Click);
            // 
            // newRecordLabel
            // 
            this.newRecordLabel.AutoSize = true;
            this.newRecordLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newRecordLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.newRecordLabel.Location = new System.Drawing.Point(68, 427);
            this.newRecordLabel.Name = "newRecordLabel";
            this.newRecordLabel.Size = new System.Drawing.Size(178, 30);
            this.newRecordLabel.TabIndex = 6;
            this.newRecordLabel.Text = "New Record!!";
            this.newRecordLabel.Visible = false;
            this.newRecordLabel.Click += new System.EventHandler(this.newRecordLabel_Click);
            // 
            // retryButton
            // 
            this.retryButton.Enabled = false;
            this.retryButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.retryButton.Location = new System.Drawing.Point(142, 579);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(137, 61);
            this.retryButton.TabIndex = 7;
            this.retryButton.Text = "Retry";
            this.retryButton.UseVisualStyleBackColor = true;
            this.retryButton.Visible = false;
            this.retryButton.Click += new System.EventHandler(this.retryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(684, 861);
            this.Controls.Add(this.retryButton);
            this.Controls.Add(this.newRecordLabel);
            this.Controls.Add(this.finalScoreLabel);
            this.Controls.Add(this.bestScoreLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoreLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label bestScoreLabel;
        private System.Windows.Forms.Label finalScoreLabel;
        private System.Windows.Forms.Label newRecordLabel;
        private System.Windows.Forms.Button retryButton;
    }
}

