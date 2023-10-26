using System;
using System.Collections.Generic;

namespace DeweyDecimalClassLibrary
{
    public class DictionaryValueGenerator
    {
        /// <summary>
        /// Stores the call numbers along with their general description
        /// </summary>
        private Dictionary<string, string> callNumberDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Stores the descriptions for the call numbers with their range
        /// </summary>
        private Dictionary<char, string> descriptionsDictionary = new Dictionary<char, string>();

        /// <summary>
        /// Stores all the call numbers that are randomly generated
        /// </summary>
        private List<int> callNumberList = new List<int>();

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Class contructor
        /// </summary>
        /// <param name="cnDictionary"></param>
        /// <param name="cnList"></param>
        public DictionaryValueGenerator(Dictionary<string, string> cnDictionary, List<int> cnList)
        {
            callNumberDictionary = cnDictionary;
            callNumberList = cnList;

            // Adding the range with their descriptions to the descriptions dictionary whenever the class is called
            descriptionsDictionary.Clear();
            descriptionsDictionary.Add('0', "General Knowledge");
            descriptionsDictionary.Add('1', "Philosophy && Psychology");
            descriptionsDictionary.Add('2', "Religion");
            descriptionsDictionary.Add('3', "Social Sciences");
            descriptionsDictionary.Add('4', "Languages");
            descriptionsDictionary.Add('5', "Science");
            descriptionsDictionary.Add('6', "Technology");
            descriptionsDictionary.Add('7', "Arts && Recreation");
            descriptionsDictionary.Add('8', "Literature");
            descriptionsDictionary.Add('9', "History && Geography");
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Generates the call numbers to store in the dictionary and use in the Matching Columns game
        /// </summary>
        public void GenerateCallNumber()
        {
            // Clearing the previous values of the dictionary and the list
            callNumberDictionary.Clear();
            callNumberList.Clear();

            Random random = new Random();
            string callNumber;
            string description;

            // For loop to generate 10 random numbers with each being in its own "100s" range
            for (int i = 0; i < 10; i++)
            {
                // Generating a random number between 00-99
                int randomNumber = random.Next(0, 100);
                string formattedNumber = randomNumber.ToString("D2");
                callNumber = i + formattedNumber;

                // Saving the call number to the call numbers list
                callNumberList.Add(Int32.Parse(callNumber));
                
                // Getting the description for the call number and adding it to the dictionary
                description = GetDescriptionForRange(callNumber);
                callNumberDictionary.Add(callNumber, description);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Generates the description for the call numbers to store in the dictionary and use in the Matching Columns game
        /// </summary>
        public string GetDescriptionForRange(string callNumber)
        {
            // Holds the description of the number retrieved from the GenerateCallNumber Method
            string descriptionForRange;

            // Getting the first digit of the call number
            char firstDigit = callNumber[0];

            // Retrieving the description of the call number
            descriptionForRange = descriptionsDictionary[firstDigit];

            return descriptionForRange;            
        }
    }
}