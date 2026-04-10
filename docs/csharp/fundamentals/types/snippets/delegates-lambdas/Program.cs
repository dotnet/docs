namespace DelegatesLambdasSample;

public sealed class MessagePublisher
{
    public event EventHandler<string>? MessagePublished;

    public void Publish(string message) => MessagePublished?.Invoke(this, message);
}

public static class Program
{
    public static void Main()
    {
        ShowFuncAndAction();
        ShowLambdaAsArgument();
        ShowStaticLambda();
        ShowDiscardParameters();
        ShowMinimalEventIntro();
    }

    private static void ShowFuncAndAction()
    {
        // <FuncAndAction>
        Func<int, int, int> add = (left, right) => left + right;
        Action<string> report = message => Console.WriteLine($"Report: {message}");

        int total = add(5, 9);
        report($"5 + 9 = {total}");
        // </FuncAndAction>
    }

    private static void ShowLambdaAsArgument()
    {
        // <LambdaAsArgument>
        int[] numbers = [1, 2, 3, 4, 5, 6];
        int[] evenNumbers = Filter(numbers, value => value % 2 == 0).ToArray();

        Console.WriteLine(string.Join(", ", evenNumbers));
        // </LambdaAsArgument>
    }

    private static IEnumerable<int> Filter(IEnumerable<int> source, Func<int, bool> predicate)
    {
        foreach (int value in source)
        {
            if (predicate(value))
            {
                yield return value;
            }
        }
    }

    private static void ShowStaticLambda()
    {
        // <StaticLambda>
        Func<int, bool> isEven = static value => value % 2 == 0;

        Console.WriteLine(isEven(14));
        Console.WriteLine(isEven(15));
        // </StaticLambda>
    }

    private static void ShowDiscardParameters()
    {
        // <DiscardParameters>
        Action<int, int, string> statusUpdate = (_, _, message) => Console.WriteLine(message);
        statusUpdate(200, 42, "Operation completed");
        // </DiscardParameters>
    }

    private static void ShowMinimalEventIntro()
    {
        // <MinimalEventIntro>
        MessagePublisher publisher = new();
        publisher.MessagePublished += (_, message) => Console.WriteLine($"Received: {message}");

        publisher.Publish("Records updated");
        // </MinimalEventIntro>
    }
}
