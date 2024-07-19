using ProductManagement.Admin_Staff;
using ProductManagement.Customer;
using Repositories.AccountR;
using System.Windows;
using BusinessObject;

namespace ProductManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountRepository accountRepository;

        public LoginWindow()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (await accountRepository.AuthenticateUser(email, password))
            {
                MessageBox.Show("Login successfully!");
                AdminMainWindow adminWindow = new AdminMainWindow();
                this.Hide();
                adminWindow.Show();
            }
            else
            {
                if (await accountRepository.CheckLogin(email, password))
                {
                    if (await accountRepository.CheckStaff(email))
                    {
                        MessageBox.Show("Login successfully!");
                        AdminMainWindow adminWindow = new AdminMainWindow();
                        this.Hide();
                        adminWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login successfully!");
                        this.Hide();
                        Account customer = await accountRepository.GetAccountByEmail(email);
                        CustomerMainWindow customerWindow = new CustomerMainWindow();
                        //customerWindow.LoggedInUser = customer;
                        customerWindow.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Email or Password is wrong! Please login again!");
                }
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
