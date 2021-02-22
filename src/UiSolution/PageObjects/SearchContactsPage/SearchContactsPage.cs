namespace UiSolution.PageObjects.SearchContactsPage
{
    using OpenQA.Selenium;
    using System.Threading;

    public partial class SearchContactsPage : BasePage
    {
        public SearchContactsPage(IWebDriver driver) 
            : base(driver)
        { }

        public void SearchForAContact(string phase)
        {
            this.InputSearch.SendKeys(phase);
            this.BtnSearch.Click();
        }
    }
}
