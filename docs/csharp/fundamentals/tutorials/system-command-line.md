---
title: "Tutorial: Build a command-line app with System.CommandLine"
description: "Learn how to use the System.CommandLine library to build a command-line app with commands, subcommands, options, and arguments in a file-based C# program."
ms.date: 03/23/2026
ms.topic: tutorial
ai-usage: ai-assisted
#customer intent: As a developer learning C#, I want to build a command-line app so that I can learn important C# language concepts and .NET libraries while also learning to use System.CommandLine.
---

# Tutorial: Build a command-line app with System.CommandLine

> [!TIP]
> This article is part of the **Fundamentals** section, written for developers who know at least one programming language and are learning C#. If you're new to programming, start with [Get started](../../tour-of-csharp/index.yml). If you need comprehensive library coverage, see the [System.CommandLine library documentation](../../../standard/commandline/index.md).

The [`System.CommandLine`](../../../standard/commandline/index.md) library handles command-line parsing, help-text generation, and input validation so you can focus on your app's logic. In this tutorial, you build a task tracker CLI that demonstrates the core concepts: commands, subcommands, options, and arguments.

In this tutorial, you:

> [!div class="checklist"]
>
> * Create a file-based app by using the `System.CommandLine` package.
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
dotnet TaskCli.cs -- add "Write documentation" --priority High --due 2026-04-01
dotnet TaskCli.cs -- list --all
dotnet TaskCli.cs -- complete 3
dotnet TaskCli.cs -- remove 3
dotnet TaskCli.cs -- --verbose list
```

> [!NOTE]
> The `--` after `TaskCli.cs` in the preceding examples tells [`dotnet run`](../../../core/tools/dotnet-run.md) that all remaining arguments are passed to your app rather than interpreted by the `dotnet` CLI itself.

Each line uses several command-line concepts:

- **Subcommands** are verbs that tell the app what to do. The task tracker has four: `add`, `list`, `complete`, and `remove`. Each subcommand can define its own parameters.
- **Arguments** are positional values that follow a subcommand. In `add "Write documentation"`, the string `"Write documentation"` is an argument specifying the task description. In `complete 3`, the number `3` is an argument specifying the task ID.
- **Options** are named values prefixed with `--`. In `add --priority High --due 2026-04-01`, both `--priority` and `--due` are options with their own values. In `list --all`, the `--all` option is a Boolean flag that doesn't need a value.
- **Global options** apply to every subcommand. The `--verbose` option is defined on the root command with `Recursive = true`, so it works with any subcommand. In `--verbose list`, the verbose flag appears before the subcommand, but `list --verbose` works equally well.

In the sections that follow, you build these pieces from the bottom up. First, you define the individual options (like `--priority` and `--all`) and arguments (like the task description and ID). Next, you create the four subcommands and attach the relevant options and arguments to each one. Then you wire up an action for each subcommand. The action is the code that runs when the user invokes that command. Finally, you assemble the root command, parse the input, and invoke the matched action.

For a deeper look at command-line syntax concepts, see [Command-line syntax overview](../../../standard/commandline/syntax.md).

## Define options and arguments

Options represent named values that users specify with a `--` prefix. Arguments represent positional values. Both are strongly typed. `System.CommandLine` parses the input string into the type you specify.

The `System.CommandLine` library uses *generic types* to enforce type safety. When you write `Option<int>`, the `int` between the angle brackets is a *type argument*. It tells the library what type of value the option holds. The class itself declares a *type parameter* `T` (as in <xref:System.CommandLine.Option`1?displayProperty=nameWithType>), and you supply the concrete type when you create an instance. The library parses the user's input string and converts it to that type automatically. If the user provides `--delay abc` for an `Option<int>`, `System.CommandLine` reports a parse error instead of passing bad data to your code. You'll see this pattern with `Option<bool>`, `Option<Priority>`, `Option<DateOnly?>`, and <xref:System.CommandLine.Argument`1?displayProperty=nameWithType> in the steps that follow. For more information on generics, see [Generics](../types/generics.md).

1. Define the options. Each `Option<T>` specifies the value type, the name, and a description. The `--priority` option uses an `enum` type, and `System.CommandLine` automatically validates the input against valid enum values:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Options":::

   The `Recursive = true` setting on `--verbose` makes the option available on every subcommand. The `DefaultValueFactory` on `--priority` provides a default value so users can omit the option.

1. Define the arguments. Each `Argument<T>` specifies the value type and a name:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Arguments":::

## Build commands and subcommands

A <xref:System.CommandLine.Command?displayProperty=nameWithType> represents an action that the user can invoke. Add the relevant options and arguments to each command so `System.CommandLine` knows which parameters belong where.

1. Create the four subcommands. Each command gets its own combination of options and arguments:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="AddCommand":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="ListCommand":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="CompleteCommand":::

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RemoveCommand":::

1. Assemble the root command. The <xref:System.CommandLine.RootCommand?displayProperty=nameWithType> is the entry point for the CLI. Add the global `--verbose` option and all subcommands:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RootCommand":::

   The autogenerated help text shows the root command description when the user runs `TaskCli --help`.

## Handle commands with actions

Each subcommand needs an *action*. An action is a [delegate](../../programming-guide/delegates/index.md) that runs when the user invokes that command. A delegate is a type that represents a reference to a method. Here, you pass a [lambda expression](../../language-reference/operators/lambda-expressions.md) (an inline anonymous function defined with `=>`) as the delegate. Call `SetAction` to assign each action. The delegate receives a <xref:System.CommandLine.ParseResult> that provides access to parsed values through `GetValue`.

1. Set the action for the `add` command. This action introduces [string interpolation](../../language-reference/tokens/interpolated.md) (`$"..."` strings that embed expressions in braces), the [conditional operator](../../language-reference/operators/conditional-operator.md) (`?:`), and a [type test pattern](../functional/pattern-matching.md) (`due is DateOnly dueDate`) that checks whether a nullable value has a value and assigns it to a new variable in one step:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="AddAction":::

1. Set the action for the `list` command. [LINQ](../../linq/index.md) (Language Integrated Query) gives you standard query operators for in-memory collections. In this action, <xref:System.Linq.Enumerable.Where*?displayProperty=nameWithType> filters the tasks to only the items that match a condition, and <xref:System.Linq.Enumerable.ToList*?displayProperty=nameWithType> materializes the filtered sequence into a list. The action then uses a [`foreach` loop](../../language-reference/statements/iteration-statements.md#the-foreach-statement) to iterate over the results, and the conditional operator to pick a status symbol:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="ListAction":::

   For more detail, see [LINQ](../../linq/index.md).

1. Set the action for the `complete` command. This action uses LINQ's <xref:System.Linq.Enumerable.FirstOrDefault*?displayProperty=nameWithType> to find:

   - A matching task.
   - An [`is null` pattern](../functional/pattern-matching.md) to check whether the task exists.
   - A [`with` expression](../../language-reference/operators/with-expression.md) to create a new record instance by copying the existing values first, and then applying the properties you set in the `with` initializer (here, `IsComplete = true`). Records are immutable by default, so this copy-and-update pattern is how you produce a modified value.

   Because the action can fail (for example, the task ID doesn't exist), the action returns an integer error code that becomes the app's exit code:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="CompleteAction":::

1. Set the action for the `remove` command. This action follows the same look-up-and-validate pattern as `complete`. Use `FirstOrDefault` to find the task and `is null` to handle the missing case:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RemoveAction":::

1. Parse the command line and invoke the matched action:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="Invoke":::

   `rootCommand.Parse(args)` parses the input into a <xref:System.CommandLine.ParseResult>, and `.Invoke()` runs the action for the matched command. The return value is an exit code (0 for success).

## Add supporting types and data helpers

The app needs a few supporting pieces: [local functions](../../programming-guide/classes-and-structs/local-functions.md), an [`enum`](../../language-reference/builtin-types/enum.md), a [`record`](../../language-reference/builtin-types/record.md), and a serialization context. The following sections introduce each concept, explain why you'd choose it, and show the code. The app uses [System.Text.Json](../../../standard/serialization/system-text-json/overview.md) to store tasks as JSON (JavaScript Object Notation). File-based apps require type declarations to appear after all top-level statements and local functions.

1. Add the local functions that load and save tasks. A [local function](../../programming-guide/classes-and-structs/local-functions.md) is a method declared inside another function, including inside other local functions. Local functions keep helper logic close to the code that calls it, which improves readability because a reader doesn't have to jump to a separate class or file to understand the flow. Here, `LoadTasks` and `SaveTasks` encapsulate the file I/O that multiple command actions share, so the app writes the load/save logic once and reuses it:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="DataHelpers":::

1. Add the `Priority` enum and `TaskItem` record at the end of the file:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="EnumDefinition":::

   An [`enum`](../../language-reference/builtin-types/enum.md) is a value type that defines a fixed set of named constants backed by an integral type. You could represent priority levels with plain integers (0, 1, 2), but an `enum` is a better choice for several reasons: the compiler restricts assignments to the defined names, so a typo like `Hihg` causes a compile-time error instead of a silent bug; the names `Low`, `Medium`, and `High` make code more readable; and `System.CommandLine` automatically validates user input against the enum members, so you get free input checking.

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="RecordDefinition":::

   A [`record`](../../language-reference/builtin-types/record.md) is a type that the compiler equips with value-based equality and nondestructive mutation. A `record` is the right fit for `TaskItem` because task data is plain state with no complex behavior—you compare tasks by their values, not by reference identity. The compiler generates `Equals`, `GetHashCode`, `ToString`, and `with` expression support from the constructor parameters, so you get correct equality checks, easy debugging output, and immutable updates without writing boilerplate. Because records are immutable by default, you use a `with` expression to produce a modified copy (as the `complete` action does) rather than mutating the original, which prevents accidental side effects when different actions read and write the same list.

1. Add the JSON serialization context for AOT-compatible serialization:

   :::code language="csharp" source="./snippets/system-commandline/TaskCli.cs" id="JsonContext":::

   This class uses two [attributes](../../advanced-topics/reflection-and-attributes/index.md) (metadata annotations placed in square brackets above a declaration). The [`[JsonSourceGenerationOptions(WriteIndented = true)]`](../../../standard/serialization/system-text-json/source-generation.md) attribute tells the source generator to emit indented JSON for readability. The [`[JsonSerializable(typeof(List<TaskItem>))]`](../../../standard/serialization/system-text-json/source-generation.md) attribute tells the generator which type to create serialization code for. Together, these attributes enable [source-generated serialization](../../../standard/serialization/system-text-json/source-generation.md), which avoids run-time reflection and supports ahead-of-time (AOT) compilation.

## Test the application

Run the app with different inputs to exercise each subcommand.

1. View the autogenerated help:

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

- **Windows**: Delete `%LOCALAPPDATA%\taskcli-sample`.
- **macOS**: Delete `~/Library/Application Support/taskcli-sample`.
- **Linux**: Delete `~/.local/share/taskcli-sample`.

## Related content

- [System.CommandLine overview](../../../standard/commandline/index.md)
- [Tutorial: Get started with System.CommandLine](../../../standard/commandline/get-started-tutorial.md)
- [Command-line syntax overview](../../../standard/commandline/syntax.md)
- [System.CommandLine design guidance](../../../standard/commandline/design-guidance.md)
- [Tutorial: Build file-based apps](file-based-programs.md)
- [How to display command-line arguments](how-to-display-command-line-arguments.md)
