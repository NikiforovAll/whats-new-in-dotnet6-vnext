using static System.Console;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

JsonSerializerOptions options = new() { WriteIndented = true };

string invalidOrderJson = "{}";

string validJson = "{\"OrderId\": 1}";

WriteLine($"{nameof(invalidOrderJson)}: {invalidOrderJson}");
_ = JsonSerializer.Deserialize<Order>(invalidOrderJson);

WriteLine($"{nameof(validJson)}: {validJson}");
var order = JsonSerializer.Deserialize<Order>(validJson);

WriteLine($"Parsed: {order}");

// IJsonOnDeserialized, IJsonOnDeserializing, IJsonOnSerialized, IJsonOnSerializing
public record class Order : IJsonOnDeserialized
{
    public int OrderId { get; init; }
    public string Address { get; init; }
    public int Quantity { get; init; }

    public void OnDeserialized() => this.Validate();

    private void Validate()
    {
        if (this.OrderId <= 0)
        {
            Console.WriteLine("Error parsing order");
        }
    }
}
