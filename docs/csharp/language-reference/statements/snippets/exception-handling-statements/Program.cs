
static int Process(int shapeAmount)
{
    // <Throw>
    if (shapeAmount < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(shapeAmount), "Amount of shapes must be non-negative.");
    }
    // </Throw>

    return shapeAmount;
}

static void Rethrow()
{
    var shapeAmount = 3;
    // <Rethrow>
    try
    {
        Process(shapeAmount);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Processing failed for {shapeAmount}: {e}.");
        throw;
    }
    // <Rethrow>
}

// <ThrowExpressionConditional>
static void DisplayFirstNumber(string[] args)
{
    string arg = args.Length >= 1 
        ? args[0]
        : throw new ArgumentException("Please supply at least one argument.");

    var message = int.TryParse(arg, out var number)
        ? $"You entered number {number}."
        : $"{arg} is not an integer number.";
    Console.WriteLine(message);
}
// </ThrowExpressionConditional>

// <ThrowExpressionExpressionBody>
DateTime ToDateTime(IFormatProvider provider) =>
         throw new InvalidCastException("Conversion to a DateTime is not supported.");
// </ThrowExpressionExpressionBody>
