﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Web.Models;

namespace Movies.Web.Controllers
{
    public class NationalitiesController : Controller
    {
        private readonly MoviesContext _context;

        public NationalitiesController(MoviesContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nationalities.ToListAsync());
        }

        // GET: Nationalities/People/3
        public async Task<IActionResult> People(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.NationalityId == id);
            if (nationality == null)
            {
                return NotFound();
            }

            var people = _context.People
                            .Where(p => p.NationalityId == id);

            ViewData["Nationaility"] = nationality.Title;

            return View(people);
        }
        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.NationalityId == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // GET: Nationalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalityId,Title")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NationalityId,Title")] Nationality nationality)
        {
            if (id != nationality.NationalityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationality.NationalityId))
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
            return View(nationality);
        }

        // GET: Nationalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.NationalityId == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nationality = await _context.Nationalities.FindAsync(id);
            _context.Nationalities.Remove(nationality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(int id)
        {
            return _context.Nationalities.Any(e => e.NationalityId == id);
        }
    }
}
