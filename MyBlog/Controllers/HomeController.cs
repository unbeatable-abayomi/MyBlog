using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Comments;
using MyBlog.Data.FileManger;
using MyBlog.Repository;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		[HttpPost]
		public async Task <IActionResult> Comment(CommentViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Post", new {id = vm.PostId});
			}
			

			var post = _repo.GetPost(vm.PostId);

			if (vm.MainCommentId == 0)
			{
				post.MainComments = post.MainComments ?? new List<MainComment>();

				post.MainComments.Add(new MainComment
				{
					Message = vm.Message,
					Created = DateTime.Now
				});

				_repo.UpdatePost(post);
			}
			else
			{
				var comment = new SubComment
				{
					MainCommentId = vm.MainCommentId,
					Message = vm.Message,
					Created = DateTime.Now
				};
				_repo.AddSubComments(comment);
			}
			await _repo.SaveChangeAsync();
			return RedirectToAction("Post", new { id = vm.PostId });

		}
		//public IActionResult Index(string category)
		//{
		//	var posts = string.IsNullOrEmpty(category)? _repo.GetAllPost(): _repo.GetAllPost(category); 
		//	return View(posts);
		//}


		public IActionResult Index(string category) => View(string.IsNullOrEmpty(category) ? _repo.GetAllPost() : _repo.GetAllPost(category));

		//public IActionResult Post(int id)
		//{
		//	var post = _repo.GetPost(id);
		//	return View(post);
		//}

		public IActionResult Post(int id) => View(_repo.GetPost(id));

		//[HttpGet("/Image/{image}")]
		//public IActionResult Image(string image)
		//{
		//	var mime = image.Substring(image.LastIndexOf('.') + 1);
		//	return new FileStreamResult(_fileManager.ImageStream(image), $"Image/{mime}");
		//}


		[HttpGet("/Image/{image}")]
		[ResponseCache(CacheProfileName ="Monthly")]
		public IActionResult Image(string image) => new FileStreamResult(_fileManager.ImageStream(image), $"Image/{ image.Substring(image.LastIndexOf('.') + 1)}");



	}
}
