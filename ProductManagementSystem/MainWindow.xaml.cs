using System.Windows;
using ProductManagementSystem.Services;


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
            MessageBox.Show("Модуль 'Управление товарами' в разработке", "Информация");
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