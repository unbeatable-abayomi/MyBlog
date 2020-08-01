using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Data.FileManger;
using MyBlog.Models;
using MyBlog.Repository;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;
        private readonly IFileManager _fileManager;

        public HomeController(ILogger<HomeController> logger, IRepository cxt, IFileManager fileManager)
        {
            _logger = logger;
            _repo = cxt;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPost(); 
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
            return new FileStreamResult(_fileManager.ImageStream(image));
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if(id == null)
        //    {
        //        return View(new Post());
        //    }
        //    else
        //    {
        //        var post = _repo.GetPost((int)id);
        //        return View(post);
        //    }

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task <IActionResult> Edit(Post post)
        //{
        //    if(post.Id > 0)
        //    {
        //        _repo.UpdatePost(post);
        //    }
        //    else
        //    {
        //        _repo.AddPost(post);
        //    }

        //    if(await _repo.SaveChangeAsync())
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(post);
        //    }
        //}

        //[HttpGet]
        //public async Task <IActionResult> Remove(int id)
        //{
        //    _repo.RemovePost(id);
        //    await _repo.SaveChangeAsync();
        //    return RedirectToAction("Index");

        //}
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
