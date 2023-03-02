﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class СustomerController : Controller
    {
        private readonly HotelContext _context;

        public СustomerController(HotelContext context)
        {
            _context = context;
        }

        // GET: Сustomer
        public async Task<IActionResult> Index()
        {
              return _context.Сustomers != null ? 
                          View(await _context.Сustomers.ToListAsync()) :
                          Problem("Entity set 'HotelContext.Сustomers'  is null.");
        }

        // GET: Сustomer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Сustomers == null)
            {
                return NotFound();
            }

            var сustomer = await _context.Сustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сustomer == null)
            {
                return NotFound();
            }

            return View(сustomer);
        }

        // GET: Сustomer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Сustomer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Gender,RoomNumber")] Сustomer сustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(сustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(сustomer);
        }

        // GET: Сustomer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Сustomers == null)
            {
                return NotFound();
            }

            var сustomer = await _context.Сustomers.FindAsync(id);
            if (сustomer == null)
            {
                return NotFound();
            }
            return View(сustomer);
        }

        // POST: Сustomer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Gender,RoomNumber")] Сustomer сustomer)
        {
            if (id != сustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(сustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!СustomerExists(сustomer.Id))
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
            return View(сustomer);
        }

        // GET: Сustomer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Сustomers == null)
            {
                return NotFound();
            }

            var сustomer = await _context.Сustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сustomer == null)
            {
                return NotFound();
            }

            return View(сustomer);
        }

        // POST: Сustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Сustomers == null)
            {
                return Problem("Entity set 'HotelContext.Сustomers'  is null.");
            }
            var сustomer = await _context.Сustomers.FindAsync(id);
            if (сustomer != null)
            {
                _context.Сustomers.Remove(сustomer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool СustomerExists(int id)
        {
          return (_context.Сustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
