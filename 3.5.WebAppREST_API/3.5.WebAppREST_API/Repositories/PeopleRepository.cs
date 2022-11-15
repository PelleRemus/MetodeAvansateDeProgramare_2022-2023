using _3._5.WebAppREST_API.Data;
using _3._5.WebAppREST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._5.WebAppREST_API.Repositories
{
    public class PeopleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PeopleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Person> GetAll()
        {
            return _applicationDbContext.People.ToList();
        }

        public Person GetOne(int id)
        {
            return _applicationDbContext.People.FirstOrDefault(person => person.Id == id);
        }

        public void CreateOne(Person person)
        {
            _applicationDbContext.People.Add(person);
            _applicationDbContext.SaveChanges();
        }

        public void EditOne(int id, Person person)
        {
            Person dbPerson = GetOne(id);

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.NickName = person.NickName;
            dbPerson.Ocupation = person.Ocupation;
            dbPerson.Country = person.Country;
            dbPerson.Age = person.Age;

            _applicationDbContext.SaveChanges();
        }

        public void DeleteOne(int id)
        {
            Person dbPerson = GetOne(id);
            _applicationDbContext.People.Remove(dbPerson);
            _applicationDbContext.SaveChanges();
        }
    }
}
