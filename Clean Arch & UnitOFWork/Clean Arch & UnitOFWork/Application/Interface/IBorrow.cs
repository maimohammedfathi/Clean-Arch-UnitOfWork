namespace Clean_Arch___UnitOFWork.Application.Interface
{
    public interface IBorrow
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int Copies { get; set; }
        bool BorrowItem();
        bool ReturnItem();
    }
}
