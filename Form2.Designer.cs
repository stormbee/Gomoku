
namespace WindowsFormsApp1
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
            if(disposing && (components != null))
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
            this.nickNameLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.turnLabel = new System.Windows.Forms.Label();
            this.nickNameLabel2 = new System.Windows.Forms.Label();
            this.pointsLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nickNameLabel
            // 
            this.nickNameLabel.AutoSize = true;
            this.nickNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nickNameLabel.Location = new System.Drawing.Point(46, 18);
            this.nickNameLabel.Name = "nickNameLabel";
            this.nickNameLabel.Size = new System.Drawing.Size(0, 20);
            this.nickNameLabel.TabIndex = 1;
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsLabel.Location = new System.Drawing.Point(46, 53);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(0, 20);
            this.pointsLabel.TabIndex = 3;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGameButton.Location = new System.Drawing.Point(230, 510);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(75, 30);
            this.StartGameButton.TabIndex = 4;
            this.StartGameButton.Text = "Start";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Location = new System.Drawing.Point(230, 31);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(0, 13);
            this.turnLabel.TabIndex = 5;
            // 
            // nickNameLabel2
            // 
            this.nickNameLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nickNameLabel2.Location = new System.Drawing.Point(340, 18);
            this.nickNameLabel2.Name = "nickNameLabel2";
            this.nickNameLabel2.Size = new System.Drawing.Size(116, 20);
            this.nickNameLabel2.TabIndex = 6;
            // 
            // pointsLabel2
            // 
            this.pointsLabel2.AutoSize = true;
            this.pointsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsLabel2.Location = new System.Drawing.Point(340, 53);
            this.pointsLabel2.Name = "pointsLabel2";
            this.pointsLabel2.Size = new System.Drawing.Size(0, 20);
            this.pointsLabel2.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(499, 561);
            this.Controls.Add(this.pointsLabel2);
            this.Controls.Add(this.nickNameLabel2);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.nickNameLabel);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nickNameLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label nickNameLabel2;
        private System.Windows.Forms.Label pointsLabel2;
    }
}