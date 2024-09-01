
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Abstracts
{
    internal interface IHamburgerProcess
    {
        void CreateHamburger(Hamburger model);
        void ReadHamburger();
    }
}
