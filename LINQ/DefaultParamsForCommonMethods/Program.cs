using Orders;

var faker = new OrderFaker();

var orders = faker.Generate(100);

for (var i = 0; i < orders.Count; i++)
{
    orders[i].Index = i + 1;
}

Order order = default;
var condition = bool (Order o) => o is { Address.Length: > 5 };

// FirstOrDefault
order = orders.FirstOrDefault(condition, defaultValue: new ());
Console.WriteLine(order);

// LastOrDefault
order = orders.LastOrDefault(condition, defaultValue: new ());
Console.WriteLine(order);

// SingleOrDefault
try
{
    order = orders.SingleOrDefault(condition, defaultValue: new ());
    Console.WriteLine(order);
}
catch
{
    Console.WriteLine("SingleOrDefault excpetion thrown");
}
