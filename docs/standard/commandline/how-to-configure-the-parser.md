---
title: How to configure the parser in System.CommandLine
description: "Learn how to configure the parser in System.CommandLine."
ms.date: 06/19/2025
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---

# How to configure the parser in System.CommandLine

[!INCLUDE [scl-preview](./includes/preview.md)]

Parsing and invocation are two separate steps, so each of them has their own configuration:

- <xref:System.CommandLine.ParserConfiguration> is a class that provides properties to configure the parsing. It is an optional argument for every `Parse` method, such as <xref:System.CommandLine.Command.Parse*?displayProperty=nameWithType> and <xref:System.CommandLine.Parsing.CommandLineParser.Parse*?displayProperty=nameWithType>.
- <xref:System.CommandLine.InvocationConfiguration> is a class that provides properties to configure the invocation. It is an optional argument of the <xref:System.CommandLine.ParseResult.Invoke*?displayProperty=nameWithType> and <xref:System.CommandLine.ParseResult.InvokeAsync*?displayProperty=nameWithType> methods.

They are exposed by the <xref:System.CommandLine.ParseResult.Configuration?displayProperty=nameWithType> and <xref:System.CommandLine.ParseResult.InvocationConfiguration?displayProperty=nameWithType> properties. When they aren't provided, the default configurations are used.

## ParserConfiguration

### EnablePosixBundling

[Bundling](syntax.md#option-bundling) of single-character options is enabled by default, but you can disable it by setting the <xref:System.CommandLine.ParserConfiguration.EnablePosixBundling?displayProperty=nameWithType> property to `false`.

### ResponseFileTokenReplacer

[Response files](syntax.md#response-files) are enabled by default, but you can disable them by setting the <xref:System.CommandLine.ParserConfiguration.ResponseFileTokenReplacer> property to `null`. You can also provide a custom implementation to customize how response files are processed.

Response file can contain other response file names, hence parsing may include opening other files. The library expects that all response files were generated and stored by trust worthy agent(s).

## InvocationConfiguration

### Standard output and error

<xref:System.CommandLine.InvocationConfiguration> makes testing, as well as many extensibility scenarios, easier than using `System.Console`. It exposes two `TextWriter` properties: <xref:System.CommandLine.InvocationConfiguration.Output> and <xref:System.CommandLine.InvocationConfiguration.Error>. You can set these properties to any `TextWriter` instance, such as a `StringWriter`, which you can use to capture output for testing.

Define a simple command that writes to standard output:

:::code language="csharp" source="snippets/configuration/csharp/Program.cs" id="rootcommand":::

Now, use <xref:System.CommandLine.InvocationConfiguration> to capture the output:

:::code language="csharp" source="snippets/configuration/csharp/Program.cs" id="captureoutput":::

### ProcessTerminationTimeout

[Process termination timeout](how-to-parse-and-invoke.md#process-termination-timeout) can be configured via the <xref:System.CommandLine.InvocationConfiguration.ProcessTerminationTimeout> property. The default value is 2 seconds.

### EnableDefaultExceptionHandler

By default, all unhandled exceptions thrown during the invocation of a command are caught and reported to the user. You can disable this behavior by setting the <xref:System.CommandLine.InvocationConfiguration.EnableDefaultExceptionHandler> property to `false`. This is useful when you want to handle exceptions in a custom way, such as logging them or providing a different user experience.

### Derived classes

<xref:System.CommandLine.InvocationConfiguration> is not sealed, so you can derive from it to add custom properties or methods. This is useful when you want to provide additional configuration options specific to your application.

## See also

- [System.CommandLine overview](index.md)
