namespace AndroidSolution.PageObjects.ContactAppPages
{
    using OpenQA.Selenium.Appium.Android;

    public partial class ContactAppPage : BasePage
    {
        public AndroidElement BtnConnect =>
           this.Driver.FindElementById("contactbook.androidclient:id/buttonConnect");

        public AndroidElement InputSearch =>
           this.Driver.FindElementById("contactbook.androidclient:id/editTextKeyword");

        public AndroidElement BtnSearch =>
           this.Driver.FindElementById("contactbook.androidclient:id/buttonSearch");

        public AndroidElement FirstName =>
          this.Driver.FindElementById("contactbook.androidclient:id/textViewFirstName");

        public AndroidElement LastName =>
        this.Driver.FindElementById("contactbook.androidclient:id/textViewLastName");
    }
}
