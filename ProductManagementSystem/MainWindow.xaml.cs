using System.Windows;
using ProductManagementSystem.Services;
using ProductManagementSystem.Views;


namespace ProductManagementSystem
{
    public partial class MainWindow : Window
    {
        private ProductService productService;

        public MainWindow()
        {
            InitializeComponent();
            productService = new ProductService();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            var productsWindow = new ProductsWindow(productService);
            productsWindow.ShowDialog();
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Модуль 'Статистика' в разработке", "Информация");
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Модуль 'Поиск' в разработке", "Информация");
        }
    }
}