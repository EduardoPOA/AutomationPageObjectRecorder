@set EDGE=-Dwebdriver.edge.driver="%cd%\msedgedriver.exe"
@set CHROME=-Dwebdriver.chrome.driver="%cd%\chromedriver.exe"
@set PHANTOM=-Dphantomjs.binary.path="%cd%\phantomjs.exe"

@set SELENIUM_SERVER_EXE=selenium-server-standalone-2.48.2.jar

start "%SELENIUM_SERVER_EXE%" java %PHANTOM% %CHROME% %EDGE% -jar %SELENIUM_SERVER_EXE%