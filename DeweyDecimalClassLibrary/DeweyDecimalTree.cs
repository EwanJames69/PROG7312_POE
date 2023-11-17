using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassLibrary
{
    public class DeweyDecimalTree
    {
        /// <summary>
        /// Stores the file path to the data file
        /// </summary>
        string path = "DeweyDecimalData.txt";

        /// <summary>
        /// Class constructor
        /// </summary>
        public DeweyDecimalTree() { }        

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to populate the tree with the values from the csv data file in the class library
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        #region PopulateTree_Method

        public Node PopulateTree(string filePath)
        {
            // Reading all the lines in the data file using the file path
            string[] lines = File.ReadAllLines(filePath);

            // Checking if the application read from the data file correctly (returning null if there was an error)
            if (lines.Length == 0)
            {
                return null;
            }

            // Getting the characters length of the root leading tab and creating the root
            int rootTabLength = lines[0].TakeWhile(c => c == '\t').Count();            
            Node root = new Node(lines[0].Trim());

            // Creating a list to hold the nodes and their corresponding tab characters lengths
            List<Tuple<Node, int>> nodesAndLengths = new List<Tuple<Node, int>>
            {
                // Adding the root to the nodes list with its tab characters length
                new Tuple<Node, int>(root, rootTabLength)
            };

            for (var i = 1; i < lines.Length; i++)
            {
                // Creating the node and retrieving its tab characters length
                Node node = new Node(lines[i].Trim());
                int nodeTabLength = lines[i].TakeWhile(c => c == '\t').Count();

                // Checking if the node is a root (there can't be more than 2 roots in one tree structure)
                if (nodeTabLength <= rootTabLength)
                {
                    throw new Exception("There cannot be more than one root, please change the data provided");
                }

                // Finding the node parent in the nodes list using LINQ then adding it to its corresponding parent
                Node parent = nodesAndLengths.Last(nodeAndLength => nodeAndLength.Item2 < nodeTabLength).Item1;
                parent.Children.Add(node);

                // Adding the node to the node list
                nodesAndLengths.Add(new Tuple<Node, int>(node, nodeTabLength));                
            }
            return root;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to find the nodes that the call number is connected to, to retrieve the values of its parent nodes later on
        /// </summary>
        /// <param name="node"></param>
        /// <param name="targetCallNumber"></param>
        /// <returns></returns>

        #region FindNodeByCallNumber_Method

        public (Node node, string text) FindNodeByCallNumber(Node node, string targetCallNumber)
        {
            // Check if the current node's value starts with the target call number
            if (node.Value.StartsWith(targetCallNumber))
            {
                // Extract the text after the call number
                string nodeText = node.Value.Substring(targetCallNumber.Length).Trim();

                return (node, nodeText);
            }

            // Recursively search in the children nodes
            foreach (var child in node.Children)
            {
                var foundNode = FindNodeByCallNumber(child, targetCallNumber);
                if (foundNode.node != null)
                {
                    return foundNode;
                }
            }

            return (null, null);
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to find the parent nodes of a certain call numbers node to check for right and wrong answers
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>

        #region FindParent

        public Node FindParent(Node rootNode, Node targetNode)
        {
            if (rootNode == null || targetNode == null || rootNode == targetNode)
            {
                return null; // No parent for the root or if targetNode is null or the root itself
            }

            foreach (var child in rootNode.Children)
            {
                if (child == targetNode)
                {
                    return rootNode; // Found the parent
                }

                Node parent = FindParent(child, targetNode);
                if (parent != null)
                {
                    return parent;
                }
            }

            return null; // Node not found in the tree
        }

        #endregion
    }
}
