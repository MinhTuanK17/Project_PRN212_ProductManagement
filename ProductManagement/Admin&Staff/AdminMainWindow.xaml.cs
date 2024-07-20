using BusinessObject;
using ProductManagement.Admin_Staff.ManageCategory;
using ProductManagement.Admin_Staff.ManageCustomer;
using ProductManagement.Admin_Staff.ManageProduct;
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
            LoadCategories();
            LoadOrders();
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

        public async void LoadCategories()
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

        public async void LoadOrders()
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
                Account selectedCustomer = (Account)dtgDisabledCustomers.SelectedItem;
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
            AddNewProduct addNewProduct = new AddNewProduct();
            addNewProduct.Closed += (s, args) => LoadProducts();
            addNewProduct.Show();
        }
        private async void Delete_Click_Product(object sender, RoutedEventArgs e)
        {
            try
            {
                Product selectedPhone = (Product)dtgProducts.SelectedItem;
                Product phone = await productRepository.GetProductById(selectedPhone.ProductPhoneId);
                if (phone != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this phone?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await productRepository.DeleteProduct(phone);
                        MessageBox.Show("Phone deleted successfully.");
                        LoadProducts();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a phone to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete phone: " + ex.Message, "Delete Error");
            }
        }
        private void Update_Click_Product(object sender, RoutedEventArgs e)
        {
            Product selectProduct = (sender as FrameworkElement)?.DataContext as Product;

            if (selectProduct != null)
            {
                UpdateProduct updatePhone = new UpdateProduct();
                updatePhone.LoadProductData(selectProduct);
                updatePhone.Closed += (s, args) => LoadProducts();
                updatePhone.Show();
            }
        }

        // Management Category
        private void Add_Click_Category(object sender, MouseButtonEventArgs e)
        {
            AddNewCategory addNewCategory = new AddNewCategory();
            addNewCategory.Closed += (s, args) => LoadCategories();
            addNewCategory.Show();
        }

        private void Update_Click_Category(object sender, RoutedEventArgs e)
        {
            Category selectBrand = (sender as FrameworkElement)?.DataContext as Category;

            if (selectBrand != null)
            {
                UpdateCategory updateBrand = new UpdateCategory();
                updateBrand.LoadCategoryData(selectBrand);
                updateBrand.Closed += (s, args) => LoadCategories();
                updateBrand.Show();
            }
        }
        private async void Delete_Click_Category(object sender, RoutedEventArgs e)
        {
            try
            {
                Category selectedBrand = (Category)dtgCategories.SelectedItem;
                Category brand = await categoryRepository.GetCategoryById(selectedBrand.CategoryId);
                if (brand != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this Brand?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await categoryRepository.DeleteCategory(brand);
                        MessageBox.Show("Brand deleted successfully.");
                        LoadCategories();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a brand to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete brand: " + ex.Message, "Delete Error");
            }
        }

        //Management Order
        private async void Delete_Click_Orders(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail selectedOrder = (OrderDetail)dtgOrders.SelectedItem;
                OrderDetail ordering = await orderDetailRepository.GetOrderDetailById(selectedOrder.OrderId, selectedOrder.ProductPhoneId);
                if (ordering != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this order?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await orderDetailRepository.DeleteOrderDetail(ordering);
                        MessageBox.Show("Order deleted successfully.");
                        LoadOrders();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a order to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete order: " + ex.Message, "Delete Error");
            }

        }

    }
}
