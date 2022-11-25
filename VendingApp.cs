using System;
using VendorApp.Interfaces;

namespace VendorApp
{
    public class VendingApp : IVendingApp
    {
        private IVendingMachine vendingMachine {get; set;}
        public VendingApp(IVendingMachine _vendingMachine)
        {
            vendingMachine = _vendingMachine;
        }
        public void Start()
        {
            Coin coin = vendingMachine.InsertCoin();
            if (coin != null)
            {
                Console.WriteLine(".............................................");
                Console.WriteLine("You have entered " + coin.ActualMoney + "$ coin.");
                Console.WriteLine(".............................................");
                Console.WriteLine("");
                vendingMachine.frameandShowProductDetails();
                Console.WriteLine("Select the product number you are looking for");
                int prodId = int.Parse(Console.ReadLine());
                vendingMachine.dispatchProduct(prodId, coin);
            }
            else
            {
                Console.WriteLine("You have enter invalid coin..");
            }
        }
    }
}
