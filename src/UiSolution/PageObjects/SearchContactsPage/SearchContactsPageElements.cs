namespace UiSolution.PageObjects.SearchContactsPage
{
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public partial class SearchContactsPage: BasePage
    {
        public IWebElement InputSearch =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("keyword")));

        public IWebElement BtnSearch =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search")));

        public IWebElement SearchResults =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("searchResult")));
    }
}
