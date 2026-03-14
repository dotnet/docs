var counter = 0;

// If a number is passed as a command-line argument,
// it will be used as the maximum counter value.
var max = args.Length > 0 && int.TryParse(args[0], out var parsedMax)
    ? parsedMax
    : -1;

// Run indefinitely if no max value is provided
while (max == -1 || counter < max)
{
    Console.WriteLine($"Counter: {++counter}");

    // Wait for one second between iterations
    await Task.Delay(TimeSpan.FromSeconds(1));
}
