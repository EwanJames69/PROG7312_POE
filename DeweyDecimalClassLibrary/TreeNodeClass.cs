using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeweyDecimalClassLibrary
{
    public class TreeNodeClass
    {
        /// <summary>
        /// Stores the values of the nodes in the tree structure
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Stores the children nodes
        /// </summary>
        public List<TreeNodeClass> Children { get; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        public TreeNodeClass(string value)
        {
            Value = value;
            Children = new List<TreeNodeClass>();
        }
    }
}