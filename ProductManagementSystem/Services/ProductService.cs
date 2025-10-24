using System.Collections.Generic;
using System.Linq;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        private int nextId = 1;

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            product.ProductID = nextId++;
            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existing = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Category = product.Category;
                existing.Price = product.Price;
                existing.Quantity = product.Quantity;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                products.Remove(product);
            }
        }

        public List<Product> SearchByName(string searchText)
        {
            return products.Where(p => p.Name.ToLower().Contains(searchText.ToLower())).ToList();
        }

        public List<Product> SearchByCategory(string category)
        {
            return products.Where(p => p.Category.ToLower().Contains(category.ToLower())).ToList();
        }

        public Statistics GetStatistics()
        {
            if (products.Count == 0)
            {
                return new Statistics
                {
                    TotalProducts = 0,
                    AveragePrice = 0,
                    TotalValue = 0
                };
            }

            return new Statistics
            {
                TotalProducts = products.Sum(p => p.Quantity),
                AveragePrice = products.Average(p => p.Price),
                TotalValue = products.Sum(p => p.Price * p.Quantity)
            };
        }
    }
}