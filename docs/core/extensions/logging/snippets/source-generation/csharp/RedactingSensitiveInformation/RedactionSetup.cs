using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RedactingSensitiveInformation;

// MyTaxonomyClassifications.Private serves two roles:
// - As a DataClassification value passed to SetRedactor().
// - As [MyTaxonomyClassifications.Private] on logging parameters, resolved via the
//   nested PrivateAttribute class (C# drops the "Attribute" suffix in attribute syntax).
public static class MyTaxonomyClassifications
{
    private static string Name => "MyTaxonomy";

    public static DataClassification Private { get; } = new(Name, nameof(Private));

    // Accessible as [MyTaxonomyClassifications.Private] due to C# attribute name convention.
    public sealed class PrivateAttribute : DataClassificationAttribute
    {
        public PrivateAttribute() : base(MyTaxonomyClassifications.Private) { }
    }
}

public sealed class StarRedactor : Redactor
{
    private const string Stars = "*****";

    public override int GetRedactedLength(ReadOnlySpan<char> input) => Stars.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        Stars.CopyTo(destination);
        return Stars.Length;
    }
}

// <LogPrivateInformation>
public static partial class LogRedactionExample
{
    [LoggerMessage(0, LogLevel.Information, "User SSN: {SSN}")]
    public static partial void LogPrivateInformation(
        this ILogger logger,
        [MyTaxonomyClassifications.Private] string SSN);
}
// </LogPrivateInformation>

public static class RedactionSetupExample
{
    public static void SetupServices()
    {
        // <RedactionSetup>
        var services = new ServiceCollection();
        services.AddLogging(builder =>
        {
            // Enable redaction.
            builder.EnableRedaction();
        });

        services.AddRedaction(builder =>
        {
            // Configure redactors for your data classifications.
            builder.SetRedactor<StarRedactor>(MyTaxonomyClassifications.Private);
        });
        // </RedactionSetup>
    }
}
