Testing in Xamarin.Forms can be done by using [Appium](http://appium.io/). Appium is an open source test automation framework for use with native, hybrid and mobile web apps. It drives iOS, Android, and Windows apps using the WebDriver protocol.

This is a small test app using Appium to run tests. The tests in this app is a basic:

- check label text
- check input
- check button click

The main purpose of this small test app was for UWP implementation. Please see [Appium](http://appium.io/) for additional info on Android and IOS.

To create your test project for use of appium you need to [do the following](https://github.com/Microsoft/WinAppDriver):
- The main project elements need an AutomationId (this will mostly find your element, in some cases more work might be needed to find a specific element)

```

var entry = new Entry
{
   AutomationId = "entryBox"
};

```

- Create NUnitTestProject
- `Install Nuget - Appium.Webdriver` (for xamarin.forms uwp use the `beta` as .net core not supported in 3.0.0.2)
- Download Windows Application Driver installer from https://github.com/Microsoft/WinAppDriver/releases and install
- get app id => C:\<PathToProject>\bin\x86\Debug\AppX\vs.appxrecipe (node `RegisteredUserModeAppID`)
    - used in 
    
    ```
    
     appCapabilities.AddAdditionalCapability("app", "f6e1170f-f196-4f71-a9d1-2a39b0baa6d2_njq1xtzjt291j!App");
     
    ```
- Initialise tests by checking if `WinAppDriver.exe` is running or not and start it up if not.
- follow [doc](https://github.com/Microsoft/WinAppDriver) to setup and write test or look at the examples as mentioned above

If you get an exception that the PC is refusing a connection, this means test initialization of the `WinAppDriver` did not run, you can manuannly run the WinAppDriver in `%ProgramFiles(x86)%\Windows Application Driver\WinAppDriver.exe` this will then allow tests to run.
