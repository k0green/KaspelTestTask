using AutoMapper;
using KaspelTestTask.BLL.DTO.OrderDTO;
using KaspelTestTask.BLL.Services.Interfaces;
using KaspelTestTask.DAL.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KaspelTestTask.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService,
        IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrderAsync();
        return Ok(orders);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrderById(long id)
    {
        if (id == null)
            return BadRequest();
        return Ok(await _orderService.GetOrderAsync(id));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFilterOrdersByDate(DateTime date)
    {
        return Ok(await _orderService.GetFilterOrdersByDateAsync(DateOnly.FromDateTime(date)));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFilterOrdersByNumber(string number)
    {
        if (number == null)
            return BadRequest();
        return Ok(await _orderService.GetFilterOrdersByNumberAsync(number));
    }

    [HttpPost]
    public async Task<IActionResult> Add(List<long> booksId)
    {
        if (booksId.Count==0)
            return BadRequest();
        await _orderService.CreateOrder(booksId);
        return Ok();
    }
}