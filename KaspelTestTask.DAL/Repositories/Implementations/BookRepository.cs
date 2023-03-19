using KaspelTestTask.DAL.Data;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaspelTestTask.DAL.Repositories.Implementations;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<List<Book>> GetFilterBookByNameAsync(string name)
        => await _dbContext.Books.Where(x => x.Name.Contains(name)).ToListAsync();
    
    public async Task<List<Book>> GetFilterByDateBookAsync(DateOnly date)
        => await _dbContext.Books.Where(x => x.ReleaseDate == date).ToListAsync();
}