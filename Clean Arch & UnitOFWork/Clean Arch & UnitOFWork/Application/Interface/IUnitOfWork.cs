using Clean_Arch___UnitOFWork.Core.Domain;

namespace Clean_Arch___UnitOFWork.Application.Interface
{
    public interface IUnitOfWork
    {
        #region Transaction 
        //void BeginTransaction();
        //void Commit();
        //void RollBack();
        #endregion

        #region SavChange
        void SaveChanges();
        #endregion

        IRepository<Book> BookRepository { get; }
        IRepository<Magazine> MagazineRepository { get; }
    }
}
