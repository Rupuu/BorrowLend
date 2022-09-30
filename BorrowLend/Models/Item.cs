using System.ComponentModel.DataAnnotations;

namespace BorrowLend.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
    }
}
