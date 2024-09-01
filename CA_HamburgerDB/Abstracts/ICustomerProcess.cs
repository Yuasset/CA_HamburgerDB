
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Abstracts
{
    internal interface ICustomerProcess
    {
        void CreateCustomer(Customer model);
        int ReadCustomerFindID(string firsname, string lastname);
    }
}
