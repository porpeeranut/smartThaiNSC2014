using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartThai
{
    class SummariBullet
    {
        private ArrayList clauses;
        public SummariBullet(ArrayList clauses)
        {
            this.clauses = clauses;
        }

        public SummariBullet() { }

        public void set(ArrayList clauses)
        {
            this.clauses = clauses;
        }

        private string fetureHighlight(string clause)
        {
            Match match = Regex.Match(clause, @"^<.+?>(.+?)<");
            if (match.Success) return match.Groups[1].Value;
            else return "";
        }

        private string fetureBracket(string clause)
        {
            Match match = Regex.Match(clause, @"^(.+?) [(]");
            if (match.Success) return match.Groups[1].Value;
            else return "";
        }

        private string fetureFirst(string clause)
        {
            string[] sm = clause.Split(' ');
            return sm[0];
        }

        public ArrayList getResult()
        {
            ArrayList result = new ArrayList();
            string tmp;
            foreach (string clause in clauses)
            {
                if ((tmp = fetureHighlight(clause)) == "")
                {
                    if ((tmp = fetureBracket(clause)) == "")
                    {
                        if (clause.Split(' ').Length > 2)
                        {
                            result.Add(clause.Split(' ')[0]);
                            
                        }
                        else
                        {
                            result.Add(clause);
                        }
                    }
                    else
                    {
                        result.Add(tmp);
                    }
                }
                else
                {
                    result.Add(tmp);
                }
            }
            return result;
        }
    }
}
