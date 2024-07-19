using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AccountR
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByEmail(string email);
        Task<Account> GetAccountById(int accountId);
        Task<bool> CheckLogin(string email, string password);
        Task<bool> CheckStaff(string email);
        Task<bool> AuthenticateUser(string email, string password);
        Task<List<Account>> GetAllAccountCustomer();
        Task AddAccountCustomer(Account account);
        Task UpdateAccountCustomer(Account account);
        Task DisableAccountCustomer(Account account);

    }
}
