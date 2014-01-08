using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartThai
{
    class Segment
    {
        private string paragraph;
        public static string[] conj_bitween = new string[] { "คือ", "และ", "เพื่อ", "หาก", "ซึ่ง", "จากนั้น", "หรือ", "โดย", "ถูกกำหนด", "ที่", "ช่วย", "ชื่อ", "จะ", "ซึ่งในบางกรณี", "ๆ", "รวมไปถึง", "นำมา", "เป็น", "จัดเป็น", "นอกจากนี้", "ก็", "เรียกว่า", "เมื่อราว", "ว่า", ":", "ใช้", "ทรงพระกรุณาโปรดเกล้าฯ", "ทรงพระกรุณา" };
        public static string[] conj_before = new string[] { "เมื่อ", "ถ้า", "ความแตกต่าง", "สำหรับ" };
        private int smallest_clause;

        public Segment(string paragraphs, int smallest_clause)
        {
            this.paragraph = paragraphs;
            this.smallest_clause = smallest_clause;

        }

        public Segment(int smallest_clause)
        {
            paragraph = "";
            this.smallest_clause = smallest_clause;
        }

        public void set(string paragraphs)
        {
            this.paragraph = paragraphs;
        }

        private Boolean isNumber(string clause)
        {
            Match match = Regex.Match(clause, @"[0-9]+");
            return match.Success;
        }

        private Boolean isConjBitween(string clause)
        {
            return conj_bitween.Contains(clause);
        }

        private Boolean lastConjBitween(string clause)
        {
            foreach (string c in conj_bitween)
            {
                Match match = Regex.Match(clause, c + @"$");
                if (match.Success) return true;
            }
            return false;
        }

        private Boolean firstConjBitween(string clause)
        {
            foreach (string c in conj_bitween)
            {
                Match match = Regex.Match(clause, @"^" + c);
                if (match.Success) return true;
            }
            return false;
        }

        private Boolean firstlastConjBitween(string clause)
        {
            return firstConjBitween(clause) && lastConjBitween(clause);
        }

        private Boolean ConjBefore(string clause)
        {
            foreach (string c in conj_before)
            {
                Match match = Regex.Match(clause, @"^" + c);
                if (match.Success) return true;
            }
            return false;
        }

        private string cutUseless(string paragraph)
        {
            paragraph = Regex.Replace(paragraph, @"เช่น (.+? )+และ(.+?) ", " ");
            paragraph = Regex.Replace(paragraph, @"[(].+?[)]", "");
            return paragraph;
        }

        public ArrayList getSegment()
        {
            ArrayList segment = new ArrayList();
            string a = cutUseless(paragraph);
            string[] clauses = a.Split(' ');
            Boolean next = false;
            foreach (string clause in clauses)
            {
                if (isConjBitween(clause))
                {
                    segment[segment.Count - 1] += " " + clause;
                    next = true;
                }
                else if (segment.Count == 0)
                {
                    segment.Add(clause);
                    next = true;
                }
                else if (isNumber(clause))
                {
                    segment[segment.Count - 1] += " " + clause;
                    next = true;
                }
                else if (ConjBefore(clause))
                {
                    segment.Add(clause);
                    next = true;
                }
                else if (firstlastConjBitween(clause))
                {
                    segment[segment.Count - 1] += " " + clause;
                    next = true;
                }
                else if ((lastConjBitween(clause) && next))
                {
                    segment[segment.Count - 1] += " " + clause;
                    next = true;
                }
                else if (firstConjBitween(clause))
                {
                    segment[segment.Count - 1] += " " + clause;
                }
                else if (lastConjBitween(clause))
                {
                    segment.Add(clause);
                    next = true;
                }
                else if (next)
                {
                    segment[segment.Count - 1] += " " + clause;
                    next = false;
                }
                else if (clause.Length > this.smallest_clause)
                {
                    segment.Add(clause);
                }
            }
            return segment;
        }
    }
}
