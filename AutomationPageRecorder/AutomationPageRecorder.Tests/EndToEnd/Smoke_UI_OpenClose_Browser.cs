using System;
using System.Linq;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

using AutomationPageRecorder.TestModel;

using System.IO;


namespace AutomationPageRecorder.Tests.EndToEnd
{
    [TestFixture]
    public class Smoke_UI_OpenClose_Browser : MyTest
    {

        private void OpenAppWithBrowser(string browserName)
        {
            var mainWin = MainWindow.GetWindow();
            mainWin.DisplayState = DisplayState.Maximized;

            var browserSettingsTab = new BrowserSettingsTabWindow();

            browserSettingsTab.SelectBrowser(browserName);
            browserSettingsTab.StartBrowser();

            UglySleep();

            browserSettingsTab.WaitWhileWaitingIndicatorDisplayed();

            browserSettingsTab.StopBrowser();
            
            UglySleep();
            browserSettingsTab.WaitWhileWaitingIndicatorDisplayed();
            
            mainWin.Close();
            App.Close();
        }

        private static void UglySleep()
        {
            System.Threading.Thread.Sleep(500);
        }        

        [Test(Description = "UI")]
        public void Start_and_Stop_Open_Recorder_with_Google_Chrome()
        {
            OpenAppWithBrowser("Chrome");
        }

        [Test(Description = "UI")]
        public void Start_and_Stop_Open_Recorder_with_Firefox()
        {
            OpenAppWithBrowser("Firefox");
        }

        [Test(Description = "UI")]
        public void Start_and_Stop_Open_Recorder_with_Edge()
        {
            OpenAppWithBrowser("Edge");
        }

        [Test(Description = "UI")]
        public void Start_and_Stop_Open_Recorder_with_PahntomJS()
        {
            OpenAppWithBrowser("PhantomJS");
        }
    }
}
