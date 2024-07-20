using BusinessObject;
using Repositories.CategoryR;
using Repositories.ProductR;
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

namespace ProductManagement.Admin_Staff.ManageProduct
{
    /// <summary>
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        public AddNewProduct()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }
        public async void LoadCategories()
        {
            try
            {
                var brand = await categoryRepository.GetAllCategories();
                cbCategory.ItemsSource = brand;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            string? selectedRam = (cbRam.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? selectedMemory = (cbMemory.SelectedItem as ComboBoxItem)?.Content.ToString();
            try
            {
                Product product = new Product
                {
                    ProductPhoneId = txtPhoneId.Text,
                    ProductPhoneName = txtPhoneName.Text,
                    CategoryId = (int) cbCategory.SelectedValue,
                    PhoneQuantity = int.Parse(txtQuantity.Text),
                    RamPhone = selectedRam,
                    MemoryPhone = selectedMemory,
                    PhonePrice = decimal.Parse(txtPrice.Text),
                    PhoneDescription = txtDescription.Text
                };

                await productRepository.InsertProduct(product);
                MessageBox.Show("Add Phone Successfully!", "Note");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Can not add phone");
            }
        }
    }
}
