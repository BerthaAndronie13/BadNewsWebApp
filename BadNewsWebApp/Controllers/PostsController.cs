using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadNews.Models;
using Microsoft.AspNetCore.Authorization;
using BadNewsWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BadNewsWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly NewsPortalContext _context;

        public PostsController(NewsPortalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult>Politics(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;
            var postsPolitics = from p in posts
                        select p;

            postsPolitics = postsPolitics.Where(p => p.Category.CategoryName.Contains("Politics"));

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postsPolitics = postsPolitics.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    postsPolitics = postsPolitics.OrderBy(s => s.CreatedAt);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                postsPolitics = postsPolitics.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }

            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(postsPolitics.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<ActionResult> Lifestyle(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;
            var postsLifestyle = from p in posts
                             select p;

            postsLifestyle = postsLifestyle.Where(p => p.Category.CategoryName.Contains("Lifestyle"));

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postsLifestyle = postsLifestyle.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    postsLifestyle = postsLifestyle.OrderBy(s => s.CreatedAt);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                postsLifestyle = postsLifestyle.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }

            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(postsLifestyle.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<ActionResult> Travel(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;
            var postsTravel = from p in posts
                                select p;

            postsTravel = postsTravel.Where(p => p.Category.CategoryName.Contains("Travel"));

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postsTravel = postsTravel.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    postsTravel = postsTravel.OrderBy(s => s.CreatedAt);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                postsTravel = postsTravel.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }

            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(postsTravel.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<ActionResult> Health(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;
            var postsHealth = from p in posts
                              select p;

            postsHealth = postsHealth.Where(p => p.Category.CategoryName.Contains("Health"));

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postsHealth = postsHealth.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    postsHealth = postsHealth.OrderBy(s => s.CreatedAt);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                postsHealth = postsHealth.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }

            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(postsHealth.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<ActionResult> Entertainment(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;
            var postsEntertainment = from p in posts
                              select p;

            postsEntertainment = postsEntertainment.Where(p => p.Category.CategoryName.Contains("Entertainment"));

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postsEntertainment = postsEntertainment.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    postsEntertainment = postsEntertainment.OrderBy(s => s.CreatedAt);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                postsEntertainment = postsEntertainment.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }

            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(postsEntertainment.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<ActionResult> Sport(string sortOrder,
       string currentFilter,
       string searchString,
       int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;
            var postsSport = from p in posts
                                     select p;

            postsSport = postsSport.Where(p => p.Category.CategoryName.Contains("Sport"));

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postsSport = postsSport.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    postsSport = postsSport.OrderBy(s => s.CreatedAt);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                postsSport = postsSport.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }

            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(postsSport.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var newsPortalContext = _context.Posts.Include(p => p.Category);
            return View(await newsPortalContext.ToListAsync());
        }

        // GET: Posts
        public async Task<IActionResult> Manage(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var posts = from p in _context.Posts
                        select p;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    posts = posts.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    posts = posts.OrderBy(s => s.CreatedAt);
                    break;
                case "date_desc":
                    posts = posts.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    posts = posts.OrderBy(s => s.Title);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(p => p.Title.Contains(searchString)
                                       || p.Introduction.Contains(searchString)
                                       || p.Middle.Contains(searchString)
                                       || p.Conclusion.Contains(searchString)
                                       || p.Quote.Contains(searchString)
                                       );
            }
            int pageSize = 6;
            return View(await PaginatedList<Post>.CreateAsync(posts.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            PostCommentsViewModel PCVM = new PostCommentsViewModel();
            PCVM.Post = post;
            var comments = _context.Comments.Include(c => c.Post).Include(c => c.User).Where(c => c.PostId == id);
            PCVM.Comments = comments;
            return View(PCVM);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("PostId,Title,PostStatus,Image,CreatedAt,UpdatedAt,CategoryId, Introduction, Middle, Quote, Conclusion, ImageCover")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostId = Guid.NewGuid();
                post.CreatedAt = DateTime.Now;
                post.UpdatedAt = DateTime.Now;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", post.CategoryId);
            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", post.CategoryId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id, [Bind("PostId,Title,PostStatus,Image,CreatedAt,UpdatedAt,CategoryId, Introduction, Middle, Quote, Conclusion, ImageCover")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    post.UpdatedAt = DateTime.Now;
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Manage));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", post.CategoryId);
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
