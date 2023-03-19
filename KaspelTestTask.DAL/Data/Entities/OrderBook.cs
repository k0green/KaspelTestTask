namespace KaspelTestTask.DAL.Data.Entities;

public class OrderBook : BaseEntity
{
    /// <summary>
    /// Gets or sets the book id.
    /// </summary>
    public long BookId { get; set; }
    /// <summary>
    /// Gets or sets the order id.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    /// Navigation property for communication between entities
    /// </summary>

    public Book? Books { get; set; }
    public Order? Orders { get; set; }
}