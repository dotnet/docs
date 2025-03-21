---
title: Data classification in .NET
description: Learn how to use .NET data classification libraries to categorize your application's data.
ms.date: 03/21/2025
---

# Data classification in .NET

Data classification helps you categorize (or classify) data based on its sensitivity and protection level. The <xref:Microsoft.Extensions.Compliance.Classification.DataClassification> structure lets you label sensitive information and enforce policies based on these labels.

- <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.TaxonomyName?displayProperty=nameWithType>: Identifies the classification system.
- <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.Value?displayProperty=nameWithType>: Represents the specific label within the taxonomy.

In some situations, you might need to specify that data explicitly has no data classification, this is achieved with <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.None?displayProperty=nameWithType>. Similarly, you might need to specify that data classification is unknown—use <xref:Microsoft.Extensions.Compliance.Classification.DataClassification.Unknown?displayProperty=nameWithType> in these cases.

## Install classification package

To get started, install the [📦 Microsoft.Extensions.Compliance.Classification](https://www.nuget.org/packages/Microsoft.Extensions.Compliance.Classification) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Compliance.Classification
```

### [PackageReference](#tab/package-reference)

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Compliance.Classification"
                    Version="*" />
</ItemGroup>
```

---

## Create custom classifications

Define custom classifications by creating `static` members for different types of sensitive data. This gives you a consistent way to label and handle data across your app. Consider the following example class:

```csharp
using Microsoft.Extensions.Compliance.Classification;

internal static class MyTaxonomyClassifications
{
    internal static string Name => "MyTaxonomy";

    internal static DataClassification PrivateInformation => new(Name, nameof(PrivateInformation));
    internal static DataClassification CreditCardNumber => new(Name, nameof(CreditCardNumber));
    internal static DataClassification SocialSecurityNumber => new(Name, nameof(SocialSecurityNumber));

    internal static DataClassificationSet PrivateAndSocialSet => new(PrivateInformation, SocialSecurityNumber);
}
```

If you want to share your custom classification taxonomy with other apps, this class and its members should be `public` instead of `internal`. For example, you can have a shared library containing custom classifications, that you can use in multiple applications.

<xref:Microsoft.Extensions.Compliance.Classification.DataClassificationSet> lets you compose multiple data classifications into a single set. This allows you classify your data with multiple data classifications. In addition, the .NET redaction APIs make use of a <xref:Microsoft.Extensions.Compliance.Classification.DataClassificationSet>.

## Create custom classification attributes

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

## Bind data classification settings

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
