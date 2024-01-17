using Clean_Arch___UnitOFWork.Application.Interface;
using Clean_Arch___UnitOFWork.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Clean_Arch___UnitOFWork.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Magazine> _magazineRepository;

        public UnitOfWork(LibraryDbContext context, IRepository<Book> bookRepository, IRepository<Magazine> magazineRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _magazineRepository = magazineRepository;
        }

        public IRepository<Book> BookRepository => _bookRepository;

        public IRepository<Magazine> MagazineRepository => _magazineRepository;

        //public void BeginTransaction() => _transaction = _context.Database.BeginTransaction();

        //public void Commit() => _transaction.Commit();

        //public void RollBack() => _transaction.Rollback();
        public void SaveChanges()
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch(DbUpdateException ex)
                {
                    Console.WriteLine($"Database update error: {ex.Message}");
                    transaction.Rollback();
                    throw;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
