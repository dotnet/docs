---
title: "Primitives: the extensions library for .NET"
description: Learn about the various primitive types from the Microsoft.Extensions.Primitives library.
author: IEvangelist
ms.author: dapine
ms.date: 10/20/2021
---

# Primitives: the extensions library for .NET

In this article, you'll learn about the [`Microsoft.Extensions.Primitives`](/dotnet/api/microsoft.extensions.primitives) library. The primitives in this article are *not* to be confused with .NET primitive types from the BCL, or that of the C# language. Instead, the types within the primitives library serve as building blocks for some of the peripheral .NET NuGet packages such as:

- [`Microsoft.Extensions.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration)
- [`Microsoft.Extensions.Configuration.FileExtensions`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions)
- [`Microsoft.Extensions.FileProviders.Composite`](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Composite)
- [`Microsoft.Extensions.FileProviders.Physical`](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Physical)
- [`Microsoft.Extensions.Logging.EventSource`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventSource)
- [`Microsoft.Extensions.Options`](https://www.nuget.org/packages/Microsoft.Extensions.Options)
- [`System.Text.Json`](https://www.nuget.org/packages/System.Text.Json)

## Change notifications

Propagating notifications when a change occurs is a fundamental concept in programming. The observed state of an object more often than not, has the ability to change. When change occurs, implementations of the <xref:Microsoft.Extensions.Primitives.IChangeToken?displayProperty=fullName> interface can be used to notify interested parties of said change. The implementations available are as follows:

- <xref:Microsoft.Extensions.Primitives.CancellationChangeToken>
- <xref:Microsoft.Extensions.Primitives.CompositeChangeToken>

As a developer, you're also free to implement your own. The <xref:Microsoft.Extensions.Primitives.IChangeToken> interface defines a few properties:

- <xref:Microsoft.Extensions.Primitives.IChangeToken.HasChanged?displayProperty=nameWithType>: Gets a value that indicates if a change has occurred.
- <xref:Microsoft.Extensions.Primitives.IChangeToken.ActiveChangeCallbacks?displayProperty=nameWithType>: Indicates if the token will proactively raise callbacks. If `false`, the token consumer must poll `HasChanged` to detect changes.

Consider the following example usage of the `CancellationChangeToken`:

:::code source="./snippets/primitives/change/Example.Cancellation.cs" id="Cancellation":::

In the preceding example, a <xref:System.Threading.CancellationTokenSource> is instantiated and it's <xref:System.Threading.CancellationTokenSource.Token%2A> is passed to the <xref:Microsoft.Extensions.Primitives.CancellationChangeToken.%23ctor%2A> constructor. The initial state of `HasChanged` is written to the console. An `Action<object?> callback` is created that writes when the callback is invoked to the console. The token's <xref:Microsoft.Extensions.Primitives.CancellationChangeToken.RegisterChangeCallback(System.Action{System.Object},System.Object)> method is called, given the `callback`. Within the `using` the `cancellationTokenSource` is cancelled. This triggers the callback, and the state of `HasChanged` is again written to the console.

## See also

- [Options pattern in .NET](options.md)
- [Configuration in .NET](configuration.md)
- [Logging providers in .NET](logging-providers.md)
