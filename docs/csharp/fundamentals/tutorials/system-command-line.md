---
title: "Tutorial: Build a command-line app with System.CommandLine"
description: "Learn how to use the System.CommandLine library to build a command-line app with commands, subcommands, options, and arguments in a file-based C# program."
ms.date: 03/23/2026
ms.topic: tutorial
ai-usage: ai-assisted
#customer intent: As a developer, I want to build a command-line app with System.CommandLine so that I can parse options, arguments, and subcommands without writing my own parser.
---

# Tutorial: Build a command-line app with System.CommandLine

> [!TIP]
> This article is part of the **Fundamentals** section, written for developers who know at least one programming language and are learning C#. If you're new to programming, start with [Get started](../../tour-of-csharp/index.yml). If you need comprehensive library coverage, see the [System.CommandLine library documentation](../../../standard/commandline/index.md).

The [`System.CommandLine`](../../../standard/commandline/index.md) library handles command-line parsing, help text generation, and input validation so you can focus on your app's logic. In this tutorial, you build a task tracker CLI that demonstrates the core concepts: commands, subcommands, options, and arguments.

In this tutorial, you:

> [!div class="checklist"]
>
> * Create a file-based app with the `System.CommandLine` package.
> * Define options and arguments with typed values.
> * Build subcommands and attach options and arguments to them.
> * Handle each subcommand with an action.
> * Test the app with different command-line inputs.

## Prerequisites

- Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later.

## Create the app

Start by creating a file-based C# program and adding the `System.CommandLine` package.

1. Create a file named `TaskCli.cs` with the following content:

   ```csharp
   #!/usr/bin/env dotnet
   ```

   The `#!` (shebang) line lets you run the file directly on Unix systems. On Windows, run the file with `dotnet run TaskCli.cs`.

1. Add the `System.CommandLine` package directive and the required `using` statements:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Package":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Usings":::

   > [!IMPORTANT]
   > Version `2.0.0` is the latest version at the time of writing. Check the package's [NuGet page](https://www.nuget.org/packages/System.CommandLine) for the latest version to ensure you have the latest security fixes.

## Understand the command structure

Before writing any parsing code, consider what the CLI looks like from the user's perspective. The task tracker supports four operations:

```console
TaskCli add "Write documentation" --priority High --due 2026-04-01
TaskCli list --all
TaskCli complete 3
TaskCli remove 3
```

Each operation is a *subcommand* of the root command. Subcommands can have their own *arguments* (positional values like a task description or ID) and *options* (named values like `--priority`). The root command also defines a `--verbose` option that applies to all subcommands. For a deeper look at command-line syntax concepts, see [Command-line syntax overview](../../../standard/commandline/syntax.md).

## Define options and arguments

Options represent named values that users specify with a `--` prefix. Arguments represent positional values. Both are strongly typed—`System.CommandLine` parses the input string into the type you specify.

1. Define the options. Each `Option<T>` specifies the value type, the name, and a description. The `--priority` option uses an `enum` type, and `System.CommandLine` automatically validates the input against valid enum values:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Options":::

   The `Recursive = true` setting on `--verbose` makes the option available on every subcommand. The `DefaultValueFactory` on `--priority` provides a default so users can omit the option.

1. Define the arguments. Each `Argument<T>` specifies the value type and a name:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Arguments":::

## Build commands and subcommands

A `Command` represents an action the user can invoke. Add the relevant options and arguments to each command so that `System.CommandLine` knows which parameters belong where.

1. Create the four subcommands. Each command gets its own combination of options and arguments:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="AddCommand":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="ListCommand":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="CompleteCommand":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RemoveCommand":::

1. Assemble the root command. The `RootCommand` is the entry point for the CLI. Add the global `--verbose` option and all subcommands:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RootCommand":::

   The root command description appears in the auto-generated help text when the user runs `TaskCli --help`.

## Handle commands with actions

