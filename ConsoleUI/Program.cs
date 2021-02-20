using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BeforeHomeWorkTest();
            //BeforeHomeWorkTest2();
            //CustomerAdding();   //customer eklemeli
                
            Rental();

        }

        private static void Rental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //Burada teslim edilmeyen bir arabanın kiralanması işlemini denedik.
            rentalManager.Add(new Rental { CustomerId = 5, CarId = 8, RentDate = DateTime.Now, ReturnDate = null });

            //Burada eldeki araçlardan birisini kiraladık.

            rentalManager.Add(new Rental { CustomerId = 2, CarId = 2, RentDate = DateTime.Now, ReturnDate = null });

            Console.WriteLine("CarId\tFirstname\tLastName\tCompany Name\tBrand\tColor\tRentDate\tReturnDate");
            foreach (var rental in rentalManager.GetRentalDetails())
            {
                Console.WriteLine(rental.CarId + "\t" + rental.FirstName + "\t\t" + rental.LastName + "\t\t" + rental.CompanyName + "\t"
                    + rental.CarBrand + "\t" + rental.CarColor + "\t" + rental.RentDate + "\t" + rental.ReturnDate);
            }
        }

        private static void CustomerAdding()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 5, CompanyName = "Beşiktaş" });
            Console.WriteLine("Firstname\tLastName\tCompany Name\t\tEmail\n");
            foreach (var customer in customerManager.GetCarDetails().Data)
            {
                Console.WriteLine(customer.FirstName + "\t\t" + customer.LastName + "\t\t" + customer.CompanyName + "\t"
                    + customer.Email);
            }
        }

        private static void BeforeHomeWorkTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Color\tYear\tBrand\tDescription\tDaily Price\n");

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.ColorName + "\t" + car.ModelYear + "\t" + car.BrandName + "\t" + car.Description + "\t\t" + car.DailyPrice);
            }
        }

        private static void BeforeHomeWorkTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            brandManager.Add(new Brand() { BrandName = "a" }); // 2 karakterden az bir model ismi ekleme denendi.

            brandManager.Add(new Brand() { BrandName = "Tofaş" }); //id göndermedik çünkü tablomuzda otomatik artan

            void ListCar()
            {
                Console.WriteLine("Color\tYear\tBrand\tDescription\tDaily Price\n");
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(colorManager.GetById(car.ColorId).Data.Name + "\t"
                        + car.ModelYear + "\t" + brandManager.GetById(car.BrandId).Data.BrandName + "\t"
                        + car.Description + "\t\t" + car.DailyPrice + " TL"
                        );
                }
            }

            // Brand idsi =2 olan arabalar
            Console.WriteLine("--------------------Brand id =2-------------------------");
            Console.WriteLine("BrandID\tColor\tYear\tBrand\tDescription\tDaily Price\n");
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.BrandId + "\t" + colorManager.GetById(car.ColorId).Data.Name + "\t"
                    + car.ModelYear + "\t" + brandManager.GetById(car.BrandId).Data.BrandName + "\t" + car.Description + "\t\t" + car.DailyPrice);
            }

            // Color idsi = 3 olan arabalar
            Console.WriteLine("\n--------------------Color id =3--------------------------");
            Console.WriteLine("ColorID\tColor\tYear\tBrand\tDescription\tDaily Price\n");

            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(car.ColorId + "\t" + colorManager.GetById(car.ColorId).Data.Name + "\t"
                                    + car.ModelYear + "\t" + brandManager.GetById(car.BrandId).Data.BrandName + "\t" + car.Description + "\t\t" + car.DailyPrice);
            }

            carManager.Add(new Car() { ColorId = 5, ModelYear = 1995, BrandId = 4, Description = "Lpg", DailyPrice = -50 });

            carManager.Add(new Car() { ColorId = 5, ModelYear = 1995, BrandId = 4, Description = "Lpg", DailyPrice = 150 });

            ListCar();
        }
    }
}
