using AutoMapper;
using KaspelTestTask.BLL.DTO.OrderDTO;
using KaspelTestTask.BLL.Models.BookModels;
using KaspelTestTask.BLL.Services.Interfaces;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Interfaces;

namespace KaspelTestTask.BLL.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderBookRepository _orderBookRepository;
    private IMapper mapperOrder = new MapperConfiguration(cfg 
        => cfg.CreateMap<Order, OrderViewDTO>().ReverseMap()).CreateMapper();
    private IMapper mapperBook = new MapperConfiguration(cfg 
        => cfg.CreateMap<Book, BookViewDTO>().ReverseMap()).CreateMapper();

    public OrderService(IOrderRepository orderRepository,
        IOrderBookRepository orderBookRepository)
    {
        _orderRepository = orderRepository;
        _orderBookRepository = orderBookRepository;
    }

    public async Task<List<OrderViewDTO>> GetAllOrderAsync()
    {
        var orders =  mapperOrder
            .Map<List<Order>, List<OrderViewDTO>>(await _orderRepository.GetAllAsync());
        foreach (var order in orders)
        {
            order.Books = mapperBook
                .Map<List<Book>, List<BookViewDTO>>(await _orderBookRepository
                    .GetAllBookForOrderByOrderId(order.Id));
        }

        return orders;
    }
    
    public async Task<OrderViewDTO> GetOrderAsync(long id)
    {
        var order =  mapperOrder.Map<Order, OrderViewDTO>(await _orderRepository.GetByIdAsync(id));
        order.Books = mapperBook
            .Map<List<Book>, List<BookViewDTO>>(await _orderBookRepository
                .GetAllBookForOrderByOrderId(order.Id));
        return order;
    }
    
    public async Task<List<OrderViewDTO>> GetFilterOrdersByNumberAsync(string number)
    {
        var orders = mapperOrder
            .Map<List<Order>, List<OrderViewDTO>>(await _orderRepository
                .GetFilterOrdersByNumberAsync(number));
        foreach (var order in orders)
        {
            order.Books = mapperBook
                .Map<List<Book>, List<BookViewDTO>>(await _orderBookRepository
                    .GetAllBookForOrderByOrderId(order.Id));
        }

        return orders;
    }
    
    public async Task<List<OrderViewDTO>> GetFilterOrdersByDateAsync(DateOnly date)
    {
        var orders = mapperOrder
            .Map<List<Order>, List<OrderViewDTO>>(await _orderRepository
                .GetFilterOrdersByDateAsync(date));
        foreach (var order in orders)
        {
            order.Books = mapperBook
                .Map<List<Book>, List<BookViewDTO>>(await _orderBookRepository
                    .GetAllBookForOrderByOrderId(order.Id));
        }

        return orders;
    }
    
    public async Task CreateOrder(List<long> booksId)
    {
        var order = new Order()
        {
            Number = Guid.NewGuid().ToString(),
            OrderDate = DateOnly.FromDateTime(DateTime.Now)
        };
        await _orderRepository.AddAsync(order);
        foreach (var id in booksId)
        {
            await _orderBookRepository.AddAsync(new OrderBook()
            {
                BookId = id,
                OrderId = await _orderRepository.GetOrderIdByNumber(order.Number)
            });
        }
    }
}