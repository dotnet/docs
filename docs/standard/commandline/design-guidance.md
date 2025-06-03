---
title: Command-line design guidance for System.CommandLine
description: "Provides guidance for designing a command-line interface."
ms.date: 06/16/2025
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line"
  - "System.CommandLine"
ms.topic: conceptual
---

# Design guidance

The following sections present guidance that we recommend you follow when designing a CLI. Think of what your app expects on the command line as similar to what a REST API server expects in the URL. Consistent rules for REST APIs are what make them readily usable to client app developers. In the same way, users of your command-line apps will have a better experience if the CLI design follows common patterns.

Once you create a CLI, it is hard to change, especially if your users have used your CLI in scripts they expect to keep running. The guidelines here were developed after the .NET CLI, and it doesn't always follow these guidelines. We are updating the .NET CLI where we can do so without introducing breaking changes. An example of this work is the new design for `dotnet new` in .NET 7.

## Symbols

### Commands and subcommands

If a command has subcommands, the command should function as an area or a grouping identifier for the subcommands, rather than specify an action. When you invoke the app, you specify the grouping command and one of its subcommands. For example, try to run `dotnet tool`, and you get an error message because the `tool` command only identifies a group of tool-related subcommands, such as `install` and `list`. You can run `dotnet tool install`, but `dotnet tool` by itself would be incomplete.

One of the ways that defining areas helps your users is that it organizes the help output.

Within a CLI, there is often an implicit area. For example, in the .NET CLI, the implicit area is the project, and in the Docker CLI, it is the image. As a result, you can use `dotnet build` without including an area. Consider whether your CLI has an implicit area. If it does, consider whether to allow the user to optionally include or omit it, as in `docker build` and `docker image build`. If you optionally allow the implicit area to be typed by your user, you also automatically have help and tab completion for this grouping of commands. Supply the optional use of the implicit group by defining two commands that perform the same operation.

### Options as parameters

Options should provide parameters to commands, rather than specifying actions themselves. This is a recommended design principle, although it isn't always followed by `System.CommandLine` (`--help` displays help information).

## Naming

### Short-form aliases

In general, we recommend that you minimize the number of short-form option aliases that you define.

In particular, avoid using any of the following aliases differently than their common usage in the .NET CLI and other .NET command-line apps:

* `-i` for `--interactive`.

  This option signals to the user that they may be prompted for inputs to questions that the command needs answered. For example, prompting for a username. Your CLI may be used in scripts, so use caution in prompting users who have not specified this switch.

* `-o` for `--output`.

  Some commands produce files as the result of their execution. This option should be used to help determine where those files should be located. In cases where a single file is created, this option should be a file path. In cases where many files are created, this option should be a directory path.

