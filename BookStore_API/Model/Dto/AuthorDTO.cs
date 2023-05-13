using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model.Dto
{
    public class AuthorDTO
    {
        [Required]
        public int AID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
