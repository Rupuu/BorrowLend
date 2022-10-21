using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BorrowLend.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The amount must be positive")]
        public double Amount { get; set; }

        public int ExpenceType { get; set; }
        [ForeignKey("ExpenceTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }

    }
}
