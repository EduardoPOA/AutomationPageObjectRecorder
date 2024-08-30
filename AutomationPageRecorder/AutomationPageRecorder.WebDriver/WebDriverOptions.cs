using AutomationPageRecorder.ConfigurationManagement.Profiles;
using AutomationPageRecorder.WebDriver.AutomationBrowserUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AutomationPageRecorder.WebDriver
{
    public class WebDriverOptions
    {
        public const string browser_Chrome = "Chrome";
        public const string browser_Firefox = "Firefox";
        public const string browser_Edge = "Edge";
        public const string browser_PhantomJS = "PhantomJS";
        public const string browser_HtmlUnit = "HtmlUnit";
        public const string browser_HtmlUnitWithJavaScript = "HtmlUnitWithJavaScript";
        public const string browser_Opera = "Opera";
        public const string browser_Safari = "Safari";
        public const string browser_IPhone = "IPhone";
        public const string browser_IPad = "IPad";
        public const string browser_Android = "Android";


        public static readonly string[] allWebdriverBrowsersSupported = new string[]
        {
            browser_Chrome,
            browser_Firefox,
            browser_Edge,
            browser_PhantomJS,
            browser_HtmlUnit,
            browser_HtmlUnitWithJavaScript,
            browser_Opera,
            browser_Safari,
            browser_IPhone,
            browser_IPad,
            browser_Android,
        };

        public static readonly string[] embededWebdriverBrowsersSupported = new string[]
        {
            browser_Chrome,
            browser_Firefox,
            browser_Edge,
            browser_PhantomJS,
            browser_Safari,
        };

        public Profile BrowserProfile { get; set; }

        public bool IsRemote { get; set; }

        public string RemoteUrl { get; set; }

        public bool MFA { get; set; }

    }
}
