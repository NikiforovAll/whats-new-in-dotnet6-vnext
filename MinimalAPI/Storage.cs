namespace MinimalAPI;

public class Storage<T> : List<T>
{
    public T Peek() => this[^1];
}