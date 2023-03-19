namespace KaspelTestTask.DAL.Data.Entities;

public class Order : BaseEntity
{
    public Order()
    {
        OrderBooks = new HashSet<OrderBook>();
    }
    /// <summary>
    /// Gets or sets the Number of the order.
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Gets or sets the OrderDate of the order.
    /// </summary>
    public DateOnly OrderDate { get; set; }
    /// <summary>
    /// Navigation property for communication between entities
    /// </summary>
    public ICollection<OrderBook> OrderBooks { get; set; }
}