* `-v` for `--verbosity`.

  Commands often provide output to the user on the console; this option is used to specify the amount of output the user requests. For more information, see [The `--verbosity` option](#the---verbosity-option) later in this article.

There are also some aliases with common usage limited to the .NET CLI. You can use these aliases for other options in your apps, but be aware of the possibility of confusion.

* `-c` for `--configuration`

  This option often refers to a named Build Configuration, like `Debug` or `Release`. You can use any name you want for a configuration, but most tools are expecting one of those. This setting is often used to configure other properties in a way that makes sense for that configuration&mdash;for example, doing less code optimization when building the `Debug` configuration. Consider this option if your command has different modes of operation.

* `-f` for `--framework`

  This option is used to select a single [Target Framework Moniker (TFM)](../frameworks.md) to execute for, so if your CLI application has differing behavior based on which TFM is chosen, you should support this flag.

* `-p` for `--property`

  If your application eventually invokes MSBuild, the user will often need to customize that call in some way. This option allows for MSBuild properties to be provided on the command line and passed on to the underlying MSBuild call. If your app doesn't use MSBuild but needs a set of key-value pairs, consider using this same option name to take advantage of users' expectations.

* `-r` for `--runtime`

  If your application can run on different runtimes, or has runtime-specific logic, consider supporting this option as a way of specifying a [Runtime Identifier](../../core/rid-catalog.md). If your app supports `--runtime`, consider supporting `--os` and `--arch` also. These options let you specify just the OS or the architecture parts of the RID, leaving the part not specified to be determined from the current platform. For more information, see [dotnet publish](../../core/tools/dotnet-publish.md).

### Short names

Make names for commands, options, and arguments as short and easy to spell as possible. For example, if `class` is clear enough, don't make the command `classification`.

### Lowercase names

Define names in lowercase only, except you can make uppercase aliases to make commands or options case-insensitive.

### Kebab case names

Use [kebab case](https://en.wikipedia.org/wiki/Letter_case#Kebab_case) to distinguish words. For example, `--additional-probing-path`.

### Pluralization

Within an app, be consistent in pluralization. For example, don't mix plural and singular names for options that can have multiple values (maximum arity greater than one):

| Option names                                 | Consistency  |
|----------------------------------------------|--------------|
| `--additional-probing-paths` and `--sources` | ✔️           |
| `--additional-probing-path` and `--source`   | ✔️           |
| `--additional-probing-paths` and `--source`  | ❌           |
| `--additional-probing-path` and `--sources`  | ❌           |

### Verbs vs. nouns

Use verbs rather than nouns for commands that refer to actions (those without subcommands under them), for example: `dotnet workload remove`, not `dotnet workload removal`. And use nouns rather than verbs for options, for example: `--configuration`, not `--configure`.

## The `--verbosity` option

`System.CommandLine` applications typically offer a `--verbosity` option that specifies how much output is sent to the console. Here are the standard five settings:

* `Q[uiet]`
* `M[inimal]`
* `N[ormal]`
* `D[etailed]`
* `Diag[nostic]`

These are the standard names, but existing apps sometimes use `Silent` in place of `Quiet`, and `Trace`, `Debug`, or `Verbose` in place of `Diagnostic`.

Each app defines its own criteria that determine what gets displayed at each level. Typically, an app only needs three levels:

* Quiet
* Normal
* Diagnostic

If an app doesn't need five different levels, the option should still define the same five settings. In that case, `Minimal` and `Normal` will produce the same output, and `Detailed` and `Diagnostic` will likewise be the same. This allows your users to just type what they are familiar with, and the best fit will be used.

The expectation for `Quiet` is that no output is displayed on the console. However, if an app offers an interactive mode, the app should do one of the following:

* Display prompts for input when `--interactive` is specified, even if `--verbosity` is `Quiet`.
* Disallow the use of `--verbosity Quiet` and `--interactive` together.

Otherwise, the app will wait for input without telling the user what it's waiting for. It will appear that your application froze, and the user will have no idea the application is waiting for input.

If you define aliases, use `-v` for `--verbosity` and make `-v` without an argument an alias for `--verbosity Diagnostic`. Use `-q` for `--verbosity Quiet`.

## The .NET CLI and POSIX conventions

The .NET CLI does not consistently follow all POSIX conventions.

### Double-dash

Several commands in the .NET CLI have a special implementation of the double-dash token. In the case of `dotnet run`, `dotnet watch`, and `dotnet tool run`, tokens that follow `--` are passed to the app that is being run by the command. For example:

```dotnetcli
dotnet run --project ./myapp.csproj -- --message "Hello world!"
                                    ^^
```

In this example, the `--project` option is passed to the `dotnet run` command, and the `--message` option with its argument is passed as a command-line option to *myapp* when it runs.

The `--` token is not always required for passing options to an app that you run by using `dotnet run`. Without the double-dash, the `dotnet run` command automatically passes on to the app being run any options that aren't recognized as applying to `dotnet run` itself or to MSBuild. So the following command lines are equivalent because `dotnet run` doesn't recognize the arguments and options:

```dotnetcli
dotnet run -- quotes read --delay 0 --fg-color red
dotnet run quotes read --delay 0 --fg-color red
```

### Omission of the option-to-argument delimiter

The .NET CLI doesn't support the POSIX convention that lets you omit the delimiter when you are specifying a single-character option alias.

### Multiple arguments without repeating the option name

The .NET CLI doesn't accept multiple arguments for one option without repeating the option name.

### Boolean options

In the .NET CLI, some Boolean options result in the same behavior when you pass `false` as when you pass `true`. This behavior results when .NET CLI code that implements the option only checks for the presence or absence of the option, ignoring the value. An example is `--no-restore` for the `dotnet build` command. Pass `--no-restore false` and the restore operation will be skipped the same as when you specify `--no-restore true` or `--no-restore`.

### Kebab case

In some cases, the .NET CLI doesn't use kebab case for command, option, or argument names. For example, there is a .NET CLI option that is named [`--additionalprobingpath`](../../core/tools/dotnet.md#additionalprobingpath) instead of `--additional-probing-path`.


## See also

* [Open-source CLI design guidance](https://clig.dev/)
* [GNU standards](https://www.gnu.org/software/libc/manual/html_node/Argument-Syntax.html)
