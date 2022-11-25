using Microsoft.Extensions.DependencyInjection;
using System;
using VendorApp.Interfaces;

namespace VendorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new();
            startup.ConfugureService(services);
            IServiceProvider serviceprovider = services.BuildServiceProvider();
            IVendingApp vendingApp = serviceprovider.GetService<IVendingApp>();
            vendingApp.Start();
        }

    }
}
