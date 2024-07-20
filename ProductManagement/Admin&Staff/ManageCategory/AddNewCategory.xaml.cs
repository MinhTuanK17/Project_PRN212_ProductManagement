using BusinessObject;
using Repositories.CategoryR;
using System.Windows;

namespace ProductManagement.Admin_Staff.ManageCategory
{
    /// <summary>
    /// Interaction logic for AddNewCategory.xaml
    /// </summary>
    public partial class AddNewCategory : Window
    {
        private readonly ICategoryRepository categoryRepository;

        public AddNewCategory()
        {
            InitializeComponent();
            categoryRepository = new CategoryRepository();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category brand = new Category
                {
                    CategoryName = txtBrand.Text,
                };

                await categoryRepository.InsertCategory(brand);
                MessageBox.Show("Add Brand Successfully!", "Note");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Can not add brand");
            }
        }
    }
}
