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
            this.lblTest = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.Location = new System.Drawing.Point(98, 87);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(601, 156);
            this.lblTest.TabIndex = 0;
            this.lblTest.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FindingCallNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTest);
            this.Name = "FindingCallNumbers";
            this.Text = "FindingCallNumbers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button button1;
    }
}