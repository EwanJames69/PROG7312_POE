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
    public partial class DeweyDecimalPictureUserControl : UserControl
    {
        public DeweyDecimalPictureUserControl()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event that runs when the continue button is clicked
        /// Takes the user back to the identify areas instructions page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Continue_Button_Click

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Hide();
            IdentifyAreasInstructions iai = new IdentifyAreasInstructions();
            iai.Show();
        }

        #endregion
    }
}
