
using CA_HamburgerDB.Abstracts;
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Concrete
{
    internal class CustomerProcess : ICustomerProcess
    {
        public void CreateCustomer(Customer model)
        {
            Process.dbContext.Customers.Add(model);
            Process.dbContext.SaveChanges();
        }

        public int ReadCustomerFindID(string firstname, string lastname)
        {
            
            return Process.dbContext.Customers.Where(customer => customer.Firstname == firstname && customer.Lastname == lastname).Select(customer => customer.Id).FirstOrDefault();
        }
    }
}
