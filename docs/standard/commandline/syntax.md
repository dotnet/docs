---
title: Command-line syntax overview for System.CommandLine
description: "An introduction to the command-line syntax that the System.CommandLine library recognizes by default. Shows how to define commands, options, and arguments."
ms.date: 05/24/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: conceptual
---

# Syntax overview: commands, options, and arguments

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

<xref:System.CommandLine.Command> is the general-purpose class for any command or subcommand, while <xref:System.CommandLine.RootCommand> is a specialized version intended for the application's root entry point, inheriting all features of <xref:System.CommandLine.Command> but adding root-specific behavior and defaults, such as [Help option](help.md#help-option), [Version option](#version-option) and [Suggest directive](#suggest-directive).

### Subcommands

Most command-line apps support *subcommands*, also known as *verbs*. For example, the `dotnet` command has a `run` subcommand that you invoke by entering `dotnet run`.

Subcommands can have their own subcommands. In `dotnet tool install`, `install` is a subcommand of `tool`.

You can add subcommands as shown in the following example:

:::code language="csharp" source="snippets/define-symbols/csharp/Program.cs" id="definesubcommands" :::

The innermost subcommand in this example can be invoked like this:

```console
myapp sub1 sub1a
```

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

`System.CommandLine` supports both POSIX and Windows prefix conventions.

When you configure an option, you specify the option name including the prefix:

:::code language="csharp" source="snippets/define-symbols/csharp/Program.cs" id="defineoptions" :::

To add an option to a command and recursively to all of its subcommands, use the <xref:System.CommandLine.Symbol.Recursive> property.

### Required Options

Some options have required arguments. For example in the .NET CLI, `--output` requires a folder name argument. If the argument is not provided, the command fails. To make an option required, set its <xref:System.CommandLine.Symbol.Required> property to `true`, as shown in the following example:

:::code language="csharp" source="snippets/define-symbols/csharp/Program.cs" id="requiredoption" :::

If a required option has a default value (specified via `DefaultValueFactory` property), the option doesn't have to be specified on the command line. In that case, the default value provides the required option value.

## Arguments

An argument is an unnamed parameter that can be passed to a command. The following example shows an argument for the `build` command.

```console
dotnet build myapp.csproj
             ^----------^
```

When you configure an argument, you specify the argument name (it's not used for parsing, but it can be used for getting parsed values by name or displaying help) and type:

:::code language="csharp" source="snippets/define-symbols/csharp/Program.cs" id="definearguments" :::

## Default Values

Both arguments and options can have default values that apply if no argument is explicitly provided. For example, many options are implicitly Boolean parameters with a default of `true` when the option name is in the command line. The following command-line examples are equivalent:

```dotnetcli
dotnet tool update dotnet-suggest --global
                                  ^------^

dotnet tool update dotnet-suggest --global true
                                  ^-----------^
```

An argument that is defined without a default value is treated as a required argument.

## Parse Errors

Options and arguments have expected types, and an error is produced when the value can't be parsed. For example, the following command errors because "silent" isn't one of the valid values for `--verbosity`:

```dotnetcli
dotnet build --verbosity silent
```

:::code language="csharp" source="snippets/define-symbols/csharp/Program.cs" id="parseerrors" :::

```output
Argument 'silent' not recognized. Must be one of:
        'quiet'
        'minimal'
        'normal'
        'detailed'
        'diagnostic'
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

When there are multiple arguments, the order does matter. The following commands are not equivalent, they differ in the order of the values, which could lead to different results:

```console
myapp argument1 argument2
myapp argument2 argument1
```

## Aliases

In both POSIX and Windows, it's common for some commands and options to have aliases. These are usually short forms that are easier to type. Aliases can also be used for other purposes, such as to [simulate case-insensitivity](#case-sensitivity) and to support alternate spellings of a word.

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

`System.CommandLine` doesn't support automatic aliases, each alias needs to be specified in explicit way. Both commands and options expose `Aliases` property, but `Option` has a constructor that accepts aliases as parameters, so you can define an option with multiple aliases in a single line:

:::code language="csharp" source="snippets/define-symbols/csharp/Program.cs" id="definealiases" :::

We recommend that you minimize the number of option aliases that you define, and avoid defining certain aliases in particular. For more information, see [Short-form aliases](design-guidance.md#short-form-aliases).

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

You can explicitly set arity by using the `Arity` property, but in most cases that is not necessary. `System.CommandLine` automatically determines the argument arity based on the argument type:

| Argument type    | Default arity              |
|------------------|----------------------------|
| `Boolean`        | `ArgumentArity.ZeroOrOne`  |
| Collection types | `ArgumentArity.ZeroOrMore` |
| Everything else  | `ArgumentArity.ExactlyOne` |

### Option overrides

If the arity maximum is 1, `System.CommandLine` can still be configured to accept multiple instances of an option. In that case, the last instance of a repeated option overwrites any earlier instances. In the following example, the value 2 would be passed to the `myapp` command.

```console
myapp --delay 3 --message example --delay 2
```

### Multiple arguments

By default, when you call a command, you can repeat an option name to specify multiple arguments for an option that has maximum [arity](#argument-arity) greater than one.

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

## Version option

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

`System.CommandLine` introduces a syntactic element called a *directive*. The `[diagram]` directive is an example. When you include `[diagram]` after the app's name, `System.CommandLine` displays a diagram of the parse result instead of invoking the command-line app:

```dotnetcli
dotnet [diagram] build --no-restore --output ./build-output/
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

* [`[diagram]`](#the-diagram-directive)
* [`[suggest]`](#the-suggest-directive)

### The `[diagram]` directive

Both users and developers may find it useful to see how an app will interpret a given input. One of the default features of a `System.CommandLine` app is the `[diagram]` directive, which lets you preview the result of parsing command input. For example:

```console
myapp [diagram] --delay not-an-int --interactive --file filename.txt extra
```

```output
![ myapp [ --delay !<not-an-int> ] [ --interactive <True> ] [ --file <filename.txt> ] *[ --fgcolor <White> ] ]   ???--> extra
```

In the preceding example:

* The command (`myapp`), its child options, and the arguments to those options are grouped using square brackets.
* For the option result `[ --delay !<not-an-int> ]`, the `!` indicates a parsing error. The value `not-an-int` for an `int` option can't be parsed to the expected type. The error is also flagged by `!` in front of the command that contains the errored option: `![ myapp...`.
* For the option result `*[ --fgcolor <White> ]`, the option wasn't specified on the command line, so the configured default was used. `White` is the effective value for this option. The asterisk indicates that the value is the default.
* `???-->` points to input that wasn't matched to any of the app's commands or options.

### Suggest directive

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
* [GNU standards](https://www.gnu.org/software/libc/manual/html_node/Argument-Syntax.html)
* [System.CommandLine overview](index.md)
* [Tutorial: Get started with System.CommandLine](get-started-tutorial.md)
* [Design guidance](design-guidance.md)
