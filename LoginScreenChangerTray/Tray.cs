using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginScreenChangerTray
{
    public partial class Tray : Form
    {

        public Tray()
        {
            InitializeComponent();

            TrayMenu = new ContextMenuStrip();
            TrayMenu.Items.Add("Change Settings", null, OpenSettings);
            TrayMenu.Items.Add("Exit", null, OnExit);

            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "Login Screen Settings";

            TrayIcon.Icon = Icon.FromHandle(Properties.Resources.TrayPng.GetHicon());
            TrayIcon.ContextMenuStrip = TrayMenu;
            TrayIcon.Visible = true;

            TrayIcon.MouseClick += TrayIconClick;
            TrayIcon.MouseDoubleClick += TrayIconClick;
        }

        protected void OpenSettings(object sender, EventArgs e)
        {
            var form = new SettingsChanger();
            form.Show();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }

        protected void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void TrayIconClick(object sender, MouseEventArgs e)
        {
            TrayMenu.Show(new Point(Cursor.Position.X - 155, Cursor.Position.Y - 70));
        }

        private NotifyIcon TrayIcon { get; set; }
        private ContextMenuStrip TrayMenu { get; set; }
    }
}
