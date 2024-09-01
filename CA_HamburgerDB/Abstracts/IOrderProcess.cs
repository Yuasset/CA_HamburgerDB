
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Abstracts
{
    internal interface IOrderProcess
    {
        void CreateOrder(Order model);
        void ReadOrder();
    }
}
