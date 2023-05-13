using BookStore_API.Data;
using BookStore_API.Model;
using BookStore_API.Repository.IRepository;

namespace BookStore_API.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Book> UpdateAsync(Book entity)
        {

            _db.book.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }
    }

}
