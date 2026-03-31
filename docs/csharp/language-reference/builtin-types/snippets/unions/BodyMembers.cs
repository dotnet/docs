// <BodyMembers>
public union OneOrMore<T>(T, IEnumerable<T>)
{
    public IEnumerable<T> AsEnumerable() => Value switch
    {
        T single => [single],
        IEnumerable<T> multiple => multiple,
        _ => []
    };
}
// </BodyMembers>

public static class BodyMembersScenario
{
    public static void Run()
    {
        BodyMembersExample();
    }

    // <BodyMembersExample>
    static void BodyMembersExample()
    {
        OneOrMore<string> single = "hello";
        OneOrMore<string> multiple = new[] { "a", "b", "c" }.AsEnumerable();

        Console.WriteLine(string.Join(", ", single.AsEnumerable())); // output: hello
        Console.WriteLine(string.Join(", ", multiple.AsEnumerable())); // output: a, b, c
    }
    // </BodyMembersExample>
}
