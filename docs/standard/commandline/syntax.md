---
title: Command-line syntax overview for System.CommandLine
description: "An introduction to the command-line syntax that the System.CommandLine library recognizes by default. Mentions exceptions where syntax in the .NET CLI differs. Provides guidance for designing a command-line interface."
ms.date: 02/03/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: conceptual
---

# Command-line syntax overview for System.CommandLine

This article explains the command-line syntax that `System.CommandLine` recognizes. The information will be useful to users as well as developers of .NET command-line apps, including the [.NET CLI](../../core/tools/index.md).

Several sections are devoted to guidance for designing an app's command-line interface. Think of what your app expects on the command line as similar to what a REST API server expects in the URL. Consistent rules for REST APIs are what make them readily usable to client app developers. In the same way, users of your command-line apps will have a better experience if the CLI design follows common patterns.

## Tokens

`System.CommandLine` parses command-line input into *tokens*, which are strings delimited by spaces. For example, consider the following command line:

```dotnetcli
dotnet tool install dotnet-suggest --global --verbosity quiet
```

This input is parsed into tokens `tool`, `install`, `dotnet-suggest`, `--global`, `--verbosity`, and `quiet`.

Tokens are interpreted as commands, options, or arguments. The command-line app that is being invoked determines how the tokens after the first one are interpreted. The first token identifies the app. The following table shows how `System.CommandLine` interprets the preceding example:

| Token            | Parsed as                         |
|------------------|-----------------------------------|
| `dotnet`         | Root command - runs *dotnet.exe*  |
| `tool`           | Subcommand                        |
| `install`        | Subcommand                        |
| `dotnet-suggest` | Argument for install command      |
| `--global`       | Option for install command        |
| `--verbosity`    | Option for install command        |
| `quiet`          | Argument for `--verbosity` option |

A token can contains spaces if it's enclosed in quotation marks (`"`). Here's an example:

```console
dotnet tool search "ef migrations add"
```

## Commands

A *command* in command-line input is a token that specifies an action or defines a group of related actions. For example:

* In `dotnet run`, `run` is a command that specifies an action.
* In `dotnet tool install`, `install` is a command that specifies an action, and `tool` is a command that specifies a group of related commands. There are other tool-related commands, such as `tool uninstall`, `tool list`, and `tool update`.

### Root commands

The *root command* is the one that specifies the name of the app's executable. For example, the `dotnet` command specifies the *dotnet.exe* executable.

### Subcommands

Most command-line apps support *subcommands*, also known as *verbs*. For example, the `dotnet` command has a `run` subcommand that you invoke by entering `dotnet run`.

Subcommands can have their own subcommands. In `dotnet tool install`, `install` is a subcommand of `tool`.

### Design guidance for commands

If a command has subcommands, the command should function as an area, or a grouping identifier for the subcommands, rather than specify an action. When you invoke the app, you have to specify the grouping command and one of its subcommands. For example, the output from entering `dotnet tool` is an error message because the `tool` command only identifies a group of tool-related subcommands, such as `install` and `list`. You can run `dotnet tool install`, but `dotnet tool` by itself would be incomplete.

Some .NET CLI commands don't currently follow this recommended pattern. For example, `dotnet new` can do several different actions such as list, search, or install templates, but there are currently no subcommands under `new`.

## Options

