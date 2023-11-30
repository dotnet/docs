public class ExceptionFromAsyncExample
{
    // <ExceptionFromAsync>
    public static async Task Run()
    {
        try
        {
            Task<int> processing = ProcessAsync(-1);
            Console.WriteLine("Launched processing.");

            int result = await processing;
            Console.WriteLine($"Result: {result}.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
        // Output:
        // Launched processing.
        // Processing failed: Input must be non-negative. (Parameter 'input')
    }

    private static async Task<int> ProcessAsync(int input)
    {
        if (input < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Input must be non-negative.");
        }

        await Task.Delay(500);
        return input;
    }
    // </ExceptionFromAsync>
}