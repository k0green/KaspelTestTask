using KaspelTestTask.DAL.Data.Entities;

namespace KaspelTestTask.DAL.Repositories.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    public Task<List<Book>> GetFilterByDateBookAsync(DateOnly date);
    public Task<List<Book>> GetFilterBookByNameAsync(string name);
}