An option is a named parameter that can be passed to a command. The [POSIX](https://en.wikipedia.org/wiki/POSIX) convention is to prefix the option name with two hyphens (`--`). The following example shows two options:

```dotnetcli
dotnet tool update dotnet-suggest --verbosity quiet --global
                                  ^---------^       ^------^
```

As this example illustrates, the value of the option may be explicit (`quiet` for `--verbosity`) or implicit (nothing follows `--global`). Options that have no value specified are typically Boolean parameters that default to `true` if the option is specified on the command line.

For some Windows command-line apps, you identify an option by using a leading slash (`/`) with the option name. For example:

```console
msbuild /version
        ^------^
```

The POSIX style (two hyphens before long-form option names) is the default for `System.CommandLine`, but the library can be configured to use other prefixes.

### Design guidance for options

Options should provide parameters to commands, rather than specifying actions themselves. This is a recommended design principle although it isn't always followed by `System.CommandLine` (`--help` displays help information) or the .NET CLI (`--list`, `--install`, and others function as commands under `dotnet new`).

## Arguments

An argument is a value passed to an option or a command. The following examples show an argument for the `verbosity` option and an argument for the `build` command.

```console
dotnet tool update dotnet-suggest --verbosity quiet --global
                                              ^---^
```

```console
dotnet build myapp.csproj
             ^----------^
```

Arguments can have default values that apply if no argument is explicitly provided. For example, many options are implicitly Boolean parameters with a default of `true` when the option name is in the command line. The following command-line examples are equivalent:

```dotnetcli
dotnet tool update dotnet-suggest --global
                                  ^------^

dotnet tool update dotnet-suggest --global true
                                  ^-----------^
```

Some options have required arguments. For example in the .NET CLI, `--output` requires a folder name argument. If the argument is not provided, the command fails.

Arguments can have expected types, and the app errors if the argument can't be parsed into the expected type. For example, the following command errors because "silent" isn't one of the valid values for `--verbosity`:

```dotnetcli
dotnet build --verbosity silent
```

```output
System.InvalidOperationException: Cannot parse
argument 'silent' for option '-v' as expected type
Microsoft.DotNet.Cli.VerbosityOptions.
```

Arguments also have expectations about how many values can be provided. Examples are provided in the [section on argument arity](#argument-arity).

## Aliases

In both POSIX and Windows, it's common for some commands and options to have aliases. These are usually short forms that are easier to type. POSIX short forms typically have a single leading hyphen followed by a single character. The following commands are equivalent:

```dotnetcli
dotnet build --verbosity quiet
dotnet build -v quiet
```

### Design guidance for aliases

Avoid causing confusion by using any of the following aliases differently than their common usage in the .NET CLI and other .NET command-line apps:

* `-i` for `--interactive`.
* `-o` for `--output`.
* `-v` for `--verbosity`.

There are also some aliases with common usage limited to the .NET CLI. You can use these for other options in your apps, but be aware of the possibility of confusion.

* `-c` for `--configuration`
* `-f` for `--framework`
* `-n` for `--no-restore`
* `-p` for `--property`
* `-r` for `--runtime`

In general, we recommend that you minimize the number of short-form option aliases that you define.

## Option-argument delimiters

`System.CommandLine` lets you use a space, '=', or ':' as the delimiter between an option name and its argument. For example, the following commands are equivalent:

```dotnetcli
dotnet build -v quiet
dotnet build -v=quiet
dotnet build -v:quiet
```

A POSIX convention lets you omit the delimiter when you are specifying a single-character option alias. For example, the following commands are equivalent:

```console
myapp -vquiet
myapp -v quiet
```

System.CommandLine supports this syntax by default, but many of the .NET CLI commands and options don't support it.

## Argument arity

The *arity* of an option or command's argument is the number of values that can be passed if that option or command is specified.

Arity is expressed with a minimum value and a maximum value, as the following table illustrates:

| Min | Max     | Example validity | Example                     |
|-----|---------|------------------|-----------------------------|
| 0   | 0       | Valid:           | --file                      |
|     |         | Invalid:         | --file a.json               |
|     |         | Invalid:         | --file a.json --file b.json |
| 0   | 1       | Valid:           | --flag                      |
|     |         | Valid:           | --flag true                 |
|     |         | Valid:           | --flag false                |
|     |         | Invalid:         | --flag false --flag false   |
| 1   | 1       | Valid:           | --file a.json               |
|     |         | Invalid:         | --file                      |
|     |         | Invalid:         | --file a.json --file b.json |
| 0   | *n*     | Valid:           | --file                      |
|     |         | Valid:           | --file a.json               |
|     |         | Valid:           | --file a.json --file b.json |
| 1   | *n*     | Valid:           | --file a.json               |
|     |         | Valid:           | --file a.json b.json        |
|     |         | Invalid:         | --file                      |

### Option overrides

If the arity maximum is 1, `System.CommandLine` can still be configured to accept multiple instances of an option. In that case, the last instance of a repeated option overwrites any earlier instances. In the following example, the value 2 would be passed to the `myapp` command.

```console
myapp --delay 3 --message example --delay 2
```

### Without repeating the option name

`System.CommandLine` can be configured to accept multiple arguments for one option without repeating the option name.

In the following example, the list passed to the `myapp` command would contain "a", "b", "c", and "d":

```console
myapp --list a b c --list d
```

This syntax pattern isn't enabled for .NET CLI commands.

## Option bundling

POSIX recommends that you support *bundling* of single-character options, also known as *stacking*. Bundled options are single-character option aliases specified together after a single hyphen prefix. The options before the last one in a bundle can't have required arguments. For example, the following command lines are equivalent:

```console
git clean -f -d -x
git clean -fdx
```

If an argument is provided after an option bundle, it applies to the last option in the bundle. The following command lines are equivalent:

```console
myapp -a -b -c arg
myapp -abc arg
```

In both variants in this example, the argument `arg` would apply only to the option `-c`.

## Boolean options (flags)

If `true` or `false` is passed for an option having a `bool` argument, it's parsed as expected. But an option whose argument type is `bool` typically doesn't require an argument to be specified. Boolean options, sometimes called "flags", typically have an [arity](#argument-arity) of `ArgumentArity.ZeroOrOne`. The presence of the option name on the command line, with no argument following it, results in a default value of `true`. The absence of the option name in command-line input results in a value of `false`. If the `myapp` command prints out the value of a Boolean option named `--interactive`, the following input creates the following output:

```console
myapp
myapp --interactive
myapp --interactive false
myapp --interactive true
```

```output
False
True
False
True
```

In the .NET CLI, this pattern doesn't always hold true. Some Boolean options result in the same behavior when you pass `false` as when you pass `true`. This behavior results when .NET CLI code that implements the option only checks for the presence or absence of the option, ignoring the value. An example is `--no-restore` for the `dotnet build` command. Pass `no-restore false` and the restore operation will be skipped the same as when you specify `no-restore true` or `no-restore`.

## Design guidance for command and option names

Make command names as short and easy to spell as possible. For example, if `class` is clear enough don't make the command `classification`.

### Case sensitivity

Names are case-sensitive by default according to POSIX convention, and `System.CommandLine` follows this convention. In some command-line tools, a difference in casing specifies a difference in function. For example, [`git clean -X`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--X) behaves differently than [`git clean -x`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--x). For .NET apps, we recommend that you define names in lowercase. Don't make behavior vary based solely on case. If you want your CLI to be case insensitive, define aliases for the various casing alternatives. For example, `--additional-probing-path` could have aliases `--Additional-Probing-Path` and `--ADDITIONAL-PROBING-PATH`.

Use [kebab case](https://en.wikipedia.org/wiki/Letter_case#Kebab_case) to distinguish words. For example, the .NET CLI option that is defined as [`--additionalprobingpath`](../../core/tools/dotnet.md#runtime-options) should have been defined as `--additional-probing-path`.

### Pluralization

Within an app, be consistent in pluralization. For example, don't mix plural and singular names for options that can have multiple values (maximum arity greater than one):

| Option names                                 | Consistency  |
|----------------------------------------------|--------------|
| `--additional-probing-paths` and `--sources` | ✔️          |
| `--additional-probing-path` and `--source`   | ✔️          |
| `--additional-probing-paths` and `--source`  | ❌          |
| `--additional-probing-path` and `--sources`  | ❌          |

### Verbs vs. nouns

Use verbs rather than nouns for commands that refer to actions (those without subcommands under them), for example: `dotnet workload remove`, not `dotnet workload removal`. And use nouns rather than verbs for options, for example: `--configuration`, not `--configure`.

## Get help

Command-line apps typically provide an option to display a brief description of the available commands, options, and arguments. For example:

```dotnetcli
dotnet list --help
```

```output
Description:
  List references or packages of a .NET project.

Usage:
  dotnet [options] list [<PROJECT | SOLUTION>] [command]

Arguments:
  <PROJECT | SOLUTION>  The project or solution file to operate on. If a file is not specified, the command will search the current directory for one.

Options:
  -?, -h, --help  Show command line help.

Commands:
  package    List all package references of the project or solution.
  reference  List all project-to-project references of the project.
```

App users might be accustomed to different ways to request help on different platforms, so apps built on `System.CommandLine` respond to many ways of requesting help. The following commands are all equivalent:

```dotnetcli
dotnet --help
dotnet -h
dotnet /h
dotnet -?
dotnet /?
```

Specific commands, options, or arguments may be *hidden*, which means they don't show up in help output but they can be specified on the command line.

## Get app version

Apps built on `System.CommandLine` automatically provide the version number in response to the `--version` option used with the root command. For example:

```dotnetcli
dotnet --version
```

```output
6.0.100
```

## Response files

A *response file* is a file that contains a set of [tokens](syntax.md#tokens) for a command-line app. Response files are a feature of `System.CommandLine` that is useful in two scenarios:

* To invoke a command-line app by specifying input that is longer than the character limit of the terminal.
* To invoke the same command repeatedly without retyping the whole line.

To use a response file, enter the file name prefixed by an `@` sign wherever in the line you want to insert commands, options, and arguments. The following lines are equivalent:

```dotnetcli
dotnet build --no-restore --output ./build-output/
dotnet @sample1.rsp
dotnet build @sample2.rsp --output ./build-output/
```

Contents of *sample1.rsp*:

```console
build
--no-restore
--output
./build-output/
```

Contents of *sample2.rsp*:

```console
--no-restore
```

By default, tokens in a response file are delimited by line breaks, not by spaces. A response file line that includes embedded spaces is passed to the app as a single token with embedded spaces.

## Directives

`System.CommandLine` introduces a syntactic element called a *directive*. The `[parse]` directive is an example. When you include `[parse]` after the app's name, `System.CommandLine` displays a diagram of the parse result instead of invoking the command-line app:

```dotnetcli
dotnet [parse] build --no-restore --output ./build-output/
       ^-----^
```

```output
[ dotnet [ build [ --no-restore <True> ] [ --output <./build-output/> ] ] ]
```

The purpose of directives is to provide cross-cutting functionality that can apply across command-line apps. Because directives are syntactically distinct from the app's own syntax, they can provide functionality that applies across apps.

A directive must conform to the following syntax rules:

* It's a token on the command line coming after the app's name but before any subcommands or options.
* It's enclosed in square brackets.
* It doesn't contain spaces.

An unrecognized directive is ignored without causing a parsing error.

A directive can include an argument, separated from the directive name by a colon.

 The following directives are built in:

* `[parse]`
* `[suggest]`

### The `[parse]` directive

Both users and developers may find it useful to see how an app will interpret a given input. One of the default features of a `System.CommandLine` app is the `[parse]` directive, which lets you preview the result of parsing command input. For example:

```console
myapp [parse] --delay not-an-int --interactive --file file.txt extra
```

```output
![ myapp [ --delay !<not-an-int> ] [ --interactive <True> ] [ --file <filename.txt> ] *[ --fgcolor <White> ] ]   ???--> extra
```

In the preceding example:

* The command (`myapp`), its child options, and the arguments to those options are grouped using square brackets.
* For the option result `![ --delay <not-an-int> ]`, the `!` indicates a parsing error. The value `not-an-int` for an `int` option can't be parsed to the expected type. The error is also flagged by `!` in front of the command that contains the errored option: `![ myapp...`.
* For the option result `*[ --fgcolor <White> ]`, the option wasn't specified on the command line, so the configured default was used. `White` is the effective value for this option.
* `???-->` points to input that wasn't matched to any of the app's commands or options.

### The `[suggest]` directive

The `[suggest]` directive lets you search for commands when you don't know the exact command.

```dotnetcli
dotnet [suggest] buil
```

```output
build
build-server
msbuild
```

## See also

* [Open-source CLI design guidance](https://clig.dev/)
* [POSIX command-line standards](https://www.gnu.org/software/libc/manual/html_node/Argument-Syntax.html)
* [System.CommandLine overview](index.md)
* [Tutorial: Get started with System.CommandLine](get-started-tutorial.md)
