using Microsoft.Extensions.Options;

namespace Project;

public class ResultBuilder
{
    public static void Main()
    {
        // <BuildResults>
        ValidateOptionsResultBuilder builder = new();
        builder.AddError("Error: invalid operation code");
        builder.AddResult(ValidateOptionsResult.Fail("Invalid request parameters"));
        builder.AddError("Malformed link", "Url");

        // Build ValidateOptionsResult object has accumulating multiple errors.
        ValidateOptionsResult result = builder.Build();

        // Reset the builder to allow using it in new validation operation.
        builder.Clear();
        // </BuildResults>
    }
}
