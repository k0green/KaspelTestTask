using KaspelTestTask.DAL.Data.Entities;

namespace KaspelTestTask.DAL.Repositories.Interfaces;

public interface IOrderBookRepository : IBaseRepository<OrderBook>
{
    public Task<List<Book>> GetAllBookForOrderByOrderId(long id);

}