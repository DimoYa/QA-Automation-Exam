namespace UiSolution.PageObjects.ViewContactsPage
{
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public partial class ViewContactsPage : BasePage
    {
        public IWebElement OldestFirstName =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//table)[1]//tr[@class='fname']//td")));

        public IWebElement OldestLastName =>
          this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//table)[1]//tr[@class='lname']//td")));

        public IWebElement LatestFirstName =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//table)[last()]//tr[@class='fname']//td")));

        public IWebElement LatestLastName =>
          this.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//table)[last()]//tr[@class='lname']//td")));
    }
}
