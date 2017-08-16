using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class that represents a computer player.
    /// </summary>
    public class ComputerPlayer : Participant
    {
        List<string> m_listOfGameDetails;
        int m_gameCounter;
        PlayerRules m_playerRules;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table"></param>
        /// <param name="playerRules"></param>
        /// <param name="name"></param>
        /// <param name="tablePosition"></param>
        public ComputerPlayer(Table table,
                              PlayerRules playerRules,
                              string name,
                              int tablePosition) : base(name, tablePosition)
        {
            m_gameCounter = 0;
            m_playerRules = playerRules;

            //Subscribe to events from Table
            table.GameComplete += onGameCompleteEvent;
            table.GameStarting += onGameStartingEvent;

            m_listOfGameDetails = new List<string>();
            //Add header to temp log file
            m_listOfGameDetails.Add("HandId; Hand; Handvalue; NumberOfSplits; SplitAces; IsDoubled; BlackJack; WinningHand; DealerHand");
        }

        private void ExportGameLog()
        {
            WriteFileUtility.WriteGameLogToTextFile(m_listOfGameDetails, this.Name, true);
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
                for (int i = 0; i < eventInfo.HandRecord[key].Count; i++)
                {
                    //For each hand build a string with all the information
                    m_listOfGameDetails.Add(eventInfo.HandRecord[key].ElementAt(i).LogString());
                }
            }
            m_listOfGameDetails.Add("Game ended: " + eventInfo.GameId.ToString());

            m_gameCounter++;
            if(m_gameCounter == m_playerRules.NrOFGames)
            {
                ExportGameLog();
                RaiseParticipantDisconnectedEvent();
            }
        }

        /// <summary>
        /// Define event for when this participant leaves.
        /// </summary>
        public event EventHandler<ParticipantEvent> ParticipantDisconnected;

        /// <summary>
        /// Raise the event of type ParticipantEvent
        /// </summary>
        private void RaiseParticipantDisconnectedEvent()
        {
            ParticipantEvent participantDisconnectedEvent = new ParticipantEvent(this.TablePosition, this.Name);
            if (ParticipantDisconnected != null)//Check that there is a subscriber
            {
                ParticipantDisconnected(this, participantDisconnectedEvent);
            }
        }

        /// <summary>
        /// Method that given a hand, responds with an action.
        /// Used by the Table.
        /// </summary>
        /// <param name="activeHand"></param>
        /// <returns></returns>
        public override ActionType GetAction(Hand activeHand)
        {
            ActionType returnAction = ActionType.Stop;
            int index = activeHand.GetHandValue().Count - 1;
            if(ListManager.CheckListElementAvailable(activeHand.GetHandValue(), index))
            {
                if(activeHand.GetHandValue().ElementAt(index) < m_playerRules.StandOn)
                { returnAction = ActionType.Draw; }
            }

            return returnAction;
        }
    }
}
