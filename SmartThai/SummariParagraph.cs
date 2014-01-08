using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartThai
{
    class SummariParagraph
    {
        private ArrayList segments;
        private ArrayList scores;
        private int percent;

        public SummariParagraph(ArrayList segment, int percent)
        {
            this.segments = segment;
            this.percent = percent;
            this.scores = new ArrayList();
            for (int i = 0; i < this.segments.Count; i++)
            {
                this.scores.Add(0);
            }

        }

        public SummariParagraph(int percent)
        {
            this.segments = null;
            this.percent = percent;
            this.scores = null;
        }

        public void set(ArrayList segments)
        {
            this.segments = segments;
            this.scores = new ArrayList();
            for (int i = 0; i < this.segments.Count; i++)
            {
                this.scores.Add(0);
            }
        }

        public void fetureLocation()
        {
            for (int i = 0; i < this.segments.Count; i++)
            {
                this.scores[i] = (int)this.scores[i] + (100 - i);
            }
        }

        public void fetureTitleWord(string title)
        {
            for (int i = 0; i < this.segments.Count; i++)
            {
                Match match = Regex.Match((string)this.segments[i], title);
                if (match.Success)
                {
                    this.scores[i] = (int)this.scores[i] + 100;
                }
            }
        }

        public ArrayList getScore()
        {
            return scores;
        }

        public ArrayList getResult()
        {
            int max = (this.segments.Count * percent) / 100;
            if (max == 0) max = 1;
            ArrayList scores_sort = (ArrayList)scores.Clone();
            ArrayList result = new ArrayList();
            scores_sort.Sort();
            scores_sort.Reverse();
            for (int i = 0; i < max; i++)
            {
                result.Add(this.segments[scores.IndexOf(scores_sort[i])]);
            }
            return result;
        }
    }
}
