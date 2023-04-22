await ExceptionFromAsyncExample.Run();

static void ProcessShapes(int shapeAmount)
{
    // <Throw>
    if (shapeAmount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(shapeAmount), "Amount of shapes must be positive.");
    }
    // </Throw>
}

static void Rethrow()
{
    var shapeAmount = 3;
    // <Rethrow>
    try
    {
        ProcessShapes(shapeAmount);
    }
    catch (Exception e)
    {
        LogError(e, "Shape processing failed.");
        throw;
    }
    // </Rethrow>
}

static void DisplayFirstNumber(string[] args)
{
    // <ThrowExpressionConditional>
    string first = args.Length >= 1 
        ? args[0]
        : throw new ArgumentException("Please supply at least one argument.");
    // </ThrowExpressionConditional>

    var message = int.TryParse(first, out var number)
        ? $"You entered number {number}."
        : $"{first} is not an integer number.";
    Console.WriteLine(message);
}

// <ThrowExpressionExpressionBody>
DateTime ToDateTime(IFormatProvider provider) =>
         throw new InvalidCastException("Conversion to a DateTime is not supported.");
// </ThrowExpressionExpressionBody>

static void TryCatch()
{
    // <TryCatch>
    try
    {
        var result = Process(-3, 4);
        Console.WriteLine($"Processing succeeded: {result}");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"Processing failed: {e.Message}");
    }
    // </TryCatch>
}

static async Task TryMultipleCatch()
{
    CancellationToken cancellationToken = default;

    // <TryMultipleCatch>
    try
    {
        var result = await ProcessAsync(-3, 4, cancellationToken);
        Console.WriteLine($"Processing succeeded: {result}");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"Processing failed: {e.Message}");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Processing is cancelled.");
    }
    // </TryMultipleCatch>

    async Task<int> ProcessAsync(int a, int b, CancellationToken ct)
    {
        if (a < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), "The first argument cannot be negative.");
        }

        return a / (a + b);
    }
}

static void RethrowInCatch()
{
    // <RethrowInCatch>
    try
    {
        var result = Process(-3, 4);
        Console.WriteLine($"Processing succeeded: {result}");
    }
    catch (Exception e)
    {
        LogError(e, "Processing failed.");
        throw;
    }
    // </RethrowInCatch>
}

static void WhenFilter()
{
    // <WhenFilter>
    try
    {
        var result = Process(-3, 4);
        Console.WriteLine($"Processing succeeded: {result}");
    }
    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
    {
        Console.WriteLine($"Processing failed: {e.Message}");
    }
    // </WhenFilter>
}

static int Process(int a, int b)
{
    if (a < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(a), "The first argument cannot be negative.");
    }
    return a / (a + b);
}

static void LogError(Exception e, string message) {}
