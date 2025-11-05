namespace DesignPattern_Creational.Services.Builder;

public record OrderItem(string Product, int Quantity);

public class Order
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public List<OrderItem> Items { get; } = new();
    public string? GiftMessage { get; set; }
    public bool IncludeGift { get; set; } // indicates whether gift option was selected
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public interface IOrderBuilder
{
    IOrderBuilder AddItem(string product, int quantity);
    IOrderBuilder WithGift(string? message);
    Order Build();
}

public class OrderBuilder : IOrderBuilder
{
    private readonly Order _order = new();

    public IOrderBuilder AddItem(string product, int quantity)
    {
        if (string.IsNullOrWhiteSpace(product)) throw new ArgumentException("Product is required", nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        _order.Items.Add(new OrderItem(product, quantity));
        return this;
    }

    public IOrderBuilder WithGift(string? message)
    {
        _order.IncludeGift = true; // mark gift selected even if no message provided
        _order.GiftMessage = string.IsNullOrWhiteSpace(message) ? null : message;
        return this;
    }

    public Order Build()
    {
        if (_order.Items.Count == 0) throw new InvalidOperationException("At least one item is required");
        return _order;
    }
}