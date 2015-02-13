namespace llParserGUI
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
            this.rtxSrc = new System.Windows.Forms.RichTextBox();
            this.rtxTokenStream = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtxErr = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtxStackTrace = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tvwParseTree = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxSrc
            // 
            this.rtxSrc.Location = new System.Drawing.Point(6, 19);
            this.rtxSrc.Name = "rtxSrc";
            this.rtxSrc.ReadOnly = true;
            this.rtxSrc.Size = new System.Drawing.Size(720, 529);
            this.rtxSrc.TabIndex = 0;
            this.rtxSrc.Text = "";
            // 
            // rtxTokenStream
            // 
            this.rtxTokenStream.BackColor = System.Drawing.SystemColors.Window;
            this.rtxTokenStream.Location = new System.Drawing.Point(4, 6);
            this.rtxTokenStream.Name = "rtxTokenStream";
            this.rtxTokenStream.ReadOnly = true;
            this.rtxTokenStream.Size = new System.Drawing.Size(383, 491);
            this.rtxTokenStream.TabIndex = 1;
            this.rtxTokenStream.Text = "";
            this.rtxTokenStream.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxSrc);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 559);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source File";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(4, 503);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(383, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next Token";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1004, 720);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1085, 720);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxErr);
            this.groupBox3.Location = new System.Drawing.Point(13, 578);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1148, 136);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Errors";
            // 
            // rtxErr
            // 
            this.rtxErr.BackColor = System.Drawing.SystemColors.Window;
            this.rtxErr.Location = new System.Drawing.Point(6, 19);
            this.rtxErr.Name = "rtxErr";
            this.rtxErr.ReadOnly = true;
            this.rtxErr.Size = new System.Drawing.Size(1136, 111);
            this.rtxErr.TabIndex = 0;
            this.rtxErr.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(760, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(401, 559);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.rtxTokenStream);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(393, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Token Stream";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.rtxStackTrace);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(393, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parse Stack Trace";
            // 
            // rtxStackTrace
            // 
            this.rtxStackTrace.BackColor = System.Drawing.SystemColors.Window;
            this.rtxStackTrace.Location = new System.Drawing.Point(3, 6);
            this.rtxStackTrace.Name = "rtxStackTrace";
            this.rtxStackTrace.ReadOnly = true;
            this.rtxStackTrace.Size = new System.Drawing.Size(384, 520);
            this.rtxStackTrace.TabIndex = 0;
            this.rtxStackTrace.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tvwParseTree);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(393, 533);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parse Tree";
            // 
            // tvwParseTree
            // 
            this.tvwParseTree.Location = new System.Drawing.Point(3, 6);
            this.tvwParseTree.Name = "tvwParseTree";
            this.tvwParseTree.Size = new System.Drawing.Size(384, 520);
            this.tvwParseTree.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 755);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "LL(1) Parser & Lexical Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxSrc;
        private System.Windows.Forms.RichTextBox rtxTokenStream;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox rtxErr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtxStackTrace;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tvwParseTree;
    }
}

