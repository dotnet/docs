---
title: How to use middleware in System.CommandLine
description: "Learn how to use middleware for the System.CommandLine library."
ms.date: 04/07/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to use middleware in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

This article explains how to work with middleware in command-line apps that are built with the `System.CommandLine` library. Use of middleware is an advanced topic that most `System.CommandLine` users won't need to consider.

## Introduction to middleware

While each command has a handler that `System.CommandLine` will route to based on input, there's also a mechanism for short-circuiting or altering the input before your application logic is invoked. In between parsing and invocation, there's a chain of responsibility, which you can customize. A number of built-in features of `System.CommandLine` make use of this capability. This is how the `--help` and `--version` options short-circuit calls to your handler.

Each call in the pipeline can take action based on the <xref:System.CommandLine.Parsing.ParseResult> and return early, or choose to call the next item in the pipeline. The `ParseResult` can even be replaced during this phase. The last call in the chain is the handler for the specified command.

## Add to the middleware pipeline

You can add a call to this pipeline by calling <xref:System.CommandLine.Builder.CommandLineBuilderExtensions.AddMiddleware%2A?displayProperty=nameWithType>. Here's an example of code that enables a custom [directive](syntax.md#directives). After creating a root command named `rootCommand`, the code as usual adds options, arguments, and handlers. Then the middleware is added:

:::code language="csharp" source="snippets/use-middleware/csharp/Program.cs" id="middleware" :::

In the preceding code, the middleware writes out "Hi!" if the directive `[just-say-hi]` is found in the parse result. When this happens, the command's normal handler isn't invoked. It isn't invoked because the middleware doesn't call the `next` delegate.

In the example, `context` is <xref:System.CommandLine.Invocation.InvocationContext>, a singleton structure that acts as the "root" of the entire command-handling process. This is the most powerful structure in `System.CommandLine`, in terms of capabilities. There are two main uses for it in middleware:

* It provides access to the <xref:System.CommandLine.Binding.BindingContext>, <xref:System.CommandLine.Parsing.ParseResult.Parser>, <xref:System.CommandLine.Invocation.InvocationContext.Console>, and <xref:System.CommandLine.Help.HelpBuilder> to retrieve dependencies that a middleware requires for its custom logic.
* You can set the <xref:System.CommandLine.Invocation.InvocationContext.InvocationResult> or <xref:System.CommandLine.Invocation.InvocationContext.ExitCode> properties in order to terminate command processing in a short-circuiting manner. An example is the `--help` option, which is implemented in this manner.

Here's the complete program, including required `using` directives.

:::code language="csharp" source="snippets/use-middleware/csharp/Program.cs" id="all" :::

Here's an example command line and resulting output from the preceding code:

```console
myapp [just-say-hi] --delay 42 --message "Hello world!"
```

```output
Hi!
```

## See also

[System.CommandLine overview](index.md)
