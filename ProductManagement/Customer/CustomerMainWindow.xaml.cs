using BusinessObject;
using ProductManagement.Admin_Staff.ManageCustomer;
using ProductManagement.Customer.ManageProfile;
using Repositories.AccountR;
using Repositories.CategoryR;
using Repositories.OrderDetailR;
using Repositories.ProductR;
using System.Windows;
using System.Windows.Controls;

namespace ProductManagement.Customer
{
    /// <summary>
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        public Account LoggedInUser { get; set; }
        public readonly IAccountRepository accountRepository;
        public readonly ICategoryRepository categoryRepository;
        public readonly IProductRepository productRepository;
        public readonly IOrderDetailRepository orderDetailRepository;
        public CustomerMainWindow()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
            categoryRepository = new CategoryRepository();
            productRepository = new ProductRepository();
            orderDetailRepository = new OrderDetailRepository();
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
            LoadCategoryList();
            LoadProductList();
            LoadOrderHistoryList();
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
                    txtDob.Text = LoggedInUser.DayOfBirth.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtDob.Text = string.Empty;
                }
                txtAddress.Text = LoggedInUser.Address;
            }
        }
        public async void LoadCategoryList()
        {
            try
            {
                var catList = await categoryRepository.GetAllCategories();
                cbCategoriesSearch.ItemsSource = catList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }
        //Module Phone
        public async void LoadProductList()
        {
            try
            {
                var productList = await productRepository.GetAllProduct();
                dtgPhones.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of phones");
            }
        }
        private void txtSearch_TextChanged(Object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                txtSearchPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder.Visibility = Visibility.Visible;

            }
        }
        private void cbCategoriesSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbCategoriesSearchPlaceHolder.Visibility = cbCategoriesSearch.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
        }
        private void RefreshSearch()
        {
            txtSearch.Text = "";
            cbCategoriesSearch.SelectedValue = null;
        }
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgPhones.ItemsSource = await productRepository.SearchProductByName(txtSearch.Text, (int?)cbCategoriesSearch.SelectedValue);
                RefreshSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No result");
            }
        }
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            LoadProductList();
        }
        private void Update_Click_Profile(object sender, RoutedEventArgs e)
        {
            UpdateProfile updateProfileWindow = new UpdateProfile();
            updateProfileWindow.LoggedInUser = LoggedInUser;
            updateProfileWindow.Closed += (s, args) => DisplayCustomerInfo();
            updateProfileWindow.ShowDialog();
        }

        //Module History
        public async void LoadOrderHistoryList()
        {
            try
            {
                var orderHistory = await orderDetailRepository.GetOrderHistory(LoggedInUser.AccountId);
                dtgOrdersHistory.ItemsSource = orderHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of Order History");
            }
        }



        //Module Change Pass
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void DisableAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
