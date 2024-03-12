using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using static W08.Program;

namespace W08
{
    internal class Program
    {
        static string filePath = "T:\\file C#\\products.txt";
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            LoadProducts();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Chọn một hành động: \n (1) Thêm sản phẩm,\n (2) Hiển thị sản phẩm, \n (3) Tìm kiếm sản phẩm,\n (4) Thoát");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        DisplayProducts();
                        break;
                    case "3":
                        SearchProducts();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }

            Console.ReadKey();
        }
        static void LoadProducts()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 5)
                        {
                            products.Add(new Product(
                                int.Parse(parts[0]),
                                parts[1],
                                parts[2],
                                decimal.Parse(parts[3]),
                                parts[4]));
                        }
                    }
                }
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("Nhập mã sản phẩm:");
            int id = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Nhập tên sản phẩm:");
            string name = Console.ReadLine();
            Console.WriteLine("Nhập hãng sản xuất:");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Nhập giá:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Nhập mô tả:");
            string description = Console.ReadLine();

            var product = new Product(id, name, manufacturer, price, description);
            products.Add(product);
            SaveProduct(product);
            Console.WriteLine("Sản phẩm đã được thêm.");
        }

        static void DisplayProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        static void SearchProducts()
        {
            Console.WriteLine("Nhập tên sản phẩm cần tìm:");
            string searchTerm = Console.ReadLine();
            var foundProducts = products.Where(p => p.ProductName.Contains(searchTerm)).ToList();
            if (foundProducts.Count > 0)
            {
                foreach (var product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        static void SaveProduct(Product product)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{product.ProductId}|{product.ProductName}|{product.Manufacturer}|{product.Price}|{product.Description}");
            }
        }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Manufacturer { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }

            public Product(int productId, string productName, string manufacturer, decimal price, string description)
            {
                ProductId = productId;
                ProductName = productName;
                Manufacturer = manufacturer;
                Price = price;
                Description = description;
            }

            public override string ToString()
            {
                return $"ID: {ProductId},  -  Name: {ProductName}, -  Manufacturer: {Manufacturer}, -  Price: {Price}, Description: -  {Description}";
            }
        }

    }
   

}

