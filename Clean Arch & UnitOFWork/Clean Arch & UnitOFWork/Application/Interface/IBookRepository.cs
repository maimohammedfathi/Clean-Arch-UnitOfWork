using Clean_Arch___UnitOFWork.Core.Domain;

namespace Clean_Arch___UnitOFWork.Application.Interface
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
