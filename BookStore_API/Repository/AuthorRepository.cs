﻿using BookStore_API.Data;
using BookStore_API.Model;
using BookStore_API.Repository.IRepository;

namespace BookStore_API.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Author> UpdateAsync(Author entity)
        {

            _db.author.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }

}
