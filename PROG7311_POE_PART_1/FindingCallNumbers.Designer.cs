namespace PROG7311_POE_PART_1
{
    partial class FindingCallNumbers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.findingCallNumbersUC1 = new PROG7311_POE_PART_1.UserControls.FindingCallNumbersUC();
            this.SuspendLayout();
            // 
            // findingCallNumbersUC1
            // 
            this.findingCallNumbersUC1.BackColor = System.Drawing.Color.BurlyWood;
            this.findingCallNumbersUC1.Location = new System.Drawing.Point(-1, 0);
            this.findingCallNumbersUC1.Name = "findingCallNumbersUC1";
            this.findingCallNumbersUC1.Size = new System.Drawing.Size(1046, 656);
            this.findingCallNumbersUC1.TabIndex = 0;
            // 
            // FindingCallNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 657);
            this.Controls.Add(this.findingCallNumbersUC1);
            this.Name = "FindingCallNumbers";
            this.Text = "FindingCallNumbers";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.FindingCallNumbersUC findingCallNumbersUC1;
    }
}