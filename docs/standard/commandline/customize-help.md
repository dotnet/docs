---
title: How to customize help in System.CommandLine
description: "Learn how to customize help in apps that are built with the System.Commandline library."
ms.date: 04/07/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to customize help in apps that are built with the System.Commandline library

You can customize help for a specific command, option, or argument, and you can add or replace whole help sections.

The examples in this article work with the following command-line application:

This code requires a `using` directive:

```csharp
using System.CommandLine;
```

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="original" :::

Without customization, the following help output is produced:

```output
Description:
  Read a file

Usage:
  scl [options]

Options:
  --file <file>                                               The file to print out. [default: scl.runtimeconfig.json]
  --light-mode                                                Determines whether the background color will be black or
                                                              white
  --color                                                     Specifies the foreground color of console output
  <Black|Blue|Cyan|DarkBlue|DarkCyan|DarkGray|DarkGreen|Dark  [default: White]
  Magenta|DarkRed|DarkYellow|Gray|Green|Magenta|Red|White|Ye
  llow>
  --version                                                   Show version information
  -?, -h, --help                                              Show help and usage information
```

## Customize help for a single option or argument

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

To customize the name of an option's argument, use the option's <xref:System.CommandLine.Option.ArgumentHelpName> property. And <xref:System.CommandLine.Help.HelpBuilder.CustomizeSymbol%2A?displayProperty=nameWithType> lets you customize several parts of the help output for a command, option, or argument (<xref:System.CommandLine.Symbol> is the base class for all three types). With `CustomizeSymbol`, you can specify:

* The first column text.
* The second column text.
* The way a default value is described.

In the sample app, `--light-mode` is explained adequately, but changes to the `--file` and `--color` option descriptions will be helpful. For `--file`, the argument can be identified as a `<FILEPATH>` instead of `<file>`. For the `--color` option, you can shorten the list of available colors in column one, and in column two you can add a warning that some colors won't work with some backgrounds.

To make these changes, delete the `await rootCommand.InvokeAsync(args);` line shown in the preceding code and add in its place the following code:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="first2columns" :::

The updated code requires additional `using` directives:

```csharp
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Parsing;
```

The app now produces the following help output:

```output
Description:
  Read a file

Usage:
  scl [options]

Options:
  --file <FILEPATH>                       The file to print out. [default: CustomHelp.runtimeconfig.json]
  --light-mode                            Determines whether the background color will be black or white
  --color <Black, White, Red, or Yellow>  Specifies the foreground color. Choose a color that provides enough contrast
                                          with the background color. For example, a yellow foreground can't be read
                                          against a light mode background.
  --version                               Show version information
  -?, -h, --help                          Show help and usage information
```

This output shows that the `firstColumnText` and `secondColumnText` parameters support word wrapping within their columns.

## Add or replace help sections

You can add or replace a whole section of the help output. For example, suppose you want to add some ASCII art to the description section by using the [Spectre.Console](https://www.nuget.org/packages/Spectre.Console/) NuGet package.

Change the layout by adding a call to <xref:System.CommandLine.Help.HelpBuilder.CustomizeLayout%2A?displayProperty=nameWithType> in the lambda passed to the <xref:System.CommandLine.Builder.CommandLineBuilderExtensions.UseHelp%2A> method:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="description" highlight="14-22" :::

The preceding code requires an additional `using` directive:

```csharp
using Spectre.Console;
```

The <xref:System.CommandLine.Help.HelpBuilder.Default?displayProperty=nameWithType> class lets you reuse pieces of existing help formatting functionality and compose them into your custom help.

The help output now looks like this:

```output
  ____                       _                __   _   _
 |  _ \    ___    __ _    __| |     __ _     / _| (_) | |   ___
 | |_) |  / _ \  / _` |  / _` |    / _` |   | |_  | | | |  / _ \
 |  _ <  |  __/ | (_| | | (_| |   | (_| |   |  _| | | | | |  __/
 |_| \_\  \___|  \__,_|  \__,_|    \__,_|   |_|   |_| |_|  \___|


Usage:
  scl [options]

Options:
  --file <FILEPATH>                       The file to print out. [default: CustomHelp.runtimeconfig.json]
  --light-mode                            Determines whether the background color will be black or white
  --color <Black, White, Red, or Yellow>  Specifies the foreground color. Choose a color that provides enough contrast
                                          with the background color. For example, a yellow foreground can't be read
                                          against a light mode background.
  --version                               Show version information
  -?, -h, --help                          Show help and usage information
```

If you want to just use a string as the replacement section text instead of formatting it with `Spectre.Console`, replace the `Prepend` code in the preceding example with the following code:

```csharp
.Prepend(
    _ => _.Output.WriteLine("**New command description section**")
```

## See also

[System.CommandLine overview](index.md)
