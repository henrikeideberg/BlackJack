using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace BlackJack.Windows
{
    /// <summary>
    /// Interaction logic for TableRulesWindow.xaml
    /// </summary>
    public partial class TableRulesWindow : Window
    {
        TableRules m_tableRules;
        int m_numberOfResplits;
        int m_numberOfSplitsOnAces;
        int m_numberOfCardsAfterSplitAces;
        int m_doubleMin;
        int m_doubleMax;

        /// <summary>
        /// Class that helps user see, configure, export and import the table rules.
        /// </summary>
        /// <param name="rules"></param>
        public TableRulesWindow(TableRules rules)
        {
            InitializeComponent();

            m_tableRules = rules;
            m_numberOfResplits = -1;
            m_numberOfSplitsOnAces = 1;
            m_numberOfCardsAfterSplitAces = 1;
            m_doubleMin = 9;
            m_doubleMax = 11;
        }

        /// <summary>
        /// Table rules
        /// </summary>
        public TableRules Rules
        {
            get { return m_tableRules; }
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            if (ValidateInput(out error))
            {
                //If inputted values are ok - set OK and close form
                UpdateTableRules();
                DialogResult = true;
                this.Close();
            }
            else { UserCommunication.DisplayErrorMsgBox(error); }
        }

        private bool ValidateInput(out string error)
        {
            error = "";
            //Read all integers
            Convertions.ConvertStringToInteger(textBox1.Text, out m_doubleMax);
            Convertions.ConvertStringToInteger(textBox2.Text, out m_doubleMin);
            Convertions.ConvertStringToInteger(textBox3.Text, out m_numberOfResplits);
            Convertions.ConvertStringToInteger(textBox4.Text, out m_numberOfSplitsOnAces);
            Convertions.ConvertStringToInteger(textBox5.Text, out m_numberOfCardsAfterSplitAces);

            return true; //No validation
        }

        private void UpdateTableRules()
        {
            m_tableRules.NumberOfResplits = m_numberOfResplits;
            m_tableRules.NumberOfSplitsOnAces = m_numberOfSplitsOnAces;
            m_tableRules.NumberOfCardsAfterSplitAces = m_numberOfCardsAfterSplitAces;
            m_tableRules.DoubleMin = m_doubleMin;
            m_tableRules.DoubleMax = m_doubleMax;

            //Read all checkboxes/booleans
            m_tableRules.AllowDoubleOnSplitAces = (true == checkBox1.IsChecked) ? true : false;
            m_tableRules.AllowDoubleAfterSplit = (true == checkBox2.IsChecked) ? true : false;
            m_tableRules.AllowDoubleOnSoftHands = (true == checkBox3.IsChecked) ? true : false;
            m_tableRules.DealerWinsAtTie = (true == checkBox4.IsChecked) ? true : false;
        }

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            if (ValidateInput(out error))
            {
                UpdateTableRules();

                SaveFileDialog xmlExport = new SaveFileDialog();
                xmlExport.Filter = "XML Files|*.xml";

                //Show XML export dialog box
                if (xmlExport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = xmlExport.FileName;
                    try
                    {
                        XMLSerializerUtility.Serialize<TableRules>(m_tableRules, fileName);
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

        private void buttonImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog xmlImport = new OpenFileDialog();
            xmlImport.Filter = "XML Files|*.xml";

            //Show XML import/open dialog box
            if (xmlImport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = xmlImport.FileName;
                try
                {
                    m_tableRules = XMLSerializerUtility.DeSerialize<TableRules>(fileName);
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
            textBox1.Text = m_tableRules.DoubleMax.ToString();
            textBox2.Text = m_tableRules.DoubleMin.ToString();
            textBox3.Text = m_tableRules.NumberOfResplits.ToString();
            textBox4.Text = m_tableRules.NumberOfSplitsOnAces.ToString();
            textBox5.Text = m_tableRules.NumberOfCardsAfterSplitAces.ToString();

            if (m_tableRules.AllowDoubleOnSplitAces)
            { checkBox1.IsChecked = true; } else { checkBox1.IsChecked = false; }
            if (m_tableRules.AllowDoubleAfterSplit)
            { checkBox2.IsChecked = true; } else { checkBox2.IsChecked = false; }
            if (m_tableRules.AllowDoubleOnSoftHands)
            { checkBox3.IsChecked = true; } else { checkBox3.IsChecked = false; }
            if (m_tableRules.DealerWinsAtTie)
            { checkBox4.IsChecked = true; } else { checkBox4.IsChecked = false; }
        }
    }
}
