namespace UiSolution.PageObjects.CreateContactPage
{
    using OpenQA.Selenium;

    public partial class CreateContactPage : BasePage
    {
        public CreateContactPage(IWebDriver driver) 
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
