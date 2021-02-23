namespace UiSolution.Tests
{
    using NUnit.Framework;
    using System;

    public class CreateContactTests : BaseTest
    {
        [Test]
        [TestCase("", "lastName", "test@test.bg", "+12345", "comment", "Error: First name cannot be empty!")]
        [TestCase("firstName", "", "test@test.bg", "+12345", "comment", "Error: Last name cannot be empty!")]
        [TestCase("firstName", "lastName", "", "+12345", "comment", "Error: Invalid email!")]
        public void CreationOfInvalidContactShouldDisplayError(string firstName, string lastName, string email,
            string phone, string comment, string expectedErrMsg)
        {
            //Act
            this.HomePage.NavigateToMainUrl();
            this.HomePage.NavigateToCreateContacts();
            this.CreateContactPage.CreateContact(firstName, lastName, email, phone, comment);

            //Assert
            Assert.AreEqual(expectedErrMsg, this.CreateContactPage.ErrMsg.Text, "Error should be displayed");
        }

        [Test]
        public void CreationOfValidContactShouldBeListedAtTheEndOfList()
        {
            //Arrange
            var firstName = $"First{Guid.NewGuid()}";
            var lastName = $"Last{Guid.NewGuid()}";
            var email = $"email@{Guid.NewGuid()}.com";
            var phone = Guid.NewGuid().ToString();
            var comment = $"comments{Guid.NewGuid()}";

            //Act
            this.HomePage.NavigateToMainUrl();
            this.HomePage.NavigateToCreateContacts();
            this.CreateContactPage.CreateContact(firstName, lastName, email, phone, comment);

            //Assert
            var actualLastContact = this.ViewContactsPage.GetLatestContactFromList();
            Assert.AreEqual($"{firstName} {lastName}", actualLastContact, "contact should be correct");
        }
    }
}
