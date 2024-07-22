using System.Windows;

namespace ProductManagement.Customer.ManageProfile
{
    /// <summary>
    /// Interaction logic for Disable_Account.xaml
    /// </summary>
    public partial class Disable_Account : Window
    {
        public Disable_Account()
        {
            InitializeComponent();
        }
        private void TogglePasswordVisibility(object sender, RoutedEventArgs e)
        {
        }

        private  void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

