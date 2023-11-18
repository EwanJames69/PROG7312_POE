using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
    }
}
