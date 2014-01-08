using System.IO;
namespace SmartThai
{
    partial class fmSmartthai
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
            System.Windows.Forms.TabPage tabPage1;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tabExport = new System.Windows.Forms.TabPage();
            this.gbExportMM = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.gbExportP = new System.Windows.Forms.GroupBox();
            this.btmExportPP = new System.Windows.Forms.Button();
            this.tabMM = new System.Windows.Forms.TabPage();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.tabTreeview = new System.Windows.Forms.TabPage();
            this.treeSmart = new System.Windows.Forms.TreeView();
            this.tabStart = new System.Windows.Forms.TabPage();
            this.gbImport = new System.Windows.Forms.GroupBox();
            this.btmImport = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lbSublogo = new System.Windows.Forms.Label();
            this.lbLogo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabExam = new System.Windows.Forms.TabPage();
            this.btnGenQuest = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.grpChoice = new System.Windows.Forms.GroupBox();
            this.radAnswer1 = new System.Windows.Forms.RadioButton();
            this.radAnswer4 = new System.Windows.Forms.RadioButton();
            this.radAnswer2 = new System.Windows.Forms.RadioButton();
            this.radAnswer3 = new System.Windows.Forms.RadioButton();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sfdExportPP = new System.Windows.Forms.SaveFileDialog();
            tabPage1 = new System.Windows.Forms.TabPage();
            this.tabExport.SuspendLayout();
            this.gbExportMM.SuspendLayout();
            this.gbExportP.SuspendLayout();
            this.tabMM.SuspendLayout();
            this.tabTreeview.SuspendLayout();
            this.tabStart.SuspendLayout();
            this.gbImport.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabExam.SuspendLayout();
            this.grpChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(696, 390);
            tabPage1.TabIndex = 7;
            tabPage1.Text = "Cartoon";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabExport
            // 
            this.tabExport.Controls.Add(this.gbExportMM);
            this.tabExport.Controls.Add(this.gbExportP);
            this.tabExport.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabExport.Location = new System.Drawing.Point(4, 24);
            this.tabExport.Name = "tabExport";
            this.tabExport.Size = new System.Drawing.Size(696, 390);
            this.tabExport.TabIndex = 5;
            this.tabExport.Text = "Export";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // gbExportMM
            // 
            this.gbExportMM.Controls.Add(this.button7);
            this.gbExportMM.Controls.Add(this.button9);
            this.gbExportMM.Location = new System.Drawing.Point(236, 176);
            this.gbExportMM.Name = "gbExportMM";
            this.gbExportMM.Size = new System.Drawing.Size(250, 167);
            this.gbExportMM.TabIndex = 11;
            this.gbExportMM.TabStop = false;
            this.gbExportMM.Text = "Export Mind Mapping";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(34, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(181, 55);
            this.button7.TabIndex = 6;
            this.button7.Text = "Export as JPG";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(34, 99);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(181, 55);
            this.button9.TabIndex = 7;
            this.button9.Text = "Export as PDF";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // gbExportP
            // 
            this.gbExportP.Controls.Add(this.btmExportPP);
            this.gbExportP.Location = new System.Drawing.Point(236, 47);
            this.gbExportP.Name = "gbExportP";
            this.gbExportP.Size = new System.Drawing.Size(250, 89);
            this.gbExportP.TabIndex = 10;
            this.gbExportP.TabStop = false;
            this.gbExportP.Text = "Export Presentation";
            // 
            // btmExportPP
            // 
            this.btmExportPP.Location = new System.Drawing.Point(34, 19);
            this.btmExportPP.Name = "btmExportPP";
            this.btmExportPP.Size = new System.Drawing.Size(181, 55);
            this.btmExportPP.TabIndex = 5;
            this.btmExportPP.Text = "Export as Powerpoint or PDF";
            this.btmExportPP.UseVisualStyleBackColor = true;
            this.btmExportPP.Click += new System.EventHandler(this.btmExportPP_Click);
            // 
            // tabMM
            // 
            this.tabMM.Controls.Add(this.webBrowser2);
            this.tabMM.ForeColor = System.Drawing.Color.GhostWhite;
            this.tabMM.Location = new System.Drawing.Point(4, 24);
            this.tabMM.Name = "tabMM";
            this.tabMM.Size = new System.Drawing.Size(696, 390);
            this.tabMM.TabIndex = 3;
            this.tabMM.Text = "Mind Mapping";
            this.tabMM.UseVisualStyleBackColor = true;
            // 
            // webBrowser2
            // 
            this.webBrowser2.AllowNavigation = false;
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(0, 0);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(696, 390);
            this.webBrowser2.TabIndex = 0;
            this.webBrowser2.Url = new System.Uri("http://bongtrop.com/smartthai/mindmap", System.UriKind.Absolute);
            // 
            // tabTreeview
            // 
            this.tabTreeview.Controls.Add(this.treeSmart);
            this.tabTreeview.Location = new System.Drawing.Point(4, 24);
            this.tabTreeview.Name = "tabTreeview";
            this.tabTreeview.Size = new System.Drawing.Size(696, 390);
            this.tabTreeview.TabIndex = 2;
            this.tabTreeview.Text = "Treeview";
            this.tabTreeview.UseVisualStyleBackColor = true;
            // 
            // treeSmart
            // 
            this.treeSmart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSmart.LabelEdit = true;
            this.treeSmart.Location = new System.Drawing.Point(0, 0);
            this.treeSmart.Name = "treeSmart";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            this.treeSmart.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeSmart.Size = new System.Drawing.Size(696, 390);
            this.treeSmart.TabIndex = 0;
            this.treeSmart.Leave += new System.EventHandler(this.treeSmart_Leave);
            // 
            // tabStart
            // 
            this.tabStart.Controls.Add(this.gbImport);
            this.tabStart.Controls.Add(this.lbSublogo);
            this.tabStart.Controls.Add(this.lbLogo);
            this.tabStart.Location = new System.Drawing.Point(4, 24);
            this.tabStart.Name = "tabStart";
            this.tabStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabStart.Size = new System.Drawing.Size(696, 390);
            this.tabStart.TabIndex = 0;
            this.tabStart.Text = "Start";
            this.tabStart.UseVisualStyleBackColor = true;
            // 
            // gbImport
            // 
            this.gbImport.Controls.Add(this.btmImport);
            this.gbImport.Controls.Add(this.txtUrl);
            this.gbImport.Location = new System.Drawing.Point(30, 218);
            this.gbImport.Name = "gbImport";
            this.gbImport.Size = new System.Drawing.Size(614, 103);
            this.gbImport.TabIndex = 6;
            this.gbImport.TabStop = false;
            this.gbImport.Text = "นำเข้าข้อมูลจากวิกิพีเดีย";
            // 
            // btmImport
            // 
            this.btmImport.Location = new System.Drawing.Point(526, 58);
            this.btmImport.Name = "btmImport";
            this.btmImport.Size = new System.Drawing.Size(75, 23);
            this.btmImport.TabIndex = 5;
            this.btmImport.Text = "Import";
            this.btmImport.UseVisualStyleBackColor = true;
            this.btmImport.Click += new System.EventHandler(this.btmImport_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(21, 32);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(580, 20);
            this.txtUrl.TabIndex = 4;
            this.txtUrl.Text = "http://th.wikipedia.org/wiki/";
            this.txtUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrl_Keypress);
            // 
            // lbSublogo
            // 
            this.lbSublogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbSublogo.Location = new System.Drawing.Point(163, 140);
            this.lbSublogo.Name = "lbSublogo";
            this.lbSublogo.Size = new System.Drawing.Size(385, 24);
            this.lbSublogo.TabIndex = 1;
            this.lbSublogo.Text = "โปรแกรมสรุปแบบหลวก รุ่นทดลอง";
            this.lbSublogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbLogo
            // 
            this.lbLogo.AutoEllipsis = true;
            this.lbLogo.AutoSize = true;
            this.lbLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbLogo.Location = new System.Drawing.Point(94, 46);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(513, 73);
            this.lbLogo.TabIndex = 0;
            this.lbLogo.Text = "SmartThai BETA";
            this.lbLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabStart);
            this.tabControl.Controls.Add(this.tabTreeview);
            this.tabControl.Controls.Add(this.tabMM);
            this.tabControl.Controls.Add(tabPage1);
            this.tabControl.Controls.Add(this.tabExam);
            this.tabControl.Controls.Add(this.tabExport);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(58, 20);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(704, 418);
            this.tabControl.TabIndex = 1;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabExam
            // 
            this.tabExam.Controls.Add(this.btnGenQuest);
            this.tabExam.Controls.Add(this.btnCheck);
            this.tabExam.Controls.Add(this.grpChoice);
            this.tabExam.Controls.Add(this.lblAnswer);
            this.tabExam.Controls.Add(this.txtQuestion);
            this.tabExam.Controls.Add(this.txtAnswer);
            this.tabExam.Controls.Add(this.label1);
            this.tabExam.Location = new System.Drawing.Point(4, 24);
            this.tabExam.Name = "tabExam";
            this.tabExam.Padding = new System.Windows.Forms.Padding(3);
            this.tabExam.Size = new System.Drawing.Size(696, 390);
            this.tabExam.TabIndex = 6;
            this.tabExam.Text = "Exam";
            this.tabExam.UseVisualStyleBackColor = true;
            // 
            // btnGenQuest
            // 
            this.btnGenQuest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenQuest.Location = new System.Drawing.Point(156, 44);
            this.btnGenQuest.Name = "btnGenQuest";
            this.btnGenQuest.Size = new System.Drawing.Size(109, 23);
            this.btnGenQuest.TabIndex = 9;
            this.btnGenQuest.Text = "Generate Question";
            this.btnGenQuest.UseVisualStyleBackColor = true;
            this.btnGenQuest.Click += new System.EventHandler(this.btnGenQuest_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheck.Location = new System.Drawing.Point(425, 197);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(104, 23);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "Check for answer";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // grpChoice
            // 
            this.grpChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpChoice.Controls.Add(this.radAnswer1);
            this.grpChoice.Controls.Add(this.radAnswer4);
            this.grpChoice.Controls.Add(this.radAnswer2);
            this.grpChoice.Controls.Add(this.radAnswer3);
            this.grpChoice.Location = new System.Drawing.Point(156, 171);
            this.grpChoice.Name = "grpChoice";
            this.grpChoice.Size = new System.Drawing.Size(373, 125);
            this.grpChoice.TabIndex = 8;
            this.grpChoice.TabStop = false;
            this.grpChoice.Visible = false;
            // 
            // radAnswer1
            // 
            this.radAnswer1.AutoSize = true;
            this.radAnswer1.Location = new System.Drawing.Point(6, 19);
            this.radAnswer1.Name = "radAnswer1";
            this.radAnswer1.Size = new System.Drawing.Size(85, 17);
            this.radAnswer1.TabIndex = 4;
            this.radAnswer1.TabStop = true;
            this.radAnswer1.Text = "radioButton1";
            this.radAnswer1.UseVisualStyleBackColor = true;
            this.radAnswer1.CheckedChanged += new System.EventHandler(this.radAnswer1_CheckedChanged);
            // 
            // radAnswer4
            // 
            this.radAnswer4.AutoSize = true;
            this.radAnswer4.Location = new System.Drawing.Point(6, 88);
            this.radAnswer4.Name = "radAnswer4";
            this.radAnswer4.Size = new System.Drawing.Size(85, 17);
            this.radAnswer4.TabIndex = 7;
            this.radAnswer4.TabStop = true;
            this.radAnswer4.Text = "radioButton4";
            this.radAnswer4.UseVisualStyleBackColor = true;
            this.radAnswer4.CheckedChanged += new System.EventHandler(this.radAnswer4_CheckedChanged);
            // 
            // radAnswer2
            // 
            this.radAnswer2.AutoSize = true;
            this.radAnswer2.Location = new System.Drawing.Point(6, 42);
            this.radAnswer2.Name = "radAnswer2";
            this.radAnswer2.Size = new System.Drawing.Size(85, 17);
            this.radAnswer2.TabIndex = 5;
            this.radAnswer2.TabStop = true;
            this.radAnswer2.Text = "radioButton2";
            this.radAnswer2.UseVisualStyleBackColor = true;
            this.radAnswer2.CheckedChanged += new System.EventHandler(this.radAnswer2_CheckedChanged);
            // 
            // radAnswer3
            // 
            this.radAnswer3.AutoSize = true;
            this.radAnswer3.Location = new System.Drawing.Point(6, 65);
            this.radAnswer3.Name = "radAnswer3";
            this.radAnswer3.Size = new System.Drawing.Size(85, 17);
            this.radAnswer3.TabIndex = 6;
            this.radAnswer3.TabStop = true;
            this.radAnswer3.Text = "radioButton3";
            this.radAnswer3.UseVisualStyleBackColor = true;
            this.radAnswer3.CheckedChanged += new System.EventHandler(this.radAnswer3_CheckedChanged);
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(101, 174);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(42, 13);
            this.lblAnswer.TabIndex = 2;
            this.lblAnswer.Text = "Answer";
            this.lblAnswer.Visible = false;
            // 
            // txtQuestion
            // 
            this.txtQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuestion.Location = new System.Drawing.Point(156, 73);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(373, 92);
            this.txtQuestion.TabIndex = 1;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAnswer.Location = new System.Drawing.Point(156, 171);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(373, 20);
            this.txtAnswer.TabIndex = 3;
            this.txtAnswer.Visible = false;
            this.txtAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnswer_Keypress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question";
            // 
            // sfdExportPP
            // 
            this.sfdExportPP.FileName = "smartthai.pptx";
            this.sfdExportPP.Title = "Export as Powerpoint";
            // 
            // fmSmartthai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(704, 418);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(720, 457);
            this.Name = "fmSmartthai";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartThai";
            this.Load += new System.EventHandler(this.fmSmartthai_Load);
            this.Resize += new System.EventHandler(this.fmSmartthai_Resize);
            this.tabExport.ResumeLayout(false);
            this.gbExportMM.ResumeLayout(false);
            this.gbExportP.ResumeLayout(false);
            this.tabMM.ResumeLayout(false);
            this.tabTreeview.ResumeLayout(false);
            this.tabStart.ResumeLayout(false);
            this.tabStart.PerformLayout();
            this.gbImport.ResumeLayout(false);
            this.gbImport.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabExam.ResumeLayout(false);
            this.tabExam.PerformLayout();
            this.grpChoice.ResumeLayout(false);
            this.grpChoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btmExportPP;
        private System.Windows.Forms.TabPage tabMM;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.TabPage tabTreeview;
        private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.Label lbSublogo;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btmImport;
        private System.Windows.Forms.TextBox txtUrl;
        public System.Windows.Forms.TreeView treeSmart;
        private System.Windows.Forms.GroupBox gbImport;
        private System.Windows.Forms.GroupBox gbExportMM;
        private System.Windows.Forms.GroupBox gbExportP;
        private System.Windows.Forms.SaveFileDialog sfdExportPP;
        private System.Windows.Forms.TabPage tabExam;
        private System.Windows.Forms.Button btnGenQuest;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.GroupBox grpChoice;
        private System.Windows.Forms.RadioButton radAnswer1;
        private System.Windows.Forms.RadioButton radAnswer4;
        private System.Windows.Forms.RadioButton radAnswer2;
        private System.Windows.Forms.RadioButton radAnswer3;

    }
}

