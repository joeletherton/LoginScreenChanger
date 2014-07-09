namespace LoginScreenChanger
{
    partial class LoginChangerInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginChangerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.LoginChangerServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // LoginChangerServiceInstaller
            // 
            this.LoginChangerServiceInstaller.Description = "Changes the default background for the login screen at random intervals using ext" +
    "ra images from the backgrounds directory.";
            this.LoginChangerServiceInstaller.DisplayName = "Login Background Changer";
            this.LoginChangerServiceInstaller.ServiceName = "LoginBackgroundChanger";
            this.LoginChangerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // LoginChangerServiceProcessInstaller
            // 
            this.LoginChangerServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LoginChangerServiceProcessInstaller.Password = null;
            this.LoginChangerServiceProcessInstaller.Username = null;
            // 
            // LoginChangerInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LoginChangerServiceInstaller,
            this.LoginChangerServiceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller LoginChangerServiceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller LoginChangerServiceProcessInstaller;
    }
}