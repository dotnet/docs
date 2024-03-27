using System.Text;

StringBuilder builder = new();
builder.AppendLine("Hello,");
builder.AppendLine("The following arguments are passed:");

Console.WriteLine(builder.ToString());

// Display the command line arguments using the args variable.
foreach (var arg in args)
{
    Console.WriteLine($"Argument={arg}");
}

// Return a success code.
return 0;
