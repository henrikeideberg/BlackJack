using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //TextReader
using Microsoft.Win32; //OpenFileDialog and SaveFileDialog

namespace BlackJack
{
    public class WriteFileUtility
    {
        /// <summary>
        /// Method get a file (name and directory) to which an
        /// operation can be made and saved.
        /// 
        /// Below documantation was useful when writing bélow method.
        /// http://stackoverflow.com/questions/5136254/saving-file-using-savefiledialog-in-c-sharp
        /// </summary>
        /// <param name="defaultFileName"></param>
        /// <returns>bool</returns>
        private static bool GetDirToSaveFileTo(string defaultFileName, out string filename)
        {
            bool result = false;
            filename = "";
            SaveFileDialog savefile = new SaveFileDialog();

            //Set the default filename passed in
            savefile.FileName = defaultFileName;

            //Get the updated file directory and name
            result = (bool)savefile.ShowDialog();
            filename = savefile.FileName;

            return result;
        }

        /// <summary>
        /// Method to write invoice details (type: string[]) to a tile.
        /// </summary>
        /// <param name="stringArray"></param>
        /// <param name="defaultFileName"></param>
        /// <returns>bool</returns>
        public static bool WriteGameLogToTextFile(List<string> stringArray,
                                                  string defaultFileName,
                                                  bool defaultDir)
        {
            bool bOk = false;
            string uriPath = String.Format(@"{0}\{1}.txt",
                                           System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase),
                                           defaultFileName);
            string filename = new Uri(uriPath).LocalPath;

            if (!defaultDir)
            {
                defaultDir = GetDirToSaveFileTo(defaultFileName, out filename);
            }

            if(defaultDir)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        for (int i = 0; i < stringArray.Count; i++)
                        {
                            sw.WriteLine(stringArray[i]);
                        }
                    }
                    bOk = true;
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            }
            return bOk;
        }
    }
}
