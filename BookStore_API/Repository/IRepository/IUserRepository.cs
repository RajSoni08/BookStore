using BookStore_API.Model;

namespace BookStore_API.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateAsync(User entity);
    }
    
}
