using System.Runtime.InteropServices.JavaScript;
using KaspelTestTask.BLL.Services.Interfaces;
using KaspelTestTask.DAL.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace KaspelTestTask.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        return Ok(await _bookService.GetAllBookAsync());
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBookById(long id)
    {
        if (id == null)
            return BadRequest();
        return Ok(await _bookService.GetBookAsync(id));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFilterBookByDateAsync(DateTime date)
    {
        return Ok(await _bookService.GetFilterBookByDateAsync(DateOnly.FromDateTime(date)));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFilterBookByNameAsync(string name)
    {
        if(name==null)
            return BadRequest();
        return Ok(await _bookService.GetFilterBookByNameAsync(name));
    }
}