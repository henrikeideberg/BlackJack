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
    /// Form used to configure whether the player shall
    /// be a human player or a computer player.
    /// </summary>
    public partial class PlayerSetup : Form
    {
        /// <summary>
        /// Property HumanPlayer
        /// </summary>
        public bool HumanPlayer { get; set; }

        /// <summary>
        /// Property PlayerName
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PlayerSetup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to set the player as human when buttonHumanPlayer
        /// is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHumanPlayer_Click(object sender, EventArgs e)
        {
            setResult(true);
        }

        private void buttonCompuerPlayer_Click(object sender, EventArgs e)
        {
            setResult(false);
        }

        /// <summary>
        /// Method to set attributes
        ///  - HumanPlayer. true or false depending on which button,
        ///    buttonHumanPlayer or buttonCompuerPlayer, was clicked.
        ///  - Name of player
        /// </summary>
        /// <param name="humanPlayer"></param>
        private void setResult(bool humanPlayer)
        {
            HumanPlayer = humanPlayer;
            if (Convertions.ValidateString(textBoxPlayerName.Text))
            {
                PlayerName = textBoxPlayerName.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
