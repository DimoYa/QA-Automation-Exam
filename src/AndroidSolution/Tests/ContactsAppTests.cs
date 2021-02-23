namespace AndroidSolution.Tests
{
    using NUnit.Framework;

    public class ContactsAppTests : BaseTest
    {
        [Test]
        public void SearchShouldBeSuccessfull()
        {
            //Arrange
            var searchedPhase = "steve";

            //Act
            this.ContactAppPage.ConnectToTheBackEnd();
            this.ContactAppPage.SearchForAContact(searchedPhase);

            //Assert
            var expectedResult = "Steve Jobs";
            var actualResult = this.ContactAppPage.GetReturnedResult();

            Assert.AreEqual(expectedResult, actualResult, "Result should be correct");
        }
    }
}
