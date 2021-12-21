using Orders;

var faker = new OrderFaker();

var orders = faker.Generate(100);

for (var i = 0; i < orders.Count; i++)
{
    orders[i].Index = i + 1;
}
var orders2 = orders.Take(^5..);
Console.WriteLine(string.Join(Environment.NewLine, orders2));