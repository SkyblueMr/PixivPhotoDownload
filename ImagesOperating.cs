using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PixivPhotoDownload
{
    public class ImagesOperating
    {
        public ImagesOperating()
        { 
        }

        public static void DownLoadImage(string url, string path)
        {
            if (!Directory.Exists("Photos"))
            {
                Directory.CreateDirectory("Photos");
            }
            if (!Directory.Exists("Photos/" + path))
            {
                Directory.CreateDirectory("Photos/" + path);
            }
            int i = url.LastIndexOf('/');
            string fileName = "Photos/" + path + url.Substring(i, url.Length - i);
            WebClient web = new WebClient();
            web.Headers.Set(HttpRequestHeader.Referer, url);
            web.DownloadFile(url, fileName);
        }
    }
}
