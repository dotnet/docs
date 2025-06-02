---
title: Data redaction in .NET
description: Learn how to use .NET data redaction libraries to protect your application's sensitive data.
ms.date: 03/21/2025
---

# Data redaction in .NET

Redaction helps you sanitize or mask sensitive information in logs, error messages, or other outputs. This keeps you compliant with privacy rules and protects sensitive data. It's useful in apps that handle personal data, financial information, or other confidential data points.

## Install redaction package

To get started, install the [📦 Microsoft.Extensions.Compliance.Redaction](https://www.nuget.org/packages/Microsoft.Extensions.Compliance.Redaction) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Compliance.Redaction
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.Extensions.Compliance.Redaction
```

### [PackageReference](#tab/package-reference)

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Compliance.Redaction"
                    Version="*" />
</ItemGroup>
```

---

## Available redactors

Redactors are responsible for the act of redacting sensitive data. They redact, replace, or mask sensitive information. Consider the following available redactors provided by the library:

- The <xref:Microsoft.Extensions.Compliance.Redaction.ErasingRedactor> replaces any input with an empty string.
- The <xref:Microsoft.Extensions.Compliance.Redaction.HmacRedactor> uses `HMACSHA256` to encode data being redacted.

## Usage example

To use the built-in redactors, you have to register the required services. Register the services using one of the available `AddRedaction` methods as described in the following list:

- <xref:Microsoft.Extensions.DependencyInjection.RedactionServiceCollectionExtensions.AddRedaction(Microsoft.Extensions.DependencyInjection.IServiceCollection)>: Registers an implementation of <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> in the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.
- <xref:Microsoft.Extensions.DependencyInjection.RedactionServiceCollectionExtensions.AddRedaction(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.Compliance.Redaction.IRedactionBuilder})>: Registers an implementation of <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> in the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> and configures available redactors with the given `configure` delegate.

### Configure a redactor

Fetch redactors at runtime using an <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider>. You can implement your own provider and register it inside the `AddRedaction` call, or use the default provider. Configure redactors using these <xref:Microsoft.Extensions.Compliance.Redaction.IRedactionBuilder> methods:

```csharp
// This will use the default redactor, which is the ErasingRedactor
var serviceCollection = new ServiceCollection();
serviceCollection.AddRedaction();

// Using the default redactor provider:
serviceCollection.AddRedaction(redactionBuilder =>
{
    // Assign a redactor to use for a set of data classifications.
    redactionBuilder.SetRedactor<StarRedactor>(
        MyTaxonomyClassifications.Private,
        MyTaxonomyClassifications.Personal);
    // Assign a fallback redactor to use when processing classified data for which no specific redactor has been registered.
    // The `ErasingRedactor` is the default fallback redactor. If no redactor is configured for a data classification then the data will be erased.
    redactionBuilder.SetFallbackRedactor<MyFallbackRedactor>();
});

// Using a custom redactor provider:
builder.Services.AddSingleton<IRedactorProvider, StarRedactorProvider>();
```

Given this data classification in your code:

```csharp
public static class MyTaxonomyClassifications
{
    public static string Name => "MyTaxonomy";

    public static DataClassification Private => new(Name, nameof(Private));
    public static DataClassification Public => new(Name, nameof(Public));
    public static DataClassification Personal => new(Name, nameof(Personal));
}
```

### Configure the HMAC redactor

Configure the HMAC redactor using these <xref:Microsoft.Extensions.Compliance.Redaction.IRedactionBuilder> methods:

```csharp
var serviceCollection = new ServiceCollection();
serviceCollection.AddRedaction(builder =>
{
    builder.SetHmacRedactor(
        options =>
        {
            options.KeyId = 1234567890;
            options.Key = Convert.ToBase64String("1234567890abcdefghijklmnopqrstuvwxyz");
        },

        // Any data tagged with Personal or Private attributes will be redacted by the Hmac redactor.
        MyTaxonomyClassifications.Personal, MyTaxonomyClassifications.Private,

        // "DataClassificationSet" lets you compose multiple data classifications:
        // For example, here the Hmac redactor will be used for data tagged
        // with BOTH Personal and Private (but not one without the other).
        new DataClassificationSet(MyTaxonomyClassifications.Personal,
                                  MyTaxonomyClassifications.Private));
});
```

