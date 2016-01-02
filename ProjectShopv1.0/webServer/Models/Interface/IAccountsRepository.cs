using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webServer.Models.Interface
{
    public interface IAccountsRepository
    {
        IEnumerable<Accounts> GetAllAccounts();
        Accounts GetAccountsByID(int id);
        void CreateAccounts(Accounts accounts);
        void DeleteAccounts(int id);
        int SaveChanges();
    }
}