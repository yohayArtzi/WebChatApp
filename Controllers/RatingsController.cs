using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebChat.Data;
using WebChat.Models;
using WebChat.Services;

namespace WebChat.Controllers
{
    public class RatingsController : Controller
    {
        private readonly IRatingsService _service;

        public RatingsController(WebChatContext context)
        {
            _service = new RatingsService();
        }

        // GET: Rating
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        
        // GET: Rating Search
        //public IActionResult Search()
        //{
        //    return View(_service.GetAll());
        //}

        // POST: Rating Search 
        [HttpPost]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query)) return RedirectToAction(nameof(Index));
            return View(_service.GetByName(query));
        }
        /*
        public IActionResult Search2(string query)
        {
            var q = _service.GetAll().Where(rating => rating.Name.Contains(query) || rating.Comment.Contains(query));
            return PartialView(q);
        }

        */

        // GET: Ratings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = _service.Get((int)id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Rate,Comment,Name,Date")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                _service.Create(rating.Rate, rating.Comment, rating.Name, now.ToString());
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = _service.Get((int)id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Rate,Comment,Name,Date")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(id, rating.Rate, rating.Comment, rating.Name);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = _service.Get((int)id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rating = _service.Get(id);
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
