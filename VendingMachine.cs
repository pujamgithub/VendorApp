using System;
using System.Collections.Generic;
using System.Linq;
using VendorApp.Interfaces;

namespace VendorApp
{
   public class VendingMachine : IVendingMachine
    {
        private List<Product> getAvailableProducts()
        {
            return new List<Product> {
                new Product { Id= 1,Name="nickels", Price=20 },
                new Product { Id= 2,Name="dimes", Price=10},
                new Product {Id= 3, Name="quarters", Price=40 },
                new Product {Id= 4, Name="pennies", Price=100 }
            };
        }
        private List<Coin> getAllCoins()
        {
            return new List<Coin> {
                new Coin { Size = "small", Weight=10, ActualMoney= 10 },
                new Coin { Size = "medium", Weight=20,ActualMoney= 20 },
                new Coin { Size = "large", Weight=30, ActualMoney= 40},
                new Coin { Size = "xtralarge", Weight=40, ActualMoney= 100},
            };
        }
        private Coin fetchCoinDetails(string size, int weight)
        {
            List<Coin> coins = getAllCoins();
            return coins.SingleOrDefault(x => x.Size == size && x.Weight == weight);
        }
        public void dispatchProduct(int prodId, Coin coin)
        {
            List<Product> allAvailableProducts = getAvailableProducts();
            Product product = allAvailableProducts.SingleOrDefault(prod => prod.Id == prodId);
            if (product != null)
            {
                string dispatchmessage =  product.Price <= coin.ActualMoney ?
                $"Please collect your Product { product.Name }" :
                "Product Price is more than your money. So please collect Your coin.";

                Console.WriteLine("..............................................");
                Console.WriteLine(dispatchmessage);
            }
            else
            {
                Console.WriteLine("..............................................");
                Console.WriteLine("You have selected Invalid product. Please collect your coin.");
            }
        }
        public Coin InsertCoin()
        {
            try
            {
                Console.WriteLine("Welcome to Vending Machine");
                Console.WriteLine("Please Enter Coin");
                Console.WriteLine("Enter Coin Size (1.small, 2.medium, 3.large, 4.xtralarge)");

                string size = Console.ReadLine();
                Console.WriteLine("Enter Coin weight (1. 10, 2.20, 3.30, 4.40)");
                int weight = int.Parse(Console.ReadLine());
                return fetchCoinDetails(size, weight);
            }
            catch
            {
                Console.WriteLine("You enter Invalid Coin");
                return null;
            }
        }
        public void frameandShowProductDetails()
        {
            List<Product> allAvailableproducts = getAvailableProducts();
            string productDetails = string.Empty;
            foreach (var product in allAvailableproducts)
            {
                productDetails = productDetails + $"{product.Id}. {product.Name}({product.Price}$) ";
            }
            Console.WriteLine(productDetails);
            Console.WriteLine("..............................................");
        }
        
    }
}
