using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model.Dto
{
    public class BookDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int PublisherID { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string ISBN { get; set; }
        public int publicationyear { get; set; }
    }
}
