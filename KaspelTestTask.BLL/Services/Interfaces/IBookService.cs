using KaspelTestTask.BLL.Models.BookModels;

namespace KaspelTestTask.BLL.Services.Interfaces;

public interface IBookService
{
    public Task<List<BookViewDTO>> GetAllBookAsync();
    public Task<BookViewDTO> GetBookAsync(long id);
    public Task<List<BookViewDTO>> GetFilterBookByNameAsync(string name);
    public Task<List<BookViewDTO>> GetFilterBookByDateAsync(DateOnly date);

}