using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_database__App.Data;
using School_database__App.Models;

namespace School_database__App.Controllers
{
    public class subjectsController : Controller
    {
        private readonly SubjectDbContext _context;

        public subjectsController(SubjectDbContext context)
        {
            _context = context;
        }

        // GET: subjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.subject.ToListAsync());
        }

        // GET: subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.subject
                .FirstOrDefaultAsync(m => m.Subject_id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject_id,Subject_Name")] subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subject_id,Subject_Name")] subject subject)
        {
            if (id != subject.Subject_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!subjectExists(subject.Subject_id))
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
            return View(subject);
        }

        // GET: subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.subject
                .FirstOrDefaultAsync(m => m.Subject_id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.subject.FindAsync(id);
            if (subject != null)
            {
                _context.subject.Remove(subject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool subjectExists(int id)
        {
            return _context.subject.Any(e => e.Subject_id == id);
        }
    }
}
