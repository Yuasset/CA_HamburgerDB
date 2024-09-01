
using CA_HamburgerDB.Abstracts;
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Concrete
{
    internal class OrderProcess : IOrderProcess
    {
        public void CreateOrder(Order model)
        {
            Process.dbContext.Orders.Add(model);
            Process.dbContext.SaveChanges();
        }

        public void ReadOrder()
        {
            var orderData = Process.dbContext.Orders.ToList();
            foreach (var item in orderData)
            {
                Console.WriteLine($"Müşteri: {item.Customer.Firstname} {item.Customer.Lastname}\nAdres: {item.Customer.Adress}\nSipariş\nHamburger: {item.Hamburger.Name} Fiyat: {item.Hamburger.Price}\nEkstra: {item.Extra.Name} Fiyat: {item.Extra.Price}");
            }
        }
    }
}
