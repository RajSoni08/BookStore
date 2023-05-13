using BookStore_API.Model;

namespace BookStore_API.Repository.IRepository
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> UpdateAsync(Author entity);
    }

}
