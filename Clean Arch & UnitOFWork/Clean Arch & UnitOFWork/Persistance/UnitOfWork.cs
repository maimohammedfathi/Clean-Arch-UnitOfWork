using Clean_Arch___UnitOFWork.Application.Interface;

namespace Clean_Arch___UnitOFWork.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IMagazineRepository _magazineRepository;

        public UnitOfWork(LibraryDbContext context, IBookRepository bookRepository, IMagazineRepository magazineRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _magazineRepository = magazineRepository;
        }

        public IBookRepository BookRepository => _bookRepository;

        public IMagazineRepository MagazineRepository => _magazineRepository;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
