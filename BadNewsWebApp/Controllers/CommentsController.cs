﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadNews.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BadNewsWebApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly NewsPortalContext _context;
        private readonly UserManager<User> userManager;

        public CommentsController(NewsPortalContext context, UserManager<User> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var newsPortalContext = _context.Comments.Include(c => c.Post).Include(c => c.User);
            return View(await newsPortalContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }


        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreatedAt,UpdatedAt,UserId,PostId,Review")] Comment comment, Guid id)
        {
            if (ModelState.IsValid)
            {
                comment.PostId = id;
                comment.CommentId = Guid.NewGuid();
                comment.UserId = userManager.GetUserId(User);
                comment.CreatedAt = DateTime.Now.ToShortDateString();
                comment.UpdatedAt = DateTime.Now.ToShortDateString();
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Posts", new { id = comment.PostId });
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "Title", comment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "Title", comment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CommentId,Content,CreatedAt,UpdatedAt,UserId,PostId, Review")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    comment.UpdatedAt = DateTime.Now.ToShortDateString();
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "Title", comment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(Guid id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
