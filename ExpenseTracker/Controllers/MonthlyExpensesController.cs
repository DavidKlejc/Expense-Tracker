using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers
{
    public class MonthlyExpensesController : Controller
    {
        private readonly ExpenseTrackerContext _context;

        public MonthlyExpensesController(ExpenseTrackerContext context)
        {
            _context = context;
        }

        // GET: MonthlyExpenses
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(await _context.MonthlyExpense.ToListAsync());
            }
            else
            {
                return NotFound();
            }
        }

        // GET: MonthlyExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyExpense = await _context.MonthlyExpense
                .FirstOrDefaultAsync(m => m.MonthlyExpenseId == id);
            if (monthlyExpense == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                return View(monthlyExpense);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: MonthlyExpenses/Create
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: MonthlyExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonthlyExpenseId,MonthlyExpenseName,Price")] MonthlyExpense monthlyExpense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthlyExpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (User.Identity.IsAuthenticated)
            {
                return View(monthlyExpense);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: MonthlyExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyExpense = await _context.MonthlyExpense.FindAsync(id);
            if (monthlyExpense == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
            {
                return View(monthlyExpense);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: MonthlyExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonthlyExpenseId,MonthlyExpenseName,Price")] MonthlyExpense monthlyExpense)
        {
            if (id != monthlyExpense.MonthlyExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthlyExpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthlyExpenseExists(monthlyExpense.MonthlyExpenseId))
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
            if (User.Identity.IsAuthenticated)
            {
                return View(monthlyExpense);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: MonthlyExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyExpense = await _context.MonthlyExpense
                .FirstOrDefaultAsync(m => m.MonthlyExpenseId == id);
            if (monthlyExpense == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                return View(monthlyExpense);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: MonthlyExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthlyExpense = await _context.MonthlyExpense.FindAsync(id);
            _context.MonthlyExpense.Remove(monthlyExpense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthlyExpenseExists(int id)
        {
            return _context.MonthlyExpense.Any(e => e.MonthlyExpenseId == id);
        }
    }
}
