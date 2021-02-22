namespace ApiSolution.Models
{
    using Newtonsoft.Json;

    public class ContactRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
