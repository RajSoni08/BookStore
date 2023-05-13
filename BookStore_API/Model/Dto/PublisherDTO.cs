using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Model.Dto
{
    public class PublisherDTO
    {
        [Required]
        public int PId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
