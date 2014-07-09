using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;

namespace LoginScreenChanger
{
    [RunInstaller(true)]
    public partial class LoginChangerInstaller : System.Configuration.Install.Installer
    {
        public const string HKCU = @"HKEY_CURRENT_USER\Software\Microsoft\CurrentVersion\Run";
        public const string TRAY_KEY = @"LoginScreenChanger";
        public const string TRAY_PATH = @"C:\Program Files (x86)\Loony Logins\LoginScreenChanger\LoginScreenChangerTray.exe";

        public LoginChangerInstaller()
        {
            InitializeComponent();
            this.AfterInstall += new InstallEventHandler(ServiceInstaller_AfterInstall);
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(this.LoginChangerServiceInstaller.ServiceName))
            {
                sc.Start();

                // Start the tray program
                string trayPath = (Registry.GetValue(HKCU, TRAY_KEY, TRAY_PATH) ?? TRAY_PATH).ToString();

                if (File.Exists(trayPath))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = trayPath;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                }
                else
                {
                    throw new ArgumentNullException("I have no idea where the file { " + trayPath + " } is.");
                }
            }
        }
    }
}
