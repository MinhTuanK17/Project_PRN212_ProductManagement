using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class AccountDAO : SingletonBase<AccountDAO>
    {
        private MyPhoneDbContext? _context;
        private AdminAccount? _admin;
        public async Task<Account> GetAccountByEmail(string email)
        {
            try
            {
                _context = new();
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
                return account!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Account> GetAccountById(int accountId)
        {
            try
            {
                _context = new();
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
                return account!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> CheckLogin(string email, string password)
        {
            try
            {
                _context = new();
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email) && a.Password.Equals(password));
                return account != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> CheckStaff(string email)
        {
            try
            {
                _context = new();
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email) && a.RoleId == 2);
                return account != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                _admin = new();
                var adminAccount = await _admin.CheckAdminAccount();
                return adminAccount.Email == email && adminAccount.Password == password;
            }
            catch (Exception e)
            {
                throw new Exception("Error authenticating user: " + e.Message);
            }
        }

        public async Task<List<Account>> GetAllAccountCustomer()
        {
            _context = new();
            return await _context.Accounts.AsNoTracking().Where(a => a.RoleId == 1).ToListAsync();
        }

        public async Task AddAccountCustomer(Account account)
        {
            _context = new();
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountCustomer(Account account)
        {
            try
            {
                _context = new();
                var findAccount = await GetAccountById(account.AccountId);
                if (findAccount != null)
                {
                    _context.Entry(findAccount).CurrentValues.SetValues(account);
                }
                else
                {
                    _context.Accounts.Update(account);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DisableAccountCustomer(Account account)
        {
            try
            {
                _context = new();
                var findAccount = await GetAccountById(account.AccountId);
                if (findAccount != null)
                {
                    findAccount.RoleId = 4;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error blocked account customer: " + e.Message);
            }
        }

    }
}
