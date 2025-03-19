---
title: Compliance libraries in .NET
description: Learn how to use compliance libraries to implement compliance features in .NET applications.
ms.date: 03/18/2025
---

# Compliance libraries in .NET

.NET provides libraries that offer foundational components and abstractions for implementing compliance features, such as data classification and redaction, in .NET applications. These abstractions help developers create and manage data in a standardized way. In this article, you learn how to use the data classification and redaction compliance libraries.

## Data classification

Data classification helps you categorize (or classify) data based on its sensitivity and protection level. The <xref:Microsoft.Extensions.Compliance.Classification.DataClassification> structure lets you label sensitive information and enforce policies based on these labels.

- <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.TaxonomyName?displayProperty=nameWithType>: Identifies the classification system.
- <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.Value?displayProperty=nameWithType>: Represents the specific label within the taxonomy.

In some situations, you might need to specify that data explicitly has no data classification, this is achieved with <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.None?displayProperty=nameWithType>. Similarly, you might need to specify that data classification is unknown—use <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.Unknown?displayProperty=nameWithType> in these cases.

### Install classification package

[.NET CLI](#tab/dotnet-cli):

```console
dotnet add package Microsoft.Extensions.Compliance.Classification
```

[PackageReference](#tab/package-reference):

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Compliance.Classification" Version="[CURRENTVERSION]" />
</ItemGroup>
```

### Create custom classifications

Define custom classifications by creating static members for different types of sensitive data. This gives you a consistent way to label and handle data across your app.

Example:

```csharp
using Microsoft.Extensions.Compliance.Classification;

internal static class MyTaxonomyClassifications
{
    internal static string Name => "MyTaxonomy";

    internal static DataClassification PrivateInformation => new(Name, nameof(PrivateInformation));
    internal static DataClassification CreditCardNumber => new(Name, nameof(CreditCardNumber));
    internal static DataClassification SocialSecurityNumber => new(Name, nameof(SocialSecurityNumber));
}
```

### Create custom classification attributes

Create custom attributes based on your custom classifications. Use these attributes to tag your data with the right classification. Consider the following custom attribute class definition:

```csharp
public sealed class PrivateInformationAttribute : DataClassificationAttribute
{
    public PrivateInformationAttribute()
        : base(MyTaxonomyClassifications.PrivateInformation)
    {
    }
}
```

The preceding code declares a private information attribute, that's a subclass of the <xref:Microsoft.Extensions.Compliance.Classification.DataClassificationAttribute> type. It defines a parameterless constructor and pass the custom <xref:Microsoft.Extensions.Compliance.Classification.DataClassification> to its `base`.

### Bind data classification settings

To bind your data classification settings, use the .NET configuration system. For example, assuming you're using a JSON configuration provider, your _appsettings.json_ could be defined as follows:

```json
{
    "Key": {
        "PhoneNumber": "MyTaxonomy:PrivateInformation",
        "ExampleDictionary": {
            "CreditCard": "MyTaxonomy:CreditCardNumber",
            "SSN": "MyTaxonomy:SocialSecurityNumber"
        }
    }
}
```

Now consider the following options pattern approach, that binds these configuration settings into the `TestOptions` object:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public class TestOptions
{
    public DataClassification? PhoneNumber { get; set; }
    public IDictionary<string, DataClassification> ExampleDictionary { get; set; } = new Dictionary<string, DataClassification>();
}

class Program
{
    static void Main(string[] args)
    {
        // Build configuration from an external json file.
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Setup DI container and bind the configuration section "Key" to TestOptions.
        IServiceCollection services = new ServiceCollection();
        services.Configure<TestOptions>(configuration.GetSection("Key"));

        // Build the service provider.
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Get the bound options.
        TestOptions options = serviceProvider.GetRequiredService<IOptions<TestOptions>>().Value;

        // Simple output demonstrating binding results.
        Console.WriteLine("Configuration bound to TestOptions:");
        Console.WriteLine($"PhoneNumber: {options.PhoneNumber}");
        foreach (var item in options.ExampleDictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
```

## Redaction

Redactors replace or mask sensitive data. They help you protect sensitive information from being leaked in logs, error messages, or other outputs.

### Install redaction package

[.NET CLI](#tab/dotnet-cli):

```console
dotnet add package Microsoft.Extensions.Compliance.Redaction
```

[PackageReference](#tab/package-reference):

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Compliance.Redaction" Version="[CURRENTVERSION]"/>
</ItemGroup>
```

To create a custom redactor, define a subclass that inherits from <xref:Microsoft.Extensions.Compliance.Redaction.Redactor>:

Create a redactor by inheriting from <xref:Microsoft.Extensions.Compliance.Redaction.Redactor>:

```csharp
public sealed class StarRedactor : Redactor

public class StarRedactor : Redactor
{
    private const string Stars = "****";

    public override int GetRedactedLength(ReadOnlySpan<char> input) => Stars.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        Stars.CopyTo(destination);
        return Stars.Length;
    }

### Create a custom redactor provider

The <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> interface provides instances of redactors based on data classification. To create a custom redactor provider, inherit from <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> as shown in the following example:
```

### Redactor provider

The <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> interface provides instances of redactors based on data classification.

Create a redactor provider by inheriting from <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider>:

```csharp
using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;

public sealed class StarRedactorProvider : IRedactorProvider
{
    private static readonly StarRedactor _starRedactor = new();

    public static StarRedactorProvider Instance { get; } = new();

    public Redactor GetRedactor(DataClassificationSet classifications) => _starRedactor;
}
```

For more information about .NET's data redaction library, check [.NET Data Redaction](data-redaction.md)
