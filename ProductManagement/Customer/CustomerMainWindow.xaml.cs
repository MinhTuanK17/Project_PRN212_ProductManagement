using BusinessObject;
using DataLayerAccess;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.Logging;
using ProductManagement.Admin_Staff.ManageCustomer;
using ProductManagement.Customer.ManageProfile;
using Repositories.AccountR;
using Repositories.CategoryR;
using Repositories.OrderDetailR;
using Repositories.OrderR;
using Repositories.ProductR;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public readonly List<OrderDetail> listOrder;
        public readonly OrderRepository orderRepository;
        
        public CustomerMainWindow()
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
            categoryRepository = new CategoryRepository();
            productRepository = new ProductRepository();
            orderDetailRepository = new OrderDetailRepository();
            listOrder = new List<OrderDetail>();
            orderRepository = new OrderRepository();
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
            LoadOrderList();
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
                cbCategory.ItemsSource = catList;
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
                cbProduct.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of phones");
            }
        }

        public void LoadOrderList()
        {
            try
            {
                dtgAddOrders.ItemsSource = null;
                dtgAddOrders.ItemsSource = listOrder;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
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
            changePassword.LoggedInUser = LoggedInUser;
            changePassword.Show();
        }

        private void DisableAccount_Click(object sender, RoutedEventArgs e)
        {
        }

        //Logout
        private void TabItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }

        private async void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                ComboBox combo = sender as ComboBox;

                if (combo.SelectedItem != null)
                {
                    Category selectedCategory = combo.SelectedItem as Category;

                    if (selectedCategory != null)
                    {
                        cbCategory.SelectedValue = selectedCategory.CategoryId;
                        var productList = await productRepository.GetProductByCategoryId((int?)cbCategory.SelectedValue);
                        cbProduct.ItemsSource = productList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error handling selection change");
            }
        }
        private void cbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;

                if (combo.SelectedItem != null)
                {
                    Product selectedProduct = combo.SelectedItem as Product;

                    if (selectedProduct != null)
                    {
                        cbProduct.SelectedValue = selectedProduct.ProductPhoneId;
                        txtRamPhone.Text = selectedProduct.RamPhone;
                        txtMemoryPhone.Text = selectedProduct.MemoryPhone;
                        txtQuantity.Text = selectedProduct.PhoneQuantity.ToString();
                        txtPrice.Text = selectedProduct.PhonePrice.ToString();
                        txtDescription.Text = selectedProduct.PhoneDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error handling selection change");
            }
        }
        
        private async void Button_AddOrder_Click(object sender, RoutedEventArgs e)
        {         
            try
            {
                OrderDetail detail = new OrderDetail()
                {
                    ProductPhoneId = cbProduct.SelectedValue.ToString(),
                    Product = await productRepository.GetProductById(cbProduct.SelectedValue.ToString()),
                    Quantity = int.Parse(txtQuantityOrder.Text),
                    TotalPrice = decimal.Parse(txtPrice.Text) * int.Parse(txtQuantityOrder.Text)
                    

                };
                listOrder.Add(detail);
                txtAmountPrice.Text = listOrder.Sum(o => o.TotalPrice).ToString();


                LoadOrderList();
            } catch
            {
                MessageBox.Show("Error of add Order", "Note");
            }
        }
        private void dtgProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Button_ORDER_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.AccountId = LoggedInUser.AccountId;
            await orderRepository.AddNewOrder(order);

            int orderId = await orderRepository.GetMaxOrderId();
            //MessageBox.Show(orderId.ToString());

            foreach (OrderDetail detail in listOrder)
            {
                detail.OrderId = orderId;
                detail.Product = null;
                MessageBox.Show("Order successfully!", "Note");
                await orderDetailRepository.AddOrderDetail(detail);
                await productRepository.ChangeQuantity(detail.ProductPhoneId, detail.Quantity);
            }

            listOrder.Clear();
            LoadOrderList();
            LoadOrderHistoryList();
        }
    }

}
