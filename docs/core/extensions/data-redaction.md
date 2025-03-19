---
title: Data redaction in .NET
description: Learn how to use .NET data redaction libraries to protect your application's sensitive data.
ms.date: 03/17/2025
---

# Data redaction in .NET

Redaction helps you sanitize or mask sensitive information in logs, error messages, or other outputs. This keeps you compliant with privacy rules and protects sensitive data. It's useful in apps that handle personal data, financial information, or other confidential data points.

## Install redaction package

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Compliance.Redaction
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
    redactionBuilder.SetRedactor<MyRedactor>(MyTaxonomy.Private, MyTaxonomy.Personal);
    // Assign a fallback redactor to use when processing classified data for which no specific redactor has been registered.
    // The `ErasingRedactor` is the default fallback redactor. If no redactor is configured for a data classification then the data will be erased.
    redactionBuilder.SetFallbackRedactor<MyFallbackRedactor>();
});

// Using a custom redactor provider:
builder.Services.AddSingleton<IRedactorProvider, MyRedactorProvider>();
```

Given this data classification in your code:

```csharp
using Microsoft.Extensions.Compliance.Classification;

public static class MyTaxonomy
{
    public static string Name => "MyTaxonomy";

    public static DataClassification Private => new(Name, nameof(Private));
    public static DataClassification Public => new(Name, nameof(Public));
    public static DataClassification Personal => new(Name, nameof(Personal));
}
```

### Configure the HMAC redactor

Configure the HMAC redactor using these `IRedactionBuilder` methods:

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
        MyTaxonomy.Personal, MyTaxonomy.Private,

        // "DataClassificationSet" lets you compose multiple data classifications:
        // For example, here the Hmac redactor will be used for data tagged
        // with BOTH Personal and Private (but not one without the other).
        new DataClassificationSet(MyTaxonomy.Personal, MyTaxonomy.Private));
});
```

Alternatively, configure it this way:

```csharp
var serviceCollection = new ServiceCollection();
serviceCollection.AddRedaction(builder =>
{
    builder.SetHmacRedactor(
        Configuration.GetSection("HmacRedactorOptions"), MyTaxonomy.Personal);
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
