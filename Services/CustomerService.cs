using Microsoft.Extensions.Logging;

using Configuration;
using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;

public class CustomerService : ICustomerService
{
    public List<ICustomer> GetCustomers(int nrItems)
    {
        var customerList = new List<ICustomer>();
        var seeder = new SeedGenerator();

        for (int i = 0; i < nrItems; i++)
        {
            var card = new CreditCard()
            {
                CardNumber = $"{seeder.Next(2222, 9999)}-{seeder.Next(2222, 9999)}-{seeder.Next(2222, 9999)}-{seeder.Next(2222, 9999)}",
                ExpiryMonth = $"{seeder.Next(25, 32)}",
                ExpiryYear = $"{seeder.Next(01, 13):D2}",
                Issuer = seeder.FromEnum<CardIssuer>()
            };
            var customer = new Customer()
            {
                FirstName = seeder.FirstName,
                LastName = seeder.LastName,
                CreditCard = card
            };
            customerList.Add(customer);
        }
        return customerList;
    }
}
