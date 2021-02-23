namespace UiSolution.PageObjects.CreateContactPage
{
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public partial class CreateContactPage : BasePage
    {
        public IWebElement InputFirstName =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));

        public IWebElement InputLastName =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lastName")));

        public IWebElement InputEmail =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));

        public IWebElement InputPhone =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("phone")));

        public IWebElement InputComments =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("comments")));

        public IWebElement BtnCreate =>
         this.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("create")));

        public IWebElement ErrMsg =>
        this.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("err")));
    }
}
