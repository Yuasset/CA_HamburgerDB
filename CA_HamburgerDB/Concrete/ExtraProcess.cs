
using CA_HamburgerDB.Abstracts;
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Concrete
{
    internal class ExtraProcess : IExtraProcess
    {
        public void CreateExtra(Extra model)
        {
            Process.dbContext.Extras.Add(model);
            Process.dbContext.SaveChanges();
        }

        public void ReadExtra()
        {
            var extraData = Process.dbContext.Extras;
            foreach (var item in extraData)
            {
                Console.WriteLine($"ID: {item.Id} Ad: {item.Name} Fiyat: {item.Price}");
            }
        }
    }
}
