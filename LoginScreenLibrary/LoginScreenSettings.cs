using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LoginScreenCommon
{
    [Serializable]
    public class LoginScreenSettings
    {
        public const int DEFAULT_INTERVAL = 30000;
        public const string DEFAULT_IMAGE_PATH = @"C:\Windows\System32\oobe\info\backgrounds";
        public const string SETTINGS_FOLDERNAME = @"LoonyLogins\LoginScreenChanger\";
        public const string SETTINGS_FILENAME = @"LoginScreenWatcher.lsc";

        public LoginScreenSettings()
            : this(DEFAULT_INTERVAL, DEFAULT_IMAGE_PATH)
        {
        }

        public LoginScreenSettings(int interval)
            : this(interval, DEFAULT_IMAGE_PATH)
        {
        }

        public LoginScreenSettings(int interval, string imagePath)
        {
            if (interval != Interval)
            {
                Interval = interval;
            }
        }

        [System.Xml.Serialization.XmlElement("Interval")]
        public int Interval { get; set; }

        [System.Xml.Serialization.XmlElement("ImagePath")]
        public string ImagePath { get; set; }

        [System.Xml.Serialization.XmlIgnore()]
        public string SettingsFileName
        {
            get
            {
                return SETTINGS_FILENAME;
            }
        }
        
        [System.Xml.Serialization.XmlIgnore()]
        public string SettingsFolder
        {
            get
            {
                return string.Format(
                    @"{0}\{1}",
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    SETTINGS_FOLDERNAME);
            }
        }

        public void LoadSettings()
        {
            LoginScreenSettings settings;
            var ser = new XmlSerializer(typeof(LoginScreenSettings));
            using (var fs = new FileStream(SettingsLocation, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                settings = (LoginScreenSettings)ser.Deserialize(fs);
                Interval = settings.Interval;
                ImagePath = settings.ImagePath;
            }
         }
    
        [System.Xml.Serialization.XmlIgnore()]
        public string SettingsLocation
        {
            get
            {
                return string.Format(
                    @"{0}\{1}{2}",
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    SETTINGS_FOLDERNAME, 
                    SETTINGS_FILENAME);
            }
        }
    }
}