Alternatively, configure it this way:

```csharp
var serviceCollection = new ServiceCollection();
serviceCollection.AddRedaction(builder =>
{
    builder.SetHmacRedactor(
        Configuration.GetSection("HmacRedactorOptions"), MyTaxonomyClassifications.Personal);
});
```

Include this section in your JSON config file:

```json
{
    "HmacRedactorOptions": {
        "KeyId": 1234567890,
        "Key": "1234567890abcdefghijklmnopqrstuvwxyz"
    }
}
```

- The <xref:Microsoft.Extensions.Compliance.Redaction.HmacRedactorOptions> requires its <xref:Microsoft.Extensions.Compliance.Redaction.HmacRedactorOptions.Key?displayProperty=nameWithType> and <xref:Microsoft.Extensions.Compliance.Redaction.HmacRedactorOptions.KeyId?displayProperty=nameWithType> properties to be set.
- The `Key` should be in base 64 format and at least 44 characters long. Use a distinct key for each major deployment of a service. Keep the key material secret and rotate it regularly.
- The `KeyId` is appended to each redacted value to identify the key used to hash the data.
- Different key IDs mean the values are unrelated and can't be used for correlation.

> [!NOTE]
> The <xref:Microsoft.Extensions.Compliance.Redaction.HmacRedactor> is still experimental, so the preceding methods will cause the `EXTEXP0002` warningm indicating it's not yet stable.
> To use it, add `<NoWarn>$(NoWarn);EXTEXP0002</NoWarn>` to your project file or add `#pragma warning disable EXTEXP0002` around the calls to `SetHmacRedactor`.

### Configure a custom redactor

To create a custom redactor, define a subclass that inherits from <xref:Microsoft.Extensions.Compliance.Redaction.Redactor>:

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
}
```

### Create a custom redactor provider

The <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> interface provides instances of redactors based on data classification. To create a custom redactor provider, inherit from <xref:Microsoft.Extensions.Compliance.Redaction.IRedactorProvider> as shown in the following example:

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

## Logging sensitive information

Logging is a common source of accidental data exposure. Sensitive information such as personal data, credentials, or financial details should never be written to logs in plain text. To prevent this, always use redaction when logging potentially sensitive data.

### Steps for logging sensitive data

1. **Install logging extensions package**: Install [Microsoft.Extensions.Telemetry](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry) to be able to use the extended logger to enable redaction feature.
2. **Set up redaction**: Integrate redactors with your logging pipeline by calling the <xref:Microsoft.Extensions.DependencyInjection.RedactionServiceCollectionExtensions.AddRedaction(Microsoft.Extensions.DependencyInjection.IServiceCollection)> method, to automatically sanitize or mask sensitive fields before they are written to logs.
3. **Identify sensitive fields**: Know which data in your application is sensitive and requires protection, and mark them with appropriate data classification.
4. **Review log output**: Regularly audit your logs to ensure no sensitive data is exposed.

### Example: Redacting data in logs

When using Microsoft.Extensions.Logging, you can combine redaction with logging as follows:

```csharp
using Microsoft.Extensions.Telemetry;
using Microsoft.Extensions.Compliance.Redaction;

var services = new ServiceCollection();
services.AddLogging(builder =>
{
    // Enable redaction.
    builder.EnableRedaction();
});

services.AddRedaction(builder =>
{
    builder.SetRedactor<StarRedactor>(MyTaxonomyClassifications.Private);
});

// Use StarRedactor to redact SSN data.
[LoggerMessage(0, LogLevel.Information, "User SSN: {SSN}")]
public static partial void LogPrivateInformation(
    this ILogger logger,
    [MyTaxonomyClassifications.Private] string SSN);

public void TestLogging()
{
    LogPrivateInformation("MySSN");
}
```

The output should be like this:

`User SSN: *****`

This ensures that sensitive data is redacted before being logged, reducing the risk of data leaks.
