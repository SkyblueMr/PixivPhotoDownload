namespace PixivPhotoDownload
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLink = new DevComponents.DotNetBar.ButtonX();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.btnDownLoad = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lvwLinkShow = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrCount = new System.Windows.Forms.Timer(this.components);
            this.lblLinkCount = new DevComponents.DotNetBar.LabelX();
            this.lblInfo = new DevComponents.DotNetBar.LabelX();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.链接管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空链接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.访问CG部落ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLink
            // 
            this.btnLink.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLink.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLink.Location = new System.Drawing.Point(115, 43);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(75, 23);
            this.btnLink.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLink.TabIndex = 0;
            this.btnLink.Text = "链接管理";
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(196, 43);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空链接";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDownLoad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDownLoad.Location = new System.Drawing.Point(277, 43);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDownLoad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDownLoad.TabIndex = 2;
            this.btnDownLoad.Text = "下载图片";
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(115, 73);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 16);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "链接数：";
            // 
            // lvwLinkShow
            // 
            this.lvwLinkShow.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwLinkShow.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            // 
            // 
            // 
            this.lvwLinkShow.Border.Class = "ListViewBorder";
            this.lvwLinkShow.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvwLinkShow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwLinkShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvwLinkShow.FullRowSelect = true;
            this.lvwLinkShow.GridLines = true;
            this.lvwLinkShow.Location = new System.Drawing.Point(0, 94);
            this.lvwLinkShow.Name = "lvwLinkShow";
            this.lvwLinkShow.Size = new System.Drawing.Size(466, 203);
            this.lvwLinkShow.TabIndex = 3;
            this.lvwLinkShow.UseCompatibleStateImageBehavior = false;
            this.lvwLinkShow.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "链接";
            this.columnHeader1.Width = 245;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "图片总数";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "已下载图片";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "进度(%)";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 61;
            // 
            // tmrCount
            // 
            this.tmrCount.Interval = 200;
            this.tmrCount.Tick += new System.EventHandler(this.tmrCount_Tick);
            // 
            // lblLinkCount
            // 
            // 
            // 
            // 
            this.lblLinkCount.BackgroundStyle.Class = "";
            this.lblLinkCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLinkCount.Location = new System.Drawing.Point(177, 72);
            this.lblLinkCount.Name = "lblLinkCount";
            this.lblLinkCount.Size = new System.Drawing.Size(56, 16);
            this.lblLinkCount.TabIndex = 2;
            // 
            // lblInfo
            // 
            // 
            // 
            // 
            this.lblInfo.BackgroundStyle.Class = "";
            this.lblInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(134, 13);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(198, 23);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载图片ToolStripMenuItem,
            this.链接管理ToolStripMenuItem,
            this.清空链接ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.帮助ToolStripMenuItem,
            this.访问CG部落ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(131, 142);
            // 
            // 下载图片ToolStripMenuItem
            // 
            this.下载图片ToolStripMenuItem.Name = "下载图片ToolStripMenuItem";
            this.下载图片ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.下载图片ToolStripMenuItem.Text = "下载图片";
            this.下载图片ToolStripMenuItem.Click += new System.EventHandler(this.下载图片ToolStripMenuItem_Click);
            // 
            // 链接管理ToolStripMenuItem
            // 
            this.链接管理ToolStripMenuItem.Name = "链接管理ToolStripMenuItem";
            this.链接管理ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.链接管理ToolStripMenuItem.Text = "链接管理";
            this.链接管理ToolStripMenuItem.Click += new System.EventHandler(this.链接管理ToolStripMenuItem_Click);
            // 
            // 清空链接ToolStripMenuItem
            // 
            this.清空链接ToolStripMenuItem.Name = "清空链接ToolStripMenuItem";
            this.清空链接ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.清空链接ToolStripMenuItem.Text = "清空链接";
            this.清空链接ToolStripMenuItem.Click += new System.EventHandler(this.清空链接ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(127, 6);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 访问CG部落ToolStripMenuItem
            // 
            this.访问CG部落ToolStripMenuItem.Name = "访问CG部落ToolStripMenuItem";
            this.访问CG部落ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.访问CG部落ToolStripMenuItem.Text = "访问CG部落";
            this.访问CG部落ToolStripMenuItem.Click += new System.EventHandler(this.访问CG部落ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnDownLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(466, 297);
            this.ContextMenuStrip = this.cmsMenu;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvwLinkShow);
            this.Controls.Add(this.lblLinkCount);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P站图片采集器              By  Miss、时代_";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnLink;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.ButtonX btnDownLoad;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ListViewEx lvwLinkShow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Timer tmrCount;
        private DevComponents.DotNetBar.LabelX lblLinkCount;
        private DevComponents.DotNetBar.LabelX lblInfo;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 访问CG部落ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 链接管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空链接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;

    }
}

