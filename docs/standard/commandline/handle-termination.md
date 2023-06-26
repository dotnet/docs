---
title: How to handle termination in System.CommandLine
description: "Learn how to handle termination in apps that are built with the System.Commandline library."
ms.date: 05/24/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to handle termination in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

To handle termination, inject a <xref:System.Threading.CancellationToken> instance into your handler code. This token can then be passed along to async APIs that you call from within your handler, as shown in the following example:

:::code language="csharp" source="snippets/handle-termination/csharp/Program.cs" id="mainandhandler" :::

The preceding code uses a `SetHandler` overload that gets an [InvocationContext](model-binding.md#invocationcontext) instance rather than one or more `IValueDescriptor<T>` objects. The `InvocationContext` is used to get the `CancellationToken` and [ParseResult](model-binding.md#parseresult) objects. `ParseResult` can provide argument or option values.

To test the sample code, run the command with a URL that will take a moment to load, and before it finishes loading, press <kbd>Ctrl</kbd>+<kbd>C</kbd>. On macOS press <kbd>Command</kbd>+<kbd>Period(.)</kbd>. For example:

```dotnetcli
testapp --url https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis
```

```output
The operation was aborted
```

Cancellation actions can also be added directly using the <xref:System.Threading.CancellationToken.Register%2A?displayProperty=nameWithType> method.

For information about an alternative way to set the process exit code, see [Set exit codes](model-binding.md#set-exit-codes).

## See also

[System.CommandLine overview](index.md)
