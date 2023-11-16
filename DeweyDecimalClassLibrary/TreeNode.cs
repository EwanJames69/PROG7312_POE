using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassLibrary
{
    public class TreeNode
    {
        /// <summary>
        /// Stores the call numbers from the data file
        /// </summary>
        public string CallNumber { get; set; }

        /// <summary>
        /// Stores the descriptions of the call numbers from the data file
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Stores all the children nodes in the tree structure
        /// </summary>
        public List<TreeNode> Children { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="callNumber"></param>
        /// <param name="description"></param>
        public TreeNode(string callNumber, string description)
        {
            CallNumber = callNumber;
            Description = description;
            Children = new List<TreeNode>();
        }
    }
}