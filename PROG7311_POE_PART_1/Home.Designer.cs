namespace PROG7311_POE_PART_1
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReplaceBooks = new System.Windows.Forms.Button();
            this.btnIdentifyAreas = new System.Windows.Forms.Button();
            this.btnFindCallNumbers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PROG7311_POE_PART_1.Properties.Resources.deweyHeader;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(229, -48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(432, 395);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnReplaceBooks
            // 
            this.btnReplaceBooks.BackColor = System.Drawing.Color.SandyBrown;
            this.btnReplaceBooks.BackgroundImage = global::PROG7311_POE_PART_1.Properties.Resources.bwReplaceBooksLogo;
            this.btnReplaceBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReplaceBooks.Location = new System.Drawing.Point(12, 290);
            this.btnReplaceBooks.Name = "btnReplaceBooks";
            this.btnReplaceBooks.Size = new System.Drawing.Size(232, 290);
            this.btnReplaceBooks.TabIndex = 1;
            this.btnReplaceBooks.UseVisualStyleBackColor = false;
            this.btnReplaceBooks.Click += new System.EventHandler(this.btnReplaceBooks_Click);
            this.btnReplaceBooks.MouseEnter += new System.EventHandler(this.btnReplaceBooks_MouseEnter);
            this.btnReplaceBooks.MouseLeave += new System.EventHandler(this.btnReplaceBooks_MouseLeave);
            // 
            // btnIdentifyAreas
            // 
            this.btnIdentifyAreas.BackgroundImage = global::PROG7311_POE_PART_1.Properties.Resources.bwIdentifyAreasLogo;
            this.btnIdentifyAreas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIdentifyAreas.Location = new System.Drawing.Point(336, 290);
            this.btnIdentifyAreas.Name = "btnIdentifyAreas";
            this.btnIdentifyAreas.Size = new System.Drawing.Size(232, 290);
            this.btnIdentifyAreas.TabIndex = 2;
            this.btnIdentifyAreas.UseVisualStyleBackColor = true;
            this.btnIdentifyAreas.Click += new System.EventHandler(this.btnIdentifyAreas_Click);
            this.btnIdentifyAreas.MouseEnter += new System.EventHandler(this.btnIdentifyAreas_MouseEnter);
            this.btnIdentifyAreas.MouseLeave += new System.EventHandler(this.btnIdentifyAreas_MouseLeave);
            // 
            // btnFindCallNumbers
            // 
            this.btnFindCallNumbers.BackgroundImage = global::PROG7311_POE_PART_1.Properties.Resources.bwFindCallNumbersLogo;
            this.btnFindCallNumbers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFindCallNumbers.Location = new System.Drawing.Point(645, 290);
            this.btnFindCallNumbers.Name = "btnFindCallNumbers";
            this.btnFindCallNumbers.Size = new System.Drawing.Size(232, 290);
            this.btnFindCallNumbers.TabIndex = 3;
            this.btnFindCallNumbers.UseVisualStyleBackColor = true;
            this.btnFindCallNumbers.Click += new System.EventHandler(this.btnFindCallNumbers_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PROG7311_POE_PART_1.Properties.Resources.deweyBackground;
            this.ClientSize = new System.Drawing.Size(889, 592);
            this.Controls.Add(this.btnFindCallNumbers);
            this.Controls.Add(this.btnIdentifyAreas);
            this.Controls.Add(this.btnReplaceBooks);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReplaceBooks;
        private System.Windows.Forms.Button btnIdentifyAreas;
        private System.Windows.Forms.Button btnFindCallNumbers;
    }
}