using BookStore_API.Model;
using BookStore_API.Model.Dto;

namespace BookStore_API.Repository.IRepository
{
    public interface IHomeRepository : IRepository<User>
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<User> UpdateAsync(User entity);


    }

}
