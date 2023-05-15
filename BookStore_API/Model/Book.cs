using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        public Author Author { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

        public string ISBN { get; set; }
        public int publicationyear { get; set; }
    }
}
