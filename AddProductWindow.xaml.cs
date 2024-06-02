using Demo_var_6;
using Microsoft.EntityFrameworkCore;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private TradeCompletedContext DbContext;
        public AddProductWindow()
        {
            InitializeComponent();
            DbContext = new TradeCompletedContext();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = productNameTextBox.Text;
            decimal cost = decimal.Parse(priceTextBox.Text);
            string description = DescriptionTextBox.Text;

            // Создаем новый продукт
            Product newProduct = new Product
            {
                Name = productName,
                Cost = cost,
                Description = description
            };
            try
            {

                // Добавляем продукт в контекст базы данных
                DbContext.Products.Add(newProduct);

                // Сохраняем изменения в базе данных
                DbContext.SaveChanges();

                // Закрываем окно
                Close();
            }
            catch
            {
                // Закрываем окно
                Close();
            }

        }
    }
}
