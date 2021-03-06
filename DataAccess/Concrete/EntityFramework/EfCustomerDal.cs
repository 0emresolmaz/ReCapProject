using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentingCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentingCarContext context = new RentingCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id

                             select new CustomerDetailDto()
                             {
                                 CustomerId = c.Id,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                             };
                return result.ToList();

            }
        }
    }
}
