using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.RepositoryService;
using PetShop.Core.UIService;
using PetShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.MainMenu();
        }


    }
}
