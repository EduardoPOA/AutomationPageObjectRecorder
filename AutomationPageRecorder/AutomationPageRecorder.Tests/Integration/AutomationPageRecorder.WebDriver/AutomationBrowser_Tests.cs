using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using AutomationPageRecorder.WebDriver;
using AutomationPageRecorder.TestModel;

using FluentAssertions;
using AutomationPageRecorder.ConfigurationManagement.Profiles;

namespace AutomationPageRecorder.Tests.Integration.AutomationPageRecorder.WebDriver
{
    [TestFixture]
    public class AutomationBrowser_Tests : MyTest    
    {

        /// <summary>
        /// AutomationBrowser.Initialize should be able to connect to the Remote Hub 
        /// Tests: @AutomationBrowser.Initialize, @WebDriverOptions, @AutomationBrowser.TestRemoteHub, @AutomationBrowser.RunStandaloneServer
        /// 
        /// 1. The test verifies if the remote hub started with @AutomationBrowser.TestRemoteHub and starts the server
        /// 2. Then it verifies if the HtmlUnitDriver is active
        /// </summary>
        [Test(Description = "WebDriver")]
        public void Initialize_should_be_able_to_start_new_browser()
        {
            Profile browserProfile = new Profile();
            browserProfile.ProfileConfig.activation.browserName = WebDriverOptions.browser_HtmlUnitWithJavaScript;

            WebDriverOptions options = new WebDriverOptions()
            {
                BrowserProfile = browserProfile,
                IsRemote = true,
                RemoteUrl = "http://localhost:4444/wd/hub/",
            };

            bool isSeleniumServerAvailable = true;

            try
            {
                AutomationBrowser.TestRemoteHub(options.RemoteUrl);
            }
            catch (Exception e)
            {
                isSeleniumServerAvailable = false;
                Console.WriteLine("Falhou: " + e.Message);
            }

            if (!isSeleniumServerAvailable)
            {
                AutomationBrowser.RunStandaloneServer("start_selenium_server.bat");
            }

            AutomationBrowser.Initialize(options);

            var rempteDriver = (RemoteWebDriver)AutomationBrowser.GetDriver();

            rempteDriver.Capabilities.BrowserName.Should().Be("htmlunit");

            AutomationBrowser.CloseDriver();
        }


        // ===========================================================================
        private static string[] GetDesktopWindowsWithSpecialTitle(string specialTitle)
        {
            var specialWindows = (from title in Helper.GetAllMainWindowTitlesOnDesktop()
                                  where title.Contains(specialTitle)
                                  select title).ToArray();

            return specialWindows;
        }

        /// <summary>
        /// AutomationBrowser.CloseDriver() deve fechar a janela do navegador aberta
        /// Testes: @AutomationBrowser.CloseDriver,
        ///
        /// 1. Abre um navegador FireFox
        /// 2. Executa um JavaScript especial que define o título do documento como "AutomationBrowser.CloseDriver TEST TEST"
        /// 3. E verifica se a janela foi aberta
        /// 4. Fecha o navegador com @AutomationBrowser.CloseDriver
        /// 5. Verifica se não há janelas com esse título na área de trabalho do Windows
        /// </summary>
        [Test(Description = "WebDriver")]
        public void CloseDriver_should_close_the_opened_browser_instance()
        {
            Profile browserProfile = new Profile();
            browserProfile.ProfileConfig.activation.browserName = WebDriverOptions.browser_Firefox;

            WebDriverOptions options = new WebDriverOptions()
            {
                BrowserProfile = browserProfile,
                IsRemote = false,
            };

            string specialTitle = "AutomationBrowser.CloseDriver TEST TEST";

            string[] specialWindows = new string[] { };
            
            specialWindows = GetDesktopWindowsWithSpecialTitle(specialTitle);
            specialWindows.Length.Should().Be(0, "Não se espera nenhuma janela com o título <{0}> no início", specialTitle);

            AutomationBrowser.Initialize(options);

            string changeTitleScript = string.Format("document.title = '{0}'", specialTitle);
            AutomationBrowser.ExecuteJavaScript(changeTitleScript);

            specialWindows = GetDesktopWindowsWithSpecialTitle(specialTitle);
            specialWindows.Length.Should().Be(1, "Espera-se apenas 1 janela com o título <{0}> após a criação do novo driver", specialTitle);

            AutomationBrowser.CloseDriver();

            specialWindows = GetDesktopWindowsWithSpecialTitle(specialTitle);
            specialWindows.Length.Should().Be(0, "Não se espera nenhuma janela com o título <{0}> após o fechamento do driver", specialTitle);

        }



        [Test(Description = "WebDriver")]
        public void Enumerate_Windows_Tabs()
        {
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_opens_several_tabs.html");

            Helper.ClickId("openTab2");
            Helper.ClickId("openTab3");

            BrowserWindow[] actualWindows = AutomationBrowser.GetBrowserWindows();

            string[] expectedWindowTitles = new string[]
            {
                "Page Tab1",
                "Page Tab3",
                "Page Tab2",
            };

            string[] actualTitles = actualWindows.Select(w => w.Title).ToArray();

            actualTitles.Should().Contain(expectedWindowTitles);

            AutomationBrowser.CloseDriver();
        }

        [Test(Description = "WebDriver")]
        public void Enumerate_Windows_Popup()
        {
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_opens_several_tabs.html");

            Helper.ClickId("openTab2");
            Helper.ClickId("openTab3");
            Helper.ClickId("openJavaScriptPopup");
            

            BrowserWindow[] actualWindows = AutomationBrowser.GetBrowserWindows();

            string[] expectedWindowTitles = new string[]
            {
               "Page Tab1", 
               "JavaScript Popup", 
               "Page Tab3", 
               "Page Tab2"
            };

            string[] actualTitles = actualWindows.Select(w => w.Title).ToArray();

            actualTitles.Should().Contain(expectedWindowTitles);

            AutomationBrowser.CloseDriver();
        }

        [Test(Description = "WebDriver")]
        public void Get_Frames_Tree()
        {

            string[] expectedTitles = new string[]
            {
              "DefaultContent", 
              "firstFrame", 
              "secondFrame", 
              "secondFrame.idIframeInsideSecondFrame", 
              "thirdFrame", 
              "thirdFrame.0"
            };

            
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_with_frames.html");


            BrowserPageFrame rootFrame = AutomationBrowser.GetPageFramesTree();
            List<BrowserPageFrame> allFrames = rootFrame.ToList();

            string[] actualTitles = allFrames.Select(i => i.ToString()).ToArray();

            actualTitles.Should().Equal(expectedTitles);

            AutomationBrowser.CloseDriver();
            
        }

    }
}
