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
        /// Stores the random call number that the user has to get to in the quiz
        /// </summary>
        private string randomCallNumber = "";

        /// <summary>
        /// Stores the answer of the user when they click a label in the quiz
        /// </summary>
        private string answerLabelText = "";

        /// <summary>
        /// Class object for the DeweyDecimalTree class in the class library
        /// </summary>
        private DeweyDecimalTree deweyDecimalTree = new DeweyDecimalTree();

        /// <summary>
        /// Stores the root of the tree (named "Root" unless changed in data file) and its nodes of the current question
        /// </summary>
        private TreeNodeClass root = null;
        private TreeNodeClass parentNode = null;
        private TreeNodeClass categoryNode = null;

        /// <summary>
        /// Stores the amount of times the user has started the quiz
        /// </summary>
        private int counter = 0;

        /// <summary>
        /// Stores the amount of quizzes the user has gotten correct during the current quiz
        /// </summary>
        private int amountCorrect = 0;

        /// <summary>
        /// Stores the quiz level the user is on (the quiz stops after 5 different questions)
        /// </summary>
        private int quizLevelCounter = 0;

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
                // Running the ReadyUpQuiz method to set all the variables and generate a random call number before the quiz starts
                ReadyUpQuiz();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the main menu button is clicked
        /// Takes the user back to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MainMenu_Button_Click

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to return to the main menu?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Home home = new Home();
                home.Show();
                Form mainForm = this.FindForm();
                mainForm.Hide();
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
                answerLabelText = clickedLabel.Text;
                CheckCorrectAnswer();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Creating the quiz for the user to play (Generating a random call number then displaying the answers for the user to choose)
        /// </summary>

        #region CreateQuiz_Method

        public void CreateQuiz()
        {
            // Stores the for loop initialization and condition depending on what level the user is currently attempting
            int initializer = 1;
            int condition = 5;
            string messageForLabel = "Find the call number for this description:\n";

            // Stores the back color of the label (colors differ depending on the users current level)
            Color labelBackColor = Color.MistyRose;

            // Stores the answers for the quiz (one correct answer and all the incorrect answers)
            List<string> answers = new List<string>();

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

            // Populating the answers list with one correct answer and multiple incorrect answers
            answers = deweyDecimalTree.GatherAnswers(randomCallNumber, currentLevel, root);
            string correctAnswer = answers[0];

            // Creating a list for the incorrect answers to shuffle then display on the quiz
            List<string> incorrectAnswers = new List<string>(answers.Skip(1));

            // Shuffling the indices of incorrectAnswers using the OrderBy query
            // This code was developed with the help of: ChatGPT
            Random random = new Random();
            List<int> shuffledIndices = Enumerable.Range(0, incorrectAnswers.Count).OrderBy(_ => random.Next()).ToList();

            // Taking the first three indices to get the three incorrect answers then adding the correct one
            List<string> randomizedAnswers = shuffledIndices.Take(3).Select(index => incorrectAnswers[index]).ToList();
            randomizedAnswers.Add(correctAnswer);

            // Custom made comparison logic to sort based on the numeric part of the call number
            randomizedAnswers.Sort((x, y) =>
            {
                // Extracting numeric parts
                string xNumericPart = x.Substring(0, 3);
                string yNumericPart = y.Substring(0, 3);

                // Converting to integers
                int xNumericValue = int.Parse(xNumericPart);
                int yNumericValue = int.Parse(yNumericPart);

                // Comparing integers
                return xNumericValue.CompareTo(yNumericValue);
            });            

            // Setting the label to display the answer that the user needs to get to
            lblCallNumberToGet.Text = messageForLabel + randomCallNumber.Substring(4).TrimStart();

            for (int i = initializer; i < condition; i++)
            {
                // Retrieving the labels that need to display values for the users current level
                Label answerLabel = Controls.Find($"lblAnswer{i}", true).FirstOrDefault() as Label;

                // Setting the labels values to display a random answer and enabling the click event
                answerLabel.Text = randomizedAnswers[i - initializer];
                answerLabel.BackColor = labelBackColor;
                answerLabel.Click += AnswerLabel_Click;                

                if (currentLevel == 2 || currentLevel == 3)
                {
                    // Disconnecting the previous labels click events
                    Label previousAnswerLabel = Controls.Find($"lblAnswer{i - 4}", true).FirstOrDefault() as Label;                    
                    previousAnswerLabel.Click -= AnswerLabel_Click;                    
                }
                if (currentLevel == 1)
                {
                    // Disconnecting the previous labels click events (but from the previous rounds labels)
                    Label previousAnswerLabel = Controls.Find($"lblAnswer{i + 8}", true).FirstOrDefault() as Label;
                    previousAnswerLabel.Click -= AnswerLabel_Click;
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Checks if the label text that the user selected matches the current quiz levels answer
        /// </summary>

        #region CheckCorrectAnswer_Method

        public void CheckCorrectAnswer()
        {
            bool isCorrect = false;

            // Coloring in the labels backgrounds
            DisplayLabelColours();
            
            if (currentLevel == 1)
            {
                // Checking if the answer was correct for level 1
                if (categoryNode?.Value.Trim() == answerLabelText.Trim())
                {
                    isCorrect = true;
                }
            }
            else if (currentLevel == 2)
            {
                // Checking if the answer was correct for level 2 
                if (parentNode?.Value == answerLabelText)
                {
                    isCorrect = true;
                }
            }
            else if (currentLevel == 3)
            {
                // Checking if the answer was correct for level 3
                if (randomCallNumber.Substring(0, 3) == answerLabelText)
                {
                    isCorrect = true;
                    amountCorrect++;
                }
            }

            // Playing the necessary sounds depending on the users answer
            if (!isCorrect)
            {
                MessageBox.Show("That answer was incorrect\n" +
                                "Correct Answers:\n" + 
                                $"Correct category: {categoryNode?.Value}\n" +
                                $"Correct sub-category: {parentNode?.Value}\n" +
                                $"Correct answer: {randomCallNumber}\n",
                                "Confirmation", MessageBoxButtons.OK);
                quizLevelCounter++;
                ReadyUpQuiz();
            }
            else if (isCorrect)
            {
                if (currentLevel != 3)
                {
                    currentLevel++;
                    CreateQuiz();
                }
                else
                {
                    quizLevelCounter++;
                    amountCorrect++;
                    ReadyUpQuiz();
                    // Progress bar update method here
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Sets all the variables and generates a new random call number before the next quiz level starts
        /// </summary>

        #region ReadyUpQuiz_Method

        private void ReadyUpQuiz()
        {
            if (quizLevelCounter < 6)
            {
                // Making all the labels transparent and clearing their text
                MakeLabelsTransparent();

                // Disabling the start button once the quiz has started, incrementing the counter and setting the level to level 1
                btnStart.Enabled = false;
                btnStop.Enabled = true;                
                currentLevel = 1;

                // Retrieving a random call number from the 4th level of the tree structure (any number not in the 100s or 10s range)
                // RandomValueGenerator method is from class library in the DeweyDecimalTree class
                randomCallNumber = deweyDecimalTree.RandomValueGenerator();

                // Receiving the random call numbers node and values
                var result = deweyDecimalTree.FindCallNumber(root, randomCallNumber);

                // Retrieving the parent node information to be used for the quiz as the "correct answers"
                parentNode = deweyDecimalTree.FindParentNode(root, result.node);
                categoryNode = deweyDecimalTree.FindParentNode(root, parentNode);

                // Starting the first part of the quiz (displaying call numbers in the 100s range)
                CreateQuiz();
            }
            else
            {
                // Message to display to the user and differs in words depending on how the user did
                string message = "";

                if (amountCorrect < 3)
                {
                    message = "Not the best attempt, but with practise, comes perfection! Keep trying, you got this\n" +
                              $"Your score was: {amountCorrect}/5";
                }
                else if (amountCorrect > 3 && amountCorrect < 5)
                {
                    message = "Almost there! You almost achieved 100%. Keep going, you were so close!" +
                              $"Your score was: {amountCorrect}/5";
                }
                else if (amountCorrect == 5)
                {
                    message = "Well done! You have beaten the game, but remember, just because you have beaten it, does not mean you have mastered it. " +
                              "Always feel free to try again. Maybe even try and get 5 perfect scores in a row?" +
                              $"Your score was: {amountCorrect}/5";
                }
                counter++;

                // Setting the application to display the decorative labels again once the quiz has been completed
                SetLabelDecorations();
            }
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
                answerLabel.Click -= AnswerLabel_Click;
                answerLabel.Text = "";

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
                answerLabel.Text = "";
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Sets the correct labels back colour green and the incorrect ones red
        /// </summary>

        #region DisplayLabelColours_Method

        public void DisplayLabelColours()
        {
            if (currentLevel == 1)
            {
                for (int i = 1; i < 5; i++)
                {
                    // Retrieving the labels to change their back colours
                    Label answerLabel = Controls.Find($"lblAnswer{i}", true).FirstOrDefault() as Label;
                    
                    // Checking which answer was correct
                    if (answerLabel.Text == categoryNode?.Value)
                    {
                        // Making the label that held the correct answer back colour green
                        answerLabel.BackColor = Color.Green;
                    }
                    else
                    {
                        // All the incorrect labels get the red back colour because no one likes them (Go away, you bad label)
                        answerLabel.BackColor = Color.Red;
                    }
                }
            }
            else if (currentLevel == 2)
            {
                for (int i = 5; i < 9; i++)
                {
                    // Retrieving the labels to change their back colours
                    Label answerLabel = Controls.Find($"lblAnswer{i}", true).FirstOrDefault() as Label;

                    // Checking which answer was correct
                    if (answerLabel.Text == parentNode?.Value)
                    {
                        // Making the label that held the correct answer back colour green
                        answerLabel.BackColor = Color.Green;
                    }
                    else
                    {
                        // All the incorrect labels get the red back colour because no one likes them (Go away, you bad label)
                        answerLabel.BackColor = Color.Red;
                    }
                }
            }
        }

        #endregion
    }
}
