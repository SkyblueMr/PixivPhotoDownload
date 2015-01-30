using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixivPhotoDownload
{
    public partial class LinkSave : DevComponents.DotNetBar.Office2007Form
    {
        public LinkSave()
        {
            InitializeComponent();
            link = new LinkOperating();
        }

        private LinkOperating link;

        private void LinkSave_Load(object sender, EventArgs e)
        {
            txtLink.Text = link.GetLink();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                link.SetLink(txtLink.Text);
                MessageBox.Show("保存成功！", "提醒");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message, "提醒");
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
