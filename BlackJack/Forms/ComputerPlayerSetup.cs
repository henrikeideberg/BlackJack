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
    /// Class of type Form that helps the user setting up a ComputerPlayer
    /// and the corresponding PlayerRules for that ComputerPlayer.
    /// </summary>
    public partial class ComputerPlayerSetup : Form
    {
        PlayerRules m_rules; 
        int m_NrOfGames;
        int m_StandOn;

        /// <summary>
        /// Constructor
        /// </summary>
        public ComputerPlayerSetup()
        {
            InitializeComponent();

            //Set player-rules attributes to initial value
            m_NrOfGames = 50;
            m_StandOn = 17;
            m_rules = new PlayerRules
            {
                StandOn = m_StandOn,
                NrOFGames = m_NrOfGames
            };
        }

        /// <summary>
        /// Make this public so that the attribute can be read
        /// from calling class.
        /// </summary>
        public PlayerRules Rules
        {
            get { return m_rules; }
        }

        /// <summary>
        /// Method to verify and save the PlayerRule attributes inputted
        /// by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            string error = "";
            if (ValidateInput(out error))
            {
                //If inputted values are ok - set OK and close form
                UpdatePlayerRules();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else { UserCommunication.DisplayErrorMsgBox(error); }
        }

        private void UpdatePlayerRules()
        {
            m_rules.StandOn = m_StandOn;
            m_rules.NrOFGames = m_NrOfGames;
        }

        /// <summary>
        /// Method to verify that the inputted Playerrule attributes
        /// are within valid ranges.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private bool ValidateInput(out string error)
        {
            //Read all input into attributes
            Convertions.ConvertStringToInteger(textBoxNrOfGames.Text, out m_NrOfGames);
            Convertions.ConvertStringToInteger(textBoxStandOn.Text, out m_StandOn);

            bool validationOk = true;
            error = "";
            if (!(m_NrOfGames > 0 && m_NrOfGames < 51))
            {
                validationOk = false;
                error = "Nr of games must be within range 1-50";
            }
            if (!(m_StandOn > 0 && m_StandOn < 21))
            {
                validationOk = false;
                error = "Stand on must be within range 1-20";
            }

            return validationOk;
        }

        /// <summary>
        /// Method to export the PlayerRules when buttonExport is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            string error = "";
            if (ValidateInput(out error))
            {
                UpdatePlayerRules();

                SaveFileDialog xmlExport = new SaveFileDialog();
                xmlExport.Filter = "XML Files|*.xml";

                //Show XML export dialog box
                if (xmlExport.ShowDialog() == DialogResult.OK)
                {
                    string fileName = xmlExport.FileName;
                    try
                    {
                        XMLSerializerUtility.Serialize<PlayerRules>(m_rules, fileName);
                        string strMessage = string.Format("PlayerRules are saved on disk at {0}", fileName);
                        UserCommunication.DisplaySuccesfulMsgBox(strMessage);
                    }
                    catch (Exception exception)
                    {
                        UserCommunication.DisplayErrorMsgBox(exception.Message);
                    }
                }
            }
            else { UserCommunication.DisplayErrorMsgBox(error); }
        }

        /// <summary>
        /// Method to import PlayerRules and present them in the form.
        /// The import is triggered by clicking buttonImport.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog xmlImport = new OpenFileDialog();
            xmlImport.Filter = "XML Files|*.xml";

            //Show XML import/open dialog box
            if (xmlImport.ShowDialog() == DialogResult.OK)
            {
                string fileName = xmlImport.FileName;
                try
                {
                    m_rules = XMLSerializerUtility.DeSerialize<PlayerRules>(fileName);
                    string strMessage = string.Format("{0} is deserialized successfully! ", fileName);
                    UserCommunication.DisplaySuccesfulMsgBox(strMessage);
                }
                catch (Exception exception)
                {
                    UserCommunication.DisplayErrorMsgBox(exception.Message);
                }
                UpdateGui();
            }
            xmlImport.Dispose();
        }

        private void UpdateGui()
        {
            if(m_rules != null)
            {
                textBoxNrOfGames.Text = m_rules.NrOFGames.ToString();
                textBoxStandOn.Text = m_rules.StandOn.ToString();
            }
        }
    }
}
