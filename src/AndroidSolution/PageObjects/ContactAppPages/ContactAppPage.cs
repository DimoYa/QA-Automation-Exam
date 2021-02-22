namespace AndroidSolution.PageObjects.ContactAppPages
{
    using OpenQA.Selenium.Appium.Android;

    public partial class ContactAppPage : BasePage
    {
        public ContactAppPage(AndroidDriver<AndroidElement> driver) 
            : base(driver)
        {
        }

        public void ConnectToTheBackEnd()
        {
            this.BtnConnect.Click();
        }

        public void SearchForAContact(string phase)
        {
            this.InputSearch.SendKeys(phase);
            this.BtnSearch.Click();
        }

        public string GetReturnedResult()
        {
            var result = $"{this.FirstName.Text} {this.LastName.Text}";

            return result;
        }
    }
}
