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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            brandManager.Add(new Brand() { BrandName = "a" }); // 2 karakterden az bir model ismi ekleme denendi.

            brandManager.Add(new Brand() { BrandName = "Tofaş" }); //id göndermedik çünkü tablomuzda otomatik artan

            void ListCar()
            {
                Console.WriteLine("Color\tYear\tBrand\tDescription\tDaily Price\n");
                foreach (var car in carManager.GetAll())
                {
                    Console.WriteLine(colorManager.GetById(car.ColorId).Name + "\t"
                        + car.ModelYear + "\t" + brandManager.GetById(car.BrandId).BrandName + "\t"
                        + car.Description + "\t\t" + car.DailyPrice + " TL"
                        );
                }
            }

            // Brand idsi =2 olan arabalar
            Console.WriteLine("--------------------Brand id =2-------------------------");
            Console.WriteLine("BrandID\tColor\tYear\tBrand\tDescription\tDaily Price\n");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandId + "\t" + colorManager.GetById(car.ColorId).Name + "\t"
                    + car.ModelYear + "\t" + brandManager.GetById(car.BrandId).BrandName + "\t" + car.Description + "\t\t" + car.DailyPrice);
            }

            // Color idsi = 3 olan arabalar
            Console.WriteLine("\n--------------------Color id =3--------------------------");
            Console.WriteLine("ColorID\tColor\tYear\tBrand\tDescription\tDaily Price\n");

            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.ColorId + "\t" + colorManager.GetById(car.ColorId).Name + "\t"
                                    + car.ModelYear + "\t" + brandManager.GetById(car.BrandId).BrandName + "\t" + car.Description + "\t\t" + car.DailyPrice);
            }

            carManager.Add(new Car() { ColorId = 5, ModelYear = 1995, BrandId = 4, Description = "Lpg", DailyPrice = -50 });

            carManager.Add(new Car() { ColorId = 5, ModelYear = 1995, BrandId = 4, Description = "Lpg", DailyPrice = 150 });

            ListCar();
        }
    }
}
