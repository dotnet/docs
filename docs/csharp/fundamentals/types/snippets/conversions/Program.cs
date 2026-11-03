namespace ConversionsSample;

public interface INamed
{
    string Name { get; }
}

public class Animal;
public class Mammal : Animal, INamed
{
    public string Name { get; init; } = "Mammal";
}

public class Reptile : Animal;

public interface ILabelled
{
    string Label { get; }
}

public readonly struct Packet(int id) : ILabelled
{
    public int Id { get; } = id;
    public string Label => $"P-{Id}";
}

public static class Program
{
    public static void Main()
    {
        ShowNumericConversions();
        ShowReferenceConversions();
        ShowAsOperator();
        ShowBoxingAndUnboxing();
        ShowParseAndTryParse();
    }

    private static void ShowNumericConversions()
    {
        // <ImplicitAndExplicitNumeric>
        int itemCount = 42;
        long widened = itemCount; // Implicit conversion.

        double average = 19.75;
        int truncated = (int)average; // Explicit cast.

        Console.WriteLine($"widened: {widened}, truncated: {truncated}");
        // </ImplicitAndExplicitNumeric>
    }

    private static void ShowReferenceConversions()
    {
        // <ImplicitReferenceConversions>
        Mammal otter = new() { Name = "River otter" };
        Animal animal = otter;           // Derived to base class: always safe.
        INamed named = otter;            // Reference type to implemented interface: always safe.
        object obj = otter;              // Any reference type to object: always safe.

        Console.WriteLine(named.Name);
        // </ImplicitReferenceConversions>

        // <ExplicitReferenceConversions>
        Animal knownAnimal = new Mammal { Name = "River otter" };

        if (knownAnimal is Mammal mammal)
        {
            Console.WriteLine($"Pattern match succeeded: {mammal.Name}");
        }

        Animal unknownAnimal = new Reptile();
        Console.WriteLine($"Can treat as mammal: {unknownAnimal is Mammal}");
        // </ExplicitReferenceConversions>
    }

    private static void ShowAsOperator()
    {
        // <AsOperator>
        object boxedMammal = new Mammal { Name = "Sea lion" };
        Mammal? maybeMammal = boxedMammal as Mammal;
        Console.WriteLine(maybeMammal is null ? "Not a mammal" : maybeMammal.Name);

        object boxedReptile = new Reptile();
        Mammal? noMammal = boxedReptile as Mammal;
        Console.WriteLine(noMammal is null ? "Safe null result" : noMammal.Name);
        // </AsOperator>
    }

    private static void ShowBoxingAndUnboxing()
    {
        // <BoxingAndUnboxing>
        int temperature = 72;
        object boxedTemperature = temperature; // Boxing.
        int unboxedTemperature = (int)boxedTemperature; // Unboxing.

        Packet packet = new(7);
        ILabelled labelledPacket = packet; // Boxing through an interface reference.

        Console.WriteLine($"Unboxed: {unboxedTemperature}, Label: {labelledPacket.Label}");
        // </BoxingAndUnboxing>
    }

    private static void ShowParseAndTryParse()
    {
        // <ParseAndTryParse>
        string textValue = "512";
        int parsed = int.Parse(textValue);

        string userInput = "12x";
        bool parsedSuccessfully = int.TryParse(userInput, out int safeValue);

        Console.WriteLine($"parsed: {parsed}");
        Console.WriteLine(parsedSuccessfully ? $"safe value: {safeValue}" : "Input is not a valid number.");
        // </ParseAndTryParse>
    }
}
