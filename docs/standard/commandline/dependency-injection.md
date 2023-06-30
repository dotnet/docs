---
title: How to configure dependency injection in System.CommandLine
description: "Learn how to configure dependency injection in System.CommandLine."
ms.date: 05/22/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to configure dependency injection in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

Use a [custom binder](model-binding.md#parameter-binding-more-than-16-options-and-arguments) to inject custom types into a command handler.

We recommend handler-specific dependency injection (DI) for the following reasons:

* Command-line apps are often short-lived processes, in which startup cost can have a noticeable impact on performance. Optimizing performance is particularly important when tab completions have to be calculated. Command-line apps are unlike Web and GUI apps, which tend to be relatively long-lived processes. Unnecessary startup time is not appropriate for short-lived processes.
* When a command-line app that has multiple subcommands is run, only one of those subcommands will be executed. If an app configures dependencies for the subcommands that don't run, it needlessly degrades performance.

To configure DI, create a class that derives from <xref:System.CommandLine.Binding.BinderBase%601> where `T` is the interface that you want to inject an instance for. In the <xref:System.CommandLine.Binding.BinderBase%601.GetBoundValue%2A> method override, get and return the instance you want to inject. The following example injects the default logger implementation for <xref:Microsoft.Extensions.Logging.ILogger>:

:::code language="csharp" source="snippets/dependency-injection/csharp/Program.cs" id="binderclass" :::

When calling the <xref:System.CommandLine.Handler.SetHandler%2A> method, pass to the lambda an instance of the injected class and pass an instance of your binder class in the list of services:

:::code language="csharp" source="snippets/dependency-injection/csharp/Program.cs" id="sethandler" :::

The following code is a complete program that contains the preceding examples:

:::code language="csharp" source="snippets/dependency-injection/csharp/Program.cs" id="all" :::

## See also

[System.CommandLine overview](index.md)
