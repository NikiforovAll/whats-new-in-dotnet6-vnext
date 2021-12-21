using Orders;

var faker = new OrderFaker();

var orders = faker.Generate(100);

for (var i = 0; i < orders.Count; i++)
{
    orders[i].Index = i + 1;
}

foreach (var chunk in orders.Chunk(size: 25))
{
    var sum = chunk.Sum(o => o.Quantity);

    Console.WriteLine($"chunk[{chunk.Length}].Quantity={sum}");
}
