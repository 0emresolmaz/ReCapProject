using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            var result = _rentalDal.GetAll(p => p.CarId == rental.CarId);


            foreach (var r in result)
            {
                if (r.ReturnDate == null)
                {
                    Console.WriteLine("\n"+Messages.RentalInvalid);
                    return new ErrorResult(Messages.RentalInvalid);

                }
            }

            _rentalDal.Add(rental);
            Console.WriteLine(Messages.RentalAdded);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CarId == carId));
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            return _rentalDal.GetRentalDetails();
        }
    }
}
