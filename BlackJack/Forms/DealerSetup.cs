using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    /// <summary>
    /// Form used to set up the dealer.
    /// </summary>
    public partial class DealerSetup : Form
    {
        /// <summary>
        /// Propoerty for StandOn
        /// </summary>
        public int StandOn { get; set; }

        /// <summary>
        /// Propoerty for DrawOnSoft
        /// </summary>
        public bool DrawOnSoft { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DealerSetup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method which describes what happens when user clicks button buttonOk.
        /// 2017-05-28: Read the user input and save in to the class properties.
        ///             Set DialogResult to OK and close this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //Get the threshold (stand-on value)
            int threshold = 0;
            Convertions.ConvertStringToInteger(textBoxThreshold.Text, out threshold);
            this.StandOn = threshold;

            //Get the boolean
            this.DrawOnSoft = false;
            if(checkBoxYes.CheckState == CheckState.Checked) { this.DrawOnSoft = true; }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
