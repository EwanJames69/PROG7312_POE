namespace PROG7311_POE_PART_1
{
    partial class IdentifyAreasInstructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentifyAreasInstructions));
            this.identifyAreasInstructionsUserControlcs1 = new PROG7311_POE_PART_1.IdentifyAreasInstructionsUserControlcs();
            this.SuspendLayout();
            // 
            // identifyAreasInstructionsUserControlcs1
            // 
            this.identifyAreasInstructionsUserControlcs1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("identifyAreasInstructionsUserControlcs1.BackgroundImage")));
            this.identifyAreasInstructionsUserControlcs1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.identifyAreasInstructionsUserControlcs1.Location = new System.Drawing.Point(1, 0);
            this.identifyAreasInstructionsUserControlcs1.Name = "identifyAreasInstructionsUserControlcs1";
            this.identifyAreasInstructionsUserControlcs1.Size = new System.Drawing.Size(654, 658);
            this.identifyAreasInstructionsUserControlcs1.TabIndex = 0;
            // 
            // IdentifyAreasInstructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 656);
            this.Controls.Add(this.identifyAreasInstructionsUserControlcs1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IdentifyAreasInstructions";
            this.Text = "IdentifyAreasInstructions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IdentifyAreas_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private IdentifyAreasInstructionsUserControlcs identifyAreasInstructionsUserControlcs1;
    }
}