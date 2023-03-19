using KaspelTestTask.BLL.DTO.OrderDTO;

namespace KaspelTestTask.BLL.Services.Interfaces;

public interface IOrderService
{
    public Task<List<OrderViewDTO>> GetAllOrderAsync();
    public Task<OrderViewDTO> GetOrderAsync(long id);
    public Task<List<OrderViewDTO>> GetFilterOrdersByNumberAsync(string number);
    public Task<List<OrderViewDTO>> GetFilterOrdersByDateAsync(DateOnly date);
    public Task CreateOrder(List<long> booksId);
}