
using CA_HamburgerDB.Abstracts;
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Concrete
{
    internal class HamburgerProcess : IHamburgerProcess
    {
        public void CreateHamburger(Hamburger model)
        {
            Process.dbContext.Hamburgers.Add(model);
            Process.dbContext.SaveChanges();
        }

        public void ReadHamburger()
        {
            var hamburgerData = Process.dbContext.Hamburgers;
            foreach (var item in hamburgerData)
            {
                Console.WriteLine($"ID: {item.Id} Ad: {item.Name} Fiyat: {item.Price}TL");
            }
        }
    }
}
