using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Views
{
    public partial class SearchWindow : Window
    {
        private ProductService productService;

        public SearchWindow(ProductService service)
        {
            InitializeComponent();
            productService = service;
            ShowAllProducts();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска!", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<Product> results;

            if (rbName.IsChecked == true)
            {
                results = productService.SearchByName(searchText);
            }
            else
            {
                results = productService.SearchByCategory(searchText);
            }

            DisplayResults(results);
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            ShowAllProducts();
            txtSearch.Clear();
        }

        private void ShowAllProducts()
        {
            var products = productService.GetAllProducts();
            DisplayResults(products);
        }

        private void DisplayResults(List<Product> results)
        {
            if (results.Count == 0)
            {
                pnlNoResults.Visibility = Visibility.Visible;
                dgResults.Visibility = Visibility.Collapsed;
            }
            else
            {
                pnlNoResults.Visibility = Visibility.Collapsed;
                dgResults.Visibility = Visibility.Visible;
                dgResults.ItemsSource = null;
                dgResults.ItemsSource = results;
            }
        }
    }
}
