using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassLibrary
{
    public class CallNumberGenerator
    {
        /// <summary>
        /// Random variable to use for generating the call numbers
        /// </summary>
        private Random random;

        /// <summary>
        /// Class constructor
        /// </summary>
        public CallNumberGenerator() 
        {
            random = new Random();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Generates the call numbers used in the Replace Books game to store them on the book panel
        /// </summary>
        /// <returns></returns>
        public string GenerateCallNumber()
        {
            // Generating a random call number for the "Replace Books" game
            // Uses a format specifier (D3 and D2) to make sure it follows the format "XXX.YY AAA" as it adds leading zeros to the number if necessary
            var callNumber = $"{random.Next(1, 1000):D3}.{random.Next(1, 100):D2} {(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";

            return callNumber;
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Sorts the call numbers that were generated in the Replace Books game, to compare the users answers with the correct ones
        /// </summary>
        /// <param name="currentCallNumbers"></param>
        /// <returns></returns>
        public List<string> SortCallNumbers(List<string> currentCallNumbers) 
        {
            var sortedCallNumbers = new List<string>();

            /*
             *  Storing the sorted call numbers in a list for comparison             
             *  (cn => cn) is a lambda expression that serves as the sorting key. It defines how the elements in the list should be evaluated for sorting. 
             *  In this case, cn is a parameter that represents each element in the list, and cn => cn essentially means "sort the elements based on themselves."
             *  In other words, it's sorting the elements in their natural order (lexicographical order for strings)
             *  This code was constructed with help of GeeksforGeeks at: https://www.geeksforgeeks.org/lambda-expressions-in-c-sharp/
            */
            sortedCallNumbers = currentCallNumbers.OrderBy(cn => cn).ToList();

            return sortedCallNumbers;
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// This method runs when the Replace Books game is opened
        /// It initializes the background images of the panels to look like books, by storing each image in a list
        /// </summary>
        /// <param name="backgroundImageList"></param>
        public List<Image> FillBackroundImages(List<Image> backgroundImageList)
        {
            // Clearing all the current images stored in the list
            backgroundImageList.Clear();

            // Initializing the list with background images for the book panels
            backgroundImageList.Add(Properties.Resources.bookRed);
            backgroundImageList.Add(Properties.Resources.bookOrange);
            backgroundImageList.Add(Properties.Resources.bookYellow);
            backgroundImageList.Add(Properties.Resources.bookGreen);
            backgroundImageList.Add(Properties.Resources.bookBlue);
            backgroundImageList.Add(Properties.Resources.bookPink);
            backgroundImageList.Add(Properties.Resources.bookPurple);
            backgroundImageList.Add(Properties.Resources.bookBrown);
            backgroundImageList.Add(Properties.Resources.bookGrey);
            backgroundImageList.Add(Properties.Resources.bookBlack);

            return backgroundImageList;
        }
    }
}