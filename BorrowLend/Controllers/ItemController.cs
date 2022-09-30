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
    }
}
