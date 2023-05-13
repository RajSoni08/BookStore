using BookStore_API.Data;
using BookStore_API.Model;
using BookStore_API.Repository.IRepository;

namespace BookStore_API.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {

        private readonly ApplicationDbContext _db;
        public PublisherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Publisher> UpdateAsync(Publisher entity)
        {

            _db.publisher.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }
    }

}
