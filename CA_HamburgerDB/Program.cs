using CA_HamburgerDB.Concrete;
using CA_HamburgerDB.Models;

namespace CA_HamburgerDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //scaffold-dbcontext "Server=.;Database=Hamburger;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

            int select;
            HamburgerProcess hamburgerProcess = new HamburgerProcess();
            ExtraProcess extraProcess = new ExtraProcess();
            CustomerProcess customerProcess = new CustomerProcess();
            OrderProcess orderProcess = new OrderProcess();

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Hamburger Sipariş Sistemi");
                    Console.WriteLine("1-Hamburger oluştur");
                    Console.WriteLine("2-Ekstra oluştur");
                    Console.WriteLine("3-Sipariş oluştur");
                    Console.WriteLine("4-Sipariş listele");
                    Console.WriteLine("5-Çıkış");
                    Console.Write("Seçiminiz: ");
                    select = int.Parse(Console.ReadLine());

                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Hamburger Listesi");
                            hamburgerProcess.ReadHamburger();
                            Console.WriteLine("Hamburger oluştur");
                            string hamburgerName;
                            decimal hamburgerPrice;
                            Console.Write("Hamburger adı: ");
                            hamburgerName = Console.ReadLine();
                            Console.Write("Hamburger fiyatı: ");
                            hamburgerPrice = decimal.Parse(Console.ReadLine());
                            hamburgerProcess.CreateHamburger(new Hamburger
                            {
                                Name = hamburgerName,
                                Price = hamburgerPrice
                            });
                            Console.WriteLine("Hamburger oluşturuldu");
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ekstra Listesi");
                            extraProcess.ReadExtra();
                            Console.WriteLine("Ekstra oluştur");
                            string extraName;
                            decimal extraPrice;
                            Console.Write("Ekstra adı: ");
                            extraName = Console.ReadLine();
                            Console.Write("Ekstra fiyatı: ");
                            extraPrice = decimal.Parse(Console.ReadLine());
                            extraProcess.CreateExtra(new Extra
                            {
                                Name = extraName,
                                Price = extraPrice
                            });
                            Console.WriteLine("Ekstra oluşturuldu");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Sipariş oluştur");
                            Console.WriteLine("Hamburger Listesi");
                            hamburgerProcess.ReadHamburger();
                            Console.Write("Seçim: ");
                            int hamburgerId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ekstra Listesi");
                            extraProcess.ReadExtra();
                            Console.Write("Seçim: ");
                            int extraId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Müşteri Bilgisi");
                            Console.Write("Ad: ");
                            string firstname = Console.ReadLine();
                            Console.Write("Soyad: ");
                            string lastname = Console.ReadLine();
                            Console.Write("Adres: ");
                            string adress = Console.ReadLine();

                            customerProcess.CreateCustomer(new Customer
                            {
                                Firstname = firstname,
                                Lastname = lastname,
                                Adress = adress
                            });

                            orderProcess.CreateOrder(new Order
                            {
                                CustomerId = customerProcess.ReadCustomerFindID(firstname, lastname),
                                HamburgerId = hamburgerId,
                                ExtraId = extraId
                            });
                            Console.WriteLine("Sipariş oluşturuldu");
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Sipariş listele");
                            orderProcess.ReadOrder();
                            Console.ReadLine();
                            break;
                        case 5:
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Hatalı bir seçim yapıldı");
                            Console.ReadLine();
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }



            }
        }
    }
}