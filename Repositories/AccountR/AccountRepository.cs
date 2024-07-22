using BusinessObject;
using DataLayerAccess;

namespace Repositories.AccountR
{
    public class AccountRepository : IAccountRepository
    {
        public async Task AddAccountCustomer(Account account) => await AccountDAO.Instance.AddAccountCustomer(account);

        public async Task<bool> AuthenticateUser(string email, string password) => await AccountDAO.Instance.AuthenticateUser(email, password);

        public async Task<Account> ChangePass(int accountId, string newPass) => await AccountDAO.Instance.ChangePass(accountId, newPass);
        public async Task<bool> CheckLogin(string email, string password) => await AccountDAO.Instance.CheckLogin(email, password);

        public async Task<bool> CheckStaff(string email) => await AccountDAO.Instance.CheckStaff(email);

        public async Task DisableAccountCustomer(Account account) => await AccountDAO.Instance.DisableAccountCustomer(account);

        public async Task EnableAccountCustomer(Account account) => await AccountDAO.Instance.EnableAccountCustomer(account);

        public async Task<Account> GetAccountByEmail(string email) => await AccountDAO.Instance.GetAccountByEmail(email);

        public async Task<Account> GetAccountById(int accountId) => await AccountDAO.Instance.GetAccountById(accountId);

        public async Task<List<Account>> GetAllActiveAccountCustomer() => await AccountDAO.Instance.GetAllActiveAccountCustomer();

        public async Task<List<Account>> GetAllADisableAccountCustomer() => await AccountDAO.Instance.GetAllADisableAccountCustomer();

        public async Task UpdateAccountCustomer(Account account) => await AccountDAO.Instance.UpdateAccountCustomer(account);

       
    }
}
