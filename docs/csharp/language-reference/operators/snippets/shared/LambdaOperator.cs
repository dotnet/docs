namespace operators;

public static class LambdaOperator
{
    public static void Examples()
    {
        WithInferredTypes();
        WithExplicitTypes();
        WithoutInput();
    }

    private static void WithInferredTypes()
    {
        // <SnippetInferredTypes>
        string[] words = { "bot", "apple", "apricot" };
        int minimalLength = words
          .Where(w => w.StartsWith("a"))
          .Min(w => w.Length);
        Console.WriteLine(minimalLength);   // output: 5

        int[] numbers = { 4, 7, 10 };
        int product = numbers.Aggregate(1, (interim, next) => interim * next);
        Console.WriteLine(product);   // output: 280
        // </SnippetInferredTypes>
    }

    private static void WithExplicitTypes()
    {
        // <SnippetExplicitTypes>
        int[] numbers = { 4, 7, 10 };
        int product = numbers.Aggregate(1, (int interim, int next) => interim * next);
        Console.WriteLine(product);   // output: 280
        // </SnippetExplicitTypes>
    }

    private static void WithoutInput()
    {
        // <SnippetWithoutInput>
        Func<string> greet = () => "Hello, World!";
        Console.WriteLine(greet());
        // </SnippetWithoutInput>
    }
}
