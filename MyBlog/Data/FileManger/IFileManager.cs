using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.FileManger
{
    public interface IFileManager
    {
        Task<string> SaveImage(IFormFile image);
    }
}
