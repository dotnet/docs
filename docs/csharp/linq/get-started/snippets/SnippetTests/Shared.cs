using Xunit;

// Tests need to be carried out synchronously, otherwise the console output for different tests gets intermingled
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]

namespace LinqSamples.Test;
public static class Shared
{
    public static StringWriter InitTest()
    {
        // We want to capture the console output for each test separately
        StringWriter sw = new();
        Console.SetOut(sw);
        return sw;
    }
}
