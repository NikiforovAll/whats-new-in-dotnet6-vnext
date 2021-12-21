using static System.Console;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

JsonSerializerOptions options = new() { WriteIndented = true };

Order order = new()
{
    OrderId = 1,
    Address = "Address",
    Quantity = 1,
    Comments = new() { "Cool", "Awesome" }
};
var serializedOrder = JsonSerializer.Serialize(order, options);
WriteLine(serializedOrder);

public record class Order
{
    [JsonPropertyOrder(-1)]
    public int OrderId { get; init; }

    [JsonPropertyOrder(2)]
    public string Address { get; init; }

    [JsonPropertyOrder(1)]
    public int Quantity { get; init; }

    [JsonPropertyOrder(99)]
    public List<string> Comments { get; init; }
}

