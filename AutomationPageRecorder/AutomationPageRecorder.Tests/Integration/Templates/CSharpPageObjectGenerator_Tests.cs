using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using AutomationPageRecorder.WebDriver;
using AutomationPageRecorder.TestModel;
using AutomationPageRecorder.UI;

using FluentAssertions;
using System.IO;

namespace AutomationPageRecorder.Tests.Integration.Templates
{
    [TestFixture]
    public class CSharpPageObjectGenerator_Tests: MyTest    
    {

        [Test(Description = "Templates")]
        //[TestCase("CSharp - PageObject(xml).cshtml")]
        [TestCase("Cypress - PageObject(xml) (Default).cshtml")]
        public void CSharpPageObjectGenerator_Generate(string templateFileName)
        {
            CSharpPageObjectGenerator engine = new CSharpPageObjectGenerator();
            string templatesFolder = Path.Combine(Helper.AssemblyDirectory(), "CodeTemplates");
            string fileName = Path.Combine(templatesFolder, templateFileName);

            AutomationPageObject pageObject = new AutomationPageObject();
            string expectedName = "ExpectedName123456";
            pageObject.PageObjectName = expectedName;

            string[] output = engine.Generate(pageObject, fileName);

            string actual = string.Join("", output);
            actual.Should().Contain(expectedName);
            Console.WriteLine(actual);
        }
    }
}
