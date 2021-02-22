namespace ApiSolution.Models
{
    using System;

    public class ContactResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DateCreated { get; set; }

        public string Comments { get; set; }
    }
}
