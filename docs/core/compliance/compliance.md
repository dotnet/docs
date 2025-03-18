---
title: Compliance
description: Learn how to use compliance libraries to implement compliance features in .NET applications.
ms.date: 03/18/2025
---

# Compliance

The <xref:Microsoft.Extensions.Compliance.Abstractions> library provides foundational components and abstractions for implementing compliance features, such as data classification and redaction, in .NET applications. These abstractions help developers create and manage data in a standardized way.

## Install the package

From the command line:

```console
dotnet add package Microsoft.Extensions.Compliance.Abstractions
```

Or directly in the C# project file:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Compliance.Abstractions" Version="[CURRENTVERSION]" />
</ItemGroup>
```

## Data classification

Data classification helps you categorize data based on its sensitivity and protection level. The `DataClassification` structure lets you label sensitive info and enforce policies based on these labels.

- **Taxonomy Name:** Identifies the classification system.
- **Value:** Represents the specific label within the taxonomy.

### Create custom classifications

Define custom classifications by creating static members for different types of sensitive data. This gives you a consistent way to label and handle data across your app.

Example:

```csharp
using Microsoft.Extensions.Compliance.Classification;

public static class MyTaxonomyClassifications
{
    public static string Name => "MyTaxonomy";

    public static DataClassification PrivateInformation => new DataClassification(Name, nameof(PrivateInformation));
    public static DataClassification CreditCardNumber => new DataClassification(Name, nameof(CreditCardNumber));
    public static DataClassification SocialSecurityNumber => new DataClassification(Name, nameof(SocialSecurityNumber));
}
```

### Create custom attributes

Create custom attributes based on your custom classifications. Use these attributes to tag your data with the right classification.

Example:

```csharp
public sealed class PrivateInformationAttribute : DataClassificationAttribute
{
    public PrivateInformationAttribute()
        : base(MyTaxonomyClassifications.PrivateInformation)
    {
    }
}
```

### Bind data classification settings

Bind data classification settings from your configuration using the options pattern. In your `appsettings.json`, add:

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

Example code:

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

Redactors replace or mask sensitive data. They help you protect sensitive info in logs, error messages, or other outputs.

### Redactor

Create a redactor by inheriting from <xref:Microsoft.Extensions.Compliance.Redaction.Redactor>:

```csharp
using Microsoft.Extensions.Compliance.Redaction;

public class StarRedactor : Redactor
{
    private const string Stars = "****";

    public override int GetRedactedLength(ReadOnlySpan<char> input) => Stars.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        Stars.CopyTo(destination);
        return Stars.Length;
    }
}
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

If you need to use .NET's data redaction library, check [.NET Data Redaction](xref:data-redaction.md)
