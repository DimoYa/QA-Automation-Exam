namespace UiSolution.PageObjects.HomePage
{
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) 
            : base(driver)
        {}

        public void NavigateToMainUrl()
        {
            this.Driver.Url = this.BaseUrl;
        }

        public void NavigateToViewContacts()
        {
            this.Driver.Url = $"{this.BaseUrl}contacts";
        }

        public void NavigateToSearchContacts()
        {
            this.Driver.Url = $"{this.BaseUrl}contacts/search";
        }

        public void NavigateToCreateContacts()
        {
            this.Driver.Url = $"{this.BaseUrl}contacts/create";
        }
    }
}
