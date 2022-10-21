using Microsoft.AspNetCore.Mvc.Rendering;

namespace BorrowLend.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }    
        public IEnumerable<SelectListItem> TypeDropDown{ get; set; }
    }
}
