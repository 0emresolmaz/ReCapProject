using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.File
{
    public static class FileOperations
    {
        static string defaultPath = @"C:\Users\Ssoft\Source\Repos\ReCapProject\WebAPI\Resource\Images\default.png";
        public static string Add(IFormFile formFile)
        {
            string imagePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\WebAPI\Resource\Images"));
            var filepath = Path.Combine(imagePath, Guid.NewGuid().ToString() + ".jpg");

            if (formFile != null)
            {
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                return filepath;

            }
            else
            {
                return defaultPath;
            }
        }

        public static void Delete(string path)
        {
            if (!path.Equals(defaultPath))
            {
                System.IO.File.Delete(path);
            }

        }

    }
}
