using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BorrowLend.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext db;

        public IActionResult Index()
        {
            IEnumerable<Item> obj = db.Items;
            return View(obj);
        }
        public ItemController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            var obj = db.Items.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.Items.Update(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = db.Items.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.Items.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
