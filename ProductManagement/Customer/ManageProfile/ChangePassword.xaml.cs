using BusinessObject;
using MaterialDesignThemes.Wpf;
using Repositories.AccountR;
using System.Windows;

namespace ProductManagement.Customer.ManageProfile
{
    public partial class ChangePassword : Window
    {
        private readonly IAccountRepository accountRepository;
        public Account LoggedInUser { get; set; }

        private bool _isOldPasswordVisible = false;
        private bool _isNewPasswordVisible = false;
        private bool _isConfirmPasswordVisible = false;

        public ChangePassword()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
            DataContext = this;
        }

        private void TogglePasswordVisibility(object sender, RoutedEventArgs e)
        {
            var icon = sender as PackIcon;

            if (icon == null) return;

            if (icon == iconOldPassword)
            {
                _isOldPasswordVisible = !_isOldPasswordVisible;
                txtOldPassword.Visibility = _isOldPasswordVisible ? Visibility.Collapsed : Visibility.Visible;
                txtOldPasswordText.Visibility = _isOldPasswordVisible ? Visibility.Visible : Visibility.Collapsed;
                if (_isOldPasswordVisible)
                {
                    txtOldPasswordText.Text = txtOldPassword.Password;
                }
            }
            else if (icon == iconNewPassword)
            {
                _isNewPasswordVisible = !_isNewPasswordVisible;
                txtNewPassword.Visibility = _isNewPasswordVisible ? Visibility.Collapsed : Visibility.Visible;
                txtNewPasswordText.Visibility = _isNewPasswordVisible ? Visibility.Visible : Visibility.Collapsed;
                if (_isNewPasswordVisible)
                {
                    txtNewPasswordText.Text = txtNewPassword.Password;
                }
            }
            else if (icon == iconConfirmPassword)
            {
                _isConfirmPasswordVisible = !_isConfirmPasswordVisible;
                txtConfirmPassword.Visibility = _isConfirmPasswordVisible ? Visibility.Collapsed : Visibility.Visible;
                txtConfirmPasswordText.Visibility = _isConfirmPasswordVisible ? Visibility.Visible : Visibility.Collapsed;
                if (_isConfirmPasswordVisible)
                {
                    txtConfirmPasswordText.Text = txtConfirmPassword.Password;
                }
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            string oldPass = txtOldPasswordText.Text;
            string newPass = txtNewPasswordText.Text;
            string confirmPassword = txtConfirmPasswordText.Text;

            if (oldPass == LoggedInUser.Password)
            {
                if (newPass == confirmPassword)
                {
                    await accountRepository.ChangePass(LoggedInUser.AccountId, newPass);
                    MessageBox.Show("Change Password successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("New password and confirmation password do not match");
                }
            }
            else
            {
                MessageBox.Show("Current Password is incorrect");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
