using Clean_Arch___UnitOFWork.Core.Domain;

namespace Clean_Arch___UnitOFWork.Application.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        Task SaveChangeAsync(CancellationToken cancellationToken);
        void Delete(Guid id);
    }

}
