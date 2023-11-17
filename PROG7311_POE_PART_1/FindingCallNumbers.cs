using DeweyDecimalClassLibrary;
using Microsoft.VisualBasic.FileIO;
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

namespace PROG7311_POE_PART_1
{
    public partial class FindingCallNumbers : Form
    {
        public FindingCallNumbers()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// FormClosing event exits the application, this event is present in all forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Form_Closing

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}