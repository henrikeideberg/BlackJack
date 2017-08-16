using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class ListManager
    {
        /// <summary>
        /// Method to return random number.
        /// 
        /// This single static random generator is there because if we are going to create 
        /// more than one random number, we need to keep the Random instance and reuse it.
        /// If we create new instances too close in time, 
        /// they will produce the same series of random numbers as the random generator 
        /// is seeded from the system clock.
        /// </summary>
        public static class Utils
        {
            public static readonly Random random = new Random();
        }

        /// <summary>
        /// Method to shuffle a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static List<T> Shuffle<T>(List<T> inputList)
        {
            List<T> randomList = new List<T>();

            Random r = new Random(DateTime.Now.Millisecond);
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                //randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomIndex = Utils.random.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        /// <summary>
        /// Method which tries to access element index in list-string-.
        /// If element is present at index, then that element (type: string) is returned.
        /// If element is not present at index, then N/A string is returned.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public static bool CheckListElementAvailable<T>(List<T> list, int index)
        {
            bool result = false;
            try
            {
                T output = list.ElementAt(index);
                result = true;
            }
            catch (Exception e)
            {
                //Do nothing
            }
            return result;
        }
    }
}
