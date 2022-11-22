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

        public List<Person> GetFilteredAndPaginated(string search, int page, int pageSz)
        {
            int pageSkip = page - 1;
            if (pageSkip == -1)
                pageSkip = 0;
            //int pageSkip = page == 0 ? 0 : page - 1;

            int pageSize = pageSz;
            if (pageSize == 0)
                pageSize = 10;
            //int pageSize = pageSz == 0 ? 10 : pageSz;

            return _applicationDbContext.People
                .ToList()
                .Where(person => SearchInteligent(person, search))
                .Skip(pageSkip * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Person GetOne(int id)
        {
            return _applicationDbContext.People.First(person => person.Id == id);
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

        private bool SearchInteligent(Person person, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            // avem nevoie de toate numele separate
            char[] separatori = new char[] { ' ', '-' };
            string numePrenume = $"{person.FirstName} {person.LastName}";
            string[] toateNumele = numePrenume.Split(separatori);

            // si inputul trebuie separat
            string[] inputs = input.Split(separatori);

            for (int i = 0; i < inputs.Length; i++)
            {
                // presupunem ca inputul curent nu apare in nume
                bool ok = false;
                // si verificam daca apare in vreun nume
                for (int j = 0; j < toateNumele.Length; j++)
                    if (toateNumele[j].ToLower().Contains(inputs[i].ToLower()))
                        ok = true;

                if (!ok)
                    return false;
            }
            return true;
        }
    }
}
