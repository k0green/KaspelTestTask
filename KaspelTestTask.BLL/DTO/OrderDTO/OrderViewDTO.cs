using KaspelTestTask.BLL.Models.BookModels;
using KaspelTestTask.DAL.Data.Entities;

namespace KaspelTestTask.BLL.DTO.OrderDTO;

public class OrderViewDTO
{
    public long Id { get; set; }
    public DateOnly OrderDate { get; set; }
    public string Number { get; set; }
    public List<BookViewDTO> Books { get; set; }
}