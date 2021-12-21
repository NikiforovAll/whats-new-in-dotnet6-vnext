using static System.Console;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

JsonSerializerOptions options = new() { WriteIndented = true };

// [SerializeAsync]

using var stream = new MemoryStream();
IAsyncEnumerable<int> collection = GenerateRangeAsync(1, 5);

// to Stream
Console.WriteLine("Serialization started...");
await JsonSerializer.SerializeAsync(stream, collection, options);
Console.WriteLine("Serialization finished...");

// reset
stream.Position = 0;

// [DeserializeAsyncEnumerable]

// from Stream
await foreach (var i in JsonSerializer.DeserializeAsyncEnumerable<int>(stream, options))
{
    await Task.Delay(500);
    WriteLine(i);
}

static async IAsyncEnumerable<int> GenerateRangeAsync(int start, int count)
{
    for (int i = 0; i < count; i++)
    {
        await Task.Delay(1000);
        yield return start + i;
    }
}
