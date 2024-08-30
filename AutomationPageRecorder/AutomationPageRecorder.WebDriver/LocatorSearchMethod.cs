using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationPageRecorder.WebDriver
{
    public enum LocatorSearchMethod
    {
        NotSet = -1,
        id = 0,
        name = 1,
        tag = 2,
        classname = 3,
        css = 4,
        link = 5,
        partiallink = 6,
        xpath = 7,
        Custom = 8,
        ByJavaScriptExpression = 20,
        ByCustomCodeExpression = 30,
    }
}
