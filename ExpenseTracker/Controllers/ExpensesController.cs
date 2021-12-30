using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        // 
        // GET: /Expenses/
        // This is the only controller I want (check if I need to add get and put controllers or if thats handles in model) 

        public IActionResult Index()
        {
            return View();
        }

    }
}