using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Common
{
    public class AdminAccount
    {
        private readonly IConfiguration _configuration;

        public AdminAccount(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AdminAccount()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public async Task<Account> CheckAdminAccount()
        {
            try
            {
                var adminEmail = await Task.Run(() => _configuration["AdminAccount:Email"]);
                var adminPassword = await Task.Run(() => _configuration["AdminAccount:Password"]);
                var adminRoleId = await Task.Run(() => _configuration["AdminAccount:RoleId"]);

                var adminAccount = new Account
                {
                    Email = adminEmail,
                    Password = adminPassword,
                    RoleId = Convert.ToInt32(adminRoleId) 
                };

                return adminAccount;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading admin account from configuration: " + ex.Message);
            }
        }

    }
}
