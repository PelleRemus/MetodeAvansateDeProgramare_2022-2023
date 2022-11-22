using _3._5.WebAppREST_API.Data;
using _3._5.WebAppREST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3._5.WebAppREST_API.Repositories
{
    public class EmailsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmailsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Email> GetAll()
        {
            return _applicationDbContext.Emails.ToList();
        }

        public Email GetOne(int id)
        {
            return _applicationDbContext.Emails.First(email => email.Id == id);
        }

        public void CreateOne(Email email)
        {
            _applicationDbContext.Emails.Add(email);
            _applicationDbContext.SaveChanges();
        }

        public void EditOne(int id, Email email)
        {
            Email dbEmail = GetOne(id);

            dbEmail.Body = email.Body;
            dbEmail.FromId = email.FromId;
            dbEmail.Subject = email.Subject;

            _applicationDbContext.SaveChanges();
        }

        public void DeleteOne(int id)
        {
            Email dbEmail = GetOne(id);
            _applicationDbContext.Emails.Remove(dbEmail);
            _applicationDbContext.SaveChanges();
        }
    }
}
