using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BorrowLend.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext db;

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> obj = db.ExpensesType;
            return View(obj);
        }
        public ExpenseTypeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType item)
        {
            db.ExpensesType.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            var obj = db.ExpensesType.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.ExpensesType.Update(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = db.ExpensesType.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ExpenseType obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.ExpensesType.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
