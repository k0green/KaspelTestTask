using KaspelTestTask.DAL.Data;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaspelTestTask.DAL.Repositories.Implementations;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<long> GetOrderIdByNumber(string number)
    {
        var order = await _dbContext.Orders.FirstAsync(x => x.Number == number);
        return order.Id;
    }
    
    public async Task<List<Order>> GetFilterOrdersByNumberAsync(string number)
    {
        return await _dbContext.Orders.Where(x => x.Number.Contains(number)).ToListAsync();
    }
    
    public async Task<List<Order>> GetFilterOrdersByDateAsync(DateOnly date)
    {
        return await _dbContext.Orders.Where(x => x.OrderDate == date).ToListAsync();
    }
}