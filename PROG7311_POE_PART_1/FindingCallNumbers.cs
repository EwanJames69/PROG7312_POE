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

namespace PROG7311_POE_PART_1
{
    public partial class FindingCallNumbers : Form
    {
        string filePath = "DeweyDecimalData.csv";

        private DeweyDecimalTree deweyTree = new DeweyDecimalTree();
        private int counter;

        public FindingCallNumbers()
        {
            InitializeComponent();          
        }

        private void ReadDataFromFileAndDisplayTree(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header line
                    reader.ReadLine();                    

                    while (!reader.EndOfStream)
                    {
                        counter++;
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        string callNumber = parts[0];
                        string description = parts[1];
                        int level = int.Parse(parts[2]);

                        // Display information directly, no need to create nodes
                        DisplayTreeInfo(callNumber, description, level);
                    }
                }
            }
            catch (Exception ex)
            {
                lblTest.Text = ($"An error occurred while reading the file: {ex.Message} " + $"{counter}");
            }
        }

        private void DisplayTreeInfo(string callNumber, string description, int level)
        {
            // Display information about the current node
            lblTest.Text += $"{callNumber}: {description}\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadDataFromFileAndDisplayTree(filePath);;
        }
    }
}
