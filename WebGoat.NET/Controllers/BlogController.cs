using WebGoatCore.Models;
using WebGoatCore.DomainPrimitives;
using WebGoatCore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WebGoatCore.Controllers
{
    [Route("[controller]/[action]")]
    public class BlogController : Controller
    {
        private readonly BlogEntryRepository _blogEntryRepository;
        private readonly BlogResponseRepository _blogResponseRepository;

        public BlogController(BlogEntryRepository blogEntryRepository, BlogResponseRepository blogResponseRepository, NorthwindContext context)
        {
            _blogEntryRepository = blogEntryRepository;
            _blogResponseRepository = blogResponseRepository;
        }

        public IActionResult Index()
        {
            return View(_blogEntryRepository.GetTopBlogEntries());
        }

        [HttpGet("{entryId}")]
        public IActionResult Reply(int entryId)
        {
            return View(_blogEntryRepository.GetBlogEntry(entryId));
        }

        [HttpPost("{entryId}")]
        public IActionResult Reply(int entryId, string contents)
        {
            var userName = User?.Identity?.Name ?? "Anonymous";
            try
            {   
                Content content = new Content(contents);

                BlogResponse blogResponse = new BlogResponse()
                {
                    BlogEntryId = entryId,
                    ResponseDate = DateTime.Now,
                    Author = userName,
                    Contents = content.value
                };
                _blogResponseRepository.CreateBlogResponse(blogResponse);
            }
            catch (ArgumentException ex)
            {
               ModelState.AddModelError(string.Empty, ex.Message);
               return View(_blogEntryRepository.GetBlogEntry(entryId));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(string title, string contents)
        {
            var blogEntry = _blogEntryRepository.CreateBlogEntry(title, contents, User!.Identity!.Name!);
            return View(blogEntry);
        }

    }
}