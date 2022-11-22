using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _3._5.WebAppREST_API.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        [ForeignKey("From")]
        public int FromId { get; set; }
        public Person From { get; set; }
        /*public string ToIds { get; set; }
        public List<Person> To { get; set; }*/
    }
}
