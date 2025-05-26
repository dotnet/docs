---
title: How to bind arguments to actions in System.CommandLine
description: "Learn how to do model-binding in apps that are built with the System.Commandline library."
ms.date: 05/24/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to bind arguments to actions in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

The process of parsing arguments and providing them to command action code is called *parameter binding*. `System.CommandLine` has the ability to parse many argument types built in. For example, integers, enums, and file system objects such as <xref:System.IO.FileInfo> and <xref:System.IO.DirectoryInfo> can be parsed and exposed to the command action via `ParseResult` type.

## Built-in argument validation

Arguments have expected types and [arity](syntax.md#argument-arity). `System.CommandLine` rejects arguments that don't match these expectations.

For example, a parse error is displayed if the argument for an integer option isn't an integer.

```console
myapp --delay not-an-int
```

```output
Cannot parse argument 'not-an-int' as System.Int32.
```

An arity error is displayed if multiple arguments are passed to an option that has maximum arity of one:

```console
myapp --delay-option 1 --delay-option 2
```

```output
Option '--delay' expects a single argument but 2 were provided.
```

This behavior can be overridden by setting <xref:System.CommandLine.Option.AllowMultipleArgumentsPerToken?displayProperty=nameWithType> to `true`. In that case you can repeat an option that has maximum arity of one, but only the last value on the line is accepted. In the following example, the value `three` would be passed to the app.

```console
myapp --item one --item two --item three
```

## Explicit parameter binding

The following example shows how to bind options to command action, by calling <xref:System.CommandLine.ParseResult.GetValue%2A>:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstring" highlight="13-16" :::

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstringaction" :::

The lambda parameter is just the `ParseResult` are option and argument values are obtained via `GetValue` method call:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="lambda" :::

### Complex types

There are two ways to bind complex types. The first is to create a custom type from parsed values in the command action. The second is to use a custom parser.

Suppose you have a `Person` type:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="persontype" :::

Just read the values and create an instance of `Person` in the command action:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="setaction" :::

With the custom parser, you can get a custom type the same way you get primitive values:

:::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="personoption" :::

## Set exit codes

There are `void` and <xref:System.Threading.Tasks.Task>-returning [Func](xref:System.Func%601) overloads of <xref:System.CommandLine.Command.SetAction%2A>. If your action is called from async code, you can return an `int` or a [`Task<int>`](xref:System.Threading.Tasks.Task%601) from the delegate that uses one of these, and just return the exit code, as in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/ReturnExitCode.cs" id="returnexitcode" :::

The exit code defaults to 1. If you don't set it explicitly, its value is set to 0 when your action exits normally. If an exception is thrown, it keeps the default value.

## Supported types

The following examples show code that binds some commonly used types.

### Enums

The values of `enum` types are bound by name, and the binding is case insensitive:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="enum" :::

Here's sample command-line input and resulting output from the preceding example:

```console
myapp --color red
myapp --color RED
```

```output
Red
Red
```

### Arrays and lists

Many common types that implement <xref:System.Collections.IEnumerable> are supported. For example:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="arrays" :::

Here's sample command-line input and resulting output from the preceding example:

```console
--items one --items two --items three
```

```output
one
two
three
```

Because <xref:System.CommandLine.Option.AllowMultipleArgumentsPerToken> is set to `true`, the following input results in the same output:

```console
--items one two three
```

### File system types

Command-line applications that work with the file system can use the <xref:System.IO.FileSystemInfo>, <xref:System.IO.FileInfo>, and <xref:System.IO.DirectoryInfo> types. The following example shows the use of `FileSystemInfo`:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="filesysteminfo" :::

With `FileInfo` and `DirectoryInfo` the pattern matching code is not required:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="fileinfo" :::

### Other supported types

Many types that have a constructor that takes a single string parameter can be bound in this way. For example, code that would work with `FileInfo` works with a <xref:System.Uri> instead.

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="uri" :::

Besides the file system types and `string`, the following types are supported:

* `bool`
* `byte` and `sbyte`
* `short` and `ushort`
* `int` and `uint`
* `long` and `ulong`
* `float` and `double`
* `decimal`
* `DateTime` and `DateTimeOffset`
* `DateOnly`and `TimeOnly`
* `Guid`

### `CancellationToken`

For information about how to use <xref:System.Threading.CancellationToken>, see [How to handle termination](handle-termination.md).

### `CommandLineConfiguration`

<xref:System.CommandLine.CommandLineConfiguration> makes testing as well as many extensibility scenarios easier than using `System.Console`. It exposes two `TextWriter` properties: `Output` and `Error`. They can be set to any `TextWriter` instance, such as a `StringWriter`, which can be used to capture output for testing. An instance of `CommandLineConfiguration` can be obtained from `ParseResult`.

### `ParseResult`

The <xref:System.CommandLine.Parsing.ParseResult> object is available in the command action. It's a structure that represents the results of parsing the command line input. You can use it to check for the presence of options or arguments on the command line or to get the <xref:System.CommandLine.Parsing.ParseResult.UnmatchedTokens?displayProperty=nameWithType> property. This property contains a list of the [tokens](syntax.md#tokens) that were parsed but didn't match any configured command, option, or argument.

The list of unmatched tokens is useful in commands that behave like wrappers. A wrapper command takes a set of [tokens](syntax.md#tokens) and forwards them to another command or app.  The `sudo` command in Linux is an example. It takes the name of a user to impersonate followed by a command to run. For example:

```console
sudo -u admin apt update
```

This command line would run the `apt update` command as the user `admin`.

To implement a wrapper command like this one, set the command property <xref:System.CommandLine.Command.TreatUnmatchedTokensAsErrors> to `false`. Then the `ParseResult.UnmatchedTokens` property will contain all of the arguments that don't explicitly belong to the command. In the preceding example, `ParseResult.UnmatchedTokens` would contain the `apt` and `update` tokens. Your command action could then forward the `UnmatchedTokens` to a new shell invocation, for example.

## Custom validation and parsing

To provide custom validation code, call <xref:System.CommandLine.Option.Validators.Add%2A> on your command, option, or argument, as shown in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/AddValidator.cs" id="delayOption" :::

If you want to parse as well as validate the input, use a `CustomParser` delegate, as shown in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="delayOption" :::

Here are some examples of what you can do with `CustomParser` that you can't do with `AddValidator`:

* Parsing of custom types, such as the `Person` class in the following example:

  :::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="persontype" :::

  :::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="personoption" :::

* Parsing of other kinds of input strings (for example, parse "1,2,3" into `int[]`).

* Dynamic arity. For example, you have two arguments that are defined as string arrays, and you have to handle a sequence of strings in the command line input. The <xref:System.CommandLine.Parsing.ArgumentResult.OnlyTake%2A?displayProperty=nameWithType> method enables you to dynamically divide up the input strings between the arguments.

## See also

[System.CommandLine overview](index.md)
