namespace UiSolution.Tests
{
    using NUnit.Framework;
    using System;
    using UiSolution.PageObjects.CreateContractsPage;
    using UiSolution.PageObjects.HomePage;
    using UiSolution.PageObjects.ViewContactsPage;

    public class CreateContractsTests : BaseTest
    {
        private HomePage homePage;
        private ViewContactsPage viewContactsPage;
        private CreateContractsPage createContractsPage;

        [SetUp]
        public void SetUp()
        {
            this.homePage = new HomePage(this.Driver);
            this.viewContactsPage = new ViewContactsPage(this.Driver);
            this.createContractsPage = new CreateContractsPage(this.Driver);
        }

        [Test]
        [TestCase("", "lastName", "test@test.bg", "+12345", "comment", "Error: First name cannot be empty!")]
        [TestCase("firstName", "", "test@test.bg", "+12345", "comment", "Error: Last name cannot be empty!")]
        [TestCase("firstName", "lastName", "", "+12345", "comment", "Error: Invalid email!")]
        public void CreationOfInvalidContractShouldDisplayError(string firstName, string lastName, string email,
            string phone, string comment, string expectedErrMsg)
        {
            //Act
            this.homePage.NavigateToMainUrl();
            this.homePage.NavigateToCreateContacts();
            this.createContractsPage.CreateContact(firstName, lastName, email, phone, comment);

            //Assert
            Assert.AreEqual(expectedErrMsg, this.createContractsPage.ErrMsg.Text, "Error should be displayed");
        }

        [Test]
        public void CreationOfValidContractShouldbeListedAtTheEndOfList()
        {
            //Arrange
            var firstName = $"First{Guid.NewGuid()}";
            var lastName = $"Last{Guid.NewGuid()}";
            var email = $"email@{Guid.NewGuid()}.com";
            var phone = Guid.NewGuid().ToString();
            var comment = $"comments@{Guid.NewGuid()}.com";

            //Act
            this.homePage.NavigateToMainUrl();
            this.homePage.NavigateToCreateContacts();
            this.createContractsPage.CreateContact(firstName, lastName, email, phone, comment);

            //Assert
            var actualLastContact = this.viewContactsPage.GetLatestContactFromList();
            Assert.AreEqual($"{firstName} {lastName}", actualLastContact, "contact should be correct");
        }
    }
}
