using CA_HamburgerDB.Models;

namespace CA_HamburgerDB.Abstracts
{
    internal interface IExtraProcess
    {
        void CreateExtra(Extra model);
        void ReadExtra();
    }
}
