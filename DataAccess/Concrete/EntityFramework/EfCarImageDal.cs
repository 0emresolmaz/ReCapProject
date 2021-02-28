using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentingCarContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImageDetails()
        {
            using (RentingCarContext context = new RentingCarContext())
            {
                var result = from ci in context.CarImages
                             join c in context.Cars
                             on ci.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId

                             select new CarImageDetailDto()
                             {
                                 Id = ci.Id,
                                 BrandName = b.BrandName,
                                 ColorName = cl.Name,
                                 Date = (DateTime)ci.Date,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath,
                                 ModelYear = c.ModelYear
                                
                             };

                return result.ToList();

            }
        }
    }
}
