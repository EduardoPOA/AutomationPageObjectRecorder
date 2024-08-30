using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AutomationPageRecorder.UI
{
   
    public static class Presenters
    {
        private static AutomationMainPresenter _AutomationMainPresenter = null;
        public static AutomationMainPresenter AutomationMainPresenter
        {
            get
            {
                return (_AutomationMainPresenter = _AutomationMainPresenter ?? new AutomationMainPresenter());
            }
        }

        private static BrowserSettingsTabPresenter _browserSettingsTabPresenter = null;
        public static BrowserSettingsTabPresenter BrowserSettingsTabPresenter
        {
            get
            {
                return (_browserSettingsTabPresenter = _browserSettingsTabPresenter ?? new BrowserSettingsTabPresenter());
            }
        }

        private static PageObjectDefinitionPresenter _pageObjectDefinitionPresenter = null;
        public static PageObjectDefinitionPresenter PageObjectDefinitionPresenter
        {
            get
            {
                return (_pageObjectDefinitionPresenter = _pageObjectDefinitionPresenter ?? new PageObjectDefinitionPresenter());
            }
        }

        private static SelectorsEditPresenter _selectorsEditPresenter = null;
        public static SelectorsEditPresenter SelectorsEditPresenter
        {
            get
            {
                return (_selectorsEditPresenter = _selectorsEditPresenter ?? new SelectorsEditPresenter());
            }
        }

        private static HtmlDomTesterPresenter _htmlDomTesterPresenter = null;
        public static HtmlDomTesterPresenter HtmlDomTesterPresenter
        {
            get
            {
                return (_htmlDomTesterPresenter = _htmlDomTesterPresenter ?? new HtmlDomTesterPresenter());
            }
        }

        private static PageObjectSourceCodePresenter _fullHtmlSourceTabPresenter = null;
        public static PageObjectSourceCodePresenter FullHtmlSourceTabPresenter
        {
            get
            {
                return (_fullHtmlSourceTabPresenter = _fullHtmlSourceTabPresenter ?? new PageObjectSourceCodePresenter());
            }
        }
    }
}



