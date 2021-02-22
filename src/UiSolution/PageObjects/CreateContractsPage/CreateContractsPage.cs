namespace UiSolution.PageObjects.CreateContractsPage
{
    using OpenQA.Selenium;
    using System.Threading;

    public partial class CreateContractsPage : BasePage
    {
        public CreateContractsPage(IWebDriver driver) 
            : base(driver)
        { }

        public void CreateContact(string firstName, string lastName, string email, string phone, string comment)
        {
            this.InputFirstName.SendKeys(firstName);
            this.InputLastName.SendKeys(lastName);
            this.InputEmail.SendKeys(email);
            this.InputPhone.SendKeys(phone);
            this.InputComments.SendKeys(comment);
            this.BtnCreate.Click();
        }
    }
}
