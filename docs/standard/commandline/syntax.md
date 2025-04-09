---
title: Command-line syntax overview for System.CommandLine
description: "An introduction to the command-line syntax that the System.CommandLine library recognizes by default. Mentions exceptions where syntax in the .NET CLI differs. Provides guidance for designing a command-line interface."
ms.date: 05/24/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: conceptual
---

# Command-line syntax overview for System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

This article explains the command-line syntax that `System.CommandLine` recognizes. The information will be useful to users as well as developers of .NET command-line apps, including the [.NET CLI](../../core/tools/index.md).

## Tokens

`System.CommandLine` parses command-line input into *tokens*, which are strings delimited by spaces. For example, consider the following command line:

```dotnetcli
dotnet tool install dotnet-suggest --global --verbosity quiet
```

This input is parsed by the `dotnet` application into tokens `tool`, `install`, `dotnet-suggest`, `--global`, `--verbosity`, and `quiet`.

Tokens are interpreted as commands, options, or arguments. The command-line app that is being invoked determines how the tokens after the first one are interpreted. The following table shows how `System.CommandLine` interprets the preceding example:

| Token            | Parsed as                         |
|------------------|-----------------------------------|
| `tool`           | Subcommand                        |
| `install`        | Subcommand                        |
| `dotnet-suggest` | Argument for install command      |
| `--global`       | Option for install command        |
| `--verbosity`    | Option for install command        |
| `quiet`          | Argument for `--verbosity` option |

A token can contain spaces if it's enclosed in quotation marks (`"`). Here's an example:

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

## Options

