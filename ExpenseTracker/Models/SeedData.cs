using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExpenseTracker.Data;
using System;
using System.Linq;

namespace ExpenseTracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExpenseTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExpenseTrackerContext>>()))
            {
                // Look for any movies.
                if (context.MonthlyExpense.Any())
                {
                    return;   // DB has been seeded
                }

                context.MonthlyExpense.AddRange(
                    new MonthlyExpense
                    {
                        MonthlyExpenseName = "Groceries",
                        Price = 250
                    },

                    new MonthlyExpense
                    {
                        MonthlyExpenseName = "Gas",
                        Price = 60
                    },

                    new MonthlyExpense
                    {
                        MonthlyExpenseName = "Car Insurance",
                        Price = 120
                    },

                    new MonthlyExpense
                    {
                        MonthlyExpenseName = "Essentials",
                        Price = 50
                    }
                );
                context.SaveChanges();
            }
        }
    }
}