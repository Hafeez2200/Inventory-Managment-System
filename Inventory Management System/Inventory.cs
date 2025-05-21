using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simple_Inventory_Management_System
{
    public class Inventory
    {
        public List<Product> Products { get; set; }
        public Inventory()
        {
            Products = new List<Product>();

        }
        public Inventory(List<Product> products)
        {
            Products = products;
        }

        public void Add(Product newProduct)
        {
            if (newProduct != null)
                Products.Add(newProduct);
        }
        public void Print()
        {
            foreach (var product in Products)
            {
                Console.WriteLine();
                Console.WriteLine(product.ToString());
                Console.WriteLine();
            }
        }

        public Product Find(string name)
        {
            foreach (var product in Products)
            {
                if (product.Name == name)
                    return product;
            }
            return null;
        }

        public bool Delete(string productName)
        {
            Product productToRemove = Find(productName);

            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
