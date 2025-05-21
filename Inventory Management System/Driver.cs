using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_Inventory_Management_System;

namespace Inventory_Management_System
{
    public class Driver
    {
        static Inventory inventory = new Inventory();

        public static void Main(string[] args)
        {
            string userSelection;
            do
            {
                Console.WriteLine("************     Simple Inventory Managemen System      ************");
                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");
                Console.WriteLine("1: Add a product");
                Console.WriteLine("2: View all products");
                Console.WriteLine("3: Edit a product");
                Console.WriteLine("4: Delete a product:");
                Console.WriteLine("5: Search for a product");
                Console.WriteLine("0: Close application");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        AddNewProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "0":
                        Console.WriteLine("GoodBye!");
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            } while (userSelection != "0");
        }

        private static void AddNewProduct()
        {
            Console.WriteLine("Adding new product:");
            Product newProduct;

            Console.Write("Enter the name of the product: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the price of the product: ");
            double price = double.Parse(Console.ReadLine() ?? "0.0");

            Console.Write("Enter the quantity of the product: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");

            newProduct = new Product(name, price, quantity);
            inventory.Add(newProduct);
            Console.WriteLine($"{name} was Added successfully Inventory: ");

        }

        private static void ViewAllProducts()
        {
            Console.WriteLine("Current Inventory: ");
            inventory.Print();
        }

        private static void EditProduct()
        {
            Console.Write("Enter the name of the product to edit: ");
            string productName = Console.ReadLine();

            Product productToEdit = inventory.Find(productName);

            if (productToEdit != null)
            {
                Console.WriteLine("Enter new details for the product:");

                Console.Write("Enter the New name of the product: ");
                string name = Console.ReadLine() ?? string.Empty;
                productToEdit.Name = name;

                Console.Write("Enter the New price of the product: ");
                double price = double.Parse(Console.ReadLine() ?? "0.0");
                productToEdit.Price = price;


                Console.Write("Enter the New quantity of the product: ");
                int quantity = int.Parse(Console.ReadLine() ?? "0");
                productToEdit.Quantity = quantity;

                Console.WriteLine($"{productName} updated in the inventory.");

            }
            else
            {
                Console.WriteLine($"{productName} not found in the inventory.");
            }
        }

        private static void DeleteProduct()
        {
            Console.Write("Enter the name of the product to delete: ");
            string productName = Console.ReadLine();
            if (inventory.Delete(productName))
                Console.WriteLine($"{productName} removed from the inventory.");
            else
                Console.WriteLine($"{productName} not found in the inventory.");
        }
        private static void SearchProduct()
        {
            Console.Write("Enter the name of the product to search: ");
            string productName = Console.ReadLine();

            Product foundProduct = inventory.Find(productName);

            if (foundProduct != null)
            {
                Console.WriteLine("Product found in the inventory:");
                Console.WriteLine(foundProduct.ToString());
            }
            else
            {
                Console.WriteLine($"{productName} not found in the inventory.");
            }
        }
    }

}
