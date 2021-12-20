namespace FileScopedNamespaces
{
    public record class Foo(string Bar)
    {
        public void Do()
        {
            Console.WriteLine(this);
        }
    }
}