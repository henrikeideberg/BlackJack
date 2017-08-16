namespace BlackJack
{
    partial class PlayerSetup
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
            this.buttonHumanPlayer = new System.Windows.Forms.Button();
            this.buttonCompuerPlayer = new System.Windows.Forms.Button();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonHumanPlayer
            // 
            this.buttonHumanPlayer.Location = new System.Drawing.Point(52, 110);
            this.buttonHumanPlayer.Name = "buttonHumanPlayer";
            this.buttonHumanPlayer.Size = new System.Drawing.Size(134, 138);
            this.buttonHumanPlayer.TabIndex = 0;
            this.buttonHumanPlayer.Text = "Human Player";
            this.buttonHumanPlayer.UseVisualStyleBackColor = true;
            this.buttonHumanPlayer.Click += new System.EventHandler(this.buttonHumanPlayer_Click);
            // 
            // buttonCompuerPlayer
            // 
            this.buttonCompuerPlayer.Location = new System.Drawing.Point(208, 110);
            this.buttonCompuerPlayer.Name = "buttonCompuerPlayer";
            this.buttonCompuerPlayer.Size = new System.Drawing.Size(134, 138);
            this.buttonCompuerPlayer.TabIndex = 1;
            this.buttonCompuerPlayer.Text = "Computer Player";
            this.buttonCompuerPlayer.UseVisualStyleBackColor = true;
            this.buttonCompuerPlayer.Click += new System.EventHandler(this.buttonCompuerPlayer_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(48, 58);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(100, 20);
            this.labelPlayerName.TabIndex = 2;
            this.labelPlayerName.Text = "Player name:";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(175, 52);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(167, 26);
            this.textBoxPlayerName.TabIndex = 3;
            this.textBoxPlayerName.Text = "Player";
            // 
            // PlayerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 282);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.buttonCompuerPlayer);
            this.Controls.Add(this.buttonHumanPlayer);
            this.Name = "PlayerSetup";
            this.Text = "PlayerSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHumanPlayer;
        private System.Windows.Forms.Button buttonCompuerPlayer;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.TextBox textBoxPlayerName;
    }
}