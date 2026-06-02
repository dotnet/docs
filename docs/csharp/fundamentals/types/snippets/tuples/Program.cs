// <BasicTuple>
var location = (Latitude: 47.6062, Longitude: -122.3321);
Console.WriteLine($"Location: {location.Latitude}, {location.Longitude}");
// Output: Location: 47.6062, -122.3321
// </BasicTuple>

BasicDeclarations();
InferredNamesExample();
MethodReturnExample();
DeconstructionExamples();
DeconstructionLoopExample();
DiscardsExample();
TupleEqualityExample();
WithExpressionExample();
DictionaryTupleExample();
TupleKeyExample();

static void BasicDeclarations()
{
    // <DeclareTuples>
    // Tuple with named elements
    (string Name, int Age) person = ("Alice", 30);
    Console.WriteLine($"{person.Name} is {person.Age} years old");

    // Tuple with default element names (Item1, Item2)
    (string, int) unnamed = ("Bob", 25);
    Console.WriteLine($"{unnamed.Item1} is {unnamed.Item2} years old");

    // Tuple declared with var and inline names
    var city = (Name: "Seattle", Population: 749_256);
    Console.WriteLine($"{city.Name}: population {city.Population}");
    // </DeclareTuples>
}

static void InferredNamesExample()
{
    // <InferredNames>
    var name = "Carol";
    var age = 28;

    // The compiler infers element names from the variable names
    var person = (name, age);
    Console.WriteLine($"{person.name} is {person.age}");
    // Output: Carol is 28
    // </InferredNames>
}

// <MethodReturn>
static (double Minimum, double Maximum, double Average) ComputeStats(List<double> values)
{
    var min = values.Min();
    var max = values.Max();
    var avg = values.Average();
    return (min, max, avg);
}
// </MethodReturn>

static void MethodReturnExample()
{
    List<double> temperatures = [72.0, 68.5, 75.3, 69.1, 71.8];
    var stats = ComputeStats(temperatures);
    Console.WriteLine($"Min: {stats.Minimum}, Max: {stats.Maximum}, Avg: {stats.Average:F1}");
    // Output: Min: 68.5, Max: 75.3, Avg: 71.3
}

static void DeconstructionExamples()
{
    // <Deconstruction>
    var point = (X: 3, Y: 7);

    // Deconstruct with var (infer all types)
    var (x, y) = point;
    Console.WriteLine($"x={x}, y={y}");

    // Deconstruct with explicit types
    (int px, int py) = point;
    Console.WriteLine($"px={px}, py={py}");

    // Deconstruct into existing variables
    int a, b;
    (a, b) = point;
    Console.WriteLine($"a={a}, b={b}");

    // Deconstruct a method return value directly
    List<double> data = [10.0, 20.0, 30.0];
    var (min, max, avg) = ComputeStats(data);
    Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg}");
    // </Deconstruction>
}

static void DeconstructionLoopExample()
{
    // <DeconstructionLoop>
    List<(string Name, int Score)> results =
    [
        ("Alice", 92),
        ("Bob", 87),
        ("Carol", 95)
    ];

    foreach (var (name, score) in results)
    {
        Console.WriteLine($"{name}: {score}");
    }
    // </DeconstructionLoop>
}

static void DiscardsExample()
{
    // <Discards>
    List<double> values = [5.0, 10.0, 15.0];
    var (_, max, _) = ComputeStats(values);
    Console.WriteLine($"Only need the max: {max}");
    // Output: Only need the max: 15
    // </Discards>
}

static void TupleEqualityExample()
{
    // <TupleEquality>
    var order1 = (Product: "Widget", Quantity: 5);
    var order2 = (Product: "Widget", Quantity: 5);
    var order3 = (Product: "Gadget", Quantity: 3);

    Console.WriteLine(order1 == order2); // True
    Console.WriteLine(order1 == order3); // False

    // Element names don't affect equality—only values matter
    var named = (X: 1, Y: 2);
    var different = (A: 1, B: 2);
    Console.WriteLine(named == different); // True
    // </TupleEquality>
}

static void WithExpressionExample()
{
    // <WithExpression>
    var original = (Name: "Widget", Price: 19.99m, InStock: true);
    var discounted = original with { Price = 14.99m };

    Console.WriteLine($"Original: {original.Name} at {original.Price:C}");
    Console.WriteLine($"Discounted: {discounted.Name} at {discounted.Price:C}");
    // Output:
    // Original: Widget at $19.99
    // Discounted: Widget at $14.99
    // </WithExpression>
}

static void DictionaryTupleExample()
{
    // <DictionaryTuple>
    var sizeChart = new Dictionary<string, (int Min, int Max)>
    {
        ["Small"] = (0, 50),
        ["Medium"] = (51, 100),
        ["Large"] = (101, 200)
    };

    if (sizeChart.TryGetValue("Medium", out var range))
    {
        Console.WriteLine($"Medium: {range.Min}–{range.Max}");
    }
    // Output: Medium: 51–100
    // </DictionaryTuple>
}

static void TupleKeyExample()
{
    // <TupleKey>
    var grid = new Dictionary<(int Row, int Column), string>
    {
        [(0, 0)] = "Origin",
        [(1, 3)] = "Sensor A",
        [(2, 5)] = "Sensor B"
    };

    var target = (Row: 1, Column: 3);
    if (grid.TryGetValue(target, out var label))
    {
        Console.WriteLine($"({target.Row}, {target.Column}): {label}");
    }
    // Output: (1, 3): Sensor A
    // </TupleKey>
}
