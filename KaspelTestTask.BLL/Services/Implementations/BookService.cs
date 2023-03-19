using AutoMapper;
using KaspelTestTask.BLL.Models.BookModels;
using KaspelTestTask.BLL.Services.Interfaces;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Interfaces;

namespace KaspelTestTask.BLL.Services.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private IMapper mapper = new MapperConfiguration(cfg 
        => cfg.CreateMap<Book, BookViewDTO>().ReverseMap()).CreateMapper();

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookViewDTO>> GetAllBookAsync()
        => mapper.Map<List<Book>, List<BookViewDTO>>(await _bookRepository.GetAllAsync());
    
    public async Task<BookViewDTO> GetBookAsync(long id)
        => mapper.Map<Book, BookViewDTO>(await _bookRepository.GetByIdAsync(id));
    
    public async Task<List<BookViewDTO>> GetFilterBookByNameAsync(string name)
        => mapper.Map<List<Book>, List<BookViewDTO>>(await _bookRepository.GetFilterBookByNameAsync(name));
    
    public async Task<List<BookViewDTO>> GetFilterBookByDateAsync(DateOnly date)
        => mapper
            .Map<List<Book>, List<BookViewDTO>>(await _bookRepository
                .GetFilterByDateBookAsync(date));
}