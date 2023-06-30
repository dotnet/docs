---
title: How to define commands in System.CommandLine
description: "Learn how to define commands, options, and arguments by using the System.Commandline library."
ms.date: 04/07/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to define commands, options, and arguments in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

This article explains how to define [commands](syntax.md#commands), [options](syntax.md#options), and [arguments](syntax.md#arguments) in command-line apps that are built with the `System.CommandLine` library. To build a complete application that illustrates these techniques, see the tutorial [Get started with System.CommandLine](get-started-tutorial.md).

For guidance on how to design a command-line app's commands, options, and arguments, see [Design guidance](syntax.md#design-guidance).

## Define a root command

Every command-line app has a [root command](syntax.md#root-commands), which refers to the executable file itself. The simplest case for invoking your code, if you have an app with no subcommands, options, or arguments, would look like this:

:::code language="csharp" source="snippets/define-commands/csharp/Program.cs" id="all" :::

## Define subcommands

Commands can have child commands, known as [*subcommands* or *verbs*](syntax.md#subcommands), and they can nest as many levels as you need. You can add subcommands as shown in the following example:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="definecommands" :::

The innermost subcommand in this example can be invoked like this:

```console
myapp sub1 sub1a
```

## Define options

A command handler method typically has parameters, and the values can come from command-line [options](syntax.md#options). The following example creates two options and adds them to the root command. The option names include double-hyphen prefixes, in accordance with [POSIX conventions](syntax.md#options). The command handler code displays the values of those options:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="defineoptions" :::

Here's an example of command-line input and the resulting output for the preceding example code:

```console
myapp --delay 21 --message "Hello world!"
```

```output
--delay = 21
--message = Hello world!
```

### Global options

To add an option to one command at a time, use the `Add` or `AddOption` method as shown in the preceding example. To add an option to a command and recursively to all of its subcommands, use the `AddGlobalOption` method, as shown in the following example:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="defineglobal" highlight="7" :::

The preceding code adds `--delay` as a global option to the root command, and it's available in the handler for `subCommand1a`.

## Define arguments

[Arguments](syntax.md#arguments) are defined and added to commands like options. The following example is like the options example, but it defines arguments instead of options:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="definearguments" :::

Here's an example of command-line input and the resulting output for the preceding example code:

```console
myapp 42 "Hello world!"
```

```output
<delay> argument = 42
<message> argument = Hello world!
```

An argument that is defined without a default value, such as `messageArgument` in the preceding example, is treated as a required argument.  An error message is displayed, and the command handler isn't called, if a required argument isn't provided.

## Define aliases

Both commands and options support [aliases](syntax.md#aliases). You can add an alias to an option by calling `AddAlias`:

```csharp
var option = new Option("--framework");
option.AddAlias("-f");
```

Given this alias, the following command lines are equivalent:

```console
myapp -f net6.0
myapp --framework net6.0
```

Command aliases work the same way.

```csharp
var command = new Command("serialize");
command.AddAlias("serialise");
```

This code makes the following command lines equivalent:

```console
myapp serialize
myapp serialise
```

We recommend that you minimize the number of option aliases that you define, and avoid defining certain aliases in particular. For more information, see [Short-form aliases](syntax.md#short-form-aliases).

## Required options

To make an option required, set its `IsRequired` property to `true`, as shown in the following example:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="requiredoption" :::

The options section of the command help indicates the option is required:

```output
Options:
  --endpoint <uri> (REQUIRED)
  --version               Show version information
  -?, -h, --help          Show help and usage information
```

If the command line for this example app doesn't include `--endpoint`, an error message is displayed and the command handler isn't called:

```output
Option '--endpoint' is required.
```

If a required option has a default value, the option doesn't have to be specified on the command line. In that case, the default value provides the required option value.

## Hidden commands, options, and arguments

You might want to support a command, option, or argument, but avoid making it easy to discover. For example, it might be a deprecated or administrative or preview feature. Use the <xref:System.CommandLine.Symbol.IsHidden> property to prevent users from discovering such features by using tab completion or help, as shown in the following example:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="hiddenoption" :::

The options section of this example's command help omits the `--endpoint` option.

```output
Options:
  --version               Show version information
  -?, -h, --help          Show help and usage information
```

## Set argument arity

You can explicitly set argument [arity](syntax.md#argument-arity) by using the `Arity` property, but in most cases that is not necessary. `System.CommandLine` automatically determines the argument arity based on the argument type:

| Argument type    | Default arity              |
|------------------|----------------------------|
| `Boolean`        | `ArgumentArity.ZeroOrOne`  |
| Collection types | `ArgumentArity.ZeroOrMore` |
| Everything else  | `ArgumentArity.ExactlyOne` |

## Multiple arguments

By default, when you call a command, you can repeat an option name to specify multiple arguments for an option that has maximum [arity](syntax.md#argument-arity) greater than one.

```console
myapp --items one --items two --items three
```

To allow multiple arguments without repeating the option name, set <xref:System.CommandLine.Option.AllowMultipleArgumentsPerToken?displayProperty=nameWithType> to `true`. This setting lets you enter the following command line.

```console
myapp --items one two three
```

The same setting has a different effect if maximum argument arity is 1. It allows you to repeat an option but takes only the last value on the line. In the following example, the value `three` would be passed to the app.

```console
myapp --item one --item two --item three
```

## List valid argument values

To specify a list of valid values for an option or argument, specify an enum as the option type or use <xref:System.CommandLine.OptionExtensions.FromAmong%2A>, as shown in the following example:

:::code language="csharp" source="snippets/define-commands/csharp/Program2.cs" id="staticlist" :::

Here's an example of command-line input and the resulting output for the preceding example code:

```console
myapp --language not-a-language
```

```output
Argument 'not-a-language' not recognized. Must be one of:
        'csharp'
        'fsharp'
        'vb'
        'pwsh'
        'sql'
```

The options section of command help shows the valid values:

```output
Options:
  --language <csharp|fsharp|vb|pwsh|sql>  An option that must be one of the values of a static list.
  --version                               Show version information
  -?, -h, --help                          Show help and usage information
```

## Option and argument validation

For information about argument validation and how to customize it, see the following sections in the [Parameter binding](model-binding.md) article:

* [Built-in type and arity argument validation](model-binding.md#built-in-argument-validation)
* [Custom validation and binding](model-binding.md#custom-validation-and-binding)

## See also

* [System.CommandLine overview](index.md)
* [Parameter binding](model-binding.md)