Each subcommand needs an *action*—a delegate that runs when the user invokes that command. Call `SetAction` to assign each action. The delegate receives a <xref:System.CommandLine.ParseResult> that provides access to parsed values through `GetValue`.

1. Set actions for all four commands:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="SetActions":::

   Each action follows the same pattern: call `parseResult.GetValue(...)` to retrieve typed values, run the app logic, and write output to the console. The `with` expression on `completeCommand` creates a copy of the record with `IsComplete` set to `true`.

1. Parse the command line and invoke the matched action:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Invoke":::

   `rootCommand.Parse(args)` parses the input into a <xref:System.CommandLine.ParseResult>, and `.Invoke()` runs the action for the matched command. The return value is an exit code (0 for success).

## Add supporting types and data helpers

The app uses a `record` to represent a task and stores tasks in a JSON file. File-based apps require type declarations to appear after all top-level statements and local functions.

1. Add the local functions that load and save tasks:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="DataHelpers":::

1. Add the `Priority` enum and `TaskItem` record at the end of the file:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="EnumDefinition":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RecordDefinition":::

1. Add the JSON serialization context for AOT-compatible serialization:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="JsonContext":::

## Test the application

Run the app with different inputs to exercise each subcommand.

1. View the auto-generated help:

   ```dotnetcli
   dotnet run TaskCli.cs -- --help
   ```

   ```output
   Description:
     A simple task tracker CLI

   Usage:
     TaskCli [command] [options]

   Options:
     --verbose       Show detailed output
     -?, -h, --help  Show help and usage information
     --version       Show version information

   Commands:
     add <description>  Add a new task
     list               List all tasks
     complete <id>      Mark a task as complete
     remove <id>        Remove a task
   ```

1. Add tasks with different options:

   ```dotnetcli
   dotnet run TaskCli.cs -- add "Write documentation" --priority High --due 2026-04-01
   dotnet run TaskCli.cs -- add "Review pull request"
   dotnet run TaskCli.cs -- add "Fix build errors"
   ```

   ```output
   Added task 1: Write documentation
   Added task 2: Review pull request
   Added task 3: Fix build errors
   ```

1. List tasks and use `--verbose` to show extra detail:

   ```dotnetcli
   dotnet run TaskCli.cs -- --verbose list
   ```

   ```output
     [ ] 1: Write documentation
          Priority: High
          Due: 4/1/2026
     [ ] 2: Review pull request
          Priority: Medium
     [ ] 3: Fix build errors
          Priority: Medium
   ```

1. Complete a task, then verify the list filters completed tasks by default:

   ```dotnetcli
   dotnet run TaskCli.cs -- complete 2
   dotnet run TaskCli.cs -- list
   ```

   ```output
   Completed task 2: Review pull request
     [ ] 1: Write documentation
     [ ] 3: Fix build errors
   ```

1. Use `--all` to include completed tasks:

   ```dotnetcli
   dotnet run TaskCli.cs -- list --all
   ```

   ```output
     [ ] 1: Write documentation
     [✓] 2: Review pull request
     [ ] 3: Fix build errors
   ```

1. Remove a task:

   ```dotnetcli
   dotnet run TaskCli.cs -- remove 3
   ```

   ```output
   Removed task 3: Fix build errors
   ```

## Clean up resources

The task tracker stores data in a JSON file under your local application data folder. Delete the `taskcli-sample` folder to remove the sample data:

- **Windows**: Delete `%LOCALAPPDATA%\taskcli-sample`
- **macOS/Linux**: Delete `~/.local/share/taskcli-sample`

## Related content

- [System.CommandLine overview](../../../standard/commandline/index.md)
- [Tutorial: Get started with System.CommandLine](../../../standard/commandline/get-started-tutorial.md)
- [Command-line syntax overview](../../../standard/commandline/syntax.md)
- [System.CommandLine design guidance](../../../standard/commandline/design-guidance.md)
- [Tutorial: Build file-based apps](file-based-programs.md)
- [How to display command-line arguments](how-to-display-command-line-arguments.md)
