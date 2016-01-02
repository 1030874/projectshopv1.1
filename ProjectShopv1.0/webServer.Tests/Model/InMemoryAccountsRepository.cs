using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webServer.Models;
using webServer.Models.Interface;

namespace webServer.Tests.Model
{
    class InMemoryAccountsRepository : IAccountsRepository
    {

        private List<Accounts> db = new List<Accounts>();

        public Exception ExceptionToThrow { get; set; }


        public IEnumerable<Accounts> GetAllAccounts()
        {
            return db.ToList();
        }

        public Accounts GetAccountsByID(int id)
        {
            return db.FirstOrDefault(a => a.id == id);
        }

        public void CreateAccounts(Accounts accounts)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            db.Add(accounts);
        }

        public void SaveChanges(Accounts accountsToUpdate)
        {
            foreach (Accounts accounts in db)
            {
                if (accounts.id == accountsToUpdate.id)
                {
                    db.Remove(accounts);
                    db.Add(accountsToUpdate);
                    break;

                }

            }
        }

        public void Add(Accounts accountsToAdd)
        {
            db.Add(accountsToAdd);
        }
        public int SaveChanges()
        {
            return 1;
        }

        public void DeleteAccounts(int id)
        {
            db.Remove(GetAccountsByID(id));
        }


    }
}
