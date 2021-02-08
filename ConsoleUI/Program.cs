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


            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandId + "," + brand.BrandName);
            //}



            //carManager.Add(new Car() { BrandId = 5, ColorId = 3, ModelYear = 1956, Description = "Cadillac", DailyPrice = -50 });
            //carManager.Add(new Car() { BrandId = 5, ColorId = 3, ModelYear = 1956, Description = "Cadillac", DailyPrice = 2000 });

            

            void ListCar()
            {
                Console.WriteLine("Color\tYear\tBrand\tDescription\tDaily Price\n");
                foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(colorManager.GetById(car.ColorId).Name +"\t"
                    +car.ModelYear +"\t" +brandManager.GetById(car.BrandId).BrandName +"\t"
                    +car.Description +"\t\t" +car.DailyPrice +" TL"                 
                    );
            }
            }

            //// Brand idsi =2 olan arabalar
            //Console.WriteLine("--------------------Brand id =2---------------------");
            //foreach (var car in carManager.GetAllByBrandId(2))
            //{
            //    Console.WriteLine(car.Id +" " +car.DailyPrice  +" TL>"+car.Description);
            //}

            //// Color idsi = 3 olan arabalar
            //Console.WriteLine("--------------------Color id =3---------------------");

            //foreach (var car in carManager.GetAllByColorId(3))
            //{
            //    Console.WriteLine(car.DailyPrice + " TL>" + car.Description);
            //}

            carManager.Add(new Car() { ColorId = 5, ModelYear = 1995, BrandId = 4, Description = "Lpg", DailyPrice = -50 });

            carManager.Add(new Car() { ColorId = 5, ModelYear = 1995, BrandId = 4, Description = "Lpg", DailyPrice = 150 });

            ListCar();


        }
    }
}
