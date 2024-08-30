using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;
using System.Net;
using AutomationPageRecorder.WebDriver.JsCommand;
using System.Xml;
using HtmlAgilityPack;
using AutomationPageRecorder.ConfigurationManagement.Profiles;
using NLog;
using Newtonsoft.Json;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium.Interactions;

namespace AutomationPageRecorder.WebDriver.AutomationBrowserUtils
{
    public static class WebDriverUtils
    {

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static IWebDriver Initialize(WebDriverOptions browserOptions, out bool isRemote)
        {
            IWebDriver driver = null;
            if (browserOptions.IsRemote)
            {
                driver = ConnetctToRemoteWebDriver(browserOptions);
                isRemote = true;
            }
            else
            {
                driver = StartEmbededWebDriver(browserOptions);
                isRemote = false;
            }
            return driver;
        }

        private static IWebDriver ConnetctToRemoteWebDriver(WebDriverOptions browserOptions)
        {
            DesiredCapabilities caps = null;
            Uri hubUri = new Uri(browserOptions.RemoteUrl);
            const bool isRemoteDriver = true;
            switch (browserOptions.BrowserProfile.ActivationBrowserName)
            {

                case WebDriverOptions.browser_Firefox:
                    caps = DesiredCapabilities.Firefox();
                    break;
                case WebDriverOptions.browser_Chrome:
                    caps = DesiredCapabilities.Chrome();
                    break;
                case WebDriverOptions.browser_Edge:
                    caps = DesiredCapabilities.Edge();
                    break;
                case WebDriverOptions.browser_PhantomJS:
                    caps = DesiredCapabilities.PhantomJS();
                    break;
                case WebDriverOptions.browser_HtmlUnit:
                    caps = DesiredCapabilities.HtmlUnit();
                    break;
                case WebDriverOptions.browser_HtmlUnitWithJavaScript:
                    caps = DesiredCapabilities.HtmlUnitWithJavaScript();
                    break;
                case WebDriverOptions.browser_Opera:
                    caps = DesiredCapabilities.Opera();
                    break;
                case WebDriverOptions.browser_Safari:
                    caps = DesiredCapabilities.Safari();
                    break;
                case WebDriverOptions.browser_IPhone:
                    caps = DesiredCapabilities.IPhone();
                    break;
                case WebDriverOptions.browser_IPad:
                    caps = DesiredCapabilities.IPad();
                    break;
                case WebDriverOptions.browser_Android:
                    caps = DesiredCapabilities.Android();
                    break;
                default:
                    throw new ArgumentException(String.Format(@"<{0}> was not recognized as supported browser. This parameter is case sensitive", browserOptions.BrowserProfile.ActivationBrowserName),
                                                "WebDriverOptions.BrowserProfile.ActivationBrowserName");
            }

            caps = ConfigureRemoteWebdriverCapabilities(caps, browserOptions.BrowserProfile, isRemoteDriver);

            RemoteWebDriver newDriver = new RemoteWebDriver(hubUri, caps);
            return newDriver;
        }

        private static IWebDriver StartEmbededWebDriver(WebDriverOptions browserOptions)
        {
            bool isRemoteDriver = false;
            DesiredCapabilities caps = null;
            switch (browserOptions.BrowserProfile.ActivationBrowserName)
            {
                case WebDriverOptions.browser_Firefox:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    FirefoxDriverService fireFoxDriverService = FirefoxDriverService.CreateDefaultService();
                    fireFoxDriverService.HideCommandPromptWindow = true;
                    FirefoxDriver driverFireFox = new FirefoxDriver(fireFoxDriverService);
                    return driverFireFox;

                case WebDriverOptions.browser_Chrome:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;

                    ChromeOptions optionChrome = null;
                    ChromeDriver driverChrome = null;

                    if (browserOptions.MFA)
                    {
                        optionChrome = new ChromeOptions();
                        optionChrome.AddArgument("user-data-dir=C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\Userdata");
                        optionChrome.AddArgument("--profile.directory.Profile=10");
                    }

                    if (optionChrome != null)
                    {
                        driverChrome = new ChromeDriver(chromeDriverService, optionChrome);
                    }
                    else
                    {
                        driverChrome = new ChromeDriver(chromeDriverService);
                    }

                    return driverChrome;






                //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                //ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                //chromeDriverService.HideCommandPromptWindow = true;                   
                //ChromeDriver driverChrome = new ChromeDriver(chromeDriverService);
                //return driverChrome;

                case WebDriverOptions.browser_Edge:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService(GetEdgeDriverFromWebdriverManager(), "msedgedriver.exe");
                    edgeDriverService.HideCommandPromptWindow = true;
                    EdgeDriver driverEdge = new EdgeDriver(edgeDriverService);
                    return driverEdge;
                //case WebDriverOptions.browser_PhantomJS:
                //    return new PhantomJSDriver();
                //case WebDriverOptions.browser_Safari:
                //    return new SafariDriver();
                default:
                    throw new ArgumentException(String.Format(@"<{0}> was not recognized as supported browser. This parameter is case sensitive", browserOptions.BrowserProfile.ActivationBrowserName),
                                                "WebDriverOptions.BrowserProfile.ActivationBrowserName");
            }
        }

        public static string GetEdgeDriverFromWebdriverManager()
        {
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string theDirectory = Path.GetDirectoryName(fullPath);
            string folderEdge = Path.Combine(theDirectory, "Edge");
            string[] directories = System.IO.Directory.GetDirectories(folderEdge, "*", System.IO.SearchOption.AllDirectories);
            string[] directoriesFiles = System.IO.Directory.GetFiles(folderEdge, "*", System.IO.SearchOption.AllDirectories);
            var driverEdge = directoriesFiles.Where(x => x.EndsWith("msedgedriver.exe")).FirstOrDefault();
            string driver = Convert.ToString(driverEdge);
            driver = driver.Remove(driver.LastIndexOf('\\'));
            return driver;
        }

        private static DesiredCapabilities ConfigureRemoteWebdriverCapabilities(DesiredCapabilities caps, Profile browserProfile, bool isRemoteDriver)
        {

            var profileCaps = browserProfile.ProfileConfig.capabilities;
            if (isRemoteDriver)
            {
                foreach (string[] capability in profileCaps.remoteWebDriver)
                {
                    AddCapability(capability, caps);
                }
            }

            return caps;
        }

        private static void AddCapability(string[] capability, DesiredCapabilities caps)
        {
            if (capability.Length != 2)
            {
                _logger.Error($"Incorrect Capability value: << {JsonConvert.SerializeObject(capability)} >>. The capability key/value pair array length is expected to be 2, but was: {capability.Length}");
                return;
            }
            string capabilityKey = capability[0];
            string capabilityValue = capability[1];
            caps.SetCapability(capabilityKey, capabilityValue);
        }
    }
}
