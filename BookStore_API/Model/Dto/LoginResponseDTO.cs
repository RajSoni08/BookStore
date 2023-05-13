namespace BookStore_API.Model.Dto
{
    public class LoginResponseDTO
    {
        public User User { get; set; }
        public string Role { get; set; }
        public string Token { get; internal set; }
    }
}
