using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

using LoginScreenCommon;

namespace LoginScreenChanger
{
    public partial class LoginChangerService : ServiceBase
    {
        public LoginChangerService()
        {
            InitializeComponent();
        }
        
        protected override void OnStart(string[] args)
        {
            // Create an event to signal the timeout count threshold in the
            // timer callback.
            var autoEvent = new AutoResetEvent(false);

            Changer = new LoginChanger(this);
            Settings = new LoginScreenSettings();
            Settings.LoadSettings();

            // Once the settings are loaded, we must make sure that 
            // the settings file is accessible to all accounts
            FileSecurity security = File.GetAccessControl(Settings.SettingsLocation);
            security.AddAccessRule(new FileSystemAccessRule("Everyone",
                FileSystemRights.FullControl, AccessControlType.Allow));
            File.SetAccessControl(Settings.SettingsLocation, security);

            // Create an inferred delegate that invokes methods for the timer.
            // var is not used here because the compiler expects it to be explicit
            TimerCallback tcb = Changer.ChangeBackgroundImage;

            // Create a timer that signals the delegate to invoke 
            // CheckStatus after one second, and every 10 seconds
            // thereafter.
            ChangeTimer = new Timer(tcb, autoEvent, 10000, Settings.Interval * 1000);

            // Set a watch filter on the settings file
            // This way any change in the settings file initiates
            // an immediate alteration in the timing.
            var watcher = new FileSystemWatcher()
            {
                Path = Settings.SettingsFolder,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.lsc"
            };
            watcher.Changed += Settings_Changed;
        }

        protected override void OnStop()
        {
            // Kill the timer
            ChangeTimer.Dispose();
        }

        protected void Settings_Changed(object source, FileSystemEventArgs e)
        {
            ChangeTimer.Change(10000, Settings.Interval * 1000);
        }

        public Timer ChangeTimer { get; set; }
        public LoginChanger Changer { get; set; }
        public LoginScreenSettings Settings { get; set; }
    }
}
