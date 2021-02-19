using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine(brand.BrandName + " " + Messages.BrandAdded);
                return new SuccessDataResult<Brand>(brand, Messages.BrandAdded);

                //Console.WriteLine("Araba modeli: {0} başarıyla eklendi\n", brand.BrandName);
            }
            else
            {
                Console.WriteLine(brand.BrandName + " " + Messages.BrandNameValid);
                return new ErrorDataResult<Brand>(brand, Messages.BrandNameValid);
                //Console.WriteLine("Araba modeli: {0} en az 2 karakter olmalıdır.\n",brand.BrandName);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id));
        }

    }
}
