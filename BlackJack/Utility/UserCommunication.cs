using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    class UserCommunication
    {
        /// <summary>
        /// Method which configures and displays a messagebox to indicate succesful registration
        /// </summary>
        /// <param name="messageBoxText"></param>
        public static void DisplaySuccesfulMsgBox(string messageBoxText)
        {
            //Configure the message box
            string caption = "Success!";                             //Sets the heading of the msgbox
            MessageBoxButtons button = MessageBoxButtons.OK;         //configures the button(s) of the msgbox
            MessageBoxIcon icon = MessageBoxIcon.Information;        //configures the icon to be displayed

            //Display the messagebox
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        /// <summary>
        /// Method which configures and displays a messagebox to indicate an error
        /// </summary>
        /// <param name="messageBoxText"></param>
        public static void DisplayErrorMsgBox(string messageBoxText)
        {
            //Configure the message box
            string caption = "Error!";            //Sets the heading of the msgbox
            MessageBoxButtons button = MessageBoxButtons.OK;            //configures the button(s) of the msgbox
            MessageBoxIcon icon = MessageBoxIcon.Error;                 //configures the icon to be displayed

            //Display the messagebox
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
