---
title: How to use middleware in System.CommandLine
description: "Learn how to use middleware for the System.Commandline library."
ms.date: 02/03/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to use middleware in System.CommandLine

This article explains how to work with middleware in command-line apps that are built with the `System.CommandLine` library.

## Introduction to middleware

While each command has a handler that `System.CommandLine` will route to based on input, there is also a mechanism for short-circuiting or altering the input before your application logic is invoked. In between parsing and invocation, there is a chain of responsibility, which you can customize. A number of built-in features of `System.CommandLine` make use of this capability. This is how the `--help` and `--version` options short-circuit calls to your handler.

Each call in the pipeline can take action based on the `ParseResult` and return early, or choose to call the next item in the pipeline. The `ParseResult` can even be replaced during this phase. The last call in the chain is the handler for the specified command.

## Add to the middleware pipeline

You can add a call to this pipeline by calling `CommandLineBuilder.AddMiddleware.` Here's an example of code that enables a custom [directive](syntax.md#directives). After creating a root command named `rootCommand`, the code as usual adds options, arguments, and handlers. Then the middleware is added:

:::code language="csharp" source="snippets/use-middleware/csharp/Program.cs" id="middleware" :::

In the preceding code, the middleware writes out "Hi!" if the directive `[just-say-hi]` is found in the parse result. When this happens, because the provided `next` delegate isn't called, the command's normal handler isn't invoked.

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
