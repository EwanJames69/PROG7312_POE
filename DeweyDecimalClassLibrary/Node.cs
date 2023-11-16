using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeweyDecimalClassLibrary
{
    public class Node
    {
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<Node> Children { get; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        public Node(string value)
        {
            Value = value;
            Children = new List<Node>();
        }
    }
}