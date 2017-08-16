using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class to hold the 'logic' of the human player. Since this is the human player
    /// this class basically only routes the user actions (from HumanPlayerWindow)
    /// to the table.
    /// </summary>
    public class HumanPlayer : Participant
    {
        private Windows.HumanPlayerWindow m_newHumanPlayerWindow;
        List<string> m_listOfGameDetails;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <param name="tablePosition"></param>
        public HumanPlayer(Table table,
                           string name,
                           int tablePosition) : base(name, tablePosition)
        {
            //Create instance of Human Player window
            m_newHumanPlayerWindow = new Windows.HumanPlayerWindow();
            m_newHumanPlayerWindow.Title = name;
            m_newHumanPlayerWindow.Name = Convertions.ReplaceSpaceWithUnderScore(name);
            m_newHumanPlayerWindow.Show();

            //Subscribe to event from Human Player Window
            m_newHumanPlayerWindow.WindowClose += onWindowClose;
            m_newHumanPlayerWindow.HumanAction += onHumanAction;
            m_newHumanPlayerWindow.ExportGameLog += onExportGameLog;

            //Subscribe to events from Table
            table.GameComplete += onGameCompleteEvent;
            table.GameStarting += onGameStartingEvent;

            m_listOfGameDetails = new List<string>();
            //Add header to temp log file
            m_listOfGameDetails.Add("HandId; Hand; Handvalue; NumberOfSplits; SplitAces; IsDoubled; BlackJack; WinningHand; DealerHand");
        }

        private void onExportGameLog(object sender, EventArgs eventinfo)
        {
            WriteFileUtility.WriteGameLogToTextFile(m_listOfGameDetails, this.Name, false);
        }

        private void onGameStartingEvent(object sender, GameStartStopEvent eventInfo)
        {
            m_listOfGameDetails.Add("Game starting: " + eventInfo.GameId.ToString());
        }

        private void onGameCompleteEvent(object sender, GameStartStopEvent eventInfo)
        {
            //Save all information in a List<string> in format
            // Game started: x
            // HandId; Hand; Handvalue; NumberOfSplits; SplitAces; IsDoubled; BlackJack; WinningHand; DealerHand
            // Game ended: x
            foreach (int key in eventInfo.HandRecord.Keys)
            {
                //Go through the list of played hands
                for (int i = 0; i<eventInfo.HandRecord[key].Count; i++)
                {
                    //For each hand build a string with all the information
                    m_listOfGameDetails.Add(eventInfo.HandRecord[key].ElementAt(i).LogString());
                }
            }
            m_listOfGameDetails.Add("Game ended: " + eventInfo.GameId.ToString());

            //Reset the GUI
            m_newHumanPlayerWindow.textBlockHandId_Value.Text = "";
            m_newHumanPlayerWindow.textBlockHand_Value.Text = "";
            m_newHumanPlayerWindow.textBlockHandValue_Value.Text = "";
        }

        /// <summary>
        /// Define event for when this participant leaves.
        /// </summary>
        public event EventHandler<ParticipantEvent> ParticipantDisconnected;

        /// <summary>
        /// Define event HumanPlayerActionEvent
        /// </summary>
        public event EventHandler<HumanPlayerActionEvent> HumanAction;

        private void RaiseParticipantDisconnectedEvent(ParticipantEvent participantDisconnectedEvent)
        {
            if (ParticipantDisconnected != null)//Check that there is a subscriber
            {
                ParticipantDisconnected(this, participantDisconnectedEvent);
            }
        }

        /// <summary>
        /// Method to decide the human player action.
        /// </summary>
        public void TriggerAction(Hand hand)
        {
            //Trigger action at user side/GUI
            m_newHumanPlayerWindow.TriggerAction(hand);
        }

        private void onHumanAction(object sender, HumanPlayerActionEvent eventInfo)
        {
            if (HumanAction != null)
            {
                HumanAction(this, eventInfo);
            }
        }

        private void onWindowClose(object sender, EventArgs eventInfo)
        {
            ParticipantEvent ParticipantDisconnectedEventInfo = new ParticipantEvent(this.TablePosition,
                                                                                     this.Name);
            RaiseParticipantDisconnectedEvent(ParticipantDisconnectedEventInfo);
        }
    }
}
