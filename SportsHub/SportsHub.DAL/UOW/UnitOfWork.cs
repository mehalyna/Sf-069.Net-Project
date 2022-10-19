﻿using SportsHub.DAL.Data;
using SportsHub.DAL.Repository;
using SportsHub.Domain.Repository;
using SportsHub.Domain.UOW;

namespace SportsHub.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ArticleRepository = new ArticleRepository(_context);
        }

        public IUserRepository UserRepository { get; }
        public IArticleRepository ArticleRepository { get; }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
