using System.Windows;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Views
{
    public partial class StatisticsWindow : Window
    {
        private ProductService productService;

        public StatisticsWindow(ProductService service)
        {
            InitializeComponent();
            productService = service;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var stats = productService.GetStatistics();

            txtTotalProducts.Text = stats.TotalProducts.ToString();
            txtAveragePrice.Text = $"{stats.AveragePrice:F2} ₽";
            txtTotalValue.Text = $"{stats.TotalValue:F2} ₽";
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadStatistics();
            MessageBox.Show("Статистика обновлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
