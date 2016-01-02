using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webServer.Models.Interface;


namespace webServer.Models.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private DatabaseConnection db = new DatabaseConnection();

        public IEnumerable<Accounts> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }

        public Accounts GetAccountsByID(int id)
        {
            return db.Accounts.FirstOrDefault(a => a.id == id);
        }

        public void CreateAccounts(Accounts accounts)
        {
            db.Accounts.Add(accounts);
            db.SaveChanges();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void DeleteAccounts(int id)
        {
            var deleteAccount = GetAccountsByID(id);
            db.Accounts.Remove(deleteAccount);
            db.SaveChanges();
        }


    }
}