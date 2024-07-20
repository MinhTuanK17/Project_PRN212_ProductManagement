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
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        public UpdateProduct()
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
        public void LoadProductData(Product product)
        {
            txtPhoneId.Text = product.ProductPhoneId.ToString();
            txtPhoneName.Text = product.ProductPhoneName;
            cbCategory.SelectedValue = product.CategoryId;
            txtQuantity.Text = product.PhoneQuantity.ToString();
            cbRam.SelectedItem = cbRam.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == product.RamPhone);
            cbMemory.SelectedItem = cbMemory.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == product.MemoryPhone);
            txtPrice.Text = product.PhonePrice.ToString();
            txtDescription.Text = product.PhoneDescription;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            string? selectedRam = (cbRam.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? selectedMemory = (cbMemory.SelectedItem as ComboBoxItem)?.Content.ToString();
            try
            {
                string productId = txtPhoneId.Text;
                Product product = await productRepository.GetProductById(productId);
                if (product != null)
                {
                    product.ProductPhoneName = txtPhoneName.Text;
                    product.CategoryId = (int)cbCategory.SelectedValue;
                    product.PhoneQuantity = int.Parse(txtQuantity.Text);
                    product.RamPhone = selectedRam;
                    product.MemoryPhone = selectedMemory;
                    product.PhonePrice = decimal.Parse(txtPrice.Text);
                    product.PhoneDescription = txtDescription.Text;

                    await productRepository.UpdateProduct(product);
                    MessageBox.Show("Update Phone Successfully!", "Note");
                    this.Close();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Cannot update phone");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
