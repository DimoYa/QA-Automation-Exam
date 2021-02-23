namespace ApiSolution
{
    using ApiSolution.Models;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class ApiTests
    {
        private const string ApiEndpoint = "https://contactbook.dimoya.repl.co/api/";
        private HttpClient httpClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.httpClient = new HttpClient()
            {
                BaseAddress = new Uri(ApiEndpoint),
                Timeout = TimeSpan.FromSeconds(3)
            };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.httpClient.Dispose();
        }

        [Test]
        public async Task ListAllContactsShouldContainsSteveJobs()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "contacts");

            //Act
            var response = await this.httpClient.SendAsync(request);
            var contacts = JsonConvert.DeserializeObject<List<ContactResponse>>(await response.Content.ReadAsStringAsync());
            var firstContact = contacts.FirstOrDefault();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code should be OK");
                Assert.AreEqual("Steve", firstContact.FirstName, "First Name should be correct");
                Assert.AreEqual("Jobs", firstContact.LastName, "Last Name should be correct");
            });
        }

        [Test]
        public async Task SearchValidContactShouldReturnCorrectResult()
        {
            //Arrange
            var keyword = "albert";
            var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/search/{keyword}");

            //Act
            var response = await this.httpClient.SendAsync(request);
            var contacts = JsonConvert.DeserializeObject<List<ContactResponse>>(await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code should be OK");
                Assert.That(contacts.Select(c => c.FirstName).Contains("Albert"), "First Name should be correct");
                Assert.That(contacts.Select(c => c.LastName).Contains("Einstein"), "Last Name should be correct");
            });
        }

        [Test]
        public async Task SearchInValidContactShouldReturnEmptyList()
        {
            //Arrange
            var keyword = $"missing{Guid.NewGuid()}";
            var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/search/{keyword}");

            //Act
            var response = await this.httpClient.SendAsync(request);
            var contacts = JsonConvert.DeserializeObject<List<ContactResponse>>(await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code should be OK");
                Assert.That(contacts, Is.Empty, "Array should be empty");
            });
        }

        [Test]
        [TestCase("", "lastName", "test@test.bg", "+12345", "comment", "First name cannot be empty!")]
        [TestCase("firstName", "", "test@test.bg", "+12345", "comment", "Last name cannot be empty!")]
        [TestCase("firstName", "lastName", "", "+12345", "comment", "Invalid email!")]
        public async Task CreationOfInvalidContactShouldReturnErrMsg(string firstName, string lastName, string email,
            string phone, string comment, string expectedErrMsg)
        {
            //Arrange
            var invalidContract = new ContactRequest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Comments = comment
            };
            var response = await CreateContact(invalidContract);
            var error = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "Status code should be BadRequest");
                Assert.AreEqual(expectedErrMsg, error.ErrMsg, "Err msg should be correct");
            });
        }

        [Test]
        public async Task CreationOfValidContactShouldReturnCreatedAndData()
        {
            //Arrange
            var validContract = new ContactRequest
            {
                FirstName = $"First{Guid.NewGuid()}",
                LastName = $"Last{Guid.NewGuid()}",
                Email = $"email@{Guid.NewGuid()}.com",
                Phone = Guid.NewGuid().ToString(),
                Comments = $"comments{Guid.NewGuid()}"
            };
            var response = await CreateContact(validContract);
            var contact = JsonConvert.DeserializeObject<CreateContactResponse>(await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "Status code should be Created");
                Assert.AreEqual("Contact added.", contact.Msg, "Success msg should be received");
                Assert.AreEqual(validContract.FirstName, contact.Contact.FirstName, "First Name should be correct");
                Assert.AreEqual(validContract.LastName, contact.Contact.LastName, "Last Name should be correct");
                Assert.AreEqual(validContract.Email, contact.Contact.Email, "Email should be correct");
                Assert.AreEqual(validContract.Phone, contact.Contact.Phone, "Phone should be correct");
                Assert.AreEqual(validContract.Comments, contact.Contact.Comments, "Comments should be correct");
            });
        }

        [Test]
        public async Task NewlyCreatedContactShouldBeListedInTheContactList()
        {
            //Arrange
            var validContact = new ContactRequest
            {
                FirstName = $"First{Guid.NewGuid()}",
                LastName = $"Last{Guid.NewGuid()}",
                Email = $"email@{Guid.NewGuid()}.com",
                Phone = Guid.NewGuid().ToString(),
                Comments = $"comments{Guid.NewGuid()}"
            };

            var response = await CreateContact(validContact);
            response.EnsureSuccessStatusCode();

            //Act
            var request = new HttpRequestMessage(HttpMethod.Get, "contacts");
            response = await this.httpClient.SendAsync(request);
            var contacts = JsonConvert.DeserializeObject<List<ContactResponse>>(await response.Content.ReadAsStringAsync());
            var latestContact = contacts.FirstOrDefault(x => x.FirstName == validContact.FirstName);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code should be OK");
                Assert.That(latestContact, Is.Not.Null, "Contact should be not null");
            });
        }

        private async Task<HttpResponseMessage> CreateContact(ContactRequest contract)
        {
            var json = JsonConvert.SerializeObject(contract);

            var request = new HttpRequestMessage(HttpMethod.Post, "contacts")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await this.httpClient.SendAsync(request);
            return response;
        }
    }
}