﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public IFormFile Image { get; set; } = null;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
