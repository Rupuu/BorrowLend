using BorrowLend.Data;
using BorrowLend.Models;
using BorrowLend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BorrowLend.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext db;

        public IActionResult Index()
        {
            IEnumerable<Expense> obj = db.Expenses;
            return View(obj);
        }
        public ExpenseController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                TypeDropDown = db.ExpensesType.Select(i => new SelectListItem
                {
                    Text = i.ExpenseTypeName,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense item)
        {
            db.Expenses.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            var obj = db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.Expenses.Update(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Expense obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.Expenses.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
