using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookListData.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Book title")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(20)]
        public string ISBN { get; set; }
    }
}
