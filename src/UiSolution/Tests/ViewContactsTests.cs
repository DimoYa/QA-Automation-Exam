namespace UiSolution.Tests
{
    using NUnit.Framework;
    using UiSolution.PageObjects.HomePage;
    using UiSolution.PageObjects.ViewContactsPage;

    public class ViewContactsTests : BaseTest
    {
        [Test]
        public void ListOfContactsDisplayFirstContactSteveJobs()
        {
            //Arrange
            var expectedFirstContact = "Steve Jobs";

            //Act
            this.HomePage.NavigateToMainUrl();
            this.HomePage.NavigateToViewContacts();

            //Assert
            var actualFirstContact = this.ViewContactsPage.GetFirstContactFromList();
            Assert.AreEqual(expectedFirstContact, actualFirstContact, "contact should be correct");
        }
    }
}
