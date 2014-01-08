using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartThai
{
    class Web
    {
        private WebClient client;
        private Encoding charset;

        public Web(Encoding charset)
        {
            this.charset = charset;
            client = new WebClient();
        }
        public string getContent(string url)
        {
            try
            {
                Stream stream = client.OpenRead(url);
                StreamReader textReader = new StreamReader(stream, this.charset, true);
                return textReader.ReadToEnd();
            }
            catch
            {
                return "";
            }

        }
    }
}
