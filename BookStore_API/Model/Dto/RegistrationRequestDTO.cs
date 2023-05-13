using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model.Dto
{
    public class RegistrationRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
