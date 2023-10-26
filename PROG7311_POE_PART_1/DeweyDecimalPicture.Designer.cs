namespace PROG7311_POE_PART_1
{
    partial class DeweyDecimalPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeweyDecimalPicture));
            this.deweyDecimalPictureUserControl1 = new PROG7311_POE_PART_1.DeweyDecimalPictureUserControl();
            this.SuspendLayout();
            // 
            // deweyDecimalPictureUserControl1
            // 
            this.deweyDecimalPictureUserControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deweyDecimalPictureUserControl1.BackgroundImage")));
            this.deweyDecimalPictureUserControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deweyDecimalPictureUserControl1.Location = new System.Drawing.Point(1, -2);
            this.deweyDecimalPictureUserControl1.Name = "deweyDecimalPictureUserControl1";
            this.deweyDecimalPictureUserControl1.Size = new System.Drawing.Size(1040, 765);
            this.deweyDecimalPictureUserControl1.TabIndex = 0;
            // 
            // DeweyDecimalPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 763);
            this.Controls.Add(this.deweyDecimalPictureUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DeweyDecimalPicture";
            this.Text = "DeweyDecimalPicture";
            this.ResumeLayout(false);

        }

        #endregion

        private DeweyDecimalPictureUserControl deweyDecimalPictureUserControl1;
    }
}