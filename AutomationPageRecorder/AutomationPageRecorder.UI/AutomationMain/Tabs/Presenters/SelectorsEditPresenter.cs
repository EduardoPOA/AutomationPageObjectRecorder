using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using AutomationPageRecorder.WebDriver;
using AutomationPageRecorder.WebDriver.JsCommand;

using System.Xml;
using System.Xml.Linq;

using System.Windows.Forms;
using System.Diagnostics;

namespace AutomationPageRecorder.UI
{
    public class SelectorsEditPresenter : IPresenter<SelectorsEditView>
    {
        private SelectorsEditView view;

        public void InitWithView(SelectorsEditView view)
        {
            this.view = view;

            // Subscribe to WebDriverUtils events
            AutomationBrowser.OnDriverStarted += InitControls;
            AutomationBrowser.OnDriverClosed += InitControls;
            InitControls();
        }

        private void InitControls()
        {
            var isDriverAlive = AutomationBrowser.IsWorking;
            view.btnHighlightWebElementInBrowser.Enabled = isDriverAlive;
        }

        public bool IsValidForm()
        {
            bool isValid = true;
            var element = view.GetWebElementDefinitionFromForm();
            if (String.IsNullOrWhiteSpace(element.Locator))
            {
                string message = "Os textbox do(s) elemento(s) não podem estar vazio(s).\n\n" +
                                  "Por favor, digite o valor ou carregue o elemento existente\n" +
                                  "no 'Painel elementos capturados' (clicando duas vezes no identificador)\n" +
                                  "para destacar na tela.";

                view.DisplayWarningMessage(message);
                isValid = false;
            }
            return isValid;
        }

        internal void NewWebElement()
        {
            Presenters.PageObjectDefinitionPresenter._isEditingExistingNode = false;
            Presenters.PageObjectDefinitionPresenter._currentEditingNode = null;
            view.ClearWebElementForm();
        }

        internal void CopyWebElement()
        {
            Presenters.PageObjectDefinitionPresenter._isEditingExistingNode = false;
            Presenters.PageObjectDefinitionPresenter._currentEditingNode = null;
            view.AppendWebElementNameWith("__Copy");
        }

        internal void RemoveWebElement(WebElementDefinition element) 
        {
            Presenters.PageObjectDefinitionPresenter.removeElementFromObjectPage(element);
        }

        internal void HighLightWebElement(WebElementDefinition element)
        {
            if (!IsValidForm()) return;

            var by = AutomationBrowser.ConvertLocatorSearchMethodToBy(element.HowToSearch, element.Locator);
            AutomationBrowser.HighlightElement(by);

        }

        internal void OpenExistingNodeForEdit(TreeNode treeNode)
        {
            Presenters.PageObjectDefinitionPresenter._isEditingExistingNode = true;
            Presenters.PageObjectDefinitionPresenter._currentEditingNode = treeNode;
            var webElementFormData = treeNode.Tag as WebElementDefinition;
            view.UpdateWebElementForm(webElementFormData);
            view.btnRemoveWebElement.Enabled = true;
        }

        internal LocatorSearchMethod GetLocatorSearchMethod()
        {
            return view.GetLocatorSearchMethod();
        }

        internal string GetLocatorText()
        {
            return view.GetLocatorText();
        }

        
        

        internal void ReadElementProperties(WebElementDefinition element)
        {

            UpdateWebElementWithAdditionalProperties(element);
            view.UpdateElementPropertiesForm(element);
        }

        public void UpdateWebElementWithAdditionalProperties(WebElementDefinition element)
        {
            var by = AutomationBrowser.ConvertLocatorSearchMethodToBy(element.HowToSearch, element.Locator);
            var attributes = new Dictionary<string, string>();
            try
            {
                attributes = AutomationBrowser.ReadElementAttributes(by);
            }
            catch(Exception e)
            {
                string errorMsg = string.Format(
                                "UpdateWebElementWithAdditionalProperties:\n" +
                                "Failed to find element: How={0};   Locator={1}\n" + 
                                "With exception:\n {2}"
                                , element.HowToSearch.ToString()
                                , element.Locator.ToString()
                                , e.Message
                                
                                );
                MyLog.Error(errorMsg);
            }
                

            if (attributes.Count == 0) return;

            element.HtmlTag = attributes["TagName"];
            attributes.Remove("TagName");

            WebElementHtmlAttributes elementAttrs = new WebElementHtmlAttributes();

            foreach (var attrKey in attributes.Keys)
            {
                elementAttrs.Add(attrKey, attributes[attrKey]);
            }

            element.AllHtmlTagProperties = elementAttrs;
        }
    }
}
