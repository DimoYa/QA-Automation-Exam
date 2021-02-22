namespace UiSolution.Tests
{
    using NUnit.Framework;
    using UiSolution.PageObjects.HomePage;
    using UiSolution.PageObjects.ViewContactsPage;

    public class ViewContactsTests : BaseTest
    {
        private HomePage homePage;
        private ViewContactsPage viewContactsPage;

        [SetUp]
        public void SetUp()
        {
            this.homePage = new HomePage(this.Driver);
            this.viewContactsPage = new ViewContactsPage(this.Driver);
        }

        [Test]
        public void ListOfContactsDisplayFirstContactSteveJobs()
        {
            //Arrange
            var expectedFirstContact = "Steve Jobs";

            //Act
            this.homePage.NavigateToMainUrl();
            this.homePage.NavigateToViewContacts();

            //Assert
            var actualFirstContact = this.viewContactsPage.GetGirstContactFromList();
            Assert.AreEqual(expectedFirstContact, actualFirstContact, "contact should be correct");
        }
    }
}
