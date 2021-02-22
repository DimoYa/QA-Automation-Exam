namespace UiSolution.PageObjects.ViewContactsPage
{
    using OpenQA.Selenium;

    public partial class ViewContactsPage : BasePage
    {
        public ViewContactsPage(IWebDriver driver) 
            : base(driver)
        { }

        public string GetGirstContactFromList()
        {
            var result = $"{this.OldestFirstName.Text} {this.OldestLastName.Text}";
            return result;
        }

        public string GetLatestContactFromList()
        {
            var result = $"{this.LatestFirstName.Text} {this.LatestLastName.Text}";
            return result;
        }
    }
}
