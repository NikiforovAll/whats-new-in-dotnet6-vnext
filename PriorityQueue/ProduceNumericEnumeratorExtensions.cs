namespace PriorityQueue;

public static class ProduceNumericEnumeratorExtensions
{
    // C# 9 feature
    public static IEnumerator<int> GetEnumerator(this int number)
    {
        for (var i = 0; i < number; i++)
        {
            yield return i;
        }
    }
}