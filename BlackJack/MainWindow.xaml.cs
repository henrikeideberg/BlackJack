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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TableRules m_tableRules;

        /// <summary>
        /// Mainwindow of application. Represents the lobby
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            CreateDefaulTableRules();
        }

        private void CreateDefaulTableRules()
        {
            m_tableRules = new TableRules
            {
                NumberOfResplits = -1,
                NumberOfSplitsOnAces = 1,
                NumberOfCardsAfterSplitAces = 1,
                AllowDoubleOnSplitAces = false,
                AllowDoubleAfterSplit = true,
                AllowDoubleOnSoftHands = false,
                DoubleMin = 9,
                DoubleMax = 11,
                DealerWinsAtTie = false
            };
        }

        /// <summary>
        /// Method to create a instance of Table when button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Create instance of Table
            Windows.TableWindow newTable = new Windows.TableWindow(m_tableRules);
            newTable.Show();
        }

        private void MenuTableRules_Click(object sender, RoutedEventArgs e)
        {
            Windows.TableRulesWindow window = new Windows.TableRulesWindow(m_tableRules);

            if(window.ShowDialog() == true)
            {
                m_tableRules = window.Rules;
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
