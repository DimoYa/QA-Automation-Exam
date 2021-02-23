namespace UiSolution.Tests
{
    using NUnit.Framework;

    public class SearchContactsTests : BaseTest
    {
        [Test]
        public void SearchForAContactShouldDiplayTheRightOne()
        {
            //Arrange
            var searchedPhase = "albert";

            //Act
            this.HomePage.NavigateToMainUrl();
            this.HomePage.NavigateToSearchContacts();
            this.SearchContactsPage.SearchForAContact(searchedPhase);

            //Assert
            var actualFirstContact = this.ViewContactsPage.GetFirstContactFromList();
            Assert.AreEqual("Albert Einstein", actualFirstContact, "contact should be correct");
        }

        [Test]
        public void SearchForInvalidContactShouldDiplayErrMsg()
        {
            //Arrange
            var searchedPhase = "invalid2635";

            //Act
            this.HomePage.NavigateToMainUrl();
            this.HomePage.NavigateToSearchContacts();
            this.SearchContactsPage.SearchForAContact(searchedPhase);

            //Assert
            Assert.AreEqual("No contacts found.", this.SearchContactsPage.SearchResults.Text, "contact should be correct");
        }
    }
}
