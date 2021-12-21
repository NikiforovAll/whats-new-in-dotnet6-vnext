namespace Orders;

using Bogus;

public record class Order
{
    public int OrderId { get; init; }
    public string? Address { get; init; }
    public int Quantity { get; init; }

    public int Index { get; set; }
}

public class OrderFaker : Faker<Order>
{
    public OrderFaker()
    {
        RuleFor(o => o.OrderId, f => f.Random.Number(1, 100));
        RuleFor(o => o.Address, f => f.Address.FullAddress());
        RuleFor(o => o.Quantity, f => f.Random.Number(1, 10));
    }
}

