// <ValueTypeCases>
public union IntOrString(int, string);
// </ValueTypeCases>

public static class ValueTypeCasesScenario
{
    public static void Run()
    {
        ValueTypeCasesExample();
    }

    // <ValueTypeCasesExample>
    static void ValueTypeCasesExample()
    {
        IntOrString val1 = 42;
        IntOrString val2 = "hello";

        Console.WriteLine(Describe(val1)); // output: int: 42
        Console.WriteLine(Describe(val2)); // output: string: hello

        static string Describe(IntOrString value) => value switch
        {
            int i => $"int: {i}",
            string s => $"string: {s}",
            null => "null",
        };
    }
    // </ValueTypeCasesExample>
}
