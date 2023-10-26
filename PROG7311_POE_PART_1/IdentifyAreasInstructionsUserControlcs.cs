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
    public partial class IdentifyAreasInstructionsUserControlcs : UserControl
    {
        public IdentifyAreasInstructionsUserControlcs()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the view image button is clicked
        /// Takes the user to the dewey decimal image form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region ViewImage_Button_Click

        private void btnViewImage_Click(object sender, EventArgs e)
        {
            DeweyDecimalPicture ddp = new DeweyDecimalPicture();
            ddp.Show();
            Form thisForm = this.FindForm();
            thisForm.Hide();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the view image button is clicked
        /// Takes the user to the dewey decimal image form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Back_Button_Click

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form thisForm = this.FindForm();
            thisForm.Hide();
            MainForm mf = new MainForm();
            mf.Show();
        }

        #endregion
    }
}
