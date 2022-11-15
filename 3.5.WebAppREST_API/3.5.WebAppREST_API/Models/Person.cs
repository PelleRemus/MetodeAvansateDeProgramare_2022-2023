using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._5.WebAppREST_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Country { get; set; }
        public string Ocupation { get; set; }
        public int Age { get; set; }
    }
}
