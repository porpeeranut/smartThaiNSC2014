using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using powerPoint = Microsoft.Office.Interop.PowerPoint;

namespace SmartThai
{
    class Export
    {
        private string smartStr;

        public Export(string smartStr)
        {
            this.smartStr = smartStr;
        }

        public Export()
        {
            this.smartStr = "";

        }

        public void set(string smartStr) 
        {
            this.smartStr = smartStr;
        }
        public Boolean toPowerPoint(string url)
        {
            string[] str = Regex.Split(smartStr, "\r\n");

            string titleTmp = "";
            string comment = "Smart Thai";
            string Arial = "Arial";
            string Tahoma = "Tahoma";

            powerPoint.Application objApp = new powerPoint.Application();
            powerPoint.Slides objSlides;
            powerPoint._Slide objSlide;
            powerPoint.TextRange objTextRng;

            // Create the Presentation File
            powerPoint.Presentation objPresSet = objApp.Presentations.Add(MsoTriState.msoTrue);

            powerPoint.CustomLayout customLayout = objPresSet.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutTitle];

            // Create new Slide
            objSlides = objPresSet.Slides;
            objSlide = objSlides.AddSlide(1, customLayout);
            objSlide.NotesPage.Shapes[2].TextFrame.TextRange.Text = comment;

            // Add title
            objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
            objTextRng.Text = str[0];
            objTextRng.Font.Name = Tahoma;
            objTextRng.Font.Size = 72;
            titleTmp = str[0];
            if (str[1].IndexOf("http") != -1)
            {
                new WebClient().DownloadFile(str[1].Trim(), "./tmp.png");
                objSlide.Shapes.AddPicture(Application.StartupPath + "/tmp.png", MsoTriState.msoFalse, MsoTriState.msoTrue,
                    260, 300, 200, 200);
            }

            customLayout = objPresSet.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];
            int tab, slideCount = 1, lineCount = 0;
            bool specialText = false, define = true;
            int tabSpecial = 0;
            int picInSlide = 0;

