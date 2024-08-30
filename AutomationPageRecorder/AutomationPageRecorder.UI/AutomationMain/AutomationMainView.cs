using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutomationPageRecorder.WebDriver;
using FormKeys = System.Windows.Forms.Keys;
using AutomationPageRecorder.UI.AutomationMain.Popups;
namespace AutomationPageRecorder.UI
{
    public partial class AutomationMainView : Form, IView
    {
        private AutomationMainPresenter presenter = null;
        private System.Threading.ManualResetEvent startedEvent;
        public string GetUrl { get; set; }

        public AutomationMainView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            string versionText = string.Format("Automation Page Recorder", Build.WebDriverVersion, Build.Version);
            this.Text = versionText;
            MyLog.Write("Started: " + versionText);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            presenter = Presenters.AutomationMainPresenter;
            presenter.InitView(this);
        }

        

        public AutomationMainView(System.Threading.ManualResetEvent startedEvent) : this()
        {
            this.startedEvent = startedEvent;
        }

        private void txtBrowserUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == FormKeys.Enter)
            {
                presenter.SetBrowserUrl(txtBrowserUrl.Text);
            }
        }


        private void btnStartVisualSearch_Click(object sender, EventArgs e)
        {
            presenter.ChangeVisualSearchRunningState();
        }



        internal void UpdateVisualSearchResult(string xPathAttributeValue)
        {

            var action = (MethodInvoker)delegate
            {
                txtVisualSearchResult.Text = xPathAttributeValue;
            };

            if (txtVisualSearchResult.InvokeRequired)
            {
                txtVisualSearchResult.Invoke(action);
            }
            else
            {
                action();
            }
        }

        internal void SetUrlText(string browserUrl)
        {
            txtBrowserUrl.DoInvokeAction(() => txtBrowserUrl.Text = browserUrl);
            GetUrl = txtBrowserUrl.Text = browserUrl;
        }

        public BrowserPageFrame getCurrentlyChosenFrame()
        {
            BrowserPageFrame frame = null;
            object item = null;
            this.ddlFrames.Invoke((MethodInvoker)delegate ()
            {
                item = ddlFrames.SelectedItem;
            }
            );
            if (item is BrowserPageFrame)
            {
                frame = item as BrowserPageFrame;

            }
            return frame;
        }

        private void btnBrowser_Go_Click(object sender, EventArgs e)
        {
            presenter.SetBrowserUrl(txtBrowserUrl.Text);
        }


        internal void VisualSearchStopped()
        {
            var action = (MethodInvoker)delegate
            {
                btnStartVisualSearch.Text = "Iniciar";
            };

            if (btnStartVisualSearch.InvokeRequired)
            {
                btnStartVisualSearch.Invoke(action);
            }
            else
            {
                action();
            }
        }

        internal void VisuaSearchStarted()
        {
            var action = (MethodInvoker)delegate
            {
                btnStartVisualSearch.Text = "Parar";
            };

            if (btnStartVisualSearch.InvokeRequired)
            {
                btnStartVisualSearch.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.google.com");
        }



        internal void ShowGlobalLoading()
        {

            var action = (MethodInvoker)delegate
            {
                pnlLoadingBar.Visible = true;
            };

            if (pnlLoadingBar.InvokeRequired)
            {
                pnlLoadingBar.Invoke(action);
            }
            else
            {
                action();
            }
        }

        internal void HideGlobalLoading()
        {
            var action = (MethodInvoker)delegate
            {
                pnlLoadingBar.Visible = false;
            };

            if (pnlLoadingBar.InvokeRequired)
            {
                pnlLoadingBar.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void AutomationMainView_Shown(object sender, EventArgs e)
        {
            if (startedEvent != null) startedEvent.Set();
        }

        internal void SetDriverDependingControlsEnabled(bool shouldControlBeEnabled)
        {
            txtBrowserUrl.DoInvokeAction(() => txtBrowserUrl.Enabled = shouldControlBeEnabled);
            btnBrowser_Go.DoInvokeAction(() => btnBrowser_Go.Enabled = shouldControlBeEnabled);
            btnTakePageScreenshot.DoInvokeAction(() => btnTakePageScreenshot.Enabled = shouldControlBeEnabled);
            btnOpenScreenshotFolder.DoInvokeAction(() => btnOpenScreenshotFolder.Enabled = shouldControlBeEnabled);
            grpVisualSearch.DoInvokeAction(() => grpVisualSearch.Enabled = shouldControlBeEnabled);
            grpSwitchTo.DoInvokeAction(() => grpSwitchTo.Enabled = shouldControlBeEnabled);
        }

        internal void UpdateBrowserWindowsList(BrowserWindow[] currentWindows, string currentWindowHandle)
        {
            ddlWindows.DoInvokeAction(() =>
            {
                ddlWindows.Items.Clear();
                ddlWindows.Items.AddRange(currentWindows);

                ddlWindows.SelectedItem = currentWindows.First(win => (win.WindowHandle == currentWindowHandle));
            });
        }

        internal void UpdatePageFramesList(BrowserPageFrame[] currentPageFrames)
        {
            ddlFrames.DoInvokeAction(() =>
            {
                ddlFrames.Items.Clear();
                ddlFrames.Items.AddRange(currentPageFrames);

                ddlFrames.SelectedItem = currentPageFrames.First();
            });

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            presenter.RefreshSwitchToList();
        }

        internal void SetInitialRefreshMessageForSwitchToControls()
        {
            ddlFrames.Enabled = false;
            ddlWindows.Enabled = false;

            ddlWindows.Text = "Pressiona o botão atualizar";
            ddlFrames.Text = "... porfavor";
        }

        internal void EnableSwitchToControls()
        {
            ddlFrames.Enabled = true;
            ddlWindows.Enabled = true;
        }

        internal void DisableSwitchToControls()
        {
            ddlFrames.Enabled = false;
            ddlWindows.Enabled = false;
        }

        private void ddlFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrowserPageFrame frame = ddlFrames.SelectedItem as BrowserPageFrame;
            presenter.SwitchToFrame(frame);
        }

        private void ddlWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrowserWindow window = ddlWindows.SelectedItem as BrowserWindow;
            presenter.SwitchToWindow(window);
        }

        internal void DisableWebElementExplorerRunButton()
        {
            btnStartVisualSearch.DoInvokeAction(() =>
            {
                btnStartVisualSearch.Enabled = false;

            });
        }

        internal void EnableWebElementExplorerRunButton()
        {
            btnStartVisualSearch.DoInvokeAction(() =>
            {
                btnStartVisualSearch.Enabled = true;

            });
        }

        internal void DisableWebElementExplorerResultsField()
        {
            txtVisualSearchResult.DoInvokeAction(() =>
            {
                txtVisualSearchResult.Enabled = false;

            });
        }

        internal void EnableWebElementExplorerResultsField()
        {
            txtVisualSearchResult.DoInvokeAction(() =>
            {
                txtVisualSearchResult.Enabled = true;

            });
        }

        private async void btnTakePageScreenshot_Click(object sender, EventArgs e)
        {
            btnTakePageScreenshot.Enabled = false;
            var oldBackground = btnTakePageScreenshot.BackColor;
            btnTakePageScreenshot.BackColor = Color.DarkGray;
            try
            {
                presenter.DisplayLoadingIndicator(true);
                await presenter.TakeAndSaveScreenshot();
            }
            finally
            {
                btnTakePageScreenshot.Enabled = true;
                btnTakePageScreenshot.BackColor = oldBackground;
                presenter.DisplayLoadingIndicator(false);
            }
        }

        private void btnOpenScreenshotFolder_Click(object sender, EventArgs e)
        {
            presenter.OpenScreenshotsFolder();
        }

        private void btnOpenBrowserPreview_Click(object sender, EventArgs e)
        {
            var browserScreenView = new BrowserScreenView();
            browserScreenView.Show();
        }

    }
}
