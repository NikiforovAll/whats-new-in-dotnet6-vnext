using Orders;

var faker = new OrderFaker();

var orders = faker.Generate(100);

for (var i = 0; i < orders.Count; i++)
{
    orders[i].Index = i + 1;
}

if (orders.TryGetNonEnumeratedCount(out int count))
{
    Console.WriteLine($"The count is {count}");
}