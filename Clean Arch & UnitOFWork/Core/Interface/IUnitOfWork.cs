namespace Clean_Arch___UnitOFWork.Core.Interface
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IMagazineRepository MagazineRepository { get; }
        void SaveChanges();
    }
}
