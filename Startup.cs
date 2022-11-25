
using Microsoft.Extensions.DependencyInjection;
using VendorApp.Interfaces;

namespace VendorApp
{
    public class Startup
    {
        public void ConfugureService(IServiceCollection services)
        {
            services.AddSingleton<IVendingMachine, VendingMachine>();
            services.AddSingleton<IVendingApp, VendingApp>();
        }
    }
}
