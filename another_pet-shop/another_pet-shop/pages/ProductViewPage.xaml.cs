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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace another_pet_shop.pages
{
    /// <summary>
    /// Логика взаимодействия для ProductViewPage.xaml
    /// </summary>
    public partial class ProductViewPage : Page
    {
        public ProductViewPage()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            classes.Manager.MainFrame.Navigate(new LoginPage());
        }

        private void AddNewProductButton_Click(object sender, RoutedEventArgs e)
        {
            classes.Manager.MainFrame.Navigate(new AddNewProductPage());
        }
    }
}
