using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class to hold the data to be presented in a listview.
    /// </summary>
    class ListViewLogItem
    {
        public DateTime TimeStamp
        {
            get;
            set;
        }

        public string Information
        {
            get;
            set;
        }

        public string Sender
        {
            get;
            set;
        }
    }
}
