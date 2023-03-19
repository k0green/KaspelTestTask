using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KaspelTestTask.DAL.Data.Entities;

public class Book : BaseEntity
{
    public Book()
    {
        OrderBooks = new HashSet<OrderBook>();
    }
    /// <summary>
    /// Gets or sets the Name of book.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the Description of book.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the Release date of book.
    /// </summary>
    public DateOnly ReleaseDate { get; set; }

    /// <summary>
    /// Navigation property for communication between entities
    /// </summary>

    public ICollection<OrderBook> OrderBooks { get; set; }

}