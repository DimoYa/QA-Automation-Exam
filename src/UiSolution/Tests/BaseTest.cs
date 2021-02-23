namespace UiSolution.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Reflection;
    using UiSolution.PageObjects.CreateContractsPage;
    using UiSolution.PageObjects.HomePage;
    using UiSolution.PageObjects.SearchContactsPage;
    using UiSolution.PageObjects.ViewContactsPage;

    [TestFixture]
    public abstract class BaseTest
    {
        private static readonly string LocalPath =
              Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected IWebDriver Driver { get; private set; }

        protected HomePage HomePage { get; private set; }

        protected ViewContactsPage ViewContactsPage { get; private set; }

        protected CreateContactPage CreateContactPage { get; private set; }

        protected SearchContactsPage SearchContactsPage { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.Driver = new ChromeDriver(LocalPath);
            this.Driver.Manage().Window.Maximize();
            this.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        [SetUp]
        public void SetUp()
        {
            this.HomePage = new HomePage(this.Driver);
            this.ViewContactsPage = new ViewContactsPage(this.Driver);
            this.CreateContactPage = new CreateContactPage(this.Driver);
            this.SearchContactsPage = new SearchContactsPage(this.Driver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.Driver.Dispose();
        }
    }
}