using static System.Console;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

JsonSerializerOptions options = new() { WriteIndented = true };

Order order = new(1, "Address", new() { "Cool", "Awesome" });
var serializedOrder = JsonSerializer.Serialize(order);

Console.WriteLine("\n> Working with DOM tokens\n");
JsonNode node = JsonNode.Parse(serializedOrder);

WriteLine($"OrderId: {node["OrderId"].GetValue<int>()}");
WriteLine($"Order.Comments[0]: {node["Comments"][0].GetValue<string>()}");

Console.WriteLine("\n> Create DOM Object via API\n");
var jObjectOrder = new JsonObject
{
    ["OrderId"] = 1,
    ["Discounts"] = new JsonArray(
        new JsonObject
        {
            ["DiscountId"] = 1,
            ["Value"] = .05,
        },
        new JsonObject
        {
            ["DiscountId"] = 2,
            ["Value"] = .1,
        }
    ),
};

WriteLine(jObjectOrder.ToJsonString(options));

public record class Order(int OrderId, string Address, List<string> Comments);