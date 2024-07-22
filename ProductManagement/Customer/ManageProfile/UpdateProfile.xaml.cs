using BusinessObject;
using Repositories.AccountR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductManagement.Customer.ManageProfile
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        public Account LoggedInUser { get; set; }
        public readonly IAccountRepository accountRepository;

        public UpdateProfile()
        {
            InitializeComponent(); 
            accountRepository = new AccountRepository();
            Loaded += UpdateProfile_Loaded;
        }
        private void UpdateProfile_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProfileCustomer();
        }

        public void LoadProfileCustomer()
        {
            if (LoggedInUser != null)
            {
                txtFullName.Text = LoggedInUser.FullName;
                txtEmail.Text = LoggedInUser.Email;
                txtGender.IsChecked = LoggedInUser.Gender;
                txtPhone.Text = LoggedInUser.PhoneNumber;
                txtDob.Text = LoggedInUser.DayOfBirth.Value.ToString("dd/MM/yyyy");
                txtAddress.Text = LoggedInUser.Address;
            }
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoggedInUser != null)
                {
                    LoggedInUser.FullName = txtFullName.Text;
                    LoggedInUser.Email = txtEmail.Text;
                    LoggedInUser.Gender = txtGender.IsChecked;
                    LoggedInUser.PhoneNumber = txtPhone.Text;
                    LoggedInUser.DayOfBirth = DateTime.Parse(txtDob.Text);
                    LoggedInUser.Address = txtAddress.Text;

                    await accountRepository.UpdateAccountCustomer(LoggedInUser);
                    MessageBox.Show("Profile updated successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
