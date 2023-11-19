using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7311_POE_PART_1
{
    public partial class FindCallNumbersInstructions : Form
    {
        public FindCallNumbersInstructions()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Runs when the back button is clicked
        /// Takes the user back to the find call numbers game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Back_Button_Click

        private void btnBack_Click(object sender, EventArgs e)
        {
            FindingCallNumbers fcn = new FindingCallNumbers();
            fcn.Show();
            Hide();
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