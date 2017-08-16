using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Utility class to help in type convertions, string replacements
    /// etc.
    /// </summary>
    public class Convertions
    {
        /// <summary>
        /// Method to convert string to integer.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public static void ConvertStringToInteger(string input, out int output)
        {
            output = 0;
            try
            {
                output = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                //Raise error if failure. The resulting output will be 0.
                string error = String.Format("Unable to convert {0} to integer", input);
                System.Windows.MessageBox.Show(error);
            }
        }

        /// <summary>
        /// Method to convert the string "1" to "A".
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertOneToAce(string input)
        {
            string output = input;
            if(input == "1") { output = "A"; }
            return output;
        }

        /// <summary>
        /// A method which controls that a given string is neither null nor empty 
        /// and should at least have one character other than a blank space (or escape sequences).
        /// </summary>
        /// <param name="stringToValidate"></param>
        /// <returns></returns>
        public static bool ValidateString(string stringToValidate)
        {
            bool result = string.IsNullOrEmpty(stringToValidate); //FALSE if string is valid
            if (result)
            {
                string error = String.Format("Unable to validate a string");
                System.Windows.MessageBox.Show(error);
            }
            return !result;
        }

        /// <summary>
        /// Method to replace space (" ") with underscore ("_") in a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReplaceSpaceWithUnderScore(string input)
        {
            return input.Replace(" ", "_");
        }
    }
}
