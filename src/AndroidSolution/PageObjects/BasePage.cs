namespace AndroidSolution.PageObjects
{
    using OpenQA.Selenium.Appium.Android;
    using System;

    public abstract class BasePage
    {
        public BasePage(AndroidDriver<AndroidElement> driver)
        {
            this.Driver = driver;
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        protected AndroidDriver<AndroidElement> Driver { get; set; }
    }
}
