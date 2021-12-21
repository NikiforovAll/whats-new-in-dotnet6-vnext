using static System.Console;
using static System.Numerics.BitOperations;

using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(250));

WriteLine("Finding random power of two...");
while (await timer.WaitForNextTickAsync())
{
    if(Random.Shared.Next(129) is var e && IsPow2(e))
    {
        WriteLine($"Done! {e}");
        break;
    }
    WriteLine(e);
}

public record class LogEntry(int Value);
