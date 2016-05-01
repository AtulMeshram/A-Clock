namespace Clock
{
    partial class frmClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClock));
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.tmr2 = new System.Windows.Forms.Timer(this.components);
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyONOFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.SuspendLayout();
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmr2
            // 
            this.tmr2.Interval = 30;
            this.tmr2.Tick += new System.EventHandler(this.tmr2_Tick);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSecondToolStripMenuItem,
            this.transparencyONOFFToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cms.Name = "contextMenuStrip1";
            this.cms.Size = new System.Drawing.Size(228, 108);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // showSecondToolStripMenuItem
            // 
            this.showSecondToolStripMenuItem.Name = "showSecondToolStripMenuItem";
            this.showSecondToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.showSecondToolStripMenuItem.Text = "Show &Second";
            this.showSecondToolStripMenuItem.Click += new System.EventHandler(this.showSecondToolStripMenuItem_Click);
            // 
            // transparencyONOFFToolStripMenuItem
            // 
            this.transparencyONOFFToolStripMenuItem.Name = "transparencyONOFFToolStripMenuItem";
            this.transparencyONOFFToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.transparencyONOFFToolStripMenuItem.Text = "&Transparency ON/OFF";
            this.transparencyONOFFToolStripMenuItem.Click += new System.EventHandler(this.transparencyONOFFToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Clock.Properties.Resources.Info_24;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Clock.Properties.Resources.Close;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cms;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Clock";
            this.notifyIcon.Visible = true;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Transparent;
            this.pbTop.BackgroundImage = global::Clock.Properties.Resources.trad_highlights;
            this.pbTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbTop.ContextMenuStrip = this.cms;
            this.pbTop.ErrorImage = null;
            this.pbTop.InitialImage = null;
            this.pbTop.Location = new System.Drawing.Point(0, 0);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(155, 150);
            this.pbTop.TabIndex = 2;
            this.pbTop.TabStop = false;
            this.pbTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTop_MouseDown);
            this.pbTop.MouseEnter += new System.EventHandler(this.pbTop_MouseEnter);
            this.pbTop.MouseLeave += new System.EventHandler(this.pbTop_MouseLeave);
            this.pbTop.MouseHover += new System.EventHandler(this.pbTop_MouseHover);
            this.pbTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbTop_MouseMove);
            // 
            // frmClock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Clock.Properties.Resources.ClockBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(155, 150);
            this.Controls.Add(this.pbTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(155, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(155, 150);
            this.Name = "frmClock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock";
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Timer tmr2;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem showSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyONOFFToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbTop;


    }
}

