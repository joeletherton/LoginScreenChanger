using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using LoginScreenCommon;

namespace LoginScreenChangerTray
{
    public partial class SettingsChanger : Form
    {
        public SettingsChanger()
        {
            InitializeComponent();

            Icon = Icon.FromHandle(Properties.Resources.TrayPng.GetHicon());
            Left = Screen.FromControl(this).Bounds.Width - 450;
            Top = Screen.FromControl(this).Bounds.Height - 230;

            var settings = new LoginScreenSettings();
            settings.LoadSettings();

            txtImageDirectory.Text = settings.ImagePath;
            txtRotationDelay.Text = settings.Interval.ToString(CultureInfo.InvariantCulture);
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSaveChangesClick(object sender, EventArgs e)
        {
            var settings = new LoginScreenSettings();

            int interval;
            int.TryParse(txtRotationDelay.Text, out interval);

            if (interval > 0)
                settings.Interval = interval;

            if (Directory.Exists(txtImageDirectory.Text))
                settings.ImagePath = txtImageDirectory.Text;

            var writer = new XmlSerializer(typeof(LoginScreenSettings));

            if (!Directory.Exists(settings.SettingsFolder))
            {
                Directory.CreateDirectory(settings.SettingsFolder);
            }

            var file = new StreamWriter(settings.SettingsLocation);
            writer.Serialize(file, settings);
            file.Close();

            this.Hide();
        }

        private void BtnSelectFolderClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
                txtImageDirectory.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
