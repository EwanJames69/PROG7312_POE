namespace PROG7311_POE_PART_1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.matchColumnsUserControl1 = new PROG7311_POE_PART_1.MatchColumnsUserControl();
            this.SuspendLayout();
            // 
            // matchColumnsUserControl1
            // 
            this.matchColumnsUserControl1.BackColor = System.Drawing.Color.DimGray;
            this.matchColumnsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.matchColumnsUserControl1.Name = "matchColumnsUserControl1";
            this.matchColumnsUserControl1.Size = new System.Drawing.Size(966, 770);
            this.matchColumnsUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 770);
            this.Controls.Add(this.matchColumnsUserControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Match The Boxes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MatchColumnsUserControl matchColumnsUserControl1;
    }
}