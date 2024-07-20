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

namespace ProductManagement.Admin_Staff.ManageCustomer
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private readonly IAccountRepository accountRepository;
        public EditCustomer()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
        }
        public void LoadCustomerData(Account customer)
        {
            txtCustomerId.Text = customer.AccountId.ToString();
            txtCustomerFullName.Text = customer.FullName;
            ckbGender.IsChecked = customer.Gender;
            txtEmail.Text = customer.Email;
            txtAddress.Text = customer.Address;
            txtdob.Text = customer.DayOfBirth.ToString();
            txtPhone.Text = customer.PhoneNumber;
            txtPassword.Text = customer.Password;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int customerId = int.Parse(txtCustomerId.Text);
                Account customer = await accountRepository.GetAccountById(customerId);
                if (customer != null)
                {
                    customer.FullName = txtCustomerFullName.Text;
                    customer.Gender = ckbGender.IsChecked ?? true;
                    customer.Email = txtEmail.Text;
                    customer.Address = txtAddress.Text;
                    customer.DayOfBirth = DateTime.Parse(txtdob.Text);
                    customer.PhoneNumber = txtPhone.Text;
                    customer.Password = txtPassword.Text;
                    await accountRepository.UpdateAccountCustomer(customer);
                    MessageBox.Show("Edit Customer Successfully!", "Note");
                    this.Close();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Cannot update customer");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
