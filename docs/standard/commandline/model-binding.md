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

## Explicit parameter binding

Before we bind options and arguments to command actions, we need to define a command. The following example shows how to define a command with options and arguments:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstring" :::

Now we can bind options to command action, by calling `SetAction` method with a delegate that takes `ParseResult` as an argument and uses <xref:System.CommandLine.ParseResult.GetValue%2A> to obtain parsed values:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="lambda" :::

After the action is defined, we can parse the command line input and invoke the action:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="invoke" :::

### Getting values by name

You can also get values by name, but this requires you to specify the type of the value you want to get.

The following example uses C# collection initializers to create a root command:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="collectioninitializersyntax" :::

And then it uses the `GetValue` method to get the values by name:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="lambdanames" :::

This overload of `GetValue` gets the parsed or default value for the specified symbol name, in the context of parsed command (not entire symbol tree). It accepts the symbol name, not an [alias](syntax.md#aliases).

### Complex types

There are two ways to bind complex types. The first is to create a custom type from parsed values in the command action. The second is to use a custom parser.

Suppose you have a `Person` type:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="persontype" :::

Just read the values and create an instance of `Person` in the command action:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="setaction" :::

With the custom parser, you can get a custom type the same way you get primitive values:

:::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="personoption" :::

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

### `CommandLineConfiguration`

<xref:System.CommandLine.CommandLineConfiguration> makes testing as well as many extensibility scenarios easier than using `System.Console`. It exposes two `TextWriter` properties: `Output` and `Error`. They can be set to any `TextWriter` instance, such as a `StringWriter`, which can be used to capture output for testing. An instance of `CommandLineConfiguration` can be obtained from `ParseResult`.

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
