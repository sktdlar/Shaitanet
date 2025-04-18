using Shaitanet.Database;
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

namespace Shaitanet.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        bool isSort = false;
        public ProductsPage()
        {
            InitializeComponent();
            if(App.currentUser.Role.id != 1)
            {
                New.Visibility = Visibility.Collapsed;
            }
            Refresh();
        }
        public void Refresh()
        {
            ProductsWP.Children.Clear();
            if(isSort)
            {

                foreach (var x in App.db.Product.ToList().Where(Y => Y.Name.ToLower().Contains(SearchTB.Text.ToLower())).OrderBy(x => x.Name))
                {
                    ProductsWP.Children.Add(new UC.ProductUC(x));
                }
            }
            else
            foreach (var x in App.db.Product.ToList().Where(Y => Y.Name.ToLower().Contains(SearchTB.Text.ToLower())))
            {
                ProductsWP.Children.Add(new UC.ProductUC(x));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage(new Product()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            isSort = !isSort;
            Refresh();
        }
    }
}
