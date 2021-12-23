using MinimalAPI;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

services.AddSingleton(new Storage<int>() { 1, 2 });

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

// [new] Explicit return type in lambdas
// [new] Lambdas with attributes
// [new] improved type inference
var lambda = IEnumerable<int> (/*not required*/[FromServices] Storage<int> storage) => storage;

// Instead of lambda, you can pass method group
async IAsyncEnumerable<int> GetStorageStream(Storage<int> storage)
{
    foreach (var i in storage)
	{
        await Task.Delay(1000);
        yield return i;
	}
}

app.MapGet(ApiConstants.Storage, lambda);

app.MapGet(ApiConstants.StorageStream, GetStorageStream)
    .WithName("GetStorageAsStream");

app.MapPost(ApiConstants.Storage, (Storage<int> storage) =>
{
    storage.Add(storage.Peek() + 3);

    return Results.Accepted();
});


app.Run();
