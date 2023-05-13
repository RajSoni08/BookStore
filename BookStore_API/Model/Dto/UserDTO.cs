using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
