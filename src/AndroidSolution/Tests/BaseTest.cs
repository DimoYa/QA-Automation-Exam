namespace AndroidSolution.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using System;

    [TestFixture]
    public abstract class BaseTest
    {
        private AppiumOptions appiumOptions;
        private string appiumServer;
        private string appDirectory;

        protected AndroidDriver<AndroidElement> Driver { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.appiumServer = "http://[::1]:4723/wd/hub";

            //app path here
            this.appDirectory = @"";
            this.appiumOptions = new AppiumOptions() { PlatformName = "Android" };
            this.appiumOptions.AddAdditionalCapability("app", appDirectory);
            this.Driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), appiumOptions);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.Driver.Dispose();
        }
    }
}