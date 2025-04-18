using Shaitanet.Database;
using Shaitanet.Pages;
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

namespace Shaitanet.UC
{
    /// <summary>
    /// Логика взаимодействия для ProductUC.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        Product product;
        public ProductUC(Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new AddEditProductPage(product));
        }
    }
}
