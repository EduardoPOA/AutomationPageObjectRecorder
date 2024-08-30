using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutomationPageRecorder.WebDriver;
using System.Net;
using System.Threading;

namespace AutomationPageRecorder.UI
{
    public static class AutomationRecorder_Program
    {
        
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                        
            var mainForm = new AutomationMainView();
            Application.Run(mainForm);
        }

        internal class ThreadExceptionHandler
        {
            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {
                MyLog.Exception(e.Exception);
                string exceptionType = string.Format("Error type: ({0})", e.Exception.GetType().ToString());
                MessageBox.Show(e.Exception.Message + "\r\n" + exceptionType, "Automation Page Recorder - Error");
            }
        }


        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            AutomationBrowser.CloseDriver();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            AutomationBrowser.CloseDriver();
        }

        public static void CloseApplication()
        {
            AutomationBrowser.CloseDriver();
            Application.Exit();
        }



    }
}
