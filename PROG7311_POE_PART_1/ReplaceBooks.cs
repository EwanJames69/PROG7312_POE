using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace PROG7311_POE_PART_1
{
    public partial class ReplaceBooks : Form
    {
        /// <summary>
        /// Stores the current call numbers of the books as they are generated
        /// </summary>
        private List<string> currentCallNumbers = new List<string>();

        /// <summary>
        /// Stores the correctly sorted call numbers out of the call numbers that are currently on the books
        /// </summary>
        private List<string> sortedCallNumbers = new List<string>();

        /// <summary>
        /// Stores the background images of the books
        /// </summary>
        List<Image> backgroundImageList = new List<Image>();

        /// <summary>
        /// Stores the name of the panel that is currently getting dragged
        /// </summary>
        private string sourcePanelName;

        /// <summary>
        /// Stores the current time the timer is on in the game
        /// </summary>
        private int elapsedTime = 0;

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the replaceBooks form starts up
        /// Initializes backgroundImage list, changes source panel values, disables buttons and sets timer interval
        /// </summary>
        
        #region ReplaceBooks

        public ReplaceBooks()
        {
            InitializeComponent();

            // Clearing all the current images stored in the list
            backgroundImageList.Clear();

            // Initializing the list with background images for the book panels
            backgroundImageList.Add(Properties.Resources.bookRed);
            backgroundImageList.Add(Properties.Resources.bookOrange);
            backgroundImageList.Add(Properties.Resources.bookYellow);
            backgroundImageList.Add(Properties.Resources.bookGreen);
            backgroundImageList.Add(Properties.Resources.bookBlue);
            backgroundImageList.Add(Properties.Resources.bookPink);
            backgroundImageList.Add(Properties.Resources.bookPurple);
            backgroundImageList.Add(Properties.Resources.bookBrown);
            backgroundImageList.Add(Properties.Resources.bookGrey);
            backgroundImageList.Add(Properties.Resources.bookBlack);

            // Disconnecting the panels from all the events for exception handling
            for (int i = 1; i <= 10; i++)
            {
                Panel sourcePanel = Controls.Find($"pnlSource{i}", true).FirstOrDefault() as Panel;
                Label sourceLabel = Controls.Find($"lblSource{i}", true).FirstOrDefault() as Label;
                sourceLabel.Font = new Font(sourceLabel.Font, FontStyle.Bold);
                sourcePanel.MouseDown -= SourcePanel_MouseDown;
                sourcePanel.DragEnter -= pnlItems_DragEnter;
                sourcePanel.DragDrop -= pnlItems_DragDrop;
            }

            // Disabling the sort and reset buttons
            btnSort.Enabled = false;
            btnReset.Enabled = false;

            // Setting the timers interval to 1 second
            timer1.Interval = 1000;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the generate button is clicked
        /// Generates new call numbers and stores them and sorted version in lists, sets source panels values and starts timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region Generate_Button_Click

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Clearing the lists previous values
            currentCallNumbers.Clear();
            sortedCallNumbers.Clear();

            // Enabling the sort and reset buttons
            btnSort.Enabled = true;
            btnReset.Enabled = true;

            // Setting the timers time back to 0 seconds
            elapsedTime = 0;

            lblProgressTracker.Text = "Goodluck!";

            // For loop used to iterate through all the panels
            for (int i = 1; i <= 10; i++)
            {
                // Clearing the previous values from the source panel and label
                Label sourceLabel = Controls.Find($"lblSource{i}", true).FirstOrDefault() as Label;
                Panel sourcePanel = Controls.Find($"pnlSource{i}", true).FirstOrDefault() as Panel;
                sourceLabel.Text = "";
                sourceLabel.BackColor = Color.SandyBrown;
                sourcePanel.BackgroundImage = null;
                sourcePanel.MouseDown -= SourcePanel_MouseDown;
                sourcePanel.DragEnter -= pnlItems_DragEnter;
                sourcePanel.DragDrop -= pnlItems_DragDrop;

                // Removing the previous values of the receiver labels
                Label receiverLabel = Controls.Find($"lblReceiver{i}", true).FirstOrDefault() as Label;
                receiverLabel.Text = "";
                receiverLabel.BackColor = Color.SandyBrown;

                // Generating a random call number
                // Uses a format specifier (D3 and D2) to make sure it follows the format "XXX.YY AAA" as it adds leading zeros to the number if necessary
                string callNumber = $"{random.Next(1, 1000):D3}.{random.Next(1, 100):D2} {(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";

                // Setting the back color and font of the source labels
                sourceLabel.BackColor = Color.White;
                sourceLabel.Font = new Font(sourceLabel.Font, FontStyle.Regular);

                if (sourceLabel != null)
                {
                    // Setting the labels text to the generated call number
                    sourceLabel.Text = callNumber;
                }

                // Storing the generated call number in the currentCallNumbers list
                currentCallNumbers.Add(callNumber);
            }

            /*
             *  Storing the sorted call numbers in a list for comparison             
             *  (cn => cn) is a lambda expression that serves as the sorting key. It defines how the elements in the list should be evaluated for sorting. 
             *  In this case, cn is a parameter that represents each element in the list, and cn => cn essentially means "sort the elements based on themselves."
             *  In other words, it's sorting the elements in their natural order (lexicographical order for strings)
             *  This code was constructed with help of GeeksforGeeks at: https://www.geeksforgeeks.org/lambda-expressions-in-c-sharp/
            */
            sortedCallNumbers = currentCallNumbers.OrderBy(cn => cn).ToList();

            // For loop to iterate through all the panels
            for(int i = 1; i <= 10; i++)
            {
                Panel sourcePanel = Controls.Find($"pnlSource{i}", true).FirstOrDefault() as Panel;
                Panel receiverPanel = Controls.Find($"pnlReceiver{i}", true).FirstOrDefault() as Panel;

                // Resetting all the panels back to its original state to essentially "restart the game"
                sourcePanel.BackgroundImage = backgroundImageList[i - 1];
                sourcePanel.MouseDown += SourcePanel_MouseDown;
                sourcePanel.DragEnter += pnlItems_DragEnter;
                sourcePanel.DragDrop += pnlItems_DragDrop;

                // Clearing all the previous values in the receiver panels
                receiverPanel.BackgroundImage = null;
                receiverPanel.Tag = null;
            }
            // Updating the progress bar
            UpdateProgressBar();

            // Checking if the timers check box is checked
            if (chkTimer.Checked)
            {
                // If checked, the timer starts
                timer1.Start();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the reset button is clicked
        /// Returns all books back to its original location from when the game started while the timer keeps running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Reset_Button_Click

        private void btnReset_Click(object sender, EventArgs e)
        {
            // For loop to iterate through the receiver panels and labels
            for (int x = 1; x <= 10; x++)
            {
                Panel receiverPanel = Controls.Find($"pnlReceiver{x}", true).FirstOrDefault() as Panel;
                if (receiverPanel.BackgroundImage != null)
                {
                    // For loop to iterate through the currentCallNumbers list for comparison
                    for (int i = 0; i < currentCallNumbers.Count; i++)
                    {
                        // Checking which book is currently in the receiver panel and storing its details
                        if (receiverPanel != null && receiverPanel.Tag != null && receiverPanel.Tag.Equals(backgroundImageList[i]))
                        {
                            // Declaring source panel and label of the book as the backgroundImage list and the source panels act similar to parallel arrays
                            Panel sourcePanel = Controls.Find($"pnlSource{i + 1}", true).FirstOrDefault() as Panel;
                            Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;
                            Label receiverLabel = Controls.Find($"lblReceiver{x}", true).FirstOrDefault() as Label;

                            // Returning the book and its values back to its original source panel and label
                            sourceLabel.Text = currentCallNumbers[i];
                            sourceLabel.BackColor = Color.White;
                            sourcePanel.BackgroundImage = backgroundImageList[i];
                            sourcePanel.MouseDown += SourcePanel_MouseDown;
                            sourcePanel.DragEnter += pnlItems_DragEnter;
                            sourcePanel.DragDrop += pnlItems_DragDrop;

                            // Clearing out the values of the receiver panel and label
                            receiverPanel.BackgroundImage = null;
                            receiverPanel.Tag = null;
                            receiverLabel.Text = "";
                            receiverLabel.BackColor = Color.SandyBrown;
                        }
                    }
                }
            }
            // Updating the progress bar
            UpdateProgressBar();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the sort button is clicked
        /// Returns the books back to its original panel, then sorts them in their respective recevier panels (no applause sound) and stops timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Sort_Button_Click

        private void btnSort_Click(object sender, EventArgs e)
        {
            // For loop to iterate through the receiver panels and labels
            for (int x = 1; x <= 10; x++)
            {
                Panel receiverPanel = Controls.Find($"pnlReceiver{x}", true).FirstOrDefault() as Panel;
                if (receiverPanel.BackgroundImage != null)
                {
                    // For loop to iterate through the currentCallNumbers list for comparison
                    for (int i = 0; i < currentCallNumbers.Count; i++)
                    {
                        // Checking which book is currently in the receiver panel and storing its details
                        if (receiverPanel != null && receiverPanel.Tag != null && receiverPanel.Tag.Equals(backgroundImageList[i]))
                        {
                            // Declaring source panel and label of the book as the backgroundImage list and the source panels act similar to parallel arrays
                            Panel sourcePanel = Controls.Find($"pnlSource{i + 1}", true).FirstOrDefault() as Panel;
                            Label sourceLabel = Controls.Find($"lblSource{i + 1}", true).FirstOrDefault() as Label;
                            Label receiverLabel = Controls.Find($"lblReceiver{x}", true).FirstOrDefault() as Label;

                            // Returning the book and its values back to its original source panel and label
                            sourceLabel.Text = currentCallNumbers[i];
                            sourceLabel.BackColor = Color.White;
                            sourcePanel.BackgroundImage = backgroundImageList[i];
                            sourcePanel.MouseDown -= SourcePanel_MouseDown;
                            sourcePanel.DragEnter -= pnlItems_DragEnter;
                            sourcePanel.DragDrop -= pnlItems_DragDrop;

                            // Clearing out the values of the receiver panel and label
                            receiverPanel.BackgroundImage = null;
                            receiverPanel.Tag = null;
                            receiverLabel.Text = "";
                            receiverLabel.BackColor = Color.SandyBrown;
                        }
                    }
                }
            }            

            // For loop to iterate through the sortedCallNumbers list and place them in each panel (left to right)
            for (int i = 0; i < sortedCallNumbers.Count; i++)
            {
                // For loop to iterate through the panels and labels
                for (int x = 1; x <= 10; x++)
                {
                    Label sourceLabel = Controls.Find($"lblSource{x}", true).FirstOrDefault() as Label;
                    // Checking which index in the sortedCallNumbers the book's label equals to, then moving the values into its respective receiver panel
                    if (sourceLabel.Text.Equals(sortedCallNumbers[i]))
                    {
                        Panel sourcePanel = Controls.Find($"pnlSource{x}", true).FirstOrDefault() as Panel;
                        Panel receiverPanel = Controls.Find($"pnlReceiver{i + 1}", true).FirstOrDefault() as Panel;
                        Label receiverLabel = Controls.Find($"lblReceiver{i + 1}", true).FirstOrDefault() as Label;

                        // Setting the values of the respective receiver panel
                        receiverLabel.Text = sortedCallNumbers[i];
                        receiverLabel.BackColor = Color.White;
                        receiverPanel.Tag = backgroundImageList[i];
                        receiverPanel.BackgroundImage = sourcePanel.BackgroundImage;

                        // Clearing the values of the source panel and label and disconnecting the events from the source panel
                        sourceLabel.Text = "";
                        sourceLabel.BackColor = Color.SandyBrown;
                        sourcePanel.BackgroundImage = null;
                        sourcePanel.MouseDown -= SourcePanel_MouseDown;
                        sourcePanel.DragEnter -= pnlItems_DragEnter;
                        sourcePanel.DragDrop -= pnlItems_DragDrop;
                    }
                }           
            }
            // Setting the progress bars value to 100% without playing the "applause" sound
            progressBar.Value = 100;

            // Setting the timer back to 0 seconds
            lblTimer.Text = "0 seconds";
            MessageBox.Show("The books have been sorted in the right order.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Hide();
            }            
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the instructions button is clicked
        /// Takes the user to the instructions form for the replace books game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region Instructions_Button_Click

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            ReplaceBooksInstructions rbi = new ReplaceBooksInstructions();
            rbi.Show();
            Hide();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Updates the progress bars value and changes the progress label depending on percentage of progress bar
        /// </summary>
        /// <returns></returns>

        #region Update_Progress_Bar Method

        private void UpdateProgressBar()
        {
            // Runs the CalculatePercentageCorrectlySorted() method to calculate the amount of placed books are correct
            double percentageCorrect = CalculatePercentageCorrectlySorted();

            // Setting the progress bars value to the calculated amount
            progressBar.Value = (int)percentageCorrect;

            // If loops to change the progress label's text depending on the progress bar's value
            if(percentageCorrect >= 25 && percentageCorrect < 50)
            {
                lblProgressTracker.Text = "Getting The Hang Of It!";
            }
            else if(percentageCorrect >= 50 && percentageCorrect < 75)
            {
                lblProgressTracker.Text = "Halfway There!";
            }
            else if(percentageCorrect >= 75 && percentageCorrect < 100)
            {
                lblProgressTracker.Text = "Almost There!";
            }
            else if (percentageCorrect == 100 && !chkTimer.Checked)
            {
                lblProgressTracker.Text = "Well Done!";

                // Playing the applause sound for the user manually reaching 100% on the progress bar
                // This sound was taken by https://www.wavsource.com/sfx/sfx.htm
                using (SoundPlayer applause = new SoundPlayer(Properties.Resources.applause))
                {
                    applause.Play();
                }
                MessageBox.Show("Congratulations! You sorted all call numbers correctly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
            else if(percentageCorrect == 100 && chkTimer.Checked)
            {
                lblProgressTracker.Text = "Well Done!";

                // Playing the applause sound for the user manually reaching 100% on the progress bar
                // This sound was taken by https://www.wavsource.com/sfx/sfx.htm
                using (SoundPlayer applause = new SoundPlayer(Properties.Resources.applause))
                {
                    applause.Play();
                }
                // Showing the amount of time taken by the user to sort the books in the correct order
                MessageBox.Show("Congratulations! You sorted all call numbers correctly.\n" +
                                $"Time taken: {elapsedTime} seconds", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Resetting the timers label
                lblTimer.Text = "0 seconds";
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        #region All_Panel_Events

        /// <summary>
        /// Event that runs when the panel has been dragged and dropped into a receiver panel
        /// Finds out what the source and receiver panels/labels are and carries over the values 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region DragDrop_Event

        private void pnlItems_DragDrop(object sender, DragEventArgs e)
        {
            // Stores the retreiver panel's name
            string targetPanelName;

            // Stores the source panel's name
            string panelSourceName = sourcePanelName;

            // Attempt to cast the sender object as a Panel
            Panel targetPanel = sender as Panel;

            if (targetPanel != null)
            {
                // Getting the name of the receiver panel
                targetPanelName = targetPanel.Name;

                // Stores the last letter of the receiver panels name, which is a number (to be used as an index)
                int receiverLastIndex = targetPanelName.Length - 1;

                // Finding the index of the last digit in the target panel's name
                while (receiverLastIndex >= 0 && Char.IsDigit(targetPanelName[receiverLastIndex]))
                {
                    receiverLastIndex--;
                }

                // storing the number from the retreiver panel's name
                string receiverNumberPart = targetPanelName.Substring(receiverLastIndex + 1);

                if (int.TryParse(receiverNumberPart, out int receiverPanelNumber))
                {
                    Panel receiverPanel = Controls.Find($"pnlReceiver{receiverPanelNumber}", true).FirstOrDefault() as Panel;
                    Panel draggedSourcePanel = Controls.Find(panelSourceName, true).FirstOrDefault() as Panel;
                    Label receiverLabel = Controls.Find($"lblReceiver{receiverPanelNumber}", true).FirstOrDefault() as Label;

                    // Chekcing if the receiver panel already has a book inside
                    if (receiverPanel.BackgroundImage != null)
                    {
                        // For loop to iterate through the backgroundImage List
                        for (int i = 1; i <= 10; i++)
                        {
                            // Using the receiver panel tag to check which book is already inside the receiver panel
                            if (receiverPanel.Tag.Equals(backgroundImageList[i - 1]))
                            {
                                // Declaring which source panel and label it came from
                                Panel sourcePanel = Controls.Find($"pnlSource{i}", true).FirstOrDefault() as Panel;
                                Label sourceLabel = Controls.Find($"lblSource{i}", true).FirstOrDefault() as Label;

                                // Returning the book back to its original panel
                                sourceLabel.Text = currentCallNumbers[i - 1];
                                sourceLabel.BackColor = Color.White;
                                sourcePanel.BackgroundImage = backgroundImageList[i - 1];
                                sourcePanel.MouseDown += SourcePanel_MouseDown;
                                sourcePanel.DragEnter += pnlItems_DragEnter;
                                sourcePanel.DragDrop += pnlItems_DragDrop;
                            }
                        }
                    }
                    // For loop to iterate through the backgroundImage List
                    for (int i = 1; i <= 10; i++)
                    {
                        // Checking if draggedSourcePanel and its BackgroundImage are not null
                        if (draggedSourcePanel != null && draggedSourcePanel.BackgroundImage != null)
                        {
                            // Checking which book has been dragged and using that index
                            if (draggedSourcePanel.BackgroundImage.Equals(backgroundImageList[i - 1]))
                            {
                                Label sourceLabel = Controls.Find($"lblSource{i}", true).FirstOrDefault() as Label;

                                // Saving the values to the receiver panel and label
                                receiverLabel.Text = currentCallNumbers[i - 1];
                                receiverLabel.BackColor = Color.White;
                                receiverPanel.Tag = backgroundImageList[i - 1]; // Setting the tag to the background it has receieved
                                receiverPanel.BackgroundImage = backgroundImageList[i - 1];

                                // Clearing the values from the source panel and label
                                sourceLabel.Text = "";
                                sourceLabel.BackColor = Color.SandyBrown;
                                draggedSourcePanel.BackgroundImage = null;                                
                                draggedSourcePanel.MouseDown -= SourcePanel_MouseDown;
                                draggedSourcePanel.DragEnter -= pnlItems_DragEnter;
                                draggedSourcePanel.DragDrop -= pnlItems_DragDrop;
                            }
                        }
                    }
                }
            }
            // Updating the progress bar
            UpdateProgressBar();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when a dragged object enters the boundaries of a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region DragEnter_Event

        private void pnlItems_DragEnter(object sender, DragEventArgs e)
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
        /// Event that runs when the user clicks on a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region MouseDown_Event

        private void SourcePanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Checking if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Starting a drag-and-drop operation with the source panels Name
                Panel sourcePanel = sender as Panel;
                sourcePanelName = sourcePanel.Name; // Setting the class variable to store the source panels name
                sourcePanel.DoDragDrop(sourcePanelName, DragDropEffects.Move);
            }
        }

        #endregion

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//        

        /// <summary>
        /// Method to calculate the correct percentage to display on the progress bar after every move
        /// </summary>
        /// <returns></returns>

        #region Calculate_Percentage_Correctly_Sorted Method

        private double CalculatePercentageCorrectlySorted()
        {
            // Storing the total amount of call numbers (always 10 unless changed in future)
            int totalCallNumbers = currentCallNumbers.Count;

            // Setting the already coreectly sorted amount of books to 0
            int correctlySorted = 0;

            if (currentCallNumbers != null && sortedCallNumbers.Count == totalCallNumbers)
            {
                // For loop to iterate through the totalCallNumbers amount and use it as an index
                for (int i = 0; i < totalCallNumbers; i++)
                {
                    // Retreiving the recevier label to compare it to the sortedCallNumbers list
                    Label receiverLabel = Controls.Find($"lblReceiver{i + 1}", true).FirstOrDefault() as Label;

                    // Checking if the receiver label equals to the corresponding sorted number in the sortedCallNumbers list
                    if (receiverLabel.Text.Equals(sortedCallNumbers[i]))
                    {
                        // Incrementing correctlySorted if the receiver label and sorted number matches
                        correctlySorted++;
                    }
                }
            }
            // Returning a calculation which retrieves the average of the correctly sorted amount of books
            return (double)correctlySorted / totalCallNumbers * 100.0;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the timer check box has changed (ticked or unticked)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region TimerCheck_Changed

        private void chkTimer_CheckedChanged(object sender, EventArgs e)
        {
            // Checking if the checkbox is checked or not
            if (chkTimer.Checked)
            {
                // Making the timer label visible to the user
                lblTimer.Text = "0 seconds";
            }
            else if (!chkTimer.Checked)
            {
                // Hiding the timer label from the user
                lblTimer.Text = "";
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the timer has ticked (every second in realtime)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Timer1_Tick

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Incrementing the elapsedTime variable to display the amount of seconds the user has been sorting books
            if (progressBar.Value < 100)
            {
                elapsedTime++;
                if (elapsedTime == 1)
                {
                    lblTimer.Text = $"{elapsedTime} second";
                }
                else
                {
                    lblTimer.Text = $"{elapsedTime} seconds";
                }
            }
            else
            {
                // Stopping the timer once the user has reached 100% on the progress bar
                timer1.Stop();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// FormClosing event double checks if the user wants to exit the application, this event is present in all forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Form_Closing

        private void ReplaceBooks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion             
    }
}