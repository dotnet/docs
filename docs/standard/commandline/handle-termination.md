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

To handle termination, pass <xref:System.Threading.CancellationToken> instance into your action code. This token can then be passed along to async APIs that you call from within your action, as shown in the following example:

:::code language="csharp" source="snippets/handle-termination/csharp/Program.cs" id="mainandhandler" :::

The preceding code uses a `SetAction` overload that gets a [ParseResult](model-binding.md#parseresult) and a <xref:System.Threading.CancellationToken> rather than  just `ParseResult`.

To test the sample code, run the command with a URL that will take a moment to load, and before it finishes loading, press <kbd>Ctrl</kbd>+<kbd>C</kbd>. On macOS press <kbd>Command</kbd>+<kbd>Period(.)</kbd>. For example:

```dotnetcli
testapp --url https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis
```

```output
The operation was aborted
```

For information about an alternative way to set the process exit code, see [Set exit codes](model-binding.md#set-exit-codes).

## See also

[System.CommandLine overview](index.md)
