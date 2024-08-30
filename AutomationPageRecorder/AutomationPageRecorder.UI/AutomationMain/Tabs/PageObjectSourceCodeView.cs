using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Threading;

namespace AutomationPageRecorder.UI
{
    public partial class PageObjectSourceCodeView : UserControl, IView
    {
        private PageObjectSourceCodePresenter presenter;
        public PageObjectSourceCodeView()
        {
            InitializeComponent();

            presenter = Presenters.FullHtmlSourceTabPresenter;
            presenter.InitWithView(this);
            presenter.InitTemplateFilesList();
            presenter.TrySelectDefaultTemplate();

        }

        private void btnGenerateSourceCode_Click(object sender, EventArgs e)
        {
            presenter.GenerateSourceCodeForPageObject();
        }

        private void btnConstructorProject_Click(object sender, EventArgs e)
        {
            presenter.MachineLearningGenerateCode();
            using (ProgressBarForm progress = new ProgressBarForm(presenter.ReadTemplateCshtml))
            {
                progress.ShowDialog(this);
            }
            Thread.Sleep(200);
            MessageBox.Show("FORAM INSERIDOS COM SUCESSO OS SCRIPTS NO PROJETO!");
        }

        internal void DisplayGeneratedCode(string[] codeLines)
        {
            txtSourceCode.Clear();
            txtSourceCode.Language = Language.CSharp;
            txtSourceCode.Text = String.Join(Environment.NewLine, codeLines);
        }

        internal void DisplayCleanCode()
        {
            txtSourceCode.Clear();
            txtSourceCode.Language = Language.CSharp;
        }

        internal string GetCodeFromTextSourceCshtml()
        {
            txtSourceCode.Language = Language.CSharp;
            return txtSourceCode.Text.ToString();
        }

        internal string GetCodeStartWithKeyXml()
        {
            txtSourceCode.Language = Language.CSharp;
            string name = null;
            foreach (string line in txtSourceCode.Lines)
            {
                if (line.StartsWith("<element key"))
                {
                    string element = line
                     .Replace("\"", "")
                        .Replace("<", "")
                        .Replace(">", "")
                        .Replace("element", "")
                        .Replace("@id=", "@id!")                       
                        .Trim();
                    name = element.Substring(element.LastIndexOf("key") + 0).Split()[0].Replace("key=", "");
                    name = name.Split('.')[0];
                }
            }
            return name;
        }

        internal void SetPageObjectFiles(string[] files)
        {
            cbCodeTemplates.Items.Clear();
            if (files.Length > 0)
            {
                cbCodeTemplates.Items.AddRange(files);
            }

        }

        internal string GetSelectedTemplateFile()
        {
            string selectedTemalateName = "";
            if (cbCodeTemplates.SelectedItem != null)
            {
                selectedTemalateName = cbCodeTemplates.SelectedItem as string;
            }
            return selectedTemalateName;
        }

        internal void WarnTemplateNeedsToBeSelected()
        {
            MessageBox.Show("Favor, selecione o template da linguagem da lista");
        }

        private void txtSourceCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtSourceCode.SelectAll();
            }
        }
    }
}
