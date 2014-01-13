using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartThai
{

    class ExamNode
    {
        public static int CHOICE = 1;
        public static int OBJ = 2;

        public int type;
        public int ansIndex;
        public string qustion;
        public string[] choice;
    }

    class Exam
    {
        private string[] smartLines;
        public Exam(string smartStr)
        {
            smartStr = smartStr.Replace('\t', '*');
            this.smartLines = Regex.Split(smartStr, "\r\n");
        }

        public Exam() { }

        private List<int[]> getEdges(int level)
        {
            List<int[]> list = new List<int[]>(); 
            for (int i = 0; i < smartLines.Length; i++)
            {
                if (smartLines[i] == new string('*', level) + "-Extrack Bullet-")
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (smartLines[j].Split('*').Length - 1 == level - 1)
                        {
                            int[] tmp = new int[] { 0, 0 };
                            tmp[0] = j;
                            tmp[1] = i;
                            list.Add(tmp);
                            break;
                        }
                    }
                }
            }
            return list;
        }

        public ExamNode examTypeOne() {
            Random rndQus = new Random();
            Random rndChot = new Random();
            Random rndChof = new Random();
            ExamNode no = new ExamNode();
            no.type = ExamNode.CHOICE;

            List<int[]> list = getEdges(2);
            
            if (list.Count < 2) return null;
            int c = 0;
            foreach (int[] l in list) 
            {
                if (l[1] - l[0] - 1 < 3)
                {
                    c++;
                }
            }

            if (c == list.Count) return null;

            int not = rndQus.Next(0, list.Count);
            int nof = rndQus.Next(0, list.Count);
            while (list[not][1] - list[not][0] - 1< 3 || not == nof)
            {
                not = rndQus.Next(0, list.Count);
            }
            int index = new Random().Next(4);
            no.ansIndex = index;
            no.qustion = "ข้อใดไม่ใช่ " + Regex.Replace(smartLines[list[not][0]],"[*]", "") + " ของ " + smartLines[0];
            no.choice = new string[4];
            no.choice[index] = Regex.Replace(smartLines[rndChot.Next(list[nof][0] + 1, list[nof][1] - 1)], "[*]", "");
            index = (++index) % 4;
            for (int i = 0; i < 3; i++) {
                do
                {
                    no.choice[index] = Regex.Replace(smartLines[rndChof.Next(list[not][0] + 1, list[not][1] - 1)], "[*]", "");
                } while (no.choice[index] == no.choice[(index + 1) % 4] ||
                        no.choice[index] == no.choice[(index + 2) % 4] ||
                        no.choice[index] == no.choice[(index + 3) % 4]);
                index = (++index)%4;
            }
            return no;
        }

        public ExamNode examTypeTwo()
        {
            Random rndQus = new Random();
            ExamNode no = new ExamNode();
            no.type = ExamNode.OBJ;

            List<int[]> list = getEdges(2);
            if (list.Count < 1) return null;

            int number = rndQus.Next(0, list.Count);
            no.qustion = "จงยกตัวอย่าง " + Regex.Replace(smartLines[list[number][0]], "[*]", "") + " ของ " + smartLines[0] + " มา 1 อย่าง";
            int size = list[number][1] - list[number][0] - 1;
            no.choice = new string[size];
            int c = 0;
            for (int i = list[number][0] + 1; i <= list[number][1] - 1; i++)
            {
                no.choice[c++] = Regex.Replace(smartLines[i], "[*]", "");
            }

            return no;
        }
    }
}
