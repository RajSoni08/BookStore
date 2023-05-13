using BookStore_API.Model;

namespace BookStore_API.Repository.IRepository
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        Task<Publisher> UpdateAsync(Publisher entity);
    }

}
