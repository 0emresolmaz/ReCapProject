using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentingCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentingCarContext context = new RentingCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                            on r.CustomerId equals c.Id
                             join ca in context.Cars
                            on r.CarId equals ca.Id
                             join b in context.Brands
                            on ca.BrandId equals b.BrandId
                             join cl in context.Colors
                            on ca.ColorId equals cl.ColorId

                             join u in context.Users

                            on c.UserId equals u.Id

                             select new RentalDetailDto()
                             {
                                 Id = r.Id,
                                 CarId =r.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                                 CarBrand = b.BrandName,
                                 CarColor = cl.Name,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName

                             };


                return result.ToList();
            }

        }
    }
}
