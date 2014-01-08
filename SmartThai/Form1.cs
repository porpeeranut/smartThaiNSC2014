using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Net;
namespace SmartThai
{
    public partial class fmSmartthai : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;
        const int MIN_ALL_UNDO = 416;
        static Smarttree st;
        static Wiki wiki;
        
        static Export export;

        private Exam exam;
        private ExamNode no;
        public fmSmartthai()
        {
            InitializeComponent();
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
            tabTreeview.Enabled = false;
            tabMM.Enabled = false;
            tabExport.Enabled = false;
            st = new Smarttree(treeSmart);
            wiki = new Wiki();
            export = new Export();
        }

        private void fmSmartthai_Load(object sender, EventArgs e)
        {
            lbLogo.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - lbLogo.Size.Width / 2, tabControl.Size.Height / 2 - 150);
            lbSublogo.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - lbSublogo.Size.Width / 2, tabControl.Size.Height / 2 - 80);
            gbImport.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - gbImport.Size.Width / 2, tabControl.Size.Height / 2);
            gbExportP.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - gbExportMM.Size.Width / 2, tabControl.Size.Height / 2 - 150);
            gbExportMM.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - gbExportMM.Size.Width / 2, tabControl.Size.Height / 2 - 50);
            this.webBrowser2.Refresh();
        }

        private void fmSmartthai_Resize(object sender, EventArgs e)
        {
            lbLogo.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - lbLogo.Size.Width / 2, tabControl.Size.Height / 2 - 150);
            lbSublogo.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - lbSublogo.Size.Width / 2, tabControl.Size.Height / 2 - 80);
            gbImport.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - gbImport.Size.Width / 2, tabControl.Size.Height / 2);
            gbExportP.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - gbExportMM.Size.Width / 2, tabControl.Size.Height / 2 - 150);
            gbExportMM.Location = new System.Drawing.Point(tabControl.Size.Width / 2 - gbExportMM.Size.Width / 2, tabControl.Size.Height / 2 - 50);
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
                MessageBox.Show("กรุณาใส่ข้อมูลนำเข้าด้านล่าง", "Error");
            }
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];

            if (!page.Enabled)
            {
                using (SolidBrush brush = new SolidBrush(SystemColors.GrayText))
                {
                    e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(page.ForeColor))
                {
                    e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds);
                }
            }
        }

        private void btmImport_Click(object sender, EventArgs e)
        {
            if (!wiki.setUrl(txtUrl.Text))
            {
                MessageBox.Show("ไม่สามารถสรุปความได้", "Error");
                return;
            }
            this.webBrowser2.Navigate(webBrowser2.Url);
            string smartStr = wiki.toString();
            exam = new Exam(smartStr);
            txtQuestion.Text = "";
            lblAnswer.Visible = false;
            txtAnswer.Visible = false;
            btnCheck.Visible = false;
            grpChoice.Visible = false;
            //Exam exam = new Exam(smartStr);
            //ExamNode no = exam.examTypeOne();
            //ExamNode no2 = exam.examTypeTwo();
            //MessageBox.Show(no.qustion + " [" + no.choice[0] + "," + no.choice[1] + "," + no.choice[2] + "," + no.choice[3] + "]");
            //MessageBox.Show(no2.qustion);
            //foreach (string c in no2.choice)
            //{
            //    MessageBox.Show(c);
            //}
            //System.IO.File.WriteAllText(@"e:\WriteText.txt", smartStr.Replace("\t", "*"));
            st.set(smartStr);
            tabTreeview.Enabled = true;
            tabMM.Enabled = true;
            tabExport.Enabled = true;
            tabControl.SelectedIndex = 1;
            smartStr = st.get();
            export.set(smartStr);
            HtmlElement text = webBrowser2.Document.GetElementsByTagName("textarea")[0];
            text.InnerHtml = smartStr.Replace("\t", "*");
            webBrowser2.Document.InvokeScript("update");
        }

        private void treeSmart_Leave(object sender, EventArgs e)
        {
            this.webBrowser2.Navigate(webBrowser2.Url);
            st.get();
            string smartStr = st.get();
            export.set(smartStr);
            exam = new Exam(smartStr);
            HtmlElement text = webBrowser2.Document.GetElementsByTagName("textarea")[0];
            text.InnerHtml = smartStr.Replace("\t", "*");
            webBrowser2.Document.InvokeScript("update");
        }

        private void btmExportPP_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            sfdExportPP.Filter = "PowerPoint Presentation |*.pptx|PowerPoint 97-2003 Presentation |*.ppt|PDF |*.pdf";
            sfdExportPP.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (sfdExportPP.ShowDialog() == DialogResult.OK)
            {
                export.toPowerPoint(sfdExportPP.FileName);
            }
        }
        private void btnGenQuest_Click(object sender, EventArgs e)
        {
            int rndQus = new Random().Next(2);
            for (int i = 0; i < 2; i++) {
                if (rndQus == 0) // choice
                {
                    no = exam.examTypeOne();
                    if (no != null) {
                        lblAnswer.Visible = true;
                        txtAnswer.Visible = false;
                        btnCheck.Visible = false;
                        grpChoice.Visible = true;
                        txtQuestion.Text = no.qustion;
                        radAnswer1.Text = no.choice[0];
                        radAnswer2.Text = no.choice[1];
                        radAnswer3.Text = no.choice[2];
                        radAnswer4.Text = no.choice[3];
                        return;
                    } else {
                        rndQus = 1;
                        continue;
                    }
                }
                else
                {    // OBJ
                    no = exam.examTypeTwo();
                    if (no != null) {
                        lblAnswer.Visible = true;
                        txtAnswer.Visible = true;
                        btnCheck.Visible = true;
                        grpChoice.Visible = false;
                        txtQuestion.Text = no.qustion;
                        return;
                    } else {
                        rndQus = 0;
                        continue;
                    }
                }
            }
            MessageBox.Show("Can't generate question");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < no.choice.Length; i++) {
                if (txtAnswer.Text == no.choice[i])
                {
                    MessageBox.Show("ถูกต้องแล้วครับ");
                    return;
                }
            }
            MessageBox.Show("ผิดครับ ลองใหม่อีกครั้งค่ะ");
        }

        private void txtAnswer_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // Enter key pressed
            {
                btnCheck_Click(sender, e);
            }
        }

        private void radAnswer1_CheckedChanged(object sender, EventArgs e)
        {
            if(radAnswer1.Checked)
                MessageBox.Show("ถูกต้องแล้วครับ");
        }

        private void radAnswer2_CheckedChanged(object sender, EventArgs e)
        {
            if (radAnswer2.Checked)
                MessageBox.Show("ผิดครับ ลองใหม่อีกครั้งค่ะ");
        }

        private void radAnswer3_CheckedChanged(object sender, EventArgs e)
        {
            if (radAnswer3.Checked)
                MessageBox.Show("ผิดครับ ลองใหม่อีกครั้งค่ะ");
        }

        private void radAnswer4_CheckedChanged(object sender, EventArgs e)
        {
            if (radAnswer4.Checked)
                MessageBox.Show("ผิดครับ ลองใหม่อีกครั้งค่ะ");
        }

        private void txtUrl_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // Enter key pressed
            {
                btmImport_Click(sender, e);
            }
        }
    }
}
