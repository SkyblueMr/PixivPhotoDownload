using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PixivPhotoDownload
{
    public class LinkStatus
    {
        public LinkStatus()
        {
            m_Link = new Queue();
        }

        public LinkStatus(Queue queue)
        {
            m_Link = new Queue();
            m_Link = queue;
        }

        private Queue m_Link;

        public Queue Link
        {
            get { return m_Link; }
            set { m_Link = value; }
        }

        public void Add(Queue queue)
        {
            foreach(object obj in queue)
            {
                m_Link.Enqueue(obj);
            }
        }

        public bool Contains(object obj)
        {
            return m_Link.Contains(obj);
        }

        /// <summary>
        /// 查找队列里图片链接对应的源链接
        /// </summary>
        /// <param name="downloadLink">一个大小为3的字符串数组，下标0的储存源链接，下标为1的储存文件目录，下标为2的储存图片链接</param>
        /// <returns>返回源链接</returns>
        public string Contains(string downloadLink)
        {
            foreach (string[] link in m_Link)
            {
                if (link[2] == downloadLink)
                {
                    return link[0];
                }
            }
            return null;
        }

        public int Count()
        {
            return m_Link.Count;
        }

        public void Clear()
        {
            m_Link.Clear();
        }
    }
}
