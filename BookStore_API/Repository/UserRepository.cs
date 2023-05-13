using BookStore_API.Data;
using BookStore_API.Model;
using BookStore_API.Repository.IRepository;

namespace BookStore_API.Repository
{
    public class UserRepository
     : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public async Task<User> UpdateAsync(User entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.user.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }
    }
}
