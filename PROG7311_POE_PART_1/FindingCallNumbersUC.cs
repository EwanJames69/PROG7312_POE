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
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace PROG7311_POE_PART_1.UserControls
{
    public partial class FindingCallNumbersUC : UserControl
    {
        /// <summary>
        /// Stores the file path to the data file
        /// </summary>
        private static string path = "DeweyDecimalData.txt";

        /// <summary>
        /// Class object for the DeweyDecimalTree class in the class library
        /// </summary>
        private DeweyDecimalTree deweyDecimalTree = new DeweyDecimalTree();

        /// <summary>
        /// Stores the root of the tree (named "Root" unless changed in data file)
        /// </summary>
        private TreeNodeClass root = null;

        /// <summary>
        /// Stores the answers for the quiz, to be compared to with the users choice
        /// </summary>
        private string currentLevelFourAnswer = null;
        private string currentLevelThreeAnswer = null;
        private string currentLevelTwoAnswer = null;

        /// <summary>
        /// Stores the amount of times the user has started the quiz
        /// </summary>
        private int counter = 0;

        /// <summary>
        /// Stores the current level of the quiz the user is currently attempting
        /// </summary>
        private int currentLevel = 0;

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
            root = deweyDecimalTree.PopulateTree(path);

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
        /// Event that runs when the start button is clicked
        /// Starts the quiz by retrieving a random "3rd-level" call number and displaying the correct and incorrect answers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Start_Button_Click

        private void btnStart_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;

            // Reminding the user to read the instructions before attempting the quiz for the first time
            if (counter == 0)
            {
                dialogResult = MessageBox.Show("Do you wish to start the quiz?\n" +
                                                            "Please make sure you have read and understood the instructions before continuing",
                                                            "Confirmation", MessageBoxButtons.YesNo);
            }
            
            if (dialogResult == DialogResult.Yes || counter > 0) 
            {
                // Disabling the start button once the quiz has started, incrementing the counter and setting the level to level 1
                btnStart.Enabled = false;
                counter++;
                currentLevel = 1;

                // Retrieving a random call number from the 4th level of the tree structure (any number not in the 100s or 10s range)
                // RandomValueGenerator method is from class library in the DeweyDecimalTree class
                string randomCallNumber = deweyDecimalTree.RandomValueGenerator();

                // Starting the first part of the quiz (displaying call numbers in the 100s range)
                CreateQuiz(randomCallNumber);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the user clicks on a label
        /// Gathers the text of the label the user clicked on, to be used to compare the text with the correct answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region AnswerLabel_Click

        private void AnswerLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Getting the text of the clicked label and storing it
                string answerLabelText = clickedLabel.Text;
                CheckCorrectAnswer(answerLabelText);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Creating the quiz for the user to play (Generating a random call number then displaying the answers for the user to choose)
        /// </summary>

        #region CreateQuiz_Method

        public void CreateQuiz(string randomCallNumber)
        {
            // Stores the for loop initialization and condition depending on what level the user is currently attempting
            int initializer = 1;
            int condition = 5;
            string messageForLabel = "Find the call number for this description:\n";

            // Stores the back color of the label (colors differ depending on the users current level)
            Color labelBackColor = Color.MistyRose;

            if (currentLevel == 2)
            {
                initializer = 5;
                condition = 9;
                labelBackColor = Color.IndianRed;
            }
            else if (currentLevel == 3)
            {
                initializer = 9;
                condition = 13;
                labelBackColor= Color.Brown;
            }          

            // Making all the labels transparent
            MakeLabelsTransparent();

            for (int i = initializer; i < condition; i++)
            {
                // Retrieving the labels that need to display values for the users current level
                Label answerLabel = Controls.Find($"lblAnswer{i}", true).FirstOrDefault() as Label;

                deweyDecimalTree.GatherAnswers(randomCallNumber, currentLevel, root);

                // Setting the labels values and connecting it to the click event
                answerLabel.BackColor = labelBackColor;
                answerLabel.Click += AnswerLabel_Click;

                if (currentLevel == 2 || currentLevel == 3)
                {
                    // Disconnecting the previous labels click events and colors
                    Label previousAnswerLabel = Controls.Find($"lblAnswer{i - 4}", true).FirstOrDefault() as Label;
                    previousAnswerLabel.BackColor = Color.Transparent;
                    previousAnswerLabel.Click -= AnswerLabel_Click;
                    previousAnswerLabel.Text = "";
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        public bool CheckCorrectAnswer(string answerLabelText)
        {
            bool isCorrect = false;

            return isCorrect;
        }

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

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Sets the labels back color to be transparent while the quiz is happening
        /// </summary>

        #region MakeLabelsTransparent_Method

        private void MakeLabelsTransparent()
        {
            for (int i = 1; i < 13; i++)
            {
                Label answerLabel = Controls.Find($"lblAnswer{i}", true).FirstOrDefault() as Label;
                answerLabel.BackColor = Color.Transparent;
            }
        }

        #endregion        
    }
}
