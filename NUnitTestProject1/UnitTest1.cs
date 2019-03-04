using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        WindowsDriver<WindowsElement> _session;

        [SetUp]
        public void Setup()
        {
            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("platformName", PlatformType.Windows);
            appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            appCapabilities.AddAdditionalCapability("app", "f6e1170f-f196-4f71-a9d1-2a39b0baa6d2_njq1xtzjt291j!App");

            _session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
            Assert.IsNotNull(_session);           

        }

        [TearDown]
        public void TearDown()
        {
            _session?.Quit();
            _session = null;
        }

        [Test]
        public void Test1()
        {
            var pageText = _session.FindElementByAccessibilityId("MainPage").Text;
            Assert.AreEqual("This is the MainPage", pageText);

            _session.FindElementByAccessibilityId("entryBox").SendKeys("from test");

            var entryText = _session.FindElementByAccessibilityId("entryBox").Text;
            Assert.AreEqual("from test", entryText);

            _session.FindElementByAccessibilityId("NextButton").Click();

            var clieckedEntryText = _session.FindElementByAccessibilityId("entryBox").Text;
            Assert.AreEqual("Text entered from test", clieckedEntryText);

            _session.FindElementByAccessibilityId("NextButton").Click();

            Assert.AreEqual("from test", entryText);

        }
    }
}