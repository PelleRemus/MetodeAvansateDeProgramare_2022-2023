using _3._5.WebAppREST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._5.WebAppREST_API.Repositories
{
    public class PeopleRepository
    {
        public List<Person> people = new List<Person>()
        {
            new Person() { Id = 1, FirstName = "Remus", LastName = "Pelle", Age = 23,
                Country = "Romania", NickName = "Nicholas", Ocupation = "Prof" },
            new Person() { Id = 2, FirstName = "Marcela", LastName = "Doe", Age = 54,
                Country = "UK", NickName = "Marci", Ocupation = "None" },
        };
    }
}
