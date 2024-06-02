using Demo_var_6;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TradeCompletedContext dbContext;

        public MainWindow()
        {

            InitializeComponent();
            dbContext = new TradeCompletedContext();
            BDList.ItemsSource = dbContext.Products.Take(25).ToList();

            ResultTxb.Text = BDList.Items.Count + "/" + dbContext.Products.Count();

            var uniqueValues = dbContext.Products.Select(p => p.Manufacturer).Distinct().ToList();
            ComboFilter.ItemsSource = uniqueValues;
        }


        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            BDList.ItemsSource = dbContext.Products.Where(p => p.Name == textBoxSearch.Text || p.Name.Contains(textBoxSearch.Text)
                || p.Manufacturer == textBoxSearch.Text || p.Manufacturer.Contains(textBoxSearch.Text)).ToList();
        }

        private void ComboFilter_Filter(object sender, SelectionChangedEventArgs e)
        {
            string selected = ComboFilter.SelectedItem as string;
            if (selected != null)
            {
                var filteredProducts = dbContext.Products.Where(p => p.Manufacturer == selected).ToList();
                BDList.ItemsSource = filteredProducts;
            }
        }

        private void ComboSort_Sort(object sender, SelectionChangedEventArgs e)
        {
            int selected = ComboSort.SelectedIndex;
            if (selected == 1)
            {
                var filteredProducts = dbContext.Products.OrderBy(p => p.Cost).ToList();
                BDList.ItemsSource = filteredProducts;
            }
            if (selected == 2)
            {
                var filteredProducts = dbContext.Products.OrderByDescending(p => p.Cost).ToList();
                BDList.ItemsSource = filteredProducts;
            }
            
        }
        private void Add_Button(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }
    }
}