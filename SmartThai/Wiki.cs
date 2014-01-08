using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartThai
{
    class Wiki {
        private string html;
        private Segment sm;
        private SummariParagraph smmprg;
        private SummariBullet smmbl;
        private Web web;
        public static string[] ignore = new string[] { "ดูเพิ่ม", "อ้างอิง", "แหล่งข้อมูลอื่น", "หนังสืออ่านเพิ่ม", "ข้อมูลเพิ่มเติม", "รายการอ้างอิง", "รายการเพิ่มเติม" };

        public Wiki() {
            html = "";
            sm = new Segment(20);
            smmprg = new SummariParagraph(50);
            smmbl = new SummariBullet();
            web = new Web(Encoding.UTF8);
        }

        public Wiki(string html) {
            this.html = html;
            sm = new Segment(20);
            smmprg = new SummariParagraph(50);
        }

        public Boolean setUrl(string url) {
            this.html = web.getContent(url);
            if (html == "" || !this.canExec())
            {
                return false;
            }
            return true;
        }

        public Boolean canExec() {
            Match match = Regex.Match(html, @"<h2><span");
            if (match.Success) return true;
            else return false;
        }

        private Boolean isLowestLevel(string content, int level) {
            Match match = Regex.Match(content, "<h" + (level + 1) + "><span");
            if (match.Success) return false;
            else return true;
        }

        private string clearTag(string content) {
            content = Regex.Replace(content, @"<.+?>", "");
            content = Regex.Replace(content, @"[\[][0-9]+[\]]", "");
            return content;
        }

        private ArrayList getParagraphs(string content) {
            ArrayList list = new ArrayList();
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, "<p>(.+?)</p>");
                if (match.Success) list.Add(clearTag(match.Groups[1].Value));
            }
            return list;
        }

        private Boolean haveBullet(string content) {
            Match match1 = Regex.Match(content, "<ul>");
            Match match2 = Regex.Match(content, "<li>");
            if (match1.Success || match2.Success) return true;
            else return false;
        }

        private Boolean haveDt(string content)
        {
            Match match = Regex.Match(content, "<dt>");
            return match.Success;
        }

        private ArrayList getBullet(string content) {
            ArrayList list = new ArrayList();
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, "<li>(.+?)</li>");
                if (match.Success) list.Add(match.Groups[1].Value);
            }
            return list;
        }

        private ArrayList getDt(string content)
        {
            ArrayList list = new ArrayList();
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, "<dt>(.+?)</dt>");
                if (match.Success) list.Add(match.Groups[1].Value);
            }
            return list;
        }

        private ArrayList getSubcontent(string content, int level) {
            ArrayList list = new ArrayList();
            string[] subs = content.Split(new string[] { "<h" + level + "><span" }, StringSplitOptions.None);
            Boolean first = true;
            foreach (string sub in subs)
            {
                if (first)
                {
                    first = !first;
                    continue;
                }
                list.Add(sub);
            }
            return list;
        }

        private string getHeading(string content) {
            Match match = Regex.Match(content, "class=\"mw-headline\" id=\".+?\">(.+?)<");
            if (match.Success) return clearTag(match.Groups[1].Value);
            else return "";
        }

        private string getTitle() {
            Match match = Regex.Match(html, "<title>(.+?) -");
            if (match.Success) return match.Groups[1].Value;
            else return "";
        }

        public string getImage(string content)
        {
            Match match = Regex.Match(content, "<table class=\"infobox biota\".+?src=\"(.+?)\"", RegexOptions.Singleline);
            if (match.Success) return "http:" + match.Groups[1].Value;
            else
            {
                match = Regex.Match(content, "<div class=\"thumbinner\".+?src=\"(.+?)\"");
                if (match.Success) return "http:" + match.Groups[1].Value;
                else
                {
                    return "No Picture";
                }
            }
        }

        private string getMeaning() {
            Match match = Regex.Match(html, @"<p><b>(.+?)</p>");
            if (match.Success) return match.Groups[1].Value;
            else return "";
        }

        private string toLine(string content, int level) {
            string output = "";
            for (int i = 0; i < level - 1; i++) output+="\t";
            if (content == "") content = "Summarization Error";
            return output + content + "\r\n";
        }

        public string recurString(string content, int level) {
            if (isLowestLevel(content, level)) {
                if (ignore.Contains(getHeading(content))) return "";
                string output = toLine(getHeading(content), level);
                
                if (haveBullet(content)) {
                    
                    ArrayList list = getBullet(content);
                    smmbl.set(list);
                    foreach (string l in smmbl.getResult())
                    {
                        string b = clearTag(l);
                        if (b.Length < 20 && !b.Contains(' '))
                        {
                            string img = getImage(web.getContent("http://th.wikipedia.org/wiki/" + l));
                            if (img != "No Picture") b += "[SMARTTHAI]" + img;
                        }
                        output += toLine(b, level + 1);
                    }
                    string p = toLine("-Extrack Bullet-", level + 1);
                    foreach (string l in list)
                    {
                       p += toLine(clearTag(l), level + 1);
                    }
                    output += p;
                }
                else if (haveDt(content))
                {
                    ArrayList list = getDt(content);
                    foreach (string l in list)
                    {
                        output += toLine(l, level + 1);
                    }
                }
                else {
                    ArrayList list = getParagraphs(content);
                    if (list.Count == 0) return "";
                    string p = "";
                    foreach (string l in list) {
                        p += l + "[br]";
                        sm.set(l);
                        ArrayList segments = sm.getSegment();
                        smmprg.set(segments);
                        smmprg.fetureLocation();
                        smmprg.fetureTitleWord(getTitle());
                        foreach (string result in smmprg.getResult())
                        {
                            output += toLine(result, level + 1);
                        }
                    }
                    output += toLine("-Extrack Paragraph-", level + 1);
                    output += toLine(p.Substring(0,p.Length - 4), level + 1);
                }
                return output;
            } else {
                string output = "";
                if (level != 1) output += toLine(getHeading(content), level);
                else
                {
                    output += toLine(getTitle(), 1);
                    output += toLine(getImage(html), 2);
                    string meaning = clearTag(getMeaning());
                    sm.set(meaning);
                    smmprg.set(sm.getSegment());
                    smmprg.fetureLocation();
                    smmprg.fetureTitleWord(getTitle());
                    foreach (string result in smmprg.getResult())
                    {
                        output += toLine(result, 2);
                    }
                }
                ArrayList list = getSubcontent(content, level+1);

                foreach (string l in list) {
                    output += recurString(l, level + 1);
                }
                return output;
            }
        }

        public string toString() {
            return recurString(html, 1);
        }
    }
}
