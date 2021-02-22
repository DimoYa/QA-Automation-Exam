namespace UiSolution.Tests
{
    using NUnit.Framework;
    using UiSolution.PageObjects.HomePage;
    using UiSolution.PageObjects.SearchContactsPage;
    using UiSolution.PageObjects.ViewContactsPage;

    public class SearchContactsTests : BaseTest
    {
        private HomePage homePage;
        private ViewContactsPage viewContactsPage;
        private SearchContactsPage searchContactsPage;

        [SetUp]
        public void SetUp()
        {
            this.homePage = new HomePage(this.Driver);
            this.viewContactsPage = new ViewContactsPage(this.Driver);
            this.searchContactsPage = new SearchContactsPage(this.Driver);
        }

        [Test]
        public void SearchForAContactShouldDiplayTheRightOne()
        {
            //Arrange
            var searchedPhase = "albert";

            //Act
            this.homePage.NavigateToMainUrl();
            this.homePage.NavigateToSearchContacts();
            this.searchContactsPage.SearchForAContact(searchedPhase);

            //Assert
            var actualFirstContact = this.viewContactsPage.GetGirstContactFromList();
            Assert.AreEqual("Albert Einstein", actualFirstContact, "contact should be correct");
        }

        [Test]
        public void SearchForInvalidContactShouldDiplayErrMsg()
        {
            //Arrange
            var searchedPhase = "invalid2635";

            //Act
            this.homePage.NavigateToMainUrl();
            this.homePage.NavigateToSearchContacts();
            this.searchContactsPage.SearchForAContact(searchedPhase);

            //Assert
            Assert.AreEqual("No contacts found.", this.searchContactsPage.SearchResults.Text, "contact should be correct");
        }
    }
}
