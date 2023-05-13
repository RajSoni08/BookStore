using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model.Dto
{
    public class AuthorUpdateDTO
    {
        [Required]
        public int AID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
