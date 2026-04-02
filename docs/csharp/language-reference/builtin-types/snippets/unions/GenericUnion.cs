// <GenericUnion>
public record class None;
public record class Some<T>(T Value);
public union Option<T>(None, Some<T>);
// </GenericUnion>

public static class GenericUnionScenario
{
    public static void Run()
    {
        GenericUnionExample();
    }

    // <GenericUnionExample>
    static void GenericUnionExample()
    {
        Option<int> some = new Some<int>(42);
        Option<int> none = new None();

        var result = some switch
        {
            Some<int> s => $"Has value: {s.Value}",
            None => "No value",
        };
        Console.WriteLine(result); // output: Has value: 42

        var result2 = none switch
        {
            Some<int> s => $"Has value: {s.Value}",
            None => "No value",
        };
        Console.WriteLine(result2); // output: No value
    }
    // </GenericUnionExample>
}
