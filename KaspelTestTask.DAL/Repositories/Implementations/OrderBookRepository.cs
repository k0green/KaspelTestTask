using KaspelTestTask.DAL.Data;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaspelTestTask.DAL.Repositories.Implementations;

public class OrderBookRepository : BaseRepository<OrderBook>, IOrderBookRepository
{
    public OrderBookRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Book>> GetAllBookForOrderByOrderId(long id)
    {
        return await _dbContext
            .OrderBooks
            .Where(x => x.OrderId == id)
            .Select(x => new Book()
        {
            Id = x.Books.Id,
            Name = x.Books.Name,
            Description = x.Books.Description,
            OrderBooks = x.Books.OrderBooks,
            ReleaseDate = x.Books.ReleaseDate
        }).ToListAsync();
    }
}