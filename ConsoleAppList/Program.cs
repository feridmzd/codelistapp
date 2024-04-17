
namespace ConsoleAppList;  
 using System;
using System.Collections.Generic;

          public class PriceMustBeGreaterThanZeroException : Exception
        {
            public PriceMustBeGreaterThanZeroException(string message) : base(message)
            {
            }
        }

        public enum ProductType
        {
            Baker,
            Drink,
            Meat,
            Diary
        }

        public class Product
        {
            private static int _nextNo = 1;

            public int No { get; }
            public string Name { get; }
            private double _price;
            public double Price
            {
                get { return _price; }
                set
                {
                    if (value <= 0)
                    {
                        throw new PriceMustBeGreaterThanZeroException("Price 0 dan boyuk olmalidir");
                    }
                    _price = value;
                }
            }
            public ProductType Type { get; }

            public Product(string name, double price, ProductType type)
            {
                No = _nextNo++;
                Name = name;
                Price = price;
                Type = type;
            }
        }

        public class Store
        {
            private List<Product> _products;

            public Store()
            {
                _products = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                _products.Add(product);
            }

            public void RemoveProductByNo(int no)
            {
                _products.RemoveAll(p => p.No == no);
            }

            public Product GetProduct(int no)
            {
                return _products.Find(p => p.No == no);
            }

            public List<Product> FilterProductsByType(ProductType type)
            {
                return _products.FindAll(p => p.Type == type);
            }

            public List<Product> FilterProductByName(string name)
            {
                return _products.FindAll(p => p.Name.Contains(name));
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Store store = new Store();

                while (true)
                {
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Filter Products by Type");
                    Console.WriteLine("3. Filter Products by Name");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter product name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter product price: ");
                            double price = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter product type (Baker, Drink, Meat, Diary): ");
                            ProductType type = (ProductType)Enum.Parse(typeof(ProductType), Console.ReadLine(), true);

                            try
                            {
                                Product product = new Product(name, price, type);
                                store.AddProduct(product);
                                Console.WriteLine("Product added successfully.");
                            }
                            catch (PriceMustBeGreaterThanZeroException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Enter product type (Baker, Drink, Meat, Diary): ");
                            ProductType filterType = (ProductType)Enum.Parse(typeof(ProductType), Console.ReadLine(), true);
                            List<Product> filteredByType = store.FilterProductsByType(filterType);
                            Console.WriteLine("Filtered Products:");
                            foreach (Product p in filteredByType)
                            {
                                Console.WriteLine($"No: {p.No}, Name: {p.Name}, Price: {p.Price}, Type: {p.Type}");
                            }
                            break;
                        case "3":
                            Console.Write("Enter product name: ");
                            string filterName = Console.ReadLine();
                            List<Product> filteredByName = store.FilterProductByName(filterName);
                            Console.WriteLine("Filtered Products:");
                            foreach (Product p in filteredByName)
                            {
                                Console.WriteLine($"No: {p.No}, Name: {p.Name}, Price: {p.Price}, Type: {p.Type}");
                            }
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose again.");
                            break;
                    }
                }
            }
        }

    

