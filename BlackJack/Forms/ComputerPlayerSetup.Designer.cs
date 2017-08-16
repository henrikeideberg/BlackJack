namespace BlackJack
{
    partial class ComputerPlayerSetup
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
            this.labelStandOn = new System.Windows.Forms.Label();
            this.labelNrOfGames = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxStandOn = new System.Windows.Forms.TextBox();
            this.textBoxNrOfGames = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelStandOn
            // 
            this.labelStandOn.AutoSize = true;
            this.labelStandOn.Location = new System.Drawing.Point(59, 29);
            this.labelStandOn.Name = "labelStandOn";
            this.labelStandOn.Size = new System.Drawing.Size(78, 20);
            this.labelStandOn.TabIndex = 0;
            this.labelStandOn.Text = "Stand on:";
            // 
            // labelNrOfGames
            // 
            this.labelNrOfGames.AutoSize = true;
            this.labelNrOfGames.Location = new System.Drawing.Point(38, 72);
            this.labelNrOfGames.Name = "labelNrOfGames";
            this.labelNrOfGames.Size = new System.Drawing.Size(99, 20);
            this.labelNrOfGames.TabIndex = 1;
            this.labelNrOfGames.Text = "Nr of games:";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(46, 218);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(90, 44);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(162, 218);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(90, 44);
            this.buttonImport.TabIndex = 3;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(332, 200);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(114, 70);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxStandOn
            // 
            this.textBoxStandOn.Location = new System.Drawing.Point(143, 23);
            this.textBoxStandOn.Name = "textBoxStandOn";
            this.textBoxStandOn.Size = new System.Drawing.Size(46, 26);
            this.textBoxStandOn.TabIndex = 5;
            this.textBoxStandOn.Text = "17";
            // 
            // textBoxNrOfGames
            // 
            this.textBoxNrOfGames.Location = new System.Drawing.Point(143, 66);
            this.textBoxNrOfGames.Name = "textBoxNrOfGames";
            this.textBoxNrOfGames.Size = new System.Drawing.Size(46, 26);
            this.textBoxNrOfGames.TabIndex = 6;
            this.textBoxNrOfGames.Text = "50";
            // 
            // ComputerPlayerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 297);
            this.Controls.Add(this.textBoxNrOfGames);
            this.Controls.Add(this.textBoxStandOn);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelNrOfGames);
            this.Controls.Add(this.labelStandOn);
            this.Name = "ComputerPlayerSetup";
            this.Text = "ComputerPlayerSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStandOn;
        private System.Windows.Forms.Label labelNrOfGames;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxStandOn;
        private System.Windows.Forms.TextBox textBoxNrOfGames;
    }
}