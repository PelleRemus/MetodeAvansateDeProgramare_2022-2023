using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _3._5.WebAppREST_API.Models
{
    public class Person
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Country { get; set; }
        public string Ocupation { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public List<Email> SentEmails { get; set; }
        [JsonIgnore]
        public List<Email> InboxEmails { get; set; }
    }
}
