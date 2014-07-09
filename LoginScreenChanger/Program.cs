using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace LoginScreenChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //Uncomment the following line to do debugging
            //System.Diagnostics.Debugger.Launch();
            ServiceBase.Run(new LoginChangerService());
        }
    }
}
