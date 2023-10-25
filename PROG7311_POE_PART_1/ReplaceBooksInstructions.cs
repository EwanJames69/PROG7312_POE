using System;
using System.Windows.Forms;

namespace PROG7311_POE_PART_1
{
    public partial class ReplaceBooksInstructions : Form
    {
        public ReplaceBooksInstructions()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------------------------/

        /// <summary>
        /// This event runs when btnContinue is clicked, and it takes the user back to the replaceBooks form
        /// Takes the user back to the ReplaceBooksForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region Continue_Button_Click

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ReplaceBooks replaceBooks = new ReplaceBooks();
            replaceBooks.Show();
            Hide();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------/

        /// <summary>
        /// FormClosing event double checks if the user wants to exit the application, this event is present in all forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region Form_Closing  

        private void ReplaceBooksInstructions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
