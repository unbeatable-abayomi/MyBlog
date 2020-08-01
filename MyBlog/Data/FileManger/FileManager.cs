using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.FileManger
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration conifg)
        {
            _imagePath = conifg["Path:Images"];
        }

        public  async Task<string> SaveImage(IFormFile image)
        {
            var save_path = Path.Combine(_imagePath);
            if (!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);
            }
          


            //Internet Exploxer Error
            //var fileName = Image.FileName 
            var mime = image.FileName.Substring(image.FileName.LastIndexOf("."));
            var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";


            using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
            {
               await image.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
