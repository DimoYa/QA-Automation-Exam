namespace UiSolution.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public abstract class BaseTest
    {
        private static readonly string LocalPath =
              Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Driver = new ChromeDriver(LocalPath);
            this.Driver.Manage().Window.Maximize();
            this.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.Driver.Dispose();
        }
    }
}