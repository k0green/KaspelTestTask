namespace KaspelTestTask.BLL.Models.BookModels;

public class BookViewDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
}