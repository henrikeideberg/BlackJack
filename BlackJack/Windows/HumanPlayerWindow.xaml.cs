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
using System.ComponentModel; //CancelEventArgs
using System.Timers; //responseTimer

namespace BlackJack.Windows
{
    /// <summary>
    /// Interaction logic for HumanPlayerWindow.xaml
    /// </summary>
    public partial class HumanPlayerWindow : Window
    {
        private ActionType m_playerAction;
        private int m_activeHandId;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public HumanPlayerWindow()
        {
            InitializeComponent();

            //Set the player action to default 'Stop'
            m_playerAction = ActionType.Stop;

            m_activeHandId = 0;

            //Disable the GUI
            DisableGui();
        }

        private void DisableGui()
        {
            buttonDraw.IsEnabled = false;
            buttonSplit.IsEnabled = false;
            buttonStop.IsEnabled = false;
        }

        /// <summary>
        /// Define event WindowCloseEvent
        /// </summary>
        public event EventHandler<EventArgs> WindowClose;

        /// <summary>
        /// Define event HumanPlayerActionEvent
        /// </summary>
        public event EventHandler<HumanPlayerActionEvent> HumanAction;

        /// <summary>
        /// Define event ExportGameLog
        /// </summary>
        public event EventHandler<EventArgs> ExportGameLog; 

        private void RaiseWindowCloseEvent(EventArgs windowCloseEventInfo)
        {
            if(WindowClose != null)
            {
                WindowClose(this, windowCloseEventInfo);
            }
        }

        private void RaiseHumanActionEvent()
        {
            HumanPlayerActionEvent humanActionEventInfo = new HumanPlayerActionEvent(m_playerAction, m_activeHandId);
            if (HumanAction != null)
            {
                HumanAction(this, humanActionEventInfo);
            }
        }

        /// <summary>
        /// Method used by the table to trigger an action
        /// at the human player. The action is e.g. Draw.
        /// This trigger enables the GUI and updates the 
        /// hand information.
        /// </summary>
        /// <param name="hand"></param>
        public void TriggerAction(Hand hand)
        {
            //Set the hand we are playing
            m_activeHandId = hand.HandId;

            //Display hand, hand-value and handId in the GUI
            textBlockHandId_Value.Text = hand.HandId.ToString();
            textBlockHand_Value.Text = hand.HandToString();
            textBlockHandValue_Value.Text = hand.HandValueToString();

            //Enable the GUI
            buttonDraw.IsEnabled = true;
            buttonStop.IsEnabled = true;
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            string msg = "Your player will be disconnected. Close (Y/N)?";

            //Display messagebox asking user to confirm close
            MessageBoxResult msgBoxResult = MessageBox.Show(
                msg,
                "Leaving?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if(msgBoxResult == MessageBoxResult.Yes)
            {
                //raise event to tell humanPlayer that window has been closed
                EventArgs windowClosed = new EventArgs();
                RaiseWindowCloseEvent(windowClosed);
            }
            else
            {
                //Cancel close
                e.Cancel = true;
            }
        }

        private void buttonDraw_Click(object sender, RoutedEventArgs e)
        {
            m_playerAction = ActionType.Draw;
            DisableGui();
            RaiseHumanActionEvent();
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            m_playerAction = ActionType.Stop;
            DisableGui();
            RaiseHumanActionEvent();
        }

        private void buttonExportGameLog_Click(object sender, RoutedEventArgs e)
        {
            EventArgs exportGameLogEventInfo = new EventArgs();
            if (ExportGameLog != null)
            {
                ExportGameLog(this, exportGameLogEventInfo);
            }
        }
    }
}