            objSlide = objSlides.AddSlide(++slideCount, customLayout);
            objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
            objTextRng.Text = str[0];
            objTextRng.Font.Name = Tahoma;
            objTextRng.Font.Size = 40;
            objTextRng.ParagraphFormat.Alignment = powerPoint.PpParagraphAlignment.ppAlignLeft;
            objSlide.NotesPage.Shapes[2].TextFrame.TextRange.Text = comment;
            for (int i = 2; i < str.Length - 1; i++)
            {
                tab = 0;
                foreach (char ch in str[i])
                {
                    if (ch == '\t')
                        tab++;
                    else
                        break;
                }
                if (define)
                {
                    if (i + 1 < str.Length - 1)
                    {
                        int nextTab = 0;
                        foreach (char ch in str[i + 1])
                        {
                            if (ch == '\t')
                                nextTab++;
                            else
                                break;
                        }
                        if (nextTab == tab)
                        {
                            if (lineCount > 5)
                            {
                                objSlide = objSlides.AddSlide(++slideCount, customLayout);
                                objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
                                objTextRng.Text = titleTmp + " (ต่อ)";
                                objTextRng.Font.Name = Tahoma;
                                objTextRng.Font.Size = 40;
                                objTextRng.ParagraphFormat.Alignment = powerPoint.PpParagraphAlignment.ppAlignLeft;
                                objSlide.NotesPage.Shapes[2].TextFrame.TextRange.Text = comment;
                                lineCount = 0;
                            }
                            objTextRng = objSlide.Shapes[2].TextFrame.TextRange;
                            if (lineCount != 0)
                                objTextRng.Text += "\r\n";
                            objTextRng.Text += str[i].Trim();
                            objTextRng.Font.Name = Arial;
                            objTextRng.Font.Size = 28;
                            lineCount++;
                        }
                        else
                        {
                            objSlide = objSlides.AddSlide(++slideCount, customLayout);

                            objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
                            objTextRng.Text = str[i].Trim();
                            objTextRng.Font.Name = Tahoma;
                            objTextRng.Font.Size = 40;
                            objTextRng.ParagraphFormat.Alignment = powerPoint.PpParagraphAlignment.ppAlignLeft;
                            objSlide.NotesPage.Shapes[2].TextFrame.TextRange.Text = comment;
                            lineCount = 0;
                            titleTmp = str[i].Trim();
                            define = false;
                        }
                    }
                    else
                    {
                        objTextRng = objSlide.Shapes[2].TextFrame.TextRange;
                        if (lineCount != 0)
                            objTextRng.Text += "\r\n";
                        objTextRng.Text += str[i].Trim();
                        objTextRng.Font.Name = Arial;
                        objTextRng.Font.Size = 28;
                        lineCount++;
                    }
                }
                else
                {
                    if (str[i].Trim() == "-Extrack Bullet-" || str[i].Trim() == "-Extrack Paragraph-")
                    {
                        specialText = true;
                        tabSpecial = tab;
                        continue;
                    }
                    if (specialText && tab == tabSpecial)
                        continue;
                    else
                        specialText = false;
                    if (tab == 1)
                    {
                        lineCount = 0;
                        objSlide = objSlides.AddSlide(++slideCount, customLayout);

                        objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
                        objTextRng.Text = str[i].Trim();
                        objTextRng.Font.Name = Tahoma;
                        objTextRng.Font.Size = 40;
                        objTextRng.ParagraphFormat.Alignment = powerPoint.PpParagraphAlignment.ppAlignLeft;
                        objSlide.NotesPage.Shapes[2].TextFrame.TextRange.Text = comment;
                        picInSlide = 0;
                        titleTmp = str[i].Trim();
                    }
                    else
                    {
                        if (lineCount > 5 || picInSlide == 2)
                        {
                            objSlide = objSlides.AddSlide(++slideCount, customLayout);

                            objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
                            objTextRng.Text = titleTmp + " (ต่อ)";
                            objTextRng.Font.Name = Tahoma;
                            objTextRng.Font.Size = 40;
                            objTextRng.ParagraphFormat.Alignment = powerPoint.PpParagraphAlignment.ppAlignLeft;
                            objSlide.NotesPage.Shapes[2].TextFrame.TextRange.Text = comment;
                            lineCount = 0;
                            picInSlide = 0;
                        }
                        string link = "", text = "";
                        if (str[i].IndexOf("[SMARTTHAI]") != -1)
                        {
                            text = Regex.Split(str[i], @"\[SMARTTHAI\]")[0].Trim();
                            link = Regex.Split(str[i], @"\[SMARTTHAI\]")[1];
                            objTextRng = objSlide.Shapes[2].TextFrame.TextRange;
                            if (lineCount != 0)
                                objTextRng.Text += "\r\n";
                            objTextRng.Text += text;
                            objTextRng.Font.Name = Arial;
                            objTextRng.Font.Size = 28;
                            if (picInSlide < 2)
                            {
                                new WebClient().DownloadFile(link, "./tmp.png");
                                objSlide.Shapes.AddPicture(Application.StartupPath + "/tmp.png", MsoTriState.msoFalse, MsoTriState.msoTrue, 360, (lineCount * 45) + 130, 160, 160);
                                picInSlide++;
                            }
                            lineCount += 3;
                            objTextRng.Text += "\r\n\r\n\r\n";
                        }
                        else
                        {
                            objTextRng = objSlide.Shapes[2].TextFrame.TextRange;
                            if (lineCount != 0)
                                objTextRng.Text += "\r\n";
                            objTextRng.Text += str[i].Trim();
                            objTextRng.Font.Name = Arial;
                            objTextRng.Font.Size = 28;
                        }

                        lineCount++;
                    }
                }
            }
            try
            {
                string[] a = url.Split('.');
                if (a[1] == "pdf")
                {
                    objPresSet.SaveAs(url, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPDF, MsoTriState.msoTrue);
                    objPresSet.Close();
                    objApp.Quit();
                    File.Delete(Application.StartupPath + "/tmp.png");
                }
                else
                {
                    objPresSet.SaveAs(url, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
