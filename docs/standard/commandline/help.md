---
title: How to customize help in System.CommandLine
description: "Learn how to use and customize help in apps that are built with the System.Commandline library."
ms.date: 04/07/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---

## Help option

Command-line apps typically provide an option to display a brief description of the available commands, options, and arguments. `System.CommandLine` provides <xref:System.CommandLine.Help.HelpOption> that is by default included in the [RootCommand](syntax.md#root-command) options. <xref:System.CommandLine.Help.HelpOption> generates help output for defined symbols by using the information exposed by <xref:System.CommandLine.Symbol.Name>, <xref:System.CommandLine.Symbol.HelpName>, <xref:System.CommandLine.Symbol.Description>, and other properties like default value or completion sources.

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="original" :::

```dotnetcli
Description:
  Read a file

Usage:
  scl [options]

Options:
  -?, -h, --help                                            Show help and usage information
  --version                                                 Show version information
  --file                                                    The file to print out.
  --light-mode                                              Determines whether the background color will be black
                                                            or white
  --color                                                   Specifies the foreground color of console output
  <Black|Blue|Cyan|DarkBlue|DarkCyan|DarkGray|DarkGreen|Da  [default: White]
  rkMagenta|DarkRed|DarkYellow|Gray|Green|Magenta|Red|Whit
  e|Yellow>
```

App users might be accustomed to different ways to request help on different platforms, so apps built on `System.CommandLine` respond to many ways of requesting help. The following commands are all equivalent:

```dotnetcli
dotnet --help
dotnet -h
dotnet /h
dotnet -?
dotnet /?
```

Help output doesn't necessarily show all available commands, arguments, and options. Some of them might be *hidden* via the <xref:System.CommandLine.Symbol.Hidden> property, which means they don't show up in help output (and completions) but can be specified on the command line.

## Help customization

 You can customize help output for commands by defining specific help text for each symbol, providing further clarity to users regarding their usage.

To customize the name of an option's argument, use the option's <xref:System.CommandLine.Option.HelpName> property.

In the sample app, `--light-mode` is explained adequately, but changes to the `--file` and `--color` option descriptions will be helpful. For `--file`, the argument can be identified as a `<FILEPATH>`. For the `--color` option, you can shorten the list of available colors.

To make these changes, extend the previous code with the following code:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="allowedvalues" :::

The app now produces the following help output:

```output
Description:
  Read a file

Usage:
  scl [options]

Options:
  -?, -h, --help                    Show help and usage information
  --version                         Show version information
  --file <FILEPATH>                 The file to print out.
  --light-mode                      Determines whether the background color will be black or white
  --color <Black|Red|White|Yellow>  Specifies the foreground color of console output [default: White]
```

## Add sections to help output

You can add first or last sections to the help output. For example, suppose you want to add some ASCII art to the description section by using the [Spectre.Console](https://www.nuget.org/packages/Spectre.Console/) NuGet package.

Define a custom action that performs some extra logic before and after calling the default `HelpAction`:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="customaction" :::

Update the `HelpAction` defined by `RootCommand` to use the custom action:

:::code language="csharp" source="snippets/customize-help/csharp/Program.cs" id="setcustomaction" highlight="5" :::

The help output now looks like this:

```output
  ____                       _                __   _   _
 |  _ \    ___    __ _    __| |     __ _     / _| (_) | |   ___
 | |_) |  / _ \  / _` |  / _` |    / _` |   | |_  | | | |  / _ \
 |  _ <  |  __/ | (_| | | (_| |   | (_| |   |  _| | | | | |  __/
 |_| \_\  \___|  \__,_|  \__,_|    \__,_|   |_|   |_| |_|  \___|

Description:
  Read a file

Usage:
  scl [options]

Options:
  -?, -h, --help                    Show help and usage information
  --version                         Show version information
  --file <FILEPATH>                 The file to print out.
  --light-mode                      Determines whether the background color will be black or white
  --color <Black|Red|White|Yellow>  Specifies the foreground color of console output [default: White]

Sample usage: --file input.txt
```

## See also

[System.CommandLine overview](index.md)
