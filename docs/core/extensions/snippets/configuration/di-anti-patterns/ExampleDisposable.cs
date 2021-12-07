namespace DependencyInjection.AntiPatterns
{
    public class ExampleDisposable : IDisposable
    {
        public void Dispose() =>
            Console.WriteLine($"Disposed: {GetHashCode(),12}");
    }
}
