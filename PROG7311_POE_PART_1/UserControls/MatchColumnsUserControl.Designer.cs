namespace PROG7311_POE_PART_1
{
    partial class MatchColumnsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnInstructionsMatch = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.pnlMainMatches = new System.Windows.Forms.Panel();
            this.lblReceiver7 = new System.Windows.Forms.Label();
            this.lblReceiver6 = new System.Windows.Forms.Label();
            this.lblReceiver5 = new System.Windows.Forms.Label();
            this.lblReceiver4 = new System.Windows.Forms.Label();
            this.lblReceiver3 = new System.Windows.Forms.Label();
            this.lblReceiver2 = new System.Windows.Forms.Label();
            this.lblReceiver1 = new System.Windows.Forms.Label();
            this.lblSource4 = new System.Windows.Forms.Label();
            this.lblSource3 = new System.Windows.Forms.Label();
            this.lblSource2 = new System.Windows.Forms.Label();
            this.lblSource1 = new System.Windows.Forms.Label();
            this.btnCheckMatches = new System.Windows.Forms.Button();
            this.btnCasual = new System.Windows.Forms.Button();
            this.btnLevel1 = new System.Windows.Forms.Button();
            this.btnLevel2 = new System.Windows.Forms.Button();
            this.btnLevel3 = new System.Windows.Forms.Button();
            this.timerMatch = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblCurrentLevel = new System.Windows.Forms.Label();
            this.pnlMainMatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 720);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(124, 40);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(157, 720);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 40);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(442, 720);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(124, 40);
            this.btnMatch.TabIndex = 9;
            this.btnMatch.Text = "Auto Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnInstructionsMatch
            // 
            this.btnInstructionsMatch.Location = new System.Drawing.Point(824, 720);
            this.btnInstructionsMatch.Name = "btnInstructionsMatch";
            this.btnInstructionsMatch.Size = new System.Drawing.Size(124, 40);
            this.btnInstructionsMatch.TabIndex = 10;
            this.btnInstructionsMatch.Text = "Instructions";
            this.btnInstructionsMatch.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(684, 720);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(124, 40);
            this.btnMainMenu.TabIndex = 12;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            // 
            // pnlMainMatches
            // 
            this.pnlMainMatches.BackColor = System.Drawing.Color.Khaki;
            this.pnlMainMatches.Controls.Add(this.lblReceiver7);
            this.pnlMainMatches.Controls.Add(this.lblReceiver6);
            this.pnlMainMatches.Controls.Add(this.lblReceiver5);
            this.pnlMainMatches.Controls.Add(this.lblReceiver4);
            this.pnlMainMatches.Controls.Add(this.lblReceiver3);
            this.pnlMainMatches.Controls.Add(this.lblReceiver2);
            this.pnlMainMatches.Controls.Add(this.lblReceiver1);
            this.pnlMainMatches.Controls.Add(this.lblSource4);
            this.pnlMainMatches.Controls.Add(this.lblSource3);
            this.pnlMainMatches.Controls.Add(this.lblSource2);
            this.pnlMainMatches.Controls.Add(this.lblSource1);
            this.pnlMainMatches.Location = new System.Drawing.Point(13, 16);
            this.pnlMainMatches.Name = "pnlMainMatches";
            this.pnlMainMatches.Size = new System.Drawing.Size(935, 546);
            this.pnlMainMatches.TabIndex = 13;
            this.pnlMainMatches.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainMatches_Paint);
            // 
            // lblReceiver7
            // 
            this.lblReceiver7.AllowDrop = true;
            this.lblReceiver7.BackColor = System.Drawing.Color.White;
            this.lblReceiver7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReceiver7.Location = new System.Drawing.Point(735, 467);
            this.lblReceiver7.Name = "lblReceiver7";
            this.lblReceiver7.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver7.TabIndex = 6;
            this.lblReceiver7.Text = "lblReceiver7";
            this.lblReceiver7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver7.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver7.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblReceiver6
            // 
            this.lblReceiver6.AllowDrop = true;
            this.lblReceiver6.BackColor = System.Drawing.Color.White;
            this.lblReceiver6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReceiver6.Location = new System.Drawing.Point(735, 391);
            this.lblReceiver6.Name = "lblReceiver6";
            this.lblReceiver6.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver6.TabIndex = 5;
            this.lblReceiver6.Text = "lblReceiver6";
            this.lblReceiver6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver6.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver6.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblReceiver5
            // 
            this.lblReceiver5.AllowDrop = true;
            this.lblReceiver5.BackColor = System.Drawing.Color.White;
            this.lblReceiver5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReceiver5.Location = new System.Drawing.Point(735, 315);
            this.lblReceiver5.Name = "lblReceiver5";
            this.lblReceiver5.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver5.TabIndex = 4;
            this.lblReceiver5.Text = "lblReceiver5";
            this.lblReceiver5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver5.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver5.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblReceiver4
            // 
            this.lblReceiver4.AllowDrop = true;
            this.lblReceiver4.BackColor = System.Drawing.Color.White;
            this.lblReceiver4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReceiver4.Location = new System.Drawing.Point(735, 239);
            this.lblReceiver4.Name = "lblReceiver4";
            this.lblReceiver4.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver4.TabIndex = 3;
            this.lblReceiver4.Text = "lblReceiver4";
            this.lblReceiver4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver4.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver4.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblReceiver3
            // 
            this.lblReceiver3.AllowDrop = true;
            this.lblReceiver3.BackColor = System.Drawing.Color.White;
            this.lblReceiver3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiver3.Location = new System.Drawing.Point(735, 166);
            this.lblReceiver3.Name = "lblReceiver3";
            this.lblReceiver3.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver3.TabIndex = 2;
            this.lblReceiver3.Text = "lblReceiver3";
            this.lblReceiver3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver3.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblReceiver2
            // 
            this.lblReceiver2.AllowDrop = true;
            this.lblReceiver2.BackColor = System.Drawing.Color.White;
            this.lblReceiver2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiver2.Location = new System.Drawing.Point(735, 90);
            this.lblReceiver2.Name = "lblReceiver2";
            this.lblReceiver2.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver2.TabIndex = 1;
            this.lblReceiver2.Text = "lblReceiver2";
            this.lblReceiver2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblReceiver1
            // 
            this.lblReceiver1.AllowDrop = true;
            this.lblReceiver1.BackColor = System.Drawing.Color.White;
            this.lblReceiver1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiver1.Location = new System.Drawing.Point(735, 14);
            this.lblReceiver1.Name = "lblReceiver1";
            this.lblReceiver1.Size = new System.Drawing.Size(200, 65);
            this.lblReceiver1.TabIndex = 0;
            this.lblReceiver1.Text = "lblReceiver1";
            this.lblReceiver1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReceiver1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblReceiver1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblReceiver1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblSource4
            // 
            this.lblSource4.AllowDrop = true;
            this.lblSource4.BackColor = System.Drawing.Color.White;
            this.lblSource4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource4.Location = new System.Drawing.Point(0, 422);
            this.lblSource4.Name = "lblSource4";
            this.lblSource4.Size = new System.Drawing.Size(200, 110);
            this.lblSource4.TabIndex = 2;
            this.lblSource4.Text = "lblSourceFour";
            this.lblSource4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSource4.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblSource4.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblSource4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblSource3
            // 
            this.lblSource3.AllowDrop = true;
            this.lblSource3.BackColor = System.Drawing.Color.White;
            this.lblSource3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource3.Location = new System.Drawing.Point(0, 286);
            this.lblSource3.Name = "lblSource3";
            this.lblSource3.Size = new System.Drawing.Size(200, 110);
            this.lblSource3.TabIndex = 2;
            this.lblSource3.Text = "lblSourceThree";
            this.lblSource3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSource3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblSource3.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblSource3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblSource2
            // 
            this.lblSource2.AllowDrop = true;
            this.lblSource2.BackColor = System.Drawing.Color.White;
            this.lblSource2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource2.Location = new System.Drawing.Point(0, 150);
            this.lblSource2.Name = "lblSource2";
            this.lblSource2.Size = new System.Drawing.Size(200, 110);
            this.lblSource2.TabIndex = 1;
            this.lblSource2.Text = "lblSourceTwo";
            this.lblSource2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSource2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblSource2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblSource2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // lblSource1
            // 
            this.lblSource1.AllowDrop = true;
            this.lblSource1.BackColor = System.Drawing.Color.White;
            this.lblSource1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource1.Location = new System.Drawing.Point(0, 14);
            this.lblSource1.Name = "lblSource1";
            this.lblSource1.Size = new System.Drawing.Size(200, 110);
            this.lblSource1.TabIndex = 0;
            this.lblSource1.Text = "lblSourceOne";
            this.lblSource1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSource1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Label_DragDrop);
            this.lblSource1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Label_DragEnter);
            this.lblSource1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceLabel_MouseDown);
            // 
            // btnCheckMatches
            // 
            this.btnCheckMatches.Location = new System.Drawing.Point(298, 720);
            this.btnCheckMatches.Name = "btnCheckMatches";
            this.btnCheckMatches.Size = new System.Drawing.Size(124, 40);
            this.btnCheckMatches.TabIndex = 15;
            this.btnCheckMatches.Text = "Check";
            this.btnCheckMatches.UseVisualStyleBackColor = true;
            this.btnCheckMatches.Click += new System.EventHandler(this.btnCheckMatches_Click);
            // 
            // btnCasual
            // 
            this.btnCasual.Location = new System.Drawing.Point(13, 574);
            this.btnCasual.Name = "btnCasual";
            this.btnCasual.Size = new System.Drawing.Size(230, 79);
            this.btnCasual.TabIndex = 16;
            this.btnCasual.Text = "button1";
            this.btnCasual.UseVisualStyleBackColor = true;
            // 
            // btnLevel1
            // 
            this.btnLevel1.Location = new System.Drawing.Point(249, 574);
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.Size = new System.Drawing.Size(230, 79);
            this.btnLevel1.TabIndex = 17;
            this.btnLevel1.Text = "button2";
            this.btnLevel1.UseVisualStyleBackColor = true;
            // 
            // btnLevel2
            // 
            this.btnLevel2.Location = new System.Drawing.Point(485, 574);
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(230, 79);
            this.btnLevel2.TabIndex = 18;
            this.btnLevel2.Text = "button3";
            this.btnLevel2.UseVisualStyleBackColor = true;
            // 
            // btnLevel3
            // 
            this.btnLevel3.Location = new System.Drawing.Point(721, 574);
            this.btnLevel3.Name = "btnLevel3";
            this.btnLevel3.Size = new System.Drawing.Size(230, 79);
            this.btnLevel3.TabIndex = 19;
            this.btnLevel3.Text = "button4";
            this.btnLevel3.UseVisualStyleBackColor = true;
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(402, 675);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(164, 23);
            this.lblTimer.TabIndex = 20;
            this.lblTimer.Text = "Timer: 0 seconds";
            // 
            // lblCurrentLevel
            // 
            this.lblCurrentLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLevel.Location = new System.Drawing.Point(15, 675);
            this.lblCurrentLevel.Name = "lblCurrentLevel";
            this.lblCurrentLevel.Size = new System.Drawing.Size(266, 23);
            this.lblCurrentLevel.TabIndex = 21;
            this.lblCurrentLevel.Text = "Current Level: Casual";
            // 
            // MatchColumnsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.lblCurrentLevel);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnLevel3);
            this.Controls.Add(this.btnLevel2);
            this.Controls.Add(this.btnLevel1);
            this.Controls.Add(this.btnCasual);
            this.Controls.Add(this.btnCheckMatches);
            this.Controls.Add(this.pnlMainMatches);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnInstructionsMatch);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerate);
            this.Name = "MatchColumnsUserControl";
            this.Size = new System.Drawing.Size(963, 772);
            this.pnlMainMatches.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnInstructionsMatch;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Panel pnlMainMatches;
        private System.Windows.Forms.Button btnCheckMatches;
        private System.Windows.Forms.Label lblSource1;
        private System.Windows.Forms.Label lblSource3;
        private System.Windows.Forms.Label lblSource2;
        private System.Windows.Forms.Label lblSource4;
        private System.Windows.Forms.Label lblReceiver1;
        private System.Windows.Forms.Label lblReceiver6;
        private System.Windows.Forms.Label lblReceiver4;
        private System.Windows.Forms.Label lblReceiver3;
        private System.Windows.Forms.Label lblReceiver7;
        private System.Windows.Forms.Label lblReceiver5;
        private System.Windows.Forms.Label lblReceiver2;
        private System.Windows.Forms.Button btnCasual;
        private System.Windows.Forms.Button btnLevel1;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Timer timerMatch;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblCurrentLevel;
    }
}
