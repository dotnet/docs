---
title: How to customize help in System.CommandLine
description: "Learn how to customize help in apps that are built with the System.Commandline library."
ms.date: 03/07/2022
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
  -?, -h, --help
```

## Customize help for a single option or argument

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

`HelpBuilder.CustomizeSymbol` lets you customize the help for a specific command, option, or argument (`Symbol` is the base class for all three types). You can customize several parts of the help output, including:

* The name of an option's argument.
* The first column text.
* The second column text.
* The way a default value is described.

In the sample app, `--light-mode` is explained adequately, but changes to the `--file` and `--color` option descriptions will be helpful. For `--file`, the argument can be identified as a `<FILEPATH>` instead of `<file>`. For the `--color` option, you can shorten the list of available colors in column one, and in column two you can add a warning that some colors won't work with some backgrounds. The following example makes these changes:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="first2columns" :::

The app now produces the following help output:

```output
Description:
  Read a file

Usage:
  scl [options]

Options:
  --file <FILEPATH>                                           The file to print out. [default: scl.runtimeconfig.json]
  --light-mode                                                Determines whether the background color will be black or
                                                              white [default: True]
  --color                                                     Specifies the foreground color. Choose a color that
  <Black|Blue|Cyan|DarkBlue|DarkCyan|DarkGray|DarkGreen|Dark  provides enough contrast with the background color. For
  Magenta|DarkRed|DarkYellow|Gray|Green|Magenta|Red|White|Ye  example, a yellow foreground can't be read against a
  llow>                                                       light mode background.
  --version                                                   Show version information
  -?, -h, --help                                              Show help and usage information
```

This output shows that the `firstColumnText` and `secondColumnText` parameters support word wrapping within their columns.

## Add or replace help sections

You can add or replace a whole section of the help output. For example, suppose you want to add some ASCII art to the description section by using the [Spectre.Console](https://www.nuget.org/packages/Spectre.Console/) NuGet package.

Change the layout by adding a call to `HelpBuilder.CustomizeLayout` in the lambda passed to the `CommandLineBuilder.UseHelp` method:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="description" highlight="13-21" :::

The `HelpBuilder.Default` class lets you reuse pieces of existing help formatting functionality and compose them into your custom help.

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
  --file <FILEPATH>                                           The file to print out. [default: scl.runtimeconfig.json]
  --light-mode                                                Determines whether the background color will be black or
                                                              white [default: True]
  --color                                                     Specifies the foreground color. Choose a color that
  <Black|Blue|Cyan|DarkBlue|DarkCyan|DarkGray|DarkGreen|Dark  provides enough contrast with the background color. For
  Magenta|DarkRed|DarkYellow|Gray|Green|Magenta|Red|White|Ye  example, a yellow foreground can't be read against a
  llow>                                                       light mode background.
  --version                                                   Show version information
  -?, -h, --help
```

## See also

[System.CommandLine overview](index.md)
