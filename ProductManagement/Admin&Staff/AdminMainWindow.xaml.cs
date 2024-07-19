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
                var customerList = await accountRepository.GetAllAccountCustomer();
                dtgCustomers.ItemsSource = customerList;
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
           
        }
        private void Edit_Click_Customer(object sender, RoutedEventArgs e)
        {

        }
        private async void Delete_Click_Customer(object sender, RoutedEventArgs e)
        {
            
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
