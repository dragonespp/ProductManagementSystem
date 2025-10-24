using System;
using System.Windows;
using System.Windows.Controls;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Views
{
    public partial class ProductsWindow : Window
    {
        private ProductService productService;
        private Product selectedProduct;

        public ProductsWindow(ProductService service)
        {
            InitializeComponent();
            productService = service;
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = productService.GetAllProducts();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Заполните название и категорию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var product = new Product
            {
                Name = txtName.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Price = price,
                Quantity = quantity
            };

            productService.AddProduct(product);
            LoadProducts();
            ClearForm();
            MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct == null) return;

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Заполните название и категорию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            selectedProduct.Name = txtName.Text.Trim();
            selectedProduct.Category = txtCategory.Text.Trim();
            selectedProduct.Price = price;
            selectedProduct.Quantity = quantity;

            productService.UpdateProduct(selectedProduct);
            LoadProducts();
            ClearForm();
            MessageBox.Show("Товар успешно обновлён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct == null) return;

            var result = MessageBox.Show($"Удалить товар '{selectedProduct.Name}'?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                productService.DeleteProduct(selectedProduct.ProductID);
                LoadProducts();
                ClearForm();
                MessageBox.Show("Товар удалён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProduct = dgProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                txtName.Text = selectedProduct.Name;
                txtCategory.Text = selectedProduct.Category;
                txtPrice.Text = selectedProduct.Price.ToString();
                txtQuantity.Text = selectedProduct.Quantity.ToString();
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            selectedProduct = null;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            dgProducts.SelectedItem = null;
        }
    }
}