using BusinessObject;
using Repositories.CategoryR;
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

namespace ProductManagement.Admin_Staff.ManageCategory
{
    /// <summary>
    /// Interaction logic for UpdateCategory.xaml
    /// </summary>
    public partial class UpdateCategory : Window
    {
        private readonly ICategoryRepository categoryRepository;
        public UpdateCategory()
        {
            InitializeComponent(); 
            categoryRepository = new CategoryRepository();
        }
        public void LoadCategoryData(Category category)
        {
            txtBrandID.Text = category.CategoryId.ToString();
            txtBrandName.Text = category.CategoryName;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int brandId = int.Parse(txtBrandID.Text);
                Category brand = await categoryRepository.GetCategoryById(brandId);
                if (brand != null)
                {
                    brand.CategoryId = int.Parse(txtBrandID.Text);
                    brand.CategoryName = txtBrandName.Text;

                    await categoryRepository.UpdateCategory(brand);
                    MessageBox.Show("Update Brand Successfully!", "Note");
                    this.Close();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Cannot update brand");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
