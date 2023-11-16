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

        public FindingCallNumbers()
        {
            InitializeComponent();            
        }

        static string[] ReadFirstThreeLines(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Reading the first three lines
                    string[] firstThreeLines = new string[3];
                    for (int i = 0; i < 3 && !reader.EndOfStream; i++)
                    {
                        firstThreeLines[i] = reader.ReadLine();
                    }

                    return firstThreeLines;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Method to read the first three lines
            string[] firstThreeLines = ReadFirstThreeLines(filePath);

            // Displaying the first three lines as a test
            if (firstThreeLines != null)
            {
                StringBuilder displayText = new StringBuilder();

                for (int i = 0; i < firstThreeLines.Length && firstThreeLines[i] != null; i++)
                {
                    displayText.AppendLine($"Line {i + 1}: {firstThreeLines[i]}");
                }

                lblTest.Text = displayText.ToString();
            }
            else
            {
                lblTest.Text = ("The file is empty or an error occurred while reading.");
            }
        }
    }
}
