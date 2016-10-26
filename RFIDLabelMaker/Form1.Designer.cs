namespace RFIDLabelMaker
{
    partial class Form1
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
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkSpecificRace = new System.Windows.Forms.CheckBox();
            this.txtRaceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSpecific = new System.Windows.Forms.Label();
            this.txtLine1 = new System.Windows.Forms.TextBox();
            this.txtLine2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(203, 110);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 0;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(203, 165);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(100, 20);
            this.txtEnd.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(330, 238);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(330, 374);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(106, 23);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload Roster";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(330, 470);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // chkSpecificRace
            // 
            this.chkSpecificRace.AutoSize = true;
            this.chkSpecificRace.Location = new System.Drawing.Point(356, 167);
            this.chkSpecificRace.Name = "chkSpecificRace";
            this.chkSpecificRace.Size = new System.Drawing.Size(146, 17);
            this.chkSpecificRace.TabIndex = 5;
            this.chkSpecificRace.Text = "Program to specific race?";
            this.chkSpecificRace.UseVisualStyleBackColor = true;
            this.chkSpecificRace.CheckedChanged += new System.EventHandler(this.chkSpecificRace_CheckedChanged);
            // 
            // txtRaceNumber
            // 
            this.txtRaceNumber.Location = new System.Drawing.Point(413, 110);
            this.txtRaceNumber.Name = "txtRaceNumber";
            this.txtRaceNumber.Size = new System.Drawing.Size(75, 20);
            this.txtRaceNumber.TabIndex = 6;
            this.txtRaceNumber.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Starting Bib #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ending Bib #:";
            // 
            // lblSpecific
            // 
            this.lblSpecific.AutoSize = true;
            this.lblSpecific.Location = new System.Drawing.Point(361, 113);
            this.lblSpecific.Name = "lblSpecific";
            this.lblSpecific.Size = new System.Drawing.Size(46, 13);
            this.lblSpecific.TabIndex = 9;
            this.lblSpecific.Text = "Race #:";
            this.lblSpecific.Visible = false;
            // 
            // txtLine1
            // 
            this.txtLine1.Location = new System.Drawing.Point(95, 240);
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.Size = new System.Drawing.Size(176, 20);
            this.txtLine1.TabIndex = 10;
            // 
            // txtLine2
            // 
            this.txtLine2.Location = new System.Drawing.Point(95, 284);
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.Size = new System.Drawing.Size(176, 20);
            this.txtLine2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 552);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblSpecific);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRaceNumber);
            this.Controls.Add(this.chkSpecificRace);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Name = "Form1";
            this.Text = "RFID Label Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox chkSpecificRace;
        private System.Windows.Forms.TextBox txtRaceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSpecific;
        private System.Windows.Forms.TextBox txtLine1;
        private System.Windows.Forms.TextBox txtLine2;
    }
}

