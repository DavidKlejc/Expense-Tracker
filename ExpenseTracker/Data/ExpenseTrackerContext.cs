using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext (DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseTracker.Models.MonthlyExpense> MonthlyExpense { get; set; }
    }
}
