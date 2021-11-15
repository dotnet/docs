---
title: "Breaking change: AddProvider validates provider isn't null"
description: Learn about the .NET 6 breaking change in .NET extensions where AddProvider now validates that the provider argument is not null.
ms.date: 11/05/2021
---
# AddProvider checks for non-null provider

<xref:Microsoft.Extensions.Logging.LoggerFactory?displayProperty=fullName> implements <xref:Microsoft.Extensions.Logging.ILoggerFactory> with an `AddProvider(ILoggerProvider)` method. `null` providers aren't accepted and will cause an <xref:System.ArgumentNullException> to be thrown.

## Version introduced

6.0 RC 1

## Previous behavior

Previously, <xref:Microsoft.Extensions.Logging.LoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)> did not perform any validation of the `provider` argument. As such, the method considered `null` to be a "valid" provider and added it to the collection of providers.

## New behavior

Starting in .NET 6, `null` providers aren't accepted, and <xref:Microsoft.Extensions.Logging.LoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)> throws an <xref:System.ArgumentNullException> if the logging provider argument is `null`. For example, the following code throws an <xref:System.ArgumentNullException>:

```csharp
var factory = new LoggerFactory();
((ILoggerFactory)factory).AddProvider(null));
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The previous behavior caused some operations inside the class to unnecessarily throw <xref:System.NullReferenceException> exceptions. For example, the <xref:Microsoft.Extensions.Logging.LoggerFactory.Dispose?displayProperty=nameWithType> method will capture the exception and do nothing.

## Recommended action

Ensure you're not passing a `null` provider to <xref:Microsoft.Extensions.Logging.LoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)>.

## Affected APIs

- <xref:Microsoft.Extensions.Logging.LoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)?displayProperty=fullName>
