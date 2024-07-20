using BusinessObject;
using Microsoft.Identity.Client;
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
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        private readonly IAccountRepository accountRepository;
        public AddNewCustomer()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account customer = new Account
                {
                    FullName = txtCustomerFullName.Text,
                    Gender = ckbGender.IsChecked ?? true,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    DayOfBirth = DateTime.Parse(txtdob.Text),
                    PhoneNumber = txtPhone.Text,
                    Password = txtPassword.Text,
                    RoleId = 1
                };

                await accountRepository.AddAccountCustomer(customer);
                MessageBox.Show("Add Customer Successfully!", "Note");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Can not add customer");
            }
        }
    }
}

