using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PixivPhotoDownload
{
    public class LinkOperating
    {
        public void IsFile()
        {
            if (!File.Exists("link.txt"))
            {
                File.Create("link.txt");
            }
        }

        public void Clear()
        {
            IsFile();
            StreamWriter sw = new StreamWriter("link.txt");
            sw.Write("");
            sw.Close();
        }

        public string GetLink()
        {
            IsFile();
            StreamReader sr = new StreamReader("link.txt");
            string link = sr.ReadToEnd();
            sr.Close();
            return link;
        }

        public int LinkCount()
        {
            IsFile();
            StreamReader sr = new StreamReader("link.txt");
            int count = 0;
            string tmp = "";
            while ((tmp = sr.ReadLine()) != null)
            {
                if (tmp != "")
                {
                    ++count;
                }
            }
            sr.Close();
            return count;
        }

        public void SetLink(string content)
        {
            IsFile();
            StreamWriter sw = new StreamWriter("link.txt");
            sw.Write(content);
            sw.Close();
        }

        public void CreateDir(string title)
        {
            Directory.CreateDirectory("Photos/" + title);
        }
    }
}
