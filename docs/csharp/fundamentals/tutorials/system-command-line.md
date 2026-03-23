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
TaskCli --verbose list
```

Each line uses several command-line concepts:

- **Subcommands** are verbs that tell the app what to do. The task tracker has four: `add`, `list`, `complete`, and `remove`. Each subcommand can define its own parameters.
- **Arguments** are positional values that follow a subcommand. In `add "Write documentation"`, the string `"Write documentation"` is an argument—the task description. In `complete 3`, the number `3` is an argument—the task ID.
- **Options** are named values prefixed with `--`. In `add --priority High --due 2026-04-01`, both `--priority` and `--due` are options with their own values. In `list --all`, the `--all` option is a boolean flag that doesn't need a value.
- **Global options** apply to every subcommand. The `--verbose` option is defined on the root command with `Recursive = true`, so it works with any subcommand. In `--verbose list`, the verbose flag appears before the subcommand, but `list --verbose` works equally well.

In the sections that follow, you build these pieces from the bottom up. First, you define the individual options (like `--priority` and `--all`) and arguments (like the task description and ID). Next, you create the four subcommands and attach the relevant options and arguments to each one. Then you wire up an action for each subcommand—the code that runs when the user invokes that command. Finally, you assemble the root command, parse the input, and invoke the matched action.

For a deeper look at command-line syntax concepts, see [Command-line syntax overview](../../../standard/commandline/syntax.md).

## Define options and arguments

Options represent named values that users specify with a `--` prefix. Arguments represent positional values. Both are strongly typed—`System.CommandLine` parses the input string into the type you specify.

The `System.CommandLine` library uses *generic types* to enforce type safety. When you write `Option<int>`, the `int` between the angle brackets is a *type argument*—it tells the library what type of value the option holds. The class itself declares a *type parameter* `T` (as in `Option<T>`), and you supply the concrete type when you create an instance. The library parses the user's input string and converts it to that type automatically. If the user provides `--delay abc` for an `Option<int>`, `System.CommandLine` reports a parse error instead of passing bad data to your code. You'll see this pattern with `Option<bool>`, `Option<Priority>`, `Option<DateOnly?>`, and `Argument<string>` in the steps that follow. For more on generics, see [Generics](../types/generics.md).

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

Each subcommand needs an *action*—a [delegate](../../programming-guide/delegates/index.md) that runs when the user invokes that command. A delegate is a type that represents a reference to a method. Here, you pass a [lambda expression](../../language-reference/operators/lambda-expressions.md) (an inline anonymous function defined with `=>`) as the delegate. Call `SetAction` to assign each action. The delegate receives a <xref:System.CommandLine.ParseResult> that provides access to parsed values through `GetValue`.

1. Set the action for the `add` command. This action introduces [string interpolation](../../language-reference/tokens/interpolated.md) (`$"..."` strings that embed expressions in braces), the [conditional operator](../../language-reference/operators/conditional-operator.md) (`?:`), and a [type test pattern](../functional/pattern-matching.md) (`due is DateOnly dueDate`) that checks whether a nullable value has a value and assigns it to a new variable in one step:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="AddAction":::

1. Set the action for the `list` command. This action uses [LINQ](../../linq/index.md) methods (`Where` and `ToList`) to filter the task list, a [`foreach` loop](../../language-reference/statements/iteration-statements.md#the-foreach-statement) to iterate over the results, and the conditional operator to pick a status symbol:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="ListAction":::

1. Set the action for the `complete` command. This action uses LINQ's `FirstOrDefault` to find a matching task, an [`is null` pattern](../functional/pattern-matching.md) to check whether the task exists, and a [`with` expression](../../language-reference/operators/with-expression.md) to create a copy of the record with `IsComplete` set to `true`—records are immutable by default, so `with` is how you produce a modified copy:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="CompleteAction":::

1. Set the action for the `remove` command. This action follows the same lookup-and-validate pattern as `complete`—use `FirstOrDefault` to find the task and `is null` to handle the missing case:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RemoveAction":::

1. Parse the command line and invoke the matched action:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Invoke":::

   `rootCommand.Parse(args)` parses the input into a <xref:System.CommandLine.ParseResult>, and `.Invoke()` runs the action for the matched command. The return value is an exit code (0 for success).

## Add supporting types and data helpers

The app needs a few supporting pieces: [local functions](../../programming-guide/classes-and-structs/local-functions.md) (methods declared inside top-level code) that load and save tasks, an [`enum`](../../language-reference/builtin-types/enum.md) (a value type that defines a set of named constants) for priority levels, a [`record`](../../language-reference/builtin-types/record.md) (a reference type with built-in value equality and immutability) to represent a task, and a serialization context for storing tasks as JSON (JavaScript Object Notation). The app uses [System.Text.Json](../../../standard/serialization/system-text-json/overview.md) for serialization. File-based apps require type declarations to appear after all top-level statements and local functions.

1. Add the local functions that load and save tasks:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="DataHelpers":::

1. Add the `Priority` enum and `TaskItem` record at the end of the file:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="EnumDefinition":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RecordDefinition":::

   The `enum` restricts priority to three valid values. The `record` declares five properties through its constructor parameters—the compiler generates a constructor, read-only properties, `Equals`, `GetHashCode`, and the `with` expression support automatically.

1. Add the JSON serialization context for AOT-compatible serialization:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="JsonContext":::

   This class uses two [attributes](../../advanced-topics/reflection-and-attributes/index.md) (metadata annotations placed in square brackets above a declaration). The [`[JsonSourceGenerationOptions(WriteIndented = true)]`](../../../standard/serialization/system-text-json/source-generation.md) attribute tells the source generator to emit indented JSON for readability. The [`[JsonSerializable(typeof(List<TaskItem>))]`](../../../standard/serialization/system-text-json/source-generation.md) attribute tells the generator which type to create serialization code for. Together, these attributes enable [source-generated serialization](../../../standard/serialization/system-text-json/source-generation.md), which avoids run-time reflection and supports ahead-of-time (AOT) compilation.

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
