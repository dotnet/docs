using System;
using Microsoft.Extensions.Logging;

namespace IdentifierNamingExamples;

// <ClassPrimaryConstructor>
public class DataService(IWorkerQueue workerQueue, ILogger logger)
{
    public void ProcessData()
    {
        // Use the parameters directly
        logger.LogInformation("Processing data");
        workerQueue.Enqueue("data");
    }
}
// </ClassPrimaryConstructor>

// <StructPrimaryConstructor>
public struct Point(double x, double y)
{
    public double Distance => Math.Sqrt(x * x + y * y);
}
// </StructPrimaryConstructor>

// <RecordPrimaryConstructor>
public record Person(string FirstName, string LastName);
public record Address(string Street, string City, string PostalCode);
// </RecordPrimaryConstructor>

// Supporting interfaces for examples
public interface IWorkerQueue
{
    void Enqueue(string item);
    int Count { get; }
}

// Add a simple main method to make it an executable
public class Program
{
    public static void Main()
    {
        // Example usage
        var person = new Person("John", "Doe");
        var address = new Address("123 Main St", "Anytown", "12345");
        Console.WriteLine($"{person.FirstName} {person.LastName}");
        Console.WriteLine($"{address.Street}, {address.City} {address.PostalCode}");
    }
}