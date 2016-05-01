using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
namespace Clock
{
    public partial class frmClock : Form
    {

        int h, m, s;
        float secondAngel = 0f;

        private Image ImageH = Clock.Properties.Resources.trad_h;
        private Image ImageM = Clock.Properties.Resources.trad_m;
        private Image ImageS = Clock.Properties.Resources.trad_s;
        private Image ImageDot = Clock.Properties.Resources.trad_dot;
        private Image ImageHighlight = Clock.Properties.Resources.trad_highlights;
        private bool trans = false;
        private bool sec = true;
        private Point ptMouseOffset;
        //-----------------------
        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);

        [Flags]
        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        #region Interop Definitions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int WS_EX_TOPMOST = unchecked((int)0x00000008L);
        private const int WS_EX_TOOLWINDOW = unchecked((int)0x00000080);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const int HWND_TOPMOST = -1;
        #endregion
        //----------------------------------------
        [DllImport("user32.dll")]
        private static extern
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        //---------------------------------------

        /// <summary>
        /// Thumb Movement
        /// </summary>
        #region
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
            && (((int)m.WParam & 0xFFFF) == 5))
            {
                // Change SB_THUMBTRACK to SB_THUMBPOSITION
                m.WParam = (IntPtr)(((int)m.WParam & ~0xFFFF) | 4);
            }
            base.WndProc(ref m);

            if (m.Msg == 163 && this.ClientRectangle.Contains(this.PointToClient(new Point(m.LParam.ToInt32()))) && m.WParam.ToInt32() == 2)
                m.WParam = (IntPtr)1;
            base.WndProc(ref m);
            if (m.Msg == 132 && m.Result.ToInt32() == 1)
                m.Result = (IntPtr)2;

        }
        #endregion
        private const int CS_DROPSHADOW = 0x0020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                cp.ExStyle |= WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
                cp.Parent = IntPtr.Zero;
                //cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }

        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );

        public frmClock()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 30, 30));
            //SetWindowPos(this.Handle, (System.IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);

            //Double Buffer the form controls
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void myClock_MouseDown(object sender, MouseEventArgs e)
        {
            ptMouseOffset = new Point(-e.X, -e.Y);
        }

        private void myClock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point ptCurrMousePos = Control.MousePosition;

                ptCurrMousePos.Offset(ptMouseOffset.X, ptMouseOffset.Y);
                this.Location = ptCurrMousePos;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            h = DateTime.Now.Hour;
            m = DateTime.Now.Minute;
            s = DateTime.Now.Second;

            secondAngel = s / 60f * 360f + 4;
            tmr2.Enabled = true;
            this.Refresh();
        }


        private void tmr2_Tick(object sender, EventArgs e)
        {
            secondAngel = s / 60f * 360f;
            tmr2.Enabled = false;
            this.Refresh();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            //Hour
            e.Graphics.TranslateTransform(77.0f,75.0f);
            e.Graphics.RotateTransform(h / 12f * 360 + m / 60f * 360f / 12f);
            e.Graphics.DrawImage(ImageH, -6.5f, -64.5f, 13, 129);
            //Minute
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(77.0f, 75.0f);
            e.Graphics.RotateTransform(m / 60f * 360);
            e.Graphics.DrawImage(ImageM, -6.5f, -64.5f, 13, 129);
            //Second
            if (sec)
            {
                e.Graphics.ResetTransform();
                e.Graphics.TranslateTransform(77.0f, 75.0f);
                e.Graphics.RotateTransform(secondAngel);
                e.Graphics.DrawImage(ImageS, -6.5f, -64.5f, 13, 129);
            }
            //Dot
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(77.0f, 75.0f);
            e.Graphics.DrawImage(ImageDot, -6.5f, -64.5f, 13, 129);
            e.Graphics.ResetTransform();

            //Glass effect
            //e.Graphics.DrawImage(ImageHighlight,10.0f,10.0f,130,130);
            this.pbTop.BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By: \tAtul Meshram\nE-Mail: \t\tatul.meshram.akm@gmail.com\nContact: \t\t+91-8050606549\n\nGuided By: \tMrs. Sumitra Subrahmanya\n\nDepartment of Mathematical And Computational Sciences\nNITK, Surathkal, INDIA", "Clock", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void showSecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sec)
                sec = false;
            else
                sec = true;
        }

        private void transparencyONOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trans)
            {
                trans = false;
                this.Opacity = 1.0;
            }
            else
            {
                trans = true;
                this.Opacity = 0.25;
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            transparencyONOFFToolStripMenuItem.Checked = trans;
            showSecondToolStripMenuItem.Checked = sec;
        }

        private void pbTop_MouseEnter(object sender, EventArgs e)
        {
            if (trans)
                this.Opacity = 1.0;
        }

        private void pbTop_MouseHover(object sender, EventArgs e)
        {
            if (trans)
                this.Opacity = 1.0;
        }

        private void pbTop_MouseLeave(object sender, EventArgs e)
        {
            if (trans)
                this.Opacity = 0.25;
        }

        private void pbTop_MouseDown(object sender, MouseEventArgs e)
        {
            ptMouseOffset = new Point(-e.X, -e.Y);
        }

        private void pbTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point ptCurrMousePos = Control.MousePosition;

                ptCurrMousePos.Offset(ptMouseOffset.X, ptMouseOffset.Y);
                this.Location = ptCurrMousePos;
            }
        }
    }
}
