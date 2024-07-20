using BusinessObject;
using ProductManagement.Customer.ManageProfile;
using Repositories.AccountR;
using System.Windows;

namespace ProductManagement.Customer
{
    /// <summary>
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        public Account LoggedInUser { get; set; }
        public readonly IAccountRepository accountRepository;
        public CustomerMainWindow()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
            DataContext = this;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayCustomerInfo();
        }
        private void DisplayCustomerInfo()
        {
            if (LoggedInUser != null)
            {
                txtFullName.Text = LoggedInUser.FullName;
                txtEmail.Text = LoggedInUser.Email;
                txtGender.IsChecked = LoggedInUser.Gender;
                txtPhone.Text = LoggedInUser.PhoneNumber;
                if (LoggedInUser.DayOfBirth.HasValue)
                {
                    txtDob.Text = LoggedInUser.DayOfBirth.Value.ToString("MM/dd/yyyy");
                }
                else
                {
                    txtDob.Text = string.Empty;
                }
                txtAddress.Text = LoggedInUser.Address;
            }
        }
        private void Update_Click_Profile(object sender, RoutedEventArgs e)
        {
            UpdateProfile updateProfileWindow = new UpdateProfile();
            updateProfileWindow.LoggedInUser = LoggedInUser;
            updateProfileWindow.Closed += (s, args) => DisplayCustomerInfo();
            updateProfileWindow.ShowDialog();
        }
    }
}
