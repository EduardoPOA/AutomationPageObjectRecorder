using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutomationPageRecorder.WebDriver;
using System.Net;


namespace AutomationPageRecorder.UI
{
    public static class WinformsAction
    {
        public static void DoInvokeAction<T>(this T control, Action action) where T : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}

