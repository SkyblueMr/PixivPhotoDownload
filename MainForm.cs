using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;

namespace PixivPhotoDownload
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007Form
    {
        public MainForm()
        {
            InitializeComponent();
            Reset();
        }

        private LinkOperating link;
        private FileSystemWatcher watcher;
        private PageOperating page;
        private bool IsChange;
        private Hashtable titleAndLink;
        private Queue generaLink;
        private Thread m_Thread;
        private Thread[] m_ImagesThread;
        private Queue webQueue;
        private LinkStatus status;//链接查询类
        private int threadCount;//下载图片进程数
        private int imagesCount = 0;//已下载图片数
        private int imagesTotal = 0;//图片总数

        private void Reset()
        {
            link = new LinkOperating();
            lblLinkCount.Text = link.LinkCount().ToString();
            IsChange = false;
            page = new PageOperating();
            link = new LinkOperating();
            titleAndLink = new Hashtable();
            generaLink = new Queue();
            webQueue = new Queue();
            status = new LinkStatus();
        }

        private void Init()
        {
            //如果图片数量小于5，则将下载图片线程设置为5个，否则线程数量等于要下载的图片数量
            if(5 > (threadCount = link.LinkCount()))
            {
                threadCount = 5;
            }
            
            m_ImagesThread = new Thread[threadCount];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            link.Clear();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            LinkSave save = new LinkSave();
            save.ShowDialog();
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCount_Tick(object sender, EventArgs e)
        {
            lblLinkCount.Text = link.LinkCount().ToString() ;

            if (IsChange)
            {
                IsChange = false;
                if (!File.Exists("link.txt"))
                {
                    File.Create("link.txt");
                }
                UpdataListView();
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (btnDownLoad.Text.Equals("下载图片"))
            {
                UpdataListView();
                if (lblLinkCount.Text == "0")
                {
                    MessageBox.Show("链接不能为空！", "提醒");
                    return;
                }
                tmrCount.Stop();
                btnDownLoad.Text = "停止下载";
                下载图片ToolStripMenuItem.Text = "停止下载";
                
                lblInfo.Text = "正在分析链接...";        
                btnLink.Enabled = false;
                btnClear.Enabled = false;
                链接管理ToolStripMenuItem.Enabled = false;
                清空链接ToolStripMenuItem.Enabled = false;
                ThreadStart ts = new ThreadStart(Parse);
                m_Thread = new Thread(ts);
                m_Thread.IsBackground = true;
                m_Thread.Start();

            }
            else
            {
                m_Thread.Abort();
                try
                {
                    for (int i = 0; i < threadCount; ++i)
                    {
                        m_ImagesThread[i].Abort();
                    }
                }
                catch (Exception)
                { 
                }
                UpdataListView();
                tmrCount.Start();
                btnDownLoad.Text = "下载图片";
                下载图片ToolStripMenuItem.Text = "下载图片";
                lblInfo.Text = "";
                btnLink.Enabled = true;
                btnClear.Enabled = true;
                链接管理ToolStripMenuItem.Enabled = true;
                清空链接ToolStripMenuItem.Enabled = true;
                下载图片ToolStripMenuItem.Enabled = true;
                Reset();
            }
        }

        private void Parse()
        {
            page = ParsePage.Start();//解析下载页面
            titleAndLink = page.TitleAndLink;
            generaLink = page.GeneraLink;
            lblInfo.Invoke(new MethodInvoker(delegate{
                lblInfo.Text = "解析完成了喵~~ 正在下载图片...";
                }));

            Init();

            lvwLinkShow.Invoke(new MethodInvoker(delegate
            {
                foreach (DictionaryEntry de in titleAndLink)
                {
                    if (((Queue)de.Value).Count == 0)
                    {
                        continue;
                    }
                    for (int i = 0; i < lvwLinkShow.Items.Count; ++i)
                    {
                        if (lvwLinkShow.Items[i].SubItems[0].Text == ((string[])((Queue)de.Value).Peek())[0])
                        {
                            lvwLinkShow.Items[i].SubItems[1].Text = ((Queue)de.Value).Count.ToString();
                        }
                    }
                }

            }));

            imagesTotal = generaLink.Count;
            status.Add(generaLink);//储存链接到查询类

            for (int i = 0; i < threadCount; ++i)
            {
                ThreadStart ts = new ThreadStart(Process);
                m_ImagesThread[i] = new Thread(ts);
                m_ImagesThread[i].IsBackground = true;
                m_ImagesThread[i].Start();
            }
        }

        private void Process()
        {
            while (generaLink.Count > 0)
            {
                string[] str = (string[])(generaLink.Dequeue());
                DownLoadImage(str[2], str[1]);
            }
        }

        /// <summary>
        /// 更新ListView控件
        /// </summary>
        private void UpdataListView()
        {
            lvwLinkShow.Items.Clear();
            StreamReader reader = new StreamReader("link.txt");
            string tmp = "";
            while ((tmp = reader.ReadLine()) != null)
            {
                if (tmp != "")
                {
                    ListViewItem items = new ListViewItem(new string[] { tmp, "0", "0", "0 %" });
                    lvwLinkShow.Items.Add(items);
                }
            }

            reader.Dispose();
            reader.Close();
        }

        /// <summary>
        /// link.txt文件更改事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnFileChange(Object source, FileSystemEventArgs e)
        {
            IsChange = true;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdataListView();
            if (!File.Exists("link.txt"))
            {
                File.Create("link.txt");
            }
            tmrCount.Start();
            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.Size;
            watcher.Path = Application.StartupPath;
            watcher.Filter = "link.txt";
            watcher.IncludeSubdirectories = false;
            watcher.Changed += new FileSystemEventHandler(OnFileChange);
            watcher.EnableRaisingEvents = true;

        }

        private void 访问CG部落ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cgbolo.com/");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }

        private void 下载图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDownLoad_Click(sender, e);
        }

        private void 链接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLink_Click(sender, e);
        }

        private void 清空链接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
        }


        public void DownLoadImage(string url, string path)
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
            try
            {
                WebClient web = new WebClient();
                webQueue.Enqueue(web);
                web.Headers.Set(HttpRequestHeader.Referer, url);
                web.BaseAddress = url;
                web.DownloadFileCompleted += new AsyncCompletedEventHandler(web_DownloadFileCompleted);
                web.DownloadFileAsync(new Uri(url), fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                DownLoadImage(url, path);
            }
        }

        public void web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //labelX1.BeginInvoke(new MethodInvoker(delegate
            //    {
            //        labelX1.Text = ((int.Parse(lblLinkCount.Text)) + 1).ToString();
            //    }));
            WebClient web = new WebClient();
            web = (WebClient)sender;
            string baseLink = status.Contains(web.BaseAddress);
            if (null != baseLink)
            {
                lvwLinkShow.Invoke(new MethodInvoker(delegate
                {
                    for (int j = 0; j < lvwLinkShow.Items.Count; ++j)
                    {
                        if (lvwLinkShow.Items[j].SubItems[0].Text == baseLink)
                        {
                            Double count = int.Parse((lvwLinkShow.Items[j].SubItems[1].Text));
                            Double num = int.Parse((lvwLinkShow.Items[j].SubItems[2].Text));
                            lvwLinkShow.Items[j].SubItems[2].Text = (++num).ToString();
                            lvwLinkShow.Items[j].SubItems[3].Text = Regex.Replace(((num / count) * 100).ToString(), @"\.\d*", "") + " %";
                            ++imagesCount;

                            //下载完成
                            if (imagesCount >= imagesTotal)
                            {
                                btnDownLoad.Enabled = false;
                                lblInfo.Text = "下载成功！";
                                lblInfo.Text = "";
                                m_Thread.Abort();
                                for (int n = 0; n < threadCount; ++n)
                                {
                                    m_ImagesThread[n].Abort();
                                }
                                tmrCount.Start();
                                btnDownLoad.Text = "下载图片";
                                下载图片ToolStripMenuItem.Text = "下载图片";
                                链接管理ToolStripMenuItem.Enabled = true;
                                清空链接ToolStripMenuItem.Enabled = true;
                                下载图片ToolStripMenuItem.Enabled = true;
                                btnDownLoad.Enabled = true;
                                btnLink.Enabled = true;
                                btnClear.Enabled = true;
                                Reset();
                                try
                                {
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                    player.SoundLocation = "Music/cat.wav";
                                    player.Load();
                                    player.Play();
                                }
                                catch (Exception)
                                { 
                                }
                            }
                        }
                    }
                }));
            }
        }
    }
}
