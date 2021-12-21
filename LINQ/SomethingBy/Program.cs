using Orders;

var faker = new OrderFaker();

var orders = faker.Generate(100);

for (var i = 0; i < orders.Count; i++)
{
    orders[i].Index = i + 1;
}

Console.WriteLine("MaxBy: " + orders.MaxBy(o => o.Quantity));
Console.WriteLine("MinBy: " + orders.MinBy(o => o.Quantity));
