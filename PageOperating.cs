using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PixivPhotoDownload
{
    public class PageOperating
    {
        public PageOperating()
        {
            reset();
        }

        private Hashtable titleAndLink;

        public Hashtable TitleAndLink
        {
            get { return titleAndLink; }
            set { titleAndLink = value; }
        }

        private Queue generaLink;

        public Queue GeneraLink
        {
            get { return generaLink; }
            set { generaLink = value; }
        }

        public void reset()
        {
            titleAndLink = new Hashtable();
            GeneraLink = new Queue();
        }

        /// <summary>
        /// 下载页面
        /// </summary>
        /// <param name="url">链接</param>
        public void GetPage(string url)
        {
            WebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string tmp = reader.ReadToEnd();
            response.Close();
            reader.Close();
            ParseCode(tmp, url);
        }

        public void ParseCode(string code, string uri)
        {
            try
            {
                Regex regexTitle = new Regex(@"(<title>)(.*?)(</title>)", RegexOptions.IgnoreCase);
                MatchCollection mc = regexTitle.Matches(code);
                string title = "";
                foreach (Match M in mc)
                {
                    title = M.Groups[0].Value;
                }
                title = Regex.Replace(title, "(<title>)|(</title>)", "", RegexOptions.IgnoreCase);

                Regex regexLink = new Regex(@"unshift\('(.*?)'\)", RegexOptions.IgnoreCase);
                MatchCollection mcLink = regexLink.Matches(code);
                string url = "";
                Queue linkQueue = new Queue();
                foreach (Match M in mcLink)
                {
                    url = M.Groups[0].Value;
                    url = Regex.Replace(url, @"(unshift\(')|('\))", "", RegexOptions.IgnoreCase);
                    string[] strUrl = new string[3]{uri, title, url};
                    linkQueue.Enqueue(strUrl);
                    generaLink.Enqueue(strUrl);
                }

                titleAndLink.Add(title, linkQueue);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }
        }
    }
}
