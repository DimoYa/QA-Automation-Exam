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

        protected WebDriverWait Wait { get; set; }
        protected IWebDriver Driver { get; set; }
        protected string BaseUrl => "https://contactbook.nakov.repl.co/";
    }
}
