using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using LoginScreenCommon;

namespace LoginScreenChanger
{
    public class LoginChanger
    {
        private const string BG_DIRECTORY = @"C:\Windows\System32\oobe\info\backgrounds";
        private const string BG_DEFAULT_NAME = "backgroundDefault";
        private const string BG_FILENAME = @"C:\Windows\System32\oobe\info\backgrounds\backgroundDefault.jpg";
        private const string WIN8_REG_KEY_NAME = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Personalization";
        private const string WIN8_REG_DWORD_NAME = @"LockScreenImage";

        public LoginChanger(LoginChangerService parent)
        {
            Parent = parent;
        }

        public void ChangeBackgroundImage(object stateInfo)
        {
            try
            {
                IEnumerable<FileInfo> availableImages = GetBackgroundImages();

                int pickImage = new Random().Next(availableImages.Count());

                FileInfo copyImage = availableImages.ElementAt(pickImage);

                if (copyImage.FullName.Equals(LastFileUsed))
                {
                    if (pickImage + 1 >= availableImages.Count())
                        pickImage--;
                    else
                    {
                        pickImage++;
                    }
                    copyImage = availableImages.ElementAt(pickImage);
                }

                if (Environment.OSVersion.Version.Major == 6)
                {
                    // Use image name to modify registry key
                    Registry.SetValue(WIN8_REG_KEY_NAME, WIN8_REG_DWORD_NAME, copyImage.FullName);
                }
                else
                {
                    if (File.Exists(BG_FILENAME))
                        File.Delete(BG_FILENAME);

                    if (!File.Exists(BG_FILENAME))
                    {
                        File.Copy(copyImage.FullName, BG_FILENAME);
                        LastFileUsed = copyImage.FullName;
                    }
                } 
            }
            catch
            {
                // Just swallow the exception
            }
        }

        private IEnumerable<FileInfo> GetBackgroundImages()
        {
            return new DirectoryInfo(BackgroundDirectory)
                .GetFiles("*.jpg")
                    .Where(x => !(x.Name.Contains(BG_DEFAULT_NAME)));
        }

        public string LastFileUsed { get; set; }

        private string _backgroundDirectory;
        public string BackgroundDirectory
        {
            get
            {
                if (Parent != null && Parent.Settings != null)
                    _backgroundDirectory = Parent.Settings.ImagePath;

                return _backgroundDirectory ?? BG_DIRECTORY;
            }
            set { _backgroundDirectory = value; }
        }

        private LoginChangerService Parent { get; set; }
    }
}
