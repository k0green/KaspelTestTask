using KaspelTestTask.DAL.Data.Entities;

namespace KaspelTestTask.DAL.Repositories.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<List<Order>> GetFilterOrdersByNumberAsync(string number);
    public Task<List<Order>> GetFilterOrdersByDateAsync(DateOnly date);
    public Task<long> GetOrderIdByNumber(string number);

}