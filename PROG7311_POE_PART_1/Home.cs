using System;
using System.Windows.Forms;

namespace PROG7311_POE_PART_1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the replaceBooks button is clicked
        /// Takes the user to the replace books game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region ReplaceBooks_Button_Click

        private void btnReplaceBooks_Click(object sender, EventArgs e)
        {
            Hide();
            ReplaceBooks replaceBooksForm = new ReplaceBooks();
            replaceBooksForm.Show();
        }

        #endregion        

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the identifyAreas button is clicked
        /// Takes the user to the identify areas game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region IdentifyAreas_Button_Click

        private void btnIdentifyAreas_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();            
        }

        #endregion        

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the findCallNumbers button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindCallNumbers_Click(object sender, EventArgs e)
        {
            Hide();
            FindingCallNumbers findingCallNumbers = new FindingCallNumbers();
            findingCallNumbers.Show();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        #region Replace_Books_Events

        /// <summary>
        /// Event that runs when the mouse hovers over the replace books game
        /// The image turns from black and white to color to give it a more game-like effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MouseEnter

        private void btnReplaceBooks_MouseEnter(object sender, EventArgs e)
        {
            // Making the background image colorful
            btnReplaceBooks.BackgroundImage = Properties.Resources.replaceBooksLogo;            
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the mouse leaves the replace books games area
        /// The image turns from colorful back to black and white
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MouseLeave        

        private void btnReplaceBooks_MouseLeave(object sender, EventArgs e)
        {
            // Making the background image black and white
            btnReplaceBooks.BackgroundImage = Properties.Resources.bwReplaceBooksLogo;
        }

        #endregion

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        #region Identify_Areas_Events

        /// <summary>
        /// Event that runs when the mouse hovers over the identify areas game
        /// The image turns from black and white to color to give it a more game-like effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MouseEnter

        private void btnIdentifyAreas_MouseEnter(object sender, EventArgs e)
        {
            // Making the background image colorful
            btnIdentifyAreas.BackgroundImage = Properties.Resources.identifyAreasLogo;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the mouse leaves the identify areas games area
        /// The image turns from colorful back to black and white
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region MouseLeave        

        private void btnIdentifyAreas_MouseLeave(object sender, EventArgs e)
        {
            // Making the background image black and white
            btnIdentifyAreas.BackgroundImage = Properties.Resources.bwIdentifyAreasLogo;
        }

        #endregion

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// FormClosing event double checks if the user wants to exit the application, this event is present in all forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region FormClosing

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion        
    }
}
