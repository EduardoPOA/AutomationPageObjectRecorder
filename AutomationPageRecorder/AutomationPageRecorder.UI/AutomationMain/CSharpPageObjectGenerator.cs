using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RazorEngine;
using AutomationPageRecorder.UI.CodeGeneration;
using AutomationPageRecorder.WebDriver;

namespace AutomationPageRecorder.UI
{
    public class TemplateViewModel
    {
        public AutomationPageObject PageObject { get; set; }
    }

    public class CSharpPageObjectGenerator
    {
        public string[] Generate(AutomationPageObject pageObject, string fullTemplatePath)
        {
            var template = File.ReadAllText(fullTemplatePath);

            object model = new TemplateViewModel() { PageObject = pageObject };

            string result = "not parsed";
            try
            {
                result = Razor.Parse(template, model);
            }
            catch
            {
                throw;
            }
            return Utils.SplitSingleLineToMultyLine(result);
        }
    }
}
