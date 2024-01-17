using Clean_Arch___UnitOFWork.Application.Interface;
using Clean_Arch___UnitOFWork.Core.Domain;
using Clean_Arch___UnitOFWork.Persistance;

namespace Clean_Arch___UnitOFWork.Persistance.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll() => _context.Books.ToList();

        public Book GetById(int id) => _context.Books.FirstOrDefault(book => book.Id == id);

        public void Add(Book book)
        {
            //If it null
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            // Already exsit
            if (_context.Books.Any(existingBook => existingBook.Name == book.Name && existingBook.Description == book.Description))
            {
                throw new InvalidOperationException("A book with the same Name and Description already exists.");
            }
            //Add book

            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.Description = book.Description;
                existingBook.Copies = book.Copies;
                _context.Books.ToList();
            }
        }

        public void Delete(int id)
        {
            var bookToRemove = _context.Books.FirstOrDefault(book => book.Id == id);
            if (bookToRemove != null)
            {
                _context.Books.Remove(bookToRemove);
                _context.Books.ToList();
            }
        }

    }
}
