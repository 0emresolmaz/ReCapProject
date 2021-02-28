using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add([FromForm(Name = "Image")] IFormFile formFile, [FromForm] CarImage carImage)
        {
            string imagePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\WebAPI\Resource\Images"));
            var filepath = Path.Combine(imagePath, Guid.NewGuid().ToString() + ".jpg");

            if (formFile!=null)
            {
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
 
                carImage.ImagePath = filepath;
            }
            else
            {
                carImage.ImagePath = @"C:\Users\Ssoft\Source\Repos\ReCapProject\WebAPI\Resource\Images\default.png";
            }

            carImage.Date = DateTime.Now;
            var result = _carImageService.Add(carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
