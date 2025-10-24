
﻿using ProductManagementSystem.Services;
using ProductManagementSystem.Views;
using System.Windows;




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
            var statisticsWindow = new StatisticsWindow(productService);
            statisticsWindow.ShowDialog();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow(productService);
            searchWindow.ShowDialog();
        }
    }
}