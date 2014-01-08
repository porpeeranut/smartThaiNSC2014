using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartThai
{
    class Smarttree
    {
        private TreeView tViewCut;
        private TreeNode root, nodeCut;
        public Smarttree(TreeView tView)
        {
            this.tViewCut = tView;
            root = tViewCut.GetNodeAt(0, 0);
        }

        public void set(string strIn)
        {
            TreeNode node = null;
            nodeCut = null;
            string[] str = Regex.Split(strIn, "\r\n");
            int index = 0;
            root = stringToTreeNodeRecursion(node, 1, ref str, ref index);
            index = 0;
            nodeCut = stringToTreeNodeCutRecursion(nodeCut, 1, ref str, ref index);
            tViewCut.BeginUpdate();
            tViewCut.Nodes.Clear();
            tViewCut.Nodes.Add(nodeCut);
            tViewCut.ExpandAll();
            tViewCut.EndUpdate();
        }

        private TreeNode stringToTreeNodeRecursion(TreeNode node, int level, ref string[] str, ref int index)
        {
            int tab, nodeCount = 0;
            while (index < str.Length - 1)
            {
                tab = 0;
                foreach (char ch in str[index])
                {
                    if (ch == '\t')
                        tab++;
                    else
                        break;
                }
                if (node == null)
                    node = new TreeNode(str[index].Trim());
                else if (tab > level)
                {
                    stringToTreeNodeRecursion(node.Nodes[nodeCount - 1], level + 1, ref str, ref index);
                    index--;
                }
                else if (tab == level)
                {
                    node.Nodes.Add(str[index].Trim());
                    nodeCount++;
                }
                else if (tab < level)
                    return null;
                index++;
            }
            return node;
        }

        private TreeNode stringToTreeNodeCutRecursion(TreeNode node, int level, ref string[] str, ref int index)
        {
            int tab, nodeCount = 0;
            bool specialText = false;
            int tabSpecial = 0;
            while (index < str.Length - 1)
            {
                if (index == 1) {
                    index++;
                    continue;
                }
                tab = 0;
                foreach (char ch in str[index])
                {
                    if (ch == '\t')
                        tab++;
                    else
                        break;
                }
                if (str[index].Trim() == "-Extrack Bullet-" || str[index].Trim() == "-Extrack Paragraph-")
                {
                    specialText = true;
                    tabSpecial = tab;
                    index++;
                    continue;
                }
                if (specialText && tab == tabSpecial) {
                    index++;
                    continue;
                } else
                    specialText = false;
                if (node == null)
                    node = new TreeNode(str[index].Trim());
                else if (tab > level)
                {
                    stringToTreeNodeCutRecursion(node.Nodes[nodeCount - 1], level + 1, ref str, ref index);
                    index--;
                }
                else if (tab == level)
                {
                    if (str[index].IndexOf("[SMARTTHAI]") != -1)
                        node.Nodes.Add(Regex.Split(str[index], @"\[SMARTTHAI\]")[0].Trim());
                    else
                        node.Nodes.Add(str[index].Trim());
                    nodeCount++;
                }
                else if (tab < level)
                    return null;
                index++;
            }
            return node;
        }

        public string get()
        {
            string[] cut = Regex.Split(treeNodeToStringRecursion("", nodeCut, 0), "\r\n");
            string[] full = Regex.Split(treeNodeToStringRecursion("", root, 0), "\r\n");
            int indexCut = 0, indexFull = 0;
            int tabCut = 0, tabFull = 0;
            while (indexCut < cut.Length - 1) {
                foreach (char ch in cut[indexCut]) {
                    if (ch == '\t')
                        tabCut++;
                    else
                        break;
                }
                bool specialText = false;
                int tabSpecial = 0;
                while (indexFull < full.Length - 1) {
                    if (indexFull == 1) {
                        indexFull++;
                        continue;
                    }
                    tabFull = 0;
                    foreach (char ch in full[indexFull]) {  
                        if (ch == '\t')
                            tabFull++;
                        else
                            break;
                    }
                    if (full[indexFull].Trim() == "-Extrack Bullet-" || full[indexFull].Trim() == "-Extrack Paragraph-") {
                        specialText = true;
                        tabSpecial = tabFull;
                        indexFull++;
                        continue;
                    }
                    if (specialText && tabFull == tabSpecial) {
                        indexFull++;
                        continue;
                    } else
                        break;
                }
                if (cut[indexCut] != full[indexFull]) {
                    string link = "";
                    if (full[indexFull].IndexOf("[SMARTTHAI]") != -1) {
                        link = "[SMARTTHAI]" + Regex.Split(full[indexFull], @"\[SMARTTHAI\]")[1];
                    }
                    full[indexFull] = cut[indexCut] + link;
                }
                indexFull++;
                indexCut++;
            }
            string strOut = "";
            for (int i = 0; i < full.Length - 1; i++) {
                strOut += full[i] + "\r\n";
            }
            return strOut;
        }

        private string treeNodeToStringRecursion(string str, TreeNode nodeIn, int level)
        {
            str += new String('\t', level) + nodeIn.Text + "\r\n";
            for (int index = 0; index < nodeIn.Nodes.Count; index++)
            {
                if (nodeIn.Nodes[index].Nodes.Count > 0)
                    str = treeNodeToStringRecursion(str, nodeIn.Nodes[index], level + 1);
                else
                    str += new String('\t', level + 1) + nodeIn.Nodes[index].Text + "\r\n";
            }
            return str;
        }
    }
}