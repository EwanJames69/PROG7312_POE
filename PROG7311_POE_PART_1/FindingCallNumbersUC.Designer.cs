namespace PROG7311_POE_PART_1.UserControls
{
    partial class FindingCallNumbersUC
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnInstructionsMatch = new System.Windows.Forms.Button();
            this.lblAnswer2 = new System.Windows.Forms.Label();
            this.lblAnswer3 = new System.Windows.Forms.Label();
            this.lblAnswer4 = new System.Windows.Forms.Label();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerAnswer = new System.Windows.Forms.Timer(this.components);
            this.lblAnswer1 = new System.Windows.Forms.Label();
            this.lblAnswer5 = new System.Windows.Forms.Label();
            this.lblAnswer9 = new System.Windows.Forms.Label();
            this.lblAnswer6 = new System.Windows.Forms.Label();
            this.lblAnswer7 = new System.Windows.Forms.Label();
            this.lblAnswer8 = new System.Windows.Forms.Label();
            this.lblAnswer10 = new System.Windows.Forms.Label();
            this.lblAnswer11 = new System.Windows.Forms.Label();
            this.lblAnswer12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 526);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(124, 40);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Quiz";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(153, 526);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(124, 40);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop Quiz";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(773, 526);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(124, 40);
            this.btnMainMenu.TabIndex = 13;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            // 
            // btnInstructionsMatch
            // 
            this.btnInstructionsMatch.Location = new System.Drawing.Point(913, 526);
            this.btnInstructionsMatch.Name = "btnInstructionsMatch";
            this.btnInstructionsMatch.Size = new System.Drawing.Size(124, 40);
            this.btnInstructionsMatch.TabIndex = 14;
            this.btnInstructionsMatch.Text = "Instructions";
            this.btnInstructionsMatch.UseVisualStyleBackColor = true;
            // 
            // lblAnswer2
            // 
            this.lblAnswer2.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer2.Location = new System.Drawing.Point(272, 14);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer2.TabIndex = 16;
            this.lblAnswer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer3
            // 
            this.lblAnswer3.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer3.Location = new System.Drawing.Point(532, 14);
            this.lblAnswer3.Name = "lblAnswer3";
            this.lblAnswer3.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer3.TabIndex = 17;
            this.lblAnswer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer4
            // 
            this.lblAnswer4.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer4.Location = new System.Drawing.Point(795, 14);
            this.lblAnswer4.Name = "lblAnswer4";
            this.lblAnswer4.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer4.TabIndex = 18;
            this.lblAnswer4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.Location = new System.Drawing.Point(8, 431);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(332, 28);
            this.lblProgressBar.TabIndex = 19;
            this.lblProgressBar.Text = "Progress (Amount Correct):";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.DimGray;
            this.progressBar.ForeColor = System.Drawing.SystemColors.Info;
            this.progressBar.Location = new System.Drawing.Point(13, 471);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1024, 34);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 20;
            // 
            // lblAnswer1
            // 
            this.lblAnswer1.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer1.Location = new System.Drawing.Point(10, 14);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer1.TabIndex = 15;
            this.lblAnswer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer5
            // 
            this.lblAnswer5.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer5.Location = new System.Drawing.Point(10, 152);
            this.lblAnswer5.Name = "lblAnswer5";
            this.lblAnswer5.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer5.TabIndex = 21;
            this.lblAnswer5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer9
            // 
            this.lblAnswer9.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer9.Location = new System.Drawing.Point(10, 290);
            this.lblAnswer9.Name = "lblAnswer9";
            this.lblAnswer9.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer9.TabIndex = 22;
            this.lblAnswer9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer6
            // 
            this.lblAnswer6.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer6.Location = new System.Drawing.Point(272, 152);
            this.lblAnswer6.Name = "lblAnswer6";
            this.lblAnswer6.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer6.TabIndex = 23;
            this.lblAnswer6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer7
            // 
            this.lblAnswer7.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer7.Location = new System.Drawing.Point(532, 152);
            this.lblAnswer7.Name = "lblAnswer7";
            this.lblAnswer7.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer7.TabIndex = 24;
            this.lblAnswer7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer8
            // 
            this.lblAnswer8.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer8.Location = new System.Drawing.Point(795, 152);
            this.lblAnswer8.Name = "lblAnswer8";
            this.lblAnswer8.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer8.TabIndex = 25;
            this.lblAnswer8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer10
            // 
            this.lblAnswer10.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer10.Location = new System.Drawing.Point(272, 290);
            this.lblAnswer10.Name = "lblAnswer10";
            this.lblAnswer10.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer10.TabIndex = 26;
            this.lblAnswer10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer11
            // 
            this.lblAnswer11.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer11.Location = new System.Drawing.Point(532, 290);
            this.lblAnswer11.Name = "lblAnswer11";
            this.lblAnswer11.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer11.TabIndex = 27;
            this.lblAnswer11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer12
            // 
            this.lblAnswer12.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer12.Location = new System.Drawing.Point(795, 290);
            this.lblAnswer12.Name = "lblAnswer12";
            this.lblAnswer12.Size = new System.Drawing.Size(242, 130);
            this.lblAnswer12.TabIndex = 28;
            this.lblAnswer12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FindingCallNumbersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.Controls.Add(this.lblAnswer12);
            this.Controls.Add(this.lblAnswer11);
            this.Controls.Add(this.lblAnswer10);
            this.Controls.Add(this.lblAnswer8);
            this.Controls.Add(this.lblAnswer7);
            this.Controls.Add(this.lblAnswer6);
            this.Controls.Add(this.lblAnswer9);
            this.Controls.Add(this.lblAnswer5);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.lblAnswer4);
            this.Controls.Add(this.lblAnswer3);
            this.Controls.Add(this.lblAnswer2);
            this.Controls.Add(this.lblAnswer1);
            this.Controls.Add(this.btnInstructionsMatch);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "FindingCallNumbersUC";
            this.Size = new System.Drawing.Size(1057, 585);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnInstructionsMatch;
        private System.Windows.Forms.Label lblAnswer2;
        private System.Windows.Forms.Label lblAnswer3;
        private System.Windows.Forms.Label lblAnswer4;
        private System.Windows.Forms.Label lblProgressBar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timerAnswer;
        private System.Windows.Forms.Label lblAnswer1;
        private System.Windows.Forms.Label lblAnswer5;
        private System.Windows.Forms.Label lblAnswer9;
        private System.Windows.Forms.Label lblAnswer6;
        private System.Windows.Forms.Label lblAnswer7;
        private System.Windows.Forms.Label lblAnswer8;
        private System.Windows.Forms.Label lblAnswer10;
        private System.Windows.Forms.Label lblAnswer11;
        private System.Windows.Forms.Label lblAnswer12;
    }
}
