namespace Clean_Arch___UnitOFWork.Application.Interface
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IMagazineRepository MagazineRepository { get; }
        void SaveChanges();
    }
}
