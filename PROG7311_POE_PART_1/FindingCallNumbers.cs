using DeweyDecimalClassLibrary;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PROG7311_POE_PART_1
{
    public partial class FindingCallNumbers : Form
    {
        /// <summary>
        /// Stores the file path to the data file
        /// </summary>
        string path = "DeweyDecimalData.csv";

        /// <summary>
        /// Class object for the DeweyDecimalTree class in the class library
        /// </summary>
        private DeweyDecimalTree deweyDecimalTree = new DeweyDecimalTree();

        /// <summary>
        /// Stores the root of the tree (named "Root" unless changed in data file)
        /// </summary>
        private Node root = null;

        public FindingCallNumbers()
        {
            InitializeComponent();

            // Populating the tree with the data from the data list (code in class library)         
            root = deweyDecimalTree.PopulateTree(path);
        }        
    }
}