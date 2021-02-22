namespace AndroidSolution.Tests
{
    using AndroidSolution.PageObjects.ContactAppPages;
    using NUnit.Framework;

    public class ContactsAppTests : BaseTest
    {
        private ContactAppPage contactAppPage;

        [SetUp]
        public void SetUp()
        {
            this.contactAppPage = new ContactAppPage(this.Driver);
        }

        [Test]
        public void SearchShouldBeSuccessfull()
        {
            //Arrange
            var searchedPhase = "steve";

            //Act
            this.contactAppPage.ConnectToTheBackEnd();
            this.contactAppPage.SearchForAContact(searchedPhase);

            //Assert
            var expectedResult = "Steve Jobs";
            var actualResult = this.contactAppPage.GetReturnedResult();

            Assert.AreEqual(expectedResult, actualResult, "Result should be correct");
        }
    }
}
