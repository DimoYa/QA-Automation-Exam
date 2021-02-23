namespace UiSolution.PageObjects
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected WebDriverWait Wait { get; private set; }
        protected IWebDriver Driver { get; private set; }
        protected string BaseUrl => "https://contactbook.dimoya.repl.co/";
    }
}
