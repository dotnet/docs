// <EverydayGenerics>
List<int> scores = [95, 87, 72, 91];
Dictionary<string, decimal> prices = new()
{
    ["Widget"] = 19.99m,
    ["Gadget"] = 29.99m
};
Task<string> greeting = Task.FromResult("Hello, generics!");
Func<int, bool> isPositive = n => n > 0;

Console.WriteLine($"First score: {scores[0]}");
Console.WriteLine($"Widget price: {prices["Widget"]:C}");
Console.WriteLine($"Greeting: {await greeting}");
Console.WriteLine($"Is 5 positive? {isPositive(5)}");
// </EverydayGenerics>

GenericCollectionsExample();
GenericMethodsExample();
CollectionExpressionsExample();
SpreadOperatorExample();
DictionaryExpressionsExample();
DictionarySpreadExample();
ConstraintsExample();
VarianceExample();
CustomGenericExample();

static void GenericCollectionsExample()
{
    // <GenericCollections>
    // A strongly typed list of strings
    List<string> names = ["Alice", "Bob", "Carol"];
    names.Add("Dave");
    // names.Add(42); // Compile-time error: can't add an int to List<string>

    // A dictionary mapping string keys to int values
    var inventory = new Dictionary<string, int>
    {
        ["Apples"] = 50,
        ["Oranges"] = 30
    };
    inventory["Bananas"] = 25;

    // A set that prevents duplicates
    HashSet<int> uniqueIds = [1, 2, 3, 1, 2];
    Console.WriteLine($"Unique count: {uniqueIds.Count}"); // 3

    // A FIFO queue
    Queue<string> tasks = new();
    tasks.Enqueue("Build");
    tasks.Enqueue("Test");
    Console.WriteLine($"Next task: {tasks.Dequeue()}"); // Build
    // </GenericCollections>
}

static void GenericMethodsExample()
{
    // <GenericMethods>
    static void Print<T>(T value) =>
        Console.WriteLine($"Value: {value}");

    Print(42);        // Compiler infers T as int
    Print("hello");   // Compiler infers T as string
    Print(3.14);      // Compiler infers T as double
    // </GenericMethods>
}

static void CollectionExpressionsExample()
{
    // <CollectionExpressions>
    // Create a list with a collection expression
    List<string> fruits = ["Apple", "Banana", "Cherry"];

    // Create an array
    int[] numbers = [1, 2, 3, 4, 5];

    // Works with any supported collection type
    IReadOnlyList<double> temperatures = [72.0, 68.5, 75.3];

    Console.WriteLine($"Fruits: {string.Join(", ", fruits)}");
    Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");
    Console.WriteLine($"Temps: {string.Join(", ", temperatures)}");
    // </CollectionExpressions>
}

static void SpreadOperatorExample()
{
    // <SpreadOperator>
    List<int> first = [1, 2, 3];
    List<int> second = [4, 5, 6];

    // Spread both lists into a new combined list
    List<int> combined = [.. first, .. second];
    Console.WriteLine(string.Join(", ", combined));
    // Output: 1, 2, 3, 4, 5, 6

    // Add extra elements alongside spreads
    List<int> withExtras = [0, .. first, 99, .. second];
    Console.WriteLine(string.Join(", ", withExtras));
    // Output: 0, 1, 2, 3, 99, 4, 5, 6
    // </SpreadOperator>
}

static void DictionaryExpressionsExample()
{
    // <DictionaryExpressions>
    Dictionary<string, int> scores = new()
    {
        ["Alice"] = 95,
        ["Bob"] = 87,
        ["Carol"] = 92
    };

    foreach (var (name, score) in scores)
    {
        Console.WriteLine($"{name}: {score}");
    }
    // </DictionaryExpressions>
}

static void DictionarySpreadExample()
{
    // <DictionarySpread>
    Dictionary<string, int> defaults = new()
    {
        ["Timeout"] = 30,
        ["Retries"] = 3
    };
    Dictionary<string, int> overrides = new()
    {
        ["Timeout"] = 60
    };

    // Merge defaults and overrides into a new dictionary
    Dictionary<string, int> config = new(defaults);
    foreach (var (key, value) in overrides)
    {
        config[key] = value;
    }

    Console.WriteLine($"Timeout: {config["Timeout"]}");  // 60
    Console.WriteLine($"Retries: {config["Retries"]}");   // 3
    // </DictionarySpread>
}

static void ConstraintsExample()
{
    // <BasicConstraints>
    static T Max<T>(T a, T b) where T : IComparable<T> =>
        a.CompareTo(b) >= 0 ? a : b;

    Console.WriteLine(Max(3, 7));          // 7
    Console.WriteLine(Max("apple", "banana")); // banana

    static T CreateDefault<T>() where T : new() => new T();

    var list = CreateDefault<List<int>>(); // Creates an empty List<int>
    Console.WriteLine($"Empty list count: {list.Count}"); // 0
    // </BasicConstraints>
}

static void VarianceExample()
{
    // <Variance>
    // Covariance: IEnumerable<Dog> can be used as IEnumerable<Animal>
    // because IEnumerable<out T> is covariant
    List<Dog> dogs = [new("Rex"), new("Buddy")];
    IEnumerable<Animal> animals = dogs; // Allowed because Dog derives from Animal

    foreach (var animal in animals)
    {
        Console.WriteLine(animal.Name);
    }

    // Contravariance: Action<Animal> can be used as Action<Dog>
    // because Action<in T> is contravariant
    Action<Animal> printAnimal = a => Console.WriteLine($"Animal: {a.Name}");
    Action<Dog> printDog = printAnimal; // Allowed because any Animal handler can handle Dog

    printDog(new Dog("Spot"));
    // </Variance>
}

static void CustomGenericExample()
{
    // <UseCustomGeneric>
    var list = new GenericList<int>();
    for (var i = 0; i < 5; i++)
    {
        list.AddHead(i);
    }

    foreach (var item in list)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
    // Output: 4 3 2 1 0
    // </UseCustomGeneric>
}

// <CustomGeneric>
public class GenericList<T>
{
    private class Node(T data)
    {
        public T Data { get; set; } = data;
        public Node? Next { get; set; }
    }

    private Node? head;

    public void AddHead(T data)
    {
        var node = new Node(data) { Next = head };
        head = node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
// </CustomGeneric>

public record Animal(string Name);
public record Dog(string Name) : Animal(Name);
