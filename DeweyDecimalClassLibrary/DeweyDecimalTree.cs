using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeweyDecimalClassLibrary
{
    public class DeweyDecimalTree
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public DeweyDecimalTree() { }

        /// <summary>
        /// Stores the file path for the data file
        /// </summary>
        string path = "DeweyDecimalData.txt";

        /// <summary>
        /// Stores all the nodes at level 4 (used to generate a random call number for the quiz)
        /// </summary>
        private int levelFourNodes;

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to populate the tree with the values from the csv data file in the class library
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        #region PopulateTree_Method

        public TreeNodeClass PopulateTree(string filePath)
        {
            // Reading all the lines in the data file using the file path
            string[] dataLines = File.ReadAllLines(filePath);

            // Getting the characters length of the root leading tab and creating the root
            int rootTabLength = dataLines[0].TakeWhile(c => c == '\t').Count();
            TreeNodeClass root = new TreeNodeClass(dataLines[0].Trim());

            /*
            * Creating a list to hold the nodes and their corresponding tab characters lengths
            * The amount of tabs of each data line in the data file is used to determine what node the data will be inserted at in the tree structure
            * This code was developed with the help of: ChatGPT
            */
            List<Tuple<TreeNodeClass, int>> tabbedNodesLength = new List<Tuple<TreeNodeClass, int>>
            {
                 // Adding the root to the nodes list with its tab characters length
                 new Tuple<TreeNodeClass, int>(root, rootTabLength)
            };

            // Resetting the nodesAtLevel4 count
            levelFourNodes = 0;

            for (var i = 1; i < dataLines.Length; i++)
            {
                // Creating the node and retrieving its tab characters length
                TreeNodeClass node = new TreeNodeClass(dataLines[i].Trim());
                int nodeTabLength = dataLines[i].TakeWhile(c => c == '\t').Count();

                // Checking if the node is at level 4, if so, the application will increment the levelFourNodes variable
                if (nodeTabLength == 3)
                {
                    levelFourNodes++;
                }

                // Finding the node parent in the nodes list using LINQ then adding it to its corresponding parent
                TreeNodeClass parent = tabbedNodesLength.Last(nodeAndLength => nodeAndLength.Item2 < nodeTabLength).Item1;
                parent.Children.Add(node);

                // Adding the node to the node list
                tabbedNodesLength.Add(new Tuple<TreeNodeClass, int>(node, nodeTabLength));
            }
            return root;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to find the nodes that the randomly generated call number is connected to, to retrieve the values of its parent nodes later on
        /// </summary>
        /// <param name="node"></param>
        /// <param name="targetCallNumber"></param>
        /// <returns></returns>

        #region FindCallNumber_Method

        public (TreeNodeClass node, string text) FindCallNumber(TreeNodeClass node, string randomlyGeneratedCallNumber)
        {
            // Checking if the current node's value starts with the randomly generated call number
            if (node.Value.StartsWith(randomlyGeneratedCallNumber))
            {
                // Retrieving the description of the call number
                string nodeText = node.Value.Substring(randomlyGeneratedCallNumber.Length).Trim();

                // Returning the description of the call number to display on the quiz
                return (node, nodeText);
            }

            // Searching for a specific node using the randomly generated call number
            foreach (var child in node.Children)
            {
                var foundNode = FindCallNumber(child, randomlyGeneratedCallNumber);
                if (foundNode.node != null)
                {
                    return foundNode;
                }
            }

            return (null, null);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to find the parent nodes of a certain call numbers node to check for right and wrong answers
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>

        #region FindParentNode

        public TreeNodeClass FindParentNode(TreeNodeClass rootNode, TreeNodeClass targetNode)
        {
            // --------------------------------------------------------------
            // This method was developed with the help of: ChatGPT
            // and StackOverflow at: https://stackoverflow.com/questions/36647672/how-to-get-parent-node-in-a-tree-structure-like-this
            // --------------------------------------------------------------

            // Checking if both the nodes are null or if they equal eachother (used for exception handling)
            if (rootNode == null || targetNode == null || rootNode == targetNode)
            {
                return null;
            }

            // Using this "foreach loop" to try and find the parent node
            foreach (var child in rootNode.Children)
            {
                if (child == targetNode)
                {
                    // The parent node has been found, and is now sent back
                    return rootNode;
                }

                TreeNodeClass parent = FindParentNode(child, targetNode);
                if (parent != null)
                {
                    return parent;
                }
            }

            // Returning null if the node has not been found in the tree
            return null;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//        

        /// <summary>
        /// Generates a random value from the 4th level node (that call number is used for the quiz game)
        /// </summary>
        /// <returns></returns>

        #region RandomValueGenerator_Method

        public string RandomValueGenerator()
        {
            // Creating an object of the random class (used to generate the random call number on the 4th level)
            Random random = new Random();

            try
            {
                // Gathering the tree from the data file
                TreeNodeClass root = PopulateTree(path);

                // Generating a random index to select a node at level 4
                // This line of code was developed with the help of: ChatGPT
                int randomCallNumber = random.Next(1, levelFourNodes + 1);

                // Retrieving the randomly selected node at level 4
                TreeNodeClass node = LevelFourNode(root, randomCallNumber, ref levelFourNodes);
                
                return node?.Value;
            }
            catch (Exception e)
            {
                // Returning an error if something went wrong
                return $"There was an error\n" +
                       $"Error: {e.Message}";
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Retrieves a random node from the 4th level of the tree structure
        /// </summary>
        /// <param name="node"></param>
        /// <param name="targetIndex"></param>
        /// <param name="remainingNodes"></param>
        /// <returns></returns>

        #region LevelFourNode_Method

        private TreeNodeClass LevelFourNode(TreeNodeClass node, int index, ref int nodesRemaining)
        {
            // --------------------------------------------------------------
            // This method was developed with the help of: ChatGPT
            // --------------------------------------------------------------

            if (node.Children.Count == 0)
            {
                // Decrementing the remaining amount of nodes if the current node has no children and is at level 4
                nodesRemaining--;

                if (nodesRemaining == index)
                {
                    // Returning the current node if the node remaining matches the current index
                    return node;
                }

                return null;
            }

            // Running the loop if the nodes children count does not equal 0
            foreach (var child in node.Children)
            {
                TreeNodeClass result = LevelFourNode(child, index, ref nodesRemaining);

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Checks which part of the quiz the user is on, and returns the correct and incorrect answers in a list (values taken from the tree structure)
        /// </summary>
        /// <param name="randomCallNumber"></param>
        /// <param name="currentLevel"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        
        #region GatherAnswers_Method

        public List<string> GatherAnswers(string randomCallNumber, int currentLevel, TreeNodeClass root)
        {
            // Receiving the random call numbers node and values
            var result = FindCallNumber(root, randomCallNumber);

            // Retrieving the parent node information to be used for the quiz as the "correct answer"
            TreeNodeClass parentNode = FindParentNode(root, result.node);
            TreeNodeClass CategoryNode = FindParentNode(root, parentNode);

            // List to store the correct answer along with the incorrect answers
            List<string> answers = new List<string>();
            List<string> finalAnswers = new List<string>();            

            if (currentLevel == 1)
            {
                // Adding the correct answer to the lists
                answers.Add(CategoryNode?.Value);
                finalAnswers.Add(CategoryNode?.Value);

                // Randomly generating 3 wrong answers for the category nodes in the tree
                List<TreeNodeClass> categoryNodes = GetNodes(root);
                AddRandomWrongAnswers(answers, categoryNodes);

                // This foreach has a lot of code, but it is ALL to check if the value in the node is a category value (in the 100s range)
                // Each line has been given a comment to make it easier to understand and each line makes sure that the value is a category node
                foreach (var value in answers)
                {
                    string callNumberOnly = value.Substring(0, Math.Min(3, value.Length));
                    bool meetsCondition = (!finalAnswers.Contains(value)) &&          // Checking if the value is already in the list
                                          (callNumberOnly.EndsWith("00")              // Checking if the value ends in "00" (eg. 100, 200, we want this)
                                          && !callNumberOnly.StartsWith("0")          // Checking if the value starts with "0" (eg. 070, 090, we don't want this)
                                          && value != CategoryNode?.Value             // Checking if the value equals the answer                                          
                                          || callNumberOnly.Equals("000"));           // Checking if the value is 000 (General Knowledge)

                    if (meetsCondition)
                    {
                        finalAnswers.Add(value);
                    }
                }

                // Sends back all the category nodes
                return finalAnswers;
            }
            else if (currentLevel == 2)
            {
                // Adding the correct answer to the lists
                answers.Add(parentNode?.Value);
                finalAnswers.Add(parentNode?.Value);

                // Randomly generating 3 wrong answers for the parent nodes in the tree
                List<TreeNodeClass> parentNodes = GetNodes(root);
                AddRandomWrongAnswers(answers, parentNodes);

                // This foreach has a lot of code, but it is ALL to check if the value in the node is a category value (in the 10s range)
                // Each line has been given a comment to make it easier to understand and each line makes sure that the value is a parent node
                foreach (var value in answers)
                {
                    // Retrieving the call number only and counting how many zeros the call number has
                    string callNumberOnly = value.Substring(0, Math.Min(3, value.Length));
                    bool containsTwoZeros = value.Count(c => c == '0') == 2;

                    bool meetsCondition = (!finalAnswers.Contains(value)) &&                   // Checking if the value is already in the list
                                          ((callNumberOnly.EndsWith("0") && !containsTwoZeros) // Checking if the value ends in "0" (eg. 010, 020, 210, 990) and does not contain 2 zeros
                                          || (callNumberOnly.StartsWith("0") && callNumberOnly.EndsWith("0") && containsTwoZeros)) // Checking if it ends and starts with "0"
                                          && (value != parentNode?.Value) || callNumberOnly.Equals("001"); // Checking if the value equals the answer and if it eqauls 001                                   

                    if (meetsCondition)
                    {
                        finalAnswers.Add(value);
                    }

                    for (int i = 0; i < finalAnswers.Count; i++)
                    {
                        if (!finalAnswers[i].StartsWith(randomCallNumber.Substring(0, 1)))
                        {
                            finalAnswers.RemoveAt(i);
                        }
                    }
                }

                return finalAnswers;
            }
            else if (currentLevel == 3)
            {
                // Adding the correct answer to the lists (retrieving the call number)
                answers.Add(randomCallNumber.Substring(0, 3));
                finalAnswers.Add(randomCallNumber.Substring(0, 3));

                // Randomly generating 3 wrong answers for the call number nodes in the tree
                List<TreeNodeClass> parentNodes = GetNodes(root);
                AddRandomWrongAnswers(answers, parentNodes);

                // This foreach has a lot of code, but it is ALL to check if the value in the node is a call number value (in the 1s range)
                // Each line has been given a comment to make it easier to understand and each line makes sure that the value is a call number
                foreach (var value in answers)
                {
                    // Retrieving the call number only and counting how many zeros the call number has
                    string callNumberOnly = value.Substring(0, Math.Min(3, value.Length));

                    bool meetsCondition = (!finalAnswers.Contains(value)) &&   // Checking if the value is already in the list
                                          value != parentNode?.Value &&        // Checking if the value equals the answer
                                          !randomCallNumber.EndsWith("0")      // All numbers that dont end in 0 are the ones the application need
                                          && !randomCallNumber.EndsWith("01"); // Making sure they dont end in 01 as 001...901 are all parent node values

                    if (meetsCondition)
                    {
                        finalAnswers.Add(value);
                    }

                    for (int i = 0; i < finalAnswers.Count; i++)
                    {
                        if (!finalAnswers[i].StartsWith(randomCallNumber.Substring(0, 2)))
                        {
                            finalAnswers.RemoveAt(i);
                        }
                    }
                }

                return answers;
            }
            return null;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Helper method to get a list of all the nodes
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>

        #region GetNodes_Method

        private List<TreeNodeClass> GetNodes(TreeNodeClass root)
        {
            List<TreeNodeClass> categoryNodes = new List<TreeNodeClass>();
            TraverseCategoryNodes(root, categoryNodes);
            return categoryNodes;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Helper method to traverse the tree and collect all the nodes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="categoryNodes"></param>

        #region TraverseCategoryNodes_Method

        private void TraverseCategoryNodes(TreeNodeClass node, List<TreeNodeClass> categoryNodes)
        {
            if (node == null)
                return;

            if (node.Children.Count > 0)
            {
                // Check if the node is a category node (has children)
                categoryNodes.Add(node);
            }

            foreach (var child in node.Children)
            {
                TraverseCategoryNodes(child, categoryNodes);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Helper method to add random wrong answers to the list
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="categoryNodes"></param>

        #region AddRandomWrongAnswers_Method

        private void AddRandomWrongAnswers(List<string> answers, List<TreeNodeClass> categoryNodes)
        {
            Random random = new Random();

            var filteredNodes = categoryNodes.Where(node => node.Children.Count > 0).ToList();

            for (int i = 0; i < filteredNodes.Count; i++)
            {
                answers.Add(filteredNodes[i]?.Value);
            }
        }

        #endregion
    }
}