An option is a named parameter that can be passed to a command. [POSIX](https://en.wikipedia.org/wiki/POSIX) CLIs typically prefix the option name with two hyphens (`--`). The following example shows two options:

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

`System.CommandLine` supports both POSIX and Windows prefix conventions. When you [configure an option](define-commands.md#define-options), you specify the option name including the prefix.

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

Arguments can have expected types, and `System.CommandLine` displays an error message if an argument can't be parsed into the expected type. For example, the following command errors because "silent" isn't one of the valid values for `--verbosity`:

```dotnetcli
dotnet build --verbosity silent
```

```output
Cannot parse argument 'silent' for option '-v' as expected type 'Microsoft.DotNet.Cli.VerbosityOptions'. Did you mean one of the following?
Detailed
Diagnostic
Minimal
Normal
Quiet
```

Arguments also have expectations about how many values can be provided. Examples are provided in the [section on argument arity](#argument-arity).

## Order of options and arguments

You can provide options before arguments or arguments before options on the command line. The following commands are equivalent:

```dotnetcli
dotnet add package System.CommandLine --prerelease
dotnet add package --prerelease System.CommandLine
```

Options can be specified in any order. The following commands are equivalent:

```dotnetcli
dotnet add package System.CommandLine --prerelease --no-restore --source https://api.nuget.org/v3/index.json
dotnet add package System.CommandLine --source https://api.nuget.org/v3/index.json --no-restore --prerelease
```

When there are multiple arguments, the order does matter. The following commands are not necessarily equivalent:

```console
myapp argument1 argument2
myapp argument2 argument1
```

These commands pass a list with the same values to the command handler code, but they differ in the order of the values, which could lead to different results.

## Aliases

In both POSIX and Windows, it's common for some commands and options to have aliases. These are usually short forms that are easier to type. Aliases can also be used for other purposes, such as to [simulate case-insensitivity](#case-sensitivity) and to [support alternate spellings of a word](define-commands.md#define-aliases).

POSIX short forms typically have a single leading hyphen followed by a single character. The following commands are equivalent:

```dotnetcli
dotnet build --verbosity quiet
dotnet build -v quiet
```

The [GNU standard](https://www.gnu.org/software/libc/manual/html_node/Argument-Syntax.html) recommends automatic aliases. That is, you can enter any part of a long-form command or option name and it will be accepted. This behavior would make the following command lines equivalent:

```dotnetcli
dotnet publish --output ./publish
dotnet publish --outpu ./publish
dotnet publish --outp ./publish
dotnet publish --out ./publish
dotnet publish --ou ./publish
dotnet publish --o ./publish
```

`System.CommandLine` doesn't support automatic aliases.

## Case sensitivity

Command and option names and aliases are case-sensitive by default according to POSIX convention, and `System.CommandLine` follows this convention. If you want your CLI to be case insensitive, define aliases for the various casing alternatives. For example, `--additional-probing-path` could have aliases `--Additional-Probing-Path` and `--ADDITIONAL-PROBING-PATH`.

In some command-line tools, a difference in casing specifies a difference in function. For example, [`git clean -X`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--X) behaves differently than [`git clean -x`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--x). The .NET CLI is all lowercase.

Case sensitivity does not apply to argument values for options that are based on enums. Enum names are matched regardless of casing.

## The `--` token

POSIX convention interprets the double-dash (`--`) token as an escape mechanism. Everything that follows the double-dash token is interpreted as arguments for the command. This functionality can be used to submit arguments that look like options, since it prevents them from being interpreted as options.

Suppose *myapp* takes a `message` argument, and you want the value of `message` to be `--interactive`. The following command line might give unexpected results.

```console
myapp --interactive
```

If `myapp` doesn't have an `--interactive` option, the `--interactive` token is interpreted as an argument. But if the app does have an `--interactive` option, this input will be interpreted as referring to that option.

The following command line uses the double-dash token to set the value of the `message` argument to "--interactive":

```console
myapp -- --interactive
      ^^
```

`System.CommandLine` supports this double-dash functionality.

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

System.CommandLine supports this syntax by default.

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

`System.CommandLine` has an <xref:System.CommandLine.ArgumentArity> struct for defining arity, with the following values:

* <xref:System.CommandLine.ArgumentArity.Zero> - No values allowed.
* <xref:System.CommandLine.ArgumentArity.ZeroOrOne> - May have one value, may have no values.
* <xref:System.CommandLine.ArgumentArity.ExactlyOne> - Must have one value.
* <xref:System.CommandLine.ArgumentArity.ZeroOrMore> - May have one value, multiple values, or no values.
* <xref:System.CommandLine.ArgumentArity.OneOrMore> - May have multiple values, must have at least one value.

Arity can often be inferred from the type. For example, an `int` option has arity of `ExactlyOne`, and a `List<int>` option has arity `OneOrMore`.

### Option overrides

If the arity maximum is 1, `System.CommandLine` can still be configured to accept multiple instances of an option. In that case, the last instance of a repeated option overwrites any earlier instances. In the following example, the value 2 would be passed to the `myapp` command.

```console
myapp --delay 3 --message example --delay 2
```

### Multiple arguments

If the arity maximum is more than one, `System.CommandLine` can be configured to accept multiple arguments for one option without repeating the option name.

In the following example, the list passed to the `myapp` command would contain "a", "b", "c", and "d":

```console
myapp --list a b c --list d
```

## Option bundling

POSIX recommends that you support *bundling* of single-character options, also known as *stacking*. Bundled options are single-character option aliases specified together after a single hyphen prefix. Only the last option can specify an argument. For example, the following command lines are equivalent:

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

If `true` or `false` is passed for an option having a `bool` argument, it's parsed as expected. But an option whose argument type is `bool` typically doesn't require an argument to be specified. Boolean options, sometimes called "flags", typically have an [arity](#argument-arity) of <xref:System.CommandLine.ArgumentArity.ZeroOrOne>. The presence of the option name on the command line, with no argument following it, results in a default value of `true`. The absence of the option name in command-line input results in a value of `false`. If the `myapp` command prints out the value of a Boolean option named `--interactive`, the following input creates the following output:

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

## The --help option

Command-line apps typically provide an option to display a brief description of the available commands, options, and arguments. `System.CommandLine` automatically generates help output. For example:

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

Help output doesn't necessarily show all available commands, arguments, and options. Some of them may be *hidden*, which means they don't show up in help output but they can be specified on the command line.

## The --version option

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

To use a response file, enter the file name prefixed by an `@` sign wherever in the line you want to insert commands, options, and arguments. The *.rsp* file extension is a common convention, but you can use any file extension.

The following lines are equivalent:

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

Here are syntax rules that determine how the text in a response file is interpreted:

* Tokens are delimited by spaces. A line that contains *Good morning!* is treated as two tokens, *Good* and *morning!*.
* Multiple tokens enclosed in quotes are interpreted as a single token. A line that contains *"Good morning!"* is treated as one token, *Good morning!*.
* Any text between a `#` symbol and the end of the line is treated as a comment and ignored.
* Tokens prefixed with `@` can reference additional response files.
* The response file can have multiple lines of text. The lines are concatenated and interpreted as a sequence of tokens.

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

* It's a token on the command line that comes after the app's name but before any subcommands or options.
* It's enclosed in square brackets.
* It doesn't contain spaces.

An unrecognized directive is ignored without causing a parsing error.

A directive can include an argument, separated from the directive name by a colon.

 The following directives are built in:

* [`[parse]`](#the-parse-directive)
* [`[suggest]`](#the-suggest-directive)

### The `[parse]` directive

Both users and developers may find it useful to see how an app will interpret a given input. One of the default features of a `System.CommandLine` app is the `[parse]` directive, which lets you preview the result of parsing command input. For example:

```console
myapp [parse] --delay not-an-int --interactive --file filename.txt extra
```

```output
![ myapp [ --delay !<not-an-int> ] [ --interactive <True> ] [ --file <filename.txt> ] *[ --fgcolor <White> ] ]   ???--> extra
```

In the preceding example:

* The command (`myapp`), its child options, and the arguments to those options are grouped using square brackets.
* For the option result `[ --delay !<not-an-int> ]`, the `!` indicates a parsing error. The value `not-an-int` for an `int` option can't be parsed to the expected type. The error is also flagged by `!` in front of the command that contains the errored option: `![ myapp...`.
* For the option result `*[ --fgcolor <White> ]`, the option wasn't specified on the command line, so the configured default was used. `White` is the effective value for this option. The asterisk indicates that the value is the default.
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

## Design guidance

The following sections present guidance that we recommend you follow when designing a CLI. Think of what your app expects on the command line as similar to what a REST API server expects in the URL. Consistent rules for REST APIs are what make them readily usable to client app developers. In the same way, users of your command-line apps will have a better experience if the CLI design follows common patterns.

Once you create a CLI it is hard to change, especially if your users have used your CLI in scripts they expect to keep running. The guidelines here were developed after the .NET CLI, and it doesn't always follow these guidelines. We are updating the .NET CLI where we can do it without introducing breaking changes. An example of this work is the new design for `dotnet new` in .NET 7.

### Commands and subcommands

If a command has subcommands, the command should function as an area, or a grouping identifier for the subcommands, rather than specify an action. When you invoke the app, you specify the grouping command and one of its subcommands. For example, try to run `dotnet tool`, and you get an error message because the `tool` command only identifies a group of tool-related subcommands, such as `install` and `list`. You can run `dotnet tool install`, but `dotnet tool` by itself would be incomplete.

One of the ways that defining areas helps your users is that it organizes the help output.

Within a CLI there is often an implicit area. For example, in the .NET CLI, the implicit area is the project and in the Docker CLI it is the image. As a result, you can use `dotnet build` without including an area. Consider whether your CLI has an implicit area. If it does, consider whether to allow the user to optionally include or omit it as in `docker build` and `docker image build`. If you optionally allow the implicit area to be typed by your user, you also automatically have help and tab completion for this grouping of commands. Supply the optional use of the implicit group by defining two commands that perform the same operation.

### Options as parameters

Options should provide parameters to commands, rather than specifying actions themselves. This is a recommended design principle although it isn't always followed by `System.CommandLine` (`--help` displays help information).

### Short-form aliases

In general, we recommend that you minimize the number of short-form option aliases that you define.

In particular, avoid using any of the following aliases differently than their common usage in the .NET CLI and other .NET command-line apps:

* `-i` for `--interactive`.

  This option signals to the user that they may be prompted for inputs to questions that the command needs answered. For example, prompting for a username. Your CLI may be used in scripts, so use caution in prompting users that have not specified this switch.

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

  If your application can run on different runtimes, or has runtime-specific logic, consider supporting this option as a way of specifying a [Runtime Identifier](../../core/rid-catalog.md). If your app supports --runtime, consider supporting `--os` and `--arch` also. These options let you specify just the OS or the architecture parts of the RID, leaving the part not specified to be determined from the current platform. For more information, see [dotnet publish](../../core/tools/dotnet-publish.md).

### Short names

Make names for commands, options, and arguments as short and easy to spell as possible. For example, if `class` is clear enough don't make the command `classification`.

### Lowercase names

Define names in lowercase only, except you can make uppercase aliases to make commands or options case insensitive.

### Kebab case names

Use [kebab case](https://en.wikipedia.org/wiki/Letter_case#Kebab_case) to distinguish words. For example, `--additional-probing-path`.

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

### The `--verbosity` option

`System.CommandLine` applications typically offer a `--verbosity` option that specifies how much output is sent to the console. Here are the standard five settings:

* `Q[uiet]`
* `M[inimal]`
* `N[ormal]`
* `D[etailed]`
* `Diag[nostic]`

These are the standard names, but existing apps sometimes use `Silent` in place of `Quiet`, and `Trace`, `Debug`, or `Verbose` in place of `Diagnostic`.

Each app defines its own criteria that determine what gets displayed at each level. Typically an app only needs three levels:

* Quiet
* Normal
* Diagnostic

If an app doesn't need five different levels, the option should still define the same five settings. In that case, `Minimal` and `Normal` will produce the same output, and `Detailed` and `Diagnostic` will likewise be the same. This allows your users to just type what they are familiar with, and the best fit will be used.

The expectation for `Quiet` is that no output is displayed on the console. However, if an app offers an interactive mode, the app should do one of the following alternatives:

* Display prompts for input when `--interactive` is specified, even if `--verbosity` is `Quiet`.
* Disallow the use of `--verbosity Quiet` and `--interactive` together.

Otherwise the app will wait for input without telling the user what it's waiting for. It will appear that your application froze and the user will have no idea the application is waiting for input.

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

In the .NET CLI, some Boolean options result in the same behavior when you pass `false` as when you pass `true`. This behavior results when .NET CLI code that implements the option only checks for the presence or absence of the option, ignoring the value. An example is `--no-restore` for the `dotnet build` command. Pass `no-restore false` and the restore operation will be skipped the same as when you specify `no-restore true` or `no-restore`.

### Kebab case

In some cases, the .NET CLI doesn't use kebab case for command, option, or argument names. For example, there is a .NET CLI option that is named [`--additionalprobingpath`](../../core/tools/dotnet.md#additionalprobingpath) instead of `--additional-probing-path`.

## See also

* [Open-source CLI design guidance](https://clig.dev/)
* [GNU standards](https://www.gnu.org/software/libc/manual/html_node/Argument-Syntax.html)
* [System.CommandLine overview](index.md)
* [Tutorial: Get started with System.CommandLine](get-started-tutorial.md)
