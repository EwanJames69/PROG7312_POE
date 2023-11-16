using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassLibrary
{
    public class DeweyDecimalTree
    {
        public TreeNode Root { get; private set; }

        public DeweyDecimalTree()
        {
            // Root node
            Root = new TreeNode("Root", "Dewey Decimal System");
        }

        public void AddNode(string callNumber, string description, int level)
        {
            AddNodeRecursive(Root, callNumber, description, level);
        }

        private void AddNodeRecursive(TreeNode parentNode, string callNumber, string description, int level)
        {
            // Check if the level is valid
            if (level <= 0)
            {
                Console.WriteLine($"Invalid level for {callNumber} - {description}");
                return;
            }

            // Find the parent node based on the call number
            TreeNode parent;

            if (level == 1)
            {
                // For level 1, add as a child of the root
                parent = parentNode;
            }
            else
            {
                // For levels 2 and 3, find the parent based on the call number
                string parentCallNumber = callNumber.Substring(0, level - 1);

                parent = parentNode.Children.FirstOrDefault(c => c.CallNumber == parentCallNumber);

                if (parent == null)
                {
                    Console.WriteLine($"Parent not found for {callNumber} - {description}");
                    return;
                }
            }

            // Add the current node as a child of the parent
            TreeNode currentNode = new TreeNode(callNumber, description);
            parent.Children.Add(currentNode);
        }

        public string GetTreeData()
        {
            StringBuilder displayText = new StringBuilder();
            DisplayTree(Root, ref displayText);
            return displayText.ToString();
        }

        private void DisplayTree(TreeNode node, ref StringBuilder displayText, string indent = "")
        {
            if (node != null)
            {
                // Display information about the current node
                displayText.AppendLine($"{indent}{node.CallNumber}: {node.Description}");

                // Traverse children
                foreach (var child in node.Children)
                {
                    DisplayTree(child, ref displayText, indent + "  ");
                }
            }
        }
    }
}
