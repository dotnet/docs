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

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

<xref:System.CommandLine.CommandLineConfiguration> is a class that provides properties to configure the parser. It is an optional argument for every `Parse` method, such as <xref:System.CommandLine.Command.Parse> or <xref:System.CommandLine.Parsing.CommandLineParser.Parse>. When it is not provided, the default configuration is used.

Every <xref:System.CommandLine.ParseResult> instance has a <xref:System.CommandLine.ParseResult.Configuration> property that returns the configuration used for parsing.

## Standard output and error

<xref:System.CommandLine.CommandLineConfiguration> makes testing, as well as many extensibility scenarios, easier than using `System.Console`. It exposes two `TextWriter` properties: `Output` and `Error`. These can be set to any `TextWriter` instance, such as a `StringWriter`, which can be used to capture output for testing.

Let's define a simple command that writes to standard output:

:::code language="csharp" source="snippets/configuration/csharp/Program.cs" id="setaction":::

Now, let's use `CommandLineConfiguration` to capture the output:

:::code language="csharp" source="snippets/configuration/csharp/Program.cs" id="captureoutput":::

## EnablePosixBundling

[Bundling](syntax.md#option-bundling) of single-character options is enabled by default, but you can disable it by setting the <xref:System.CommandLine.CommandLineConfiguration.EnablePosixBundling> property to `false`.

## ProcessTerminationTimeout

[Process termination timeout](how-to-parse-and-invoke.md#process-termination-timeout) can be configured via the <xref:System.CommandLine.CommandLineConfiguration.ProcessTerminationTimeout> property. The default value is 2 seconds.

## ResponseFileTokenReplacer

[Response files](syntax.md#response-files) are enabled by default, but you can disable them by setting the <xref:System.CommandLine.CommandLineConfiguration.ResponseFileTokenReplacer> property to `null`. You can also provide a custom implementation to customize how response files are processed.

## EnableDefaultExceptionHandler

By default, all unhandled exceptions thrown during the invocation of a command are caught and reported to the user. This behavior can be disabled by setting the <xref:System.CommandLine.CommandLineConfiguration.EnableDefaultExceptionHandler> property to `false`. This is useful when you want to handle exceptions in a custom way, such as logging them or providing a different user experience.

## Derived classes

<xref:System.CommandLine.CommandLineConfiguration> is not sealed, so you can derive from it to add custom properties or methods. This is useful when you want to provide additional configuration options specific to your application.

## See also

- [System.CommandLine overview](index.md)
