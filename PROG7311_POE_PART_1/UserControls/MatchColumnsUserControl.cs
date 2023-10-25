using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeweyDecimalClassLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PROG7311_POE_PART_1
{
    public partial class MatchColumnsUserControl : UserControl
    {
        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Stores the call numbers along with their general description
        /// </summary>
        private Dictionary<string, string> callNumberDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Stores all the call numbers that are randomly generated
        /// </summary>
        private List<int> callNumberList = new List<int>();

        /// <summary>
        /// Stores the label's names along with their location on the user control
        /// </summary>
        private Dictionary<string, Point> labelLocationsDictionary = new Dictionary<string, Point>();

        /// <summary>
        /// Stores the lines drawn by the user
        /// </summary>
        private List<Line> linesList = new List<Line>();

        /// <summary>
        /// Stores the location of the label that is being dragged
        /// </summary>
        private Point sourceLabelLocation = new Point();

        /// <summary>
        /// Stores the location of the label that got dropped into
        /// </summary>
        private Point receiverLabelLocation = new Point();

        /// <summary>
        /// Stores the images used for the countdown of the game
        /// </summary>
        private PictureBox countdownPictureBox = new PictureBox();

        /// <summary>
        /// Stores the name of the panel that is currently getting dragged
        /// </summary>
        private string sourceLabelName;

        /// <summary>
        /// Stores if the user is currently matching call numbers to descriptions or the other way around
        /// </summary>
        private bool callNumbers = true;

        /// <summary>
        /// Stores the level the user is currently playing
        /// </summary>
        private string level = "casual";

        /// <summary>
        /// Stores the value that tells the code if the countdown must start or not
        /// </summary>
        private string countdown = "finish";

        /// <summary>
        /// Stores the current time the timer is on in the game
        /// </summary>
        private int elapsedTime = 0;

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the matchColumn form starts up
        /// Disconnects labels events, initializes labelLocationsDictionary, disables buttons, sets timer interval and draws lines for decoration
        /// </summary>

        #region MatchColumns

        public MatchColumnsUserControl()
        {
            InitializeComponent();

            // Initializing the labelLocationsDictionary with the source and receiver labels and their locations
            Point mainPanelLocation = pnlMainMatches.Location;

            for (int i = 0; i < 4; i++)
            {
                // Getting the location of the source label within the user control
                Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;

                Point labelLocation = new Point(
                    mainPanelLocation.X + sourceLabel.Location.X + 140,
                    mainPanelLocation.Y + sourceLabel.Location.Y + 30
                );

                // Adding the values to the locations dictionary
                labelLocationsDictionary.Add(sourceLabel.Name, labelLocation);

                // Disconnecting the labels from their events for exception handling
                sourceLabel.MouseDown -= SourceLabel_MouseDown;
                sourceLabel.DragEnter -= Label_DragEnter;
                sourceLabel.DragDrop -= Label_DragDrop;
            }

            for (int i = 0; i < 7; i++)
            {
                // Getting the location of the receiver label within the user control
                Label receiverLabel = Controls.Find($"lblReceiver{i + 1}", true).FirstOrDefault() as Label;

                Point labelLocation = new Point(
                    mainPanelLocation.X + receiverLabel.Location.X,
                    mainPanelLocation.Y + receiverLabel.Location.Y + 10
                );

                // Adding the values to the locations dictionary
                labelLocationsDictionary.Add(receiverLabel.Name, labelLocation);

                // Disconnecting the labels from their events for exception handling
                receiverLabel.MouseDown -= SourceLabel_MouseDown;
                receiverLabel.DragEnter -= Label_DragEnter;
                receiverLabel.DragDrop -= Label_DragDrop;
            }

            // Creating the decoration lines
            Line newLine1 = new Line(labelLocationsDictionary["lblSource1"], labelLocationsDictionary["lblReceiver4"], "lblSource1", "lblReceiver4");
            Line newLine2 = new Line(labelLocationsDictionary["lblSource2"], labelLocationsDictionary["lblReceiver7"], "lblSource2", "lblReceiver7");
            Line newLine3 = new Line(labelLocationsDictionary["lblSource3"], labelLocationsDictionary["lblReceiver2"], "lblSource3", "lblReceiver2");
            Line newLine4 = new Line(labelLocationsDictionary["lblSource4"], labelLocationsDictionary["lblReceiver5"], "lblSource4", "lblReceiver5");
            linesList.Add(newLine1);
            linesList.Add(newLine2);
            linesList.Add(newLine3);
            linesList.Add(newLine4);

            // Disabling the game buttons
            btnReset.Enabled = false;
            btnCheckMatches.Enabled = false;
            btnMatch.Enabled = false;
            btnCasual.Enabled = false;
            btnLevel1.Enabled = false;
            btnLevel2.Enabled = false;
            btnLevel3.Enabled = false;
            btnSwap.Enabled = false;
            lblTimer.Text = "";

            // Setting the timers interval to 1 second
            timerMatch.Interval = 1000;

            // Invalidating the main panel to trigger a repaint
            pnlMainMatches.Invalidate();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the generate button is clicked
        /// Generates new call numbers and stores them in a dictionary, re-connects labels events, sets the numbers and descriptions in panels and starts timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Generate_Button_Click

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Clearing all previous values
            callNumberDictionary.Clear();
            callNumberList.Clear();
            linesList.Clear();

            // Deleting the header label to not get in the way
            Label labelToDelete = Controls.Find($"lblHeader", true).FirstOrDefault() as Label;
            if (labelToDelete != null)
            {
                Controls.Remove(labelToDelete);
                labelToDelete.Dispose();
            }

            // Enabling the game buttons
            btnReset.Enabled = true;
            btnCheckMatches.Enabled = true;
            btnMatch.Enabled = true;
            btnCasual.Enabled = true;
            btnLevel1.Enabled = true;
            btnLevel2.Enabled = true;
            btnLevel3.Enabled = true;
            btnSwap.Enabled = true;

            // Class constructor for DictionaryValueGenerator class in the class library
            DictionaryValueGenerator dvg = new DictionaryValueGenerator(callNumberDictionary, callNumberList);
            dvg.GenerateCallNumber();

            /*
             * Shuffling the callNumbersList to display 4 random call numbers from the dictionary
             * The Enumerable.OrderBy method sorts the elements of a sequence using the specified comparer
             * This code was taken from Techie Delight at: https://www.techiedelight.com/randomize-a-list-in-csharp/
            */
            Random random = new Random();
            var shuffledCallNumbers = callNumberList.OrderBy(_ => random.Next()).ToList();

            // Randomly generating 4 out of 7 numbers to display for the correct answers
            List<int> sevenNumberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var shuffledNumbers = sevenNumberList.OrderBy(_ => random.Next()).ToList();

            // Checking if the user wants to match call numbers to descriptions or the other way around
            if (callNumbers)
            {
                // Setting the source label values with the shuffled call numbers
                for (int i = 0; i < 4; i++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;
                    sourceLabel.Text = shuffledCallNumbers[i].ToString("D3");

                    // Reconnecting the source labels with the events
                    sourceLabel.MouseDown += SourceLabel_MouseDown;
                    sourceLabel.DragEnter += Label_DragEnter;
                    sourceLabel.DragDrop += Label_DragDrop;
                }

                // Setting the correct receiver label values
                List<int> usedNumbersList = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{shuffledNumbers[i]}", true).FirstOrDefault() as Label;
                    usedNumbersList.Add(shuffledNumbers[i]);
                    receiverLabel.Text = callNumberDictionary[shuffledCallNumbers[i].ToString("D3")];

                    // Reconnecting the correct receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }

                // Creating a list to store the 3 numbers that were not used, to fill in the missing labels with the "incorrect" values
                var missingNumbers = sevenNumberList.Except(usedNumbersList).ToList();

                // Setting the incorrect receiver label values
                for (int i = 0; i < missingNumbers.Count; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{missingNumbers[i]}", true).FirstOrDefault() as Label;
                    receiverLabel.Text = callNumberDictionary[shuffledCallNumbers[i + 4].ToString("D3")];

                    // Reconnecting the incorrect receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }
            }
            else if (!callNumbers)
            {
                // Setting the source label values with the shuffled descriptions
                for (int i = 0; i < 4; i++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;
                    sourceLabel.Text = callNumberDictionary[shuffledCallNumbers[i].ToString("D3")];

                    // Reconnecting the source labels with the events
                    sourceLabel.MouseDown += SourceLabel_MouseDown;
                    sourceLabel.DragEnter += Label_DragEnter;
                    sourceLabel.DragDrop += Label_DragDrop;
                }

                // Setting the correct receiver label values
                List<int> usedNumbersList = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{shuffledNumbers[i]}", true).FirstOrDefault() as Label;
                    usedNumbersList.Add(shuffledNumbers[i]);
                    receiverLabel.Text = shuffledCallNumbers[i].ToString("D3");

                    // Reconnecting the correct receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }

                // Creating a list to store the 3 numbers that were not used, to fill in the missing labels with the "incorrect" values
                var missingNumbers = sevenNumberList.Except(usedNumbersList).ToList();

                // Setting the incorrect receiver label values
                for (int i = 0; i < missingNumbers.Count; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{missingNumbers[i]}", true).FirstOrDefault() as Label;
                    receiverLabel.Text = shuffledCallNumbers[i + 4].ToString("D3");

                    // Reconnecting the incorrect receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }
            }

            // Invalidating the main panel to trigger a repaint
            pnlMainMatches.Invalidate();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the reset button is clicked
        /// Clears the lines list and clears the lines drawn on the main panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Reset_Button_Click

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clearing the lines stored in the lines 
            linesList.Clear();

            // Clearing the lines drawn on the main panel
            pnlMainMatches.Invalidate();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the check button is clicked
        /// Checks how many of the lines drawn were matched correctly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Check_Button_Click

        private void btnCheckMatches_Click(object sender, EventArgs e)
        {
            // Running the correctMatches method to determine how many lines drawn were matched correctly
            int correctMatches = CheckMatches();

            if (level == "casual")
            {
                MessageBox.Show($"You have {correctMatches * 25}% correct matches.");
            }
            else if (level == "levelOne" || level == "levelTwo" || level == "levelThree")
            {
                if (correctMatches == 4 && level == "levelOne" || level == "levelTwo")
                {
                    MessageBox.Show($"Congratulations! You got {correctMatches * 25}% correct matches\nIn a time of {elapsedTime} seconds\n" +
                                     "Think you can give the next level a try?");
                }
                else if (correctMatches == 4 && level == "levelThree")
                {
                    MessageBox.Show($"Congratulations! You got {correctMatches * 25}% correct matches\nIn a time of {elapsedTime} seconds\n" +
                                     "You have now mastered the game! Well done, the application is proud of you.");
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the auto match button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region AutoMatch_Button_Click

        private void btnMatch_Click(object sender, EventArgs e)
        {
            // Clearing all the lines previously drawn by the user
            linesList.Clear();

            Point sourceLocation;
            Point receiverLocation;

            if (callNumbers)
            {
                // Finding the correct answers for the call numbers on the source label
                for (int i = 0; i < 4; i++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;

                    string callNumber = sourceLabel.Text;
                    string description = callNumberDictionary[callNumber];

                    for (int j = 0; j < 7; j++)
                    {
                        Label receiverLabel = Controls.Find($"lblReceiver{j + 1}", true).FirstOrDefault() as Label;
                        if (receiverLabel.Text == description)
                        {
                            foreach (var kvp in labelLocationsDictionary)
                            {
                                if (kvp.Key.Equals(receiverLabel.Name))
                                {
                                    receiverLocation = kvp.Value;
                                    sourceLocation = labelLocationsDictionary[sourceLabel.Name];

                                    // Creating a new line and adding it to the list
                                    Line newLine = new Line(sourceLocation, receiverLocation, sourceLabel.Name, receiverLabel.Name);
                                    linesList.Add(newLine);
                                }
                            }
                        }
                    }
                }
            }
            else if (!callNumbers)
            {
                // Finding the correct answers for the descriptions on the source label
                for (int i = 0; i < 4; i++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;

                    string description = sourceLabel.Text;
                    string callNumber = GetKeyFromValue(description);

                    for (int j = 0; j < 7; j++)
                    {
                        Label receiverLabel = Controls.Find($"lblReceiver{j + 1}", true).FirstOrDefault() as Label;
                        if (receiverLabel.Text == callNumber)
                        {
                            foreach (var kvp in labelLocationsDictionary)
                            {
                                if (kvp.Key.Equals(receiverLabel.Name))
                                {
                                    receiverLocation = kvp.Value;
                                    sourceLocation = labelLocationsDictionary[sourceLabel.Name];

                                    // Creating a new line and adding it to the list
                                    Line newLine = new Line(sourceLocation, receiverLocation, sourceLabel.Name, receiverLabel.Name);
                                    linesList.Add(newLine);
                                }
                            }
                        }
                    }
                }
            }

            // Invalidating the main panel to trigger a repaint
            pnlMainMatches.Invalidate();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the swap button is clicked
        /// Performs the same function as the generate button but just swaps the bool value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Swap_Button_Click

        private void btnSwap_Click(object sender, EventArgs e)
        {
            // Swapping the bool value
            if (callNumbers)
            {
                callNumbers = false;
            }
            else if (!callNumbers)
            {
                callNumbers = true;
            }

            // Clearing all previous values
            callNumberDictionary.Clear();
            callNumberList.Clear();
            linesList.Clear();

            // Class constructor for DictionaryValueGenerator class in the class library
            DictionaryValueGenerator dvg = new DictionaryValueGenerator(callNumberDictionary, callNumberList);
            dvg.GenerateCallNumber();

            /*
             * Shuffling the callNumbersList to display 4 random call numbers from the dictionary
             * The Enumerable.OrderBy method sorts the elements of a sequence using the specified comparer
             * This code was taken from Techie Delight at: https://www.techiedelight.com/randomize-a-list-in-csharp/
            */
            Random random = new Random();
            var shuffledCallNumbers = callNumberList.OrderBy(_ => random.Next()).ToList();

            // Randomly generating 4 out of 7 numbers to display for the correct answers
            List<int> sevenNumberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var shuffledNumbers = sevenNumberList.OrderBy(_ => random.Next()).ToList();

            // Checking if the user wants to match call numbers to descriptions or the other way around
            if (callNumbers)
            {
                // Setting the source label values with the shuffled call numbers
                for (int i = 0; i < 4; i++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;
                    sourceLabel.Text = shuffledCallNumbers[i].ToString("D3");

                    // Reconnecting the source labels with the events
                    sourceLabel.MouseDown += SourceLabel_MouseDown;
                    sourceLabel.DragEnter += Label_DragEnter;
                    sourceLabel.DragDrop += Label_DragDrop;
                }

                // Setting the correct receiver label values
                List<int> usedNumbersList = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{shuffledNumbers[i]}", true).FirstOrDefault() as Label;
                    usedNumbersList.Add(shuffledNumbers[i]);
                    receiverLabel.Text = callNumberDictionary[shuffledCallNumbers[i].ToString("D3")];

                    // Reconnecting the correct receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }

                // Creating a list to store the 3 numbers that were not used, to fill in the missing labels with the "incorrect" values
                var missingNumbers = sevenNumberList.Except(usedNumbersList).ToList();

                // Setting the incorrect receiver label values
                for (int i = 0; i < missingNumbers.Count; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{missingNumbers[i]}", true).FirstOrDefault() as Label;
                    receiverLabel.Text = callNumberDictionary[shuffledCallNumbers[i + 4].ToString("D3")];

                    // Reconnecting the incorrect receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }
            }
            else if (!callNumbers)
            {
                // Setting the source label values with the shuffled descriptions
                for (int i = 0; i < 4; i++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;
                    sourceLabel.Text = callNumberDictionary[shuffledCallNumbers[i].ToString("D3")];

                    // Reconnecting the source labels with the events
                    sourceLabel.MouseDown += SourceLabel_MouseDown;
                    sourceLabel.DragEnter += Label_DragEnter;
                    sourceLabel.DragDrop += Label_DragDrop;
                }

                // Setting the correct receiver label values
                List<int> usedNumbersList = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{shuffledNumbers[i]}", true).FirstOrDefault() as Label;
                    usedNumbersList.Add(shuffledNumbers[i]);
                    receiverLabel.Text = shuffledCallNumbers[i].ToString("D3");

                    // Reconnecting the correct receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }

                // Creating a list to store the 3 numbers that were not used, to fill in the missing labels with the "incorrect" values
                var missingNumbers = sevenNumberList.Except(usedNumbersList).ToList();

                // Setting the incorrect receiver label values
                for (int i = 0; i < missingNumbers.Count; i++)
                {
                    Label receiverLabel = Controls.Find($"lblReceiver{missingNumbers[i]}", true).FirstOrDefault() as Label;
                    receiverLabel.Text = shuffledCallNumbers[i + 4].ToString("D3");

                    // Reconnecting the incorrect receiver labels with the events
                    receiverLabel.MouseDown += SourceLabel_MouseDown;
                    receiverLabel.DragEnter += Label_DragEnter;
                    receiverLabel.DragDrop += Label_DragDrop;
                }
            }

            // Invalidating the main panel to trigger a repaint
            pnlMainMatches.Invalidate();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the casual button is clicked
        /// Hides timer label, turns timer off and generates a new list of call numbers and descriptions, 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Casual_Button_Click

        private void btnCasual_Click(object sender, EventArgs e)
        {
            lblTimer.Text = "";
            lblCurrentLevel.Text = "Current Level: Casual";
            level = "casual";
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the level one button is clicked
        /// Sets the timer to 20 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region LevelOne_Button_Click

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you wish to proceed to level 1?\n" +
                                                        "Please make sure you have read and understood the instructions before continuing",
                                                        "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                linesList.Clear();
                pnlMainMatches.Invalidate();

                level = "levelOne";
                countdown = "start";
                elapsedTime = 4;

                // Setting up the PictureBox properties when the user starts the countdown
                countdownPictureBox.Name = "pbCountdown";
                countdownPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                countdownPictureBox.Size = new Size(250, 300);
                countdownPictureBox.Location = new Point(230, 100);
                pnlMainMatches.Controls.Add(countdownPictureBox);
                countdownPictureBox.BringToFront();

                timerMatch.Start();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the level two button is clicked
        /// Sets the timer to 20 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region LevelTwo_Button_Click

        private void btnLevel2_Click(object sender, EventArgs e)
        {

        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the level three button is clicked
        /// Sets the timer to 20 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region LevelThree_Button_Click

        private void btnLevel3_Click(object sender, EventArgs e)
        {

        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Region that stores all the events for the labels
        /// Current events: MouseDown, DragEnter, DragDrop
        /// </summary>

        #region All_Label_Events

        /// <summary>
        /// Event that runs when the user clicks on a label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MouseDown_Event

        private void SourceLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Checking if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Starting a drag-and-drop operation with the source panel's Name
                Label sourceLabel = sender as Label;
                sourceLabelName = sourceLabel.Name;
                sourceLabel.DoDragDrop(sourceLabelName, DragDropEffects.Move);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when a dragged object enters the boundaries of another label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region DragEnter_Event

        private void Label_DragEnter(object sender, DragEventArgs e)
        {
            // Checking if the dragged data is of type string.
            if (e.Data.GetDataPresent(typeof(string)))
            {
                // Setting the effect to move, indicating a valid drop target.
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                // Setting the effect to none, indicating an invalid drop target.
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the label has been dragged and dropped into a receiver label
        /// Draws a line between the two labels, and checks if its correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region DragDrop_Event

        private void Label_DragDrop(object sender, DragEventArgs e)
        {
            // Stores the receiver label's name
            string receiverLabel;

            // Stores the source label's name
            string sourceLabel = sourceLabelName;

            // Attempt to cast the sender object as a Label
            Label getReceiverLabelName = sender as Label;

            if (getReceiverLabelName != null)
            {
                // Getting the name of the receiver label (the label the user dragged and dropped in)
                receiverLabel = getReceiverLabelName.Name;

                // Storing the locations of the source and receiver labels
                sourceLabelLocation = labelLocationsDictionary[sourceLabel];
                receiverLabelLocation = labelLocationsDictionary[receiverLabel];

                // Checking if a line from the source or receiver label already exists
                Line existingLine = linesList.FirstOrDefault(line => (line.sourceLabelName == sourceLabel) || (line.receiverLabelName == receiverLabel));

                if (existingLine != null)
                {
                    // Replace the old line with a new one
                    linesList.Remove(existingLine);
                }

                // Finding and removing any existing line associated with the source or receiver label (stops 2 lines matching with 1 label)
                RemoveExistingLine(sourceLabel);
                RemoveExistingLine(receiverLabel);

                // Creating a new line and adding it to the list
                Line newLine = new Line(sourceLabelLocation, receiverLabelLocation, sourceLabel, receiverLabel);
                linesList.Add(newLine);

                // Invalidating the main panel to trigger a repaint
                pnlMainMatches.Invalidate();
            }
        }

        #endregion

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Draws all the lines stored in the linesList on the main panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MainPanel_Paint

        private void pnlMainMatches_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                foreach (var line in linesList)
                {
                    e.Graphics.DrawLine(pen, line.sourceLabelLocation, line.receiverLabelLocation);
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Removes all the lines connected to the source and receiver panel when a user draws a line
        /// </summary>
        /// <param name="labelName"></param>

        #region RemoveExistingLine_Method

        private void RemoveExistingLine(string labelName)
        {
            // Find and remove any lines associated with the given label
            var linesToRemove = linesList.Where(line => line.sourceLabelName == labelName || line.receiverLabelName == labelName).ToList();
            foreach (var lineToRemove in linesToRemove)
            {
                linesList.Remove(lineToRemove);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Checks how many of the connected lines drawn are correctly matched
        /// </summary>
        /// <returns></returns>

        #region CheckMatches_Method

        private int CheckMatches()
        {
            // Stores the amount of correctly matched lines
            int correctMatches = 0;

            foreach (Line line in linesList)
            {
                // Retrieving the source and receiver label that the line is connected to
                Label sourceLabel = Controls.Find($"{line.sourceLabelName}", true).FirstOrDefault() as Label;
                Label receiverLabel = Controls.Find($"{line.receiverLabelName}", true).FirstOrDefault() as Label;

                // Retrieving the first four letters of the receiver label's name
                // It is used to determine if the line was drawn from a source label or receiver label
                string receiverLabelName = receiverLabel.Name;
                string firstFourLetters = receiverLabelName.Substring(0, 4);

                if (callNumbers)
                {
                    // Code that runs if the line was drawn from a source label
                    if (firstFourLetters == "lblR")
                    {
                        string sourceCallNumber = sourceLabel.Text;
                        string receiverCallNumber = GetKeyFromValue(receiverLabel.Text);

                        if (sourceCallNumber == receiverCallNumber)
                        {
                            correctMatches++;
                        }
                    }
                    // Code that runs if the line was drawn from a receiver label
                    else if (firstFourLetters == "lblS")
                    {
                        string sourceCallNumber = receiverLabel.Text;
                        string receiverCallNumber = GetKeyFromValue(sourceLabel.Text);

                        if (sourceCallNumber == receiverCallNumber)
                        {
                            correctMatches++;
                        }
                    }
                }
                else if (!callNumbers)
                {
                    // Code that runs if the line was drawn from a receiver label
                    if (firstFourLetters == "lblS")
                    {
                        string sourceCallNumber = sourceLabel.Text;
                        string receiverCallNumber = GetKeyFromValue(receiverLabel.Text);

                        if (sourceCallNumber == receiverCallNumber)
                        {
                            correctMatches++;
                        }
                    }
                    // Code that runs if the line was drawn from a source label
                    else if (firstFourLetters == "lblR")
                    {
                        string sourceCallNumber = receiverLabel.Text;
                        string receiverCallNumber = GetKeyFromValue(sourceLabel.Text);

                        if (sourceCallNumber == receiverCallNumber)
                        {
                            correctMatches++;
                        }
                    }
                }
            }

            // Returns the amount of correctly matched lines
            return correctMatches;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets the key using the kvp.value 
        /// </summary>
        /// <param name="targetValue"></param>
        /// <returns></returns>

        #region GetKeyFromValue_Method

        private string GetKeyFromValue(string targetValue)
        {
            foreach (var kvp in callNumberDictionary)
            {
                if (kvp.Value == targetValue)
                {
                    // Returning the key associated with the target value
                    return kvp.Key;
                }
            }

            // If the value is not found, it returns null
            return null;
        }

        #endregion        

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the timer has ticked (every second in realtime)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region TimerMatch_Tick

        private void TimerMatch_Tick(object sender, EventArgs e)
        {
            if (countdown == "start")
            {
                elapsedTime--;

                using (SoundPlayer levelCountdown = new SoundPlayer(Properties.Resources.levelCountdown))
                {
                    if (elapsedTime == 3)
                    {
                        levelCountdown.Play();
                        countdownPictureBox.Image = Properties.Resources.threePhoto;
                    }
                    else if (elapsedTime == 2)
                    {
                        levelCountdown.Play();
                        countdownPictureBox.Image = Properties.Resources.twoPhoto;
                    }
                    if (elapsedTime == 1)
                    {
                        levelCountdown.Play();
                        countdownPictureBox.Image = Properties.Resources.onePhoto;
                    }
                    else if (elapsedTime == 0)
                    {
                        levelCountdown.Play();
                        pnlMainMatches.Controls.Remove(countdownPictureBox);
                        countdownPictureBox.Dispose();
                        timerMatch.Stop();
                        countdown = "finish";
                        LevelStarter();
                    }
                }
            }
            else if (countdown == "finish")
            {
                elapsedTime--;

                if (elapsedTime > 1)
                {
                    lblTimer.Text = $"Timer: {elapsedTime}" + " seconds";
                }
                if (elapsedTime == 1)
                {
                    lblTimer.Text = $"Timer: {elapsedTime}" + " second";
                }                
                if (elapsedTime == 0)
                {
                    timerMatch.Stop();
                    if (level == "levelOne")
                    {
                        using (SoundPlayer levelOneFail = new SoundPlayer(Properties.Resources.levelOneFail))
                        {
                            levelOneFail.Play();
                        }
                        MessageBox.Show("Fail! You did not manage to match the correct values in time.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (level == "levelTwo")
                    {
                        using (SoundPlayer levelTwoThreeFail = new SoundPlayer(Properties.Resources.levelTwoThreeFail))
                        {
                            levelTwoThreeFail.Play();
                        }
                        MessageBox.Show("Fail! You did not manage to match the correct values in time.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (level == "levelThree")
                    {
                        using (SoundPlayer levelTwoThreeFail = new SoundPlayer(Properties.Resources.levelTwoThreeFail))
                        {
                            levelTwoThreeFail.Play();
                        }
                        MessageBox.Show("Fail! You did not manage to match the correct values in time.\nI told you this level was difficult", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Checks what level the user has selected and starts it
        /// </summary>

        #region LevelStarter_Method

        private void LevelStarter()
        {
            lblCurrentLevel.Text = level;
            if (level == "levelOne")
            {
                lblCurrentLevel.Text = "Current Level: Level 1";
                elapsedTime = 20;
                timerMatch.Start();
            }
            else if (level == "levelTwo")
            {
                lblCurrentLevel.Text = "Current Level: Level 2";
                elapsedTime = 10;
                timerMatch.Start();
            }
            else if (level == "levelThree")
            {
                lblCurrentLevel.Text = "Current Level: Level 3";
                elapsedTime = 5;
                timerMatch.Start();
            }
        }

        #endregion
    }
}