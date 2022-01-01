using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class MonthlyExpense
    {
        public int MonthlyExpenseId { get; set; }

        [Display(Name = "Expense")]
        public string MonthlyExpenseName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}