using Clean_Arch___UnitOFWork.Application.Interface;
using Clean_Arch___UnitOFWork.Core.Domain;
using Clean_Arch___UnitOFWork.Persistance;

namespace Clean_Arch___UnitOFWork.Persistance.Repositories
{
    public class MagazineRepository : IMagazineRepository
    {
        private readonly LibraryDbContext _context;
        public MagazineRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public List<Magazine> GetAll() => _context.Magazines.ToList();

        public Magazine GetById(int id) => _context.Magazines.FirstOrDefault(magazine => magazine.Id == id);

        public void Add(Magazine magazine)
        {
            //If it null
            if (magazine == null)
            {
                throw new ArgumentNullException(nameof(magazine), "Magazine cannot be null.");
            }
            // Already exsit
            if (_context.Magazines.Any(existingBook => existingBook.Name == magazine.Name && existingBook.Description == magazine.Description))
            {
                throw new InvalidOperationException("A book with the same Name and Description already exists.");
            }
            //Add book

            _context.Magazines.Add(magazine);
        }
        public void Update(Magazine magazine)
        {
            var existingMagazine = _context.Magazines.FirstOrDefault(m => m.Id == magazine.Id);
            if (existingMagazine != null)
            {
                existingMagazine.Name = magazine.Name;
                existingMagazine.Description = magazine.Description;
                existingMagazine.Copies = magazine.Copies;
            }
        }
        public void Delete(int id)
        {
            var magazineToRemove = _context.Magazines.FirstOrDefault(magazine => magazine.Id == id);
            if (magazineToRemove != null)
            {
                _context.Magazines.Remove(magazineToRemove);
            }
        }


    }
}
