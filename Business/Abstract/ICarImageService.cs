using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetById(int id);
        IDataResult<List<CarImageDetailDto>> GetCarImageDetails();

        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> Get(int id);


    }
}
