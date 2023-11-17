using DeweyDecimalClassLibrary;
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

namespace PROG7311_POE_PART_1.UserControls
{
    public partial class FindingCallNumbersUC : UserControl
    {
        /// <summary>
        /// Stores the file path to the data file
        /// </summary>
        private static string fileName = "DeweyDecimalData.txt";

        /// <summary>
        /// Class object for the DeweyDecimalTree class in the class library
        /// </summary>
        private DeweyDecimalTree deweyDecimalTree = new DeweyDecimalTree();

        /// <summary>
        /// Stores the root of the tree (named "Root" unless changed in data file)
        /// </summary>
        private Node root = null;

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the FindingCallNumbers form starts up
        /// Sets labels decorations, populates tree, disables buttons and sets timer interval
        /// </summary>

        #region FindingCallNumbers

        public FindingCallNumbersUC()
        {
            InitializeComponent();

            // Populating the tree with the data from the data list (code in class library)         
            root = deweyDecimalTree.PopulateTree(fileName);

            // Setting the label's decorations for when the quiz is not currently happening
            SetLabelDecorations();

            // Disabling certain buttons before the user begins the quiz
            btnStop.Enabled = false;

            // Setting the timer interval to one second
            timerAnswer.Interval = 1000;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Sets the label's values to look good while the user is not busy with a quiz
        /// </summary>

        #region SetLabelDecorations_Method

        private void SetLabelDecorations()
        {
            // Making the labels look nice whenever the user is not currently busy with a quiz
            for (int i = 0; i < 12; i++)
            {
                // Retrieving the labels from the designer to change its values
                Label answerLabel = Controls.Find($"lblAnswer{i + 1}", true).FirstOrDefault() as Label;

                if (i + 1 == 1)
                {
                    answerLabel.BackColor = Color.RosyBrown;
                    answerLabel.Text = "Welcome";
                }
                else if (i + 1 == 2 || i + 1 == 5 || i + 1 == 6) 
                { 
                    answerLabel.BackColor = Color.IndianRed;
                    if(i + 1 == 6) { answerLabel.Text = "To The"; }
                }
                else if (i + 1 == 3 || i + 1 == 7 || i + 1 == 9 || i + 1 == 10 || i + 1 == 11)
                {
                    answerLabel.BackColor = Color.Brown;
                    if (i + 1 == 11) { answerLabel.Text = "Finding Call Numbers Game"; }
                }
                else if (i + 1 == 4 || i + 1 == 8 || i + 1 == 12)
                {
                    answerLabel.BackColor = Color.Brown;
                    if (i + 1 == 8) { answerLabel.Text = "Click Start To Begin"; }
                }
            }
        }

        #endregion
    }
}
