using System.Runtime.CompilerServices;

var f = new Foo(new Foo(default, 1), 0);

TestFramework.Assert(f is not null);

Console.WriteLine(f);
// [new] Extended property patterns​, instead of {Child: {Value: ...}}
TestFramework.Assert(f.Child.Value is > 0 and < 100);

TestFramework.Assert(f.Child.Child is null);

// [new] built-in null guard
ArgumentNullException.ThrowIfNull​(f.Child.Child);

public record Foo(Foo? Child, int Value);

public class TestFramework
{
    public static void Print(bool result, [CallerArgumentExpression("result")] string? expr = default)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"({expr}) is {result}");
        Console.ResetColor();
    }

    public static void Assert(bool condition, [CallerArgumentExpression("condition")]
        string? conditionExpression = default)
    {
        if (!condition)
            throw new Exception($"Condition failed: {conditionExpression}");

        Print(condition, conditionExpression);
    }
}