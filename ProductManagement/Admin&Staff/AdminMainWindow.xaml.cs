using BusinessObject;
using ProductManagement.Admin_Staff.ManageCustomer;
using Repositories.AccountR;
using Repositories.CategoryR;
using Repositories.OrderDetailR;
using Repositories.ProductR;
using System.Windows;
using System.Windows.Input;

namespace ProductManagement.Admin_Staff
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private readonly IAccountRepository accountRepository;
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public AdminMainWindow()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
            orderDetailRepository = new OrderDetailRepository();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
            LoadProducts();
            LoadCategory();
            LoadOrder();
        }
        public async void LoadCustomers()
        {
            try
            {
                var customerActiveList = await accountRepository.GetAllActiveAccountCustomer();
                var customerDisableList = await accountRepository.GetAllADisableAccountCustomer();
                dtgActiveCustomers.ItemsSource = customerActiveList;
                dtgDisabledCustomers.ItemsSource = customerDisableList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of customers");
            }
        }

        public async void LoadProducts()
        {
            try
            {
                var productList = await productRepository.GetAllProduct();
                dtgProducts.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of products");
            }
        }

        public async void LoadCategory()
        {
            try
            {
                var categoryList = await categoryRepository.GetAllCategories();
                dtgCategories.ItemsSource = categoryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public async void LoadOrder()
        {
            try
            {
                var orderList = await orderDetailRepository.GetAllOrderDetail();
                dtgOrders.ItemsSource = orderList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of orders");
            }
        }
        // Management Customer
        private void Add_Click_Customer(object sender, MouseButtonEventArgs e)
        {
            AddNewCustomer addNewCustomer = new AddNewCustomer();
            addNewCustomer.Closed += (s, args) => LoadCustomers();
            addNewCustomer.Show();
        }
        private void Edit_Click_Customer(object sender, RoutedEventArgs e)
        {
            Account? selectedCustomer = (sender as FrameworkElement)?.DataContext as Account;

            if (selectedCustomer != null)
            {
                EditCustomer editCustomer = new EditCustomer();
                editCustomer.LoadCustomerData(selectedCustomer);
                editCustomer.Closed += (s, args) => LoadCustomers();
                editCustomer.Show();
            }
        }
        private async void Disable_Click_Customer(object sender, RoutedEventArgs e)
        {
            try
            {
                Account selectedCustomer = (Account)dtgActiveCustomers.SelectedItem;
                Account customer = await accountRepository.GetAccountById(selectedCustomer.AccountId);
                if (customer != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to disable this customer?",
                                                        "Confirm Disabling",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await accountRepository.DisableAccountCustomer(customer);
                        MessageBox.Show("Customer disabled successfully.");
                        LoadCustomers();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to disable.", "Disable Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot disable customer: " + ex.Message, "Disable Error");
            }
        }
        private async void Enable_Click_Customer(object sender, RoutedEventArgs e)
        {
            try
            {
                Account selectedCustomer = (Account)dtgActiveCustomers.SelectedItem;
                Account customer = await accountRepository.GetAccountById(selectedCustomer.AccountId);
                if (customer != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to enable this customer?",
                                                        "Confirm Enabling",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await accountRepository.EnableAccountCustomer(customer);
                        MessageBox.Show("Customer enable successfully.");
                        LoadCustomers();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to enable.", "Enable Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot enable customer: " + ex.Message, "Enable Error");
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }
        // Management Product
        private void Add_Click_Product(object sender, MouseButtonEventArgs e)
        {
            
        }
        private async void Delete_Click_Product(object sender, RoutedEventArgs e)
        {
            
        }
        private void Edit_Click_Product(object sender, RoutedEventArgs e)
        {
           
        }

        // Management Category
        private void Add_Click_Category(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Edit_Click_Category(object sender, RoutedEventArgs e)
        {
           
        }
        private async void Delete_Click_Category(object sender, RoutedEventArgs e)
        {

        }

        //Management Order
        private async void Delete_Click_Orders(object sender, RoutedEventArgs e)
        {
          
           
        }

    }
}
