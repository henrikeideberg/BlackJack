namespace BlackJack
{
    partial class DealerSetup
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelStandOn = new System.Windows.Forms.Label();
            this.labelDrawOnSoft = new System.Windows.Forms.Label();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.checkBoxYes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(70, 165);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(141, 68);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelStandOn
            // 
            this.labelStandOn.AutoSize = true;
            this.labelStandOn.Location = new System.Drawing.Point(66, 45);
            this.labelStandOn.Name = "labelStandOn";
            this.labelStandOn.Size = new System.Drawing.Size(210, 20);
            this.labelStandOn.TabIndex = 1;
            this.labelStandOn.Text = "Dealer stands on (threshold)";
            // 
            // labelDrawOnSoft
            // 
            this.labelDrawOnSoft.AutoSize = true;
            this.labelDrawOnSoft.Location = new System.Drawing.Point(66, 107);
            this.labelDrawOnSoft.Name = "labelDrawOnSoft";
            this.labelDrawOnSoft.Size = new System.Drawing.Size(234, 20);
            this.labelDrawOnSoft.TabIndex = 2;
            this.labelDrawOnSoft.Text = "Dealer draws on soft threshold?";
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(310, 45);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(57, 26);
            this.textBoxThreshold.TabIndex = 3;
            this.textBoxThreshold.Text = "17";
            // 
            // checkBoxYes
            // 
            this.checkBoxYes.AutoSize = true;
            this.checkBoxYes.Location = new System.Drawing.Point(310, 107);
            this.checkBoxYes.Name = "checkBoxYes";
            this.checkBoxYes.Size = new System.Drawing.Size(73, 24);
            this.checkBoxYes.TabIndex = 4;
            this.checkBoxYes.Text = "(Yes)";
            this.checkBoxYes.UseVisualStyleBackColor = true;
            // 
            // DealerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 272);
            this.Controls.Add(this.checkBoxYes);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.labelDrawOnSoft);
            this.Controls.Add(this.labelStandOn);
            this.Controls.Add(this.buttonOk);
            this.Name = "DealerSetup";
            this.Text = "DealerSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelStandOn;
        private System.Windows.Forms.Label labelDrawOnSoft;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.CheckBox checkBoxYes;
    }
}