using Clean_Arch___UnitOFWork.Core.Domain;

namespace Clean_Arch___UnitOFWork.Core.Interface
{
    public interface IMagazineRepository
    {
        List<Magazine> GetAll();
        Magazine GetById(int id);
        void Add(Magazine magazine);
        void Update(Magazine magazine);
        void Delete(int id);
    }
}
