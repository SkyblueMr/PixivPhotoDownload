using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PixivPhotoDownload
{
    public class ParsePage
    {
        public static PageOperating Start()
        {
            PageOperating page = new PageOperating();

            StreamReader reader = new StreamReader("link.txt");
            string tmp = "";
            while ((tmp = reader.ReadLine()) != null)
            {
                if (tmp != "")
                {
                    page.GetPage(tmp);
                }
            }

            reader.Dispose();
            reader.Close();

            return page;
        }
    }
}
