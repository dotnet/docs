---
title: System.CommandLine migration guide to 2.0.0-beta5+
description: "Learn about how to migrate to System.CommandLine 2.0.0-beta5+."
ms.date: 08/13/2025
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
---

# System.CommandLine 2.0.0-beta5+ migration guide

[!INCLUDE [scl-preview](./includes/preview.md)]

The main focus for the 2.0.0-beta5 release was to improve the APIs and take a step toward releasing a stable version of System.CommandLine. The APIs have been simplified and made more coherent and consistent with the [Framework design guidelines](../design-guidelines/index.md). This article describes the breaking changes that were made in 2.0.0-beta5 and 2.0.0-beta7, and the reasoning behind them.

## Renaming

In 2.0.0-beta4, not all types and members followed the [naming guidelines](../design-guidelines/naming-guidelines.md). Some weren't consistent with the naming conventions, such as using the `Is` prefix for Boolean properties. In 2.0.0-beta5, some types and members have been renamed. The following table shows the old and new names:

| Old name                                               | New name                                                       |
|--------------------------------------------------------|----------------------------------------------------------------|
| `System.CommandLine.Parsing.Parser`                    | <xref:System.CommandLine.Parsing.CommandLineParser>            |
| `System.CommandLine.Parsing.OptionResult.IsImplicit`   | <xref:System.CommandLine.Parsing.OptionResult.Implicit>        |
| `System.CommandLine.Option.IsRequired`                 | <xref:System.CommandLine.Option.Required>                      |
| `System.CommandLine.Symbol.IsHidden`                   | <xref:System.CommandLine.Symbol.Hidden>                        |
| `System.CommandLine.Option.ArgumentHelpName`           | <xref:System.CommandLine.Option.HelpName>                      |
| `System.CommandLine.Parsing.OptionResult.Token`        | <xref:System.CommandLine.Parsing.OptionResult.IdentifierToken> |
| `System.CommandLine.Parsing.ParseResult.FindResultFor` | <xref:System.CommandLine.ParseResult.GetResult*>               |
| `System.CommandLine.Parsing.SymbolResult.ErrorMessage` | <xref:System.CommandLine.Parsing.SymbolResult.AddError(System.String)>† |

†To allow multiple errors for the same symbol to be reported, the `ErrorMessage` property was converted to a method and renamed to `AddError`.

## Mutable collections of options and validators

Version 2.0.0-beta4 had numerous `Add` methods that were used to add items to collections, such as arguments, options, subcommands, validators, and completions. Some of these collections were exposed via properties as read-only collections. Because of that, it was impossible to remove items from those collections.

In 2.0.0-beta5, the APIs were changed to expose mutable collections instead of `Add` methods and (sometimes) read-only collections. This allows you to not only add items or enumerate them, but also remove them. The following table shows the old method and new property names:

| Old method name           | New property                     |
|---------------------------|----------------------------------|
| `Command.AddArgument`     | `Command.Arguments.Add`          |
| `Command.AddOption`       | `Command.Options.Add`            |
| `Command.AddCommand`      | `Command.Subcommands.Add`        |
| `Command.AddValidator`    | `Command.Validators.Add`         |
| `Option.AddValidator`     | `Option.Validators.Add`          |
| `Argument.AddValidator`   | `Argument.Validators.Add`        |
| `Command.AddCompletions`  | `Command.CompletionSources.Add`  |
| `Option.AddCompletions`   | `Option.CompletionSources.Add`   |
| `Argument.AddCompletions` | `Argument.CompletionSources.Add` |
| `Command.AddAlias`        | `Command.Aliases.Add`            |
| `Option.AddAlias`         | `Option.Aliases.Add`             |

The `RemoveAlias` and `HasAlias` methods were also removed, as the `Aliases` property is now a mutable collection. You can use the `Remove` method to remove an alias from the collection. Use the `Contains` method to check if an alias exists.

## Names and aliases

Before 2.0.0-beta5, there was no clear separation between the name and [aliases](syntax.md#aliases) of a symbol. When `name` wasn't provided for the `Option<T>` constructor, the symbol reported its name as the longest alias with prefixes like `--`, `-`, or `/` removed. That was confusing.

Moreover, to get the parsed value, you had to store a reference to an option or an argument and then use it to get the value from `ParseResult`.

To promote simplicity and explicitness, the name of a symbol is now a mandatory parameter for every symbol constructor (including `Argument<T>`). The concept of a name and aliases is now separate: aliases are just aliases and don't include the name of the symbol. Of course, they're optional. As a result, the following changes were made:

- `name` is now a mandatory argument for every public constructor of <xref:System.CommandLine.Argument`1>, <xref:System.CommandLine.Option`1>, and <xref:System.CommandLine.Command>. In the case of `Argument<T>`, it isn't used for parsing, but to generate the help. In the case of `Option<T>` and `Command`, it's used to identify the symbol during parsing and also for help and completions.
- The <xref:System.CommandLine.Symbol.Name?displayProperty=nameWithType> property is no longer `virtual`; it's now read-only and returns the name as it was provided when the symbol was created. Because of that, `Symbol.DefaultName` was removed and <xref:System.CommandLine.Option.Name?displayProperty=nameWithType> no longer removes the `--`, `-`, or `/` or any other prefix from the longest alias.
- The `Aliases` property exposed by [`Option`](xref:System.CommandLine.Option.Aliases) and [`Command`](xref:System.CommandLine.Command.Aliases) is now a mutable collection. This collection no longer includes the name of the symbol.
- `System.CommandLine.Parsing.IdentifierSymbol` was removed (it was a base type for both `Command` and `Option`).

Having the name always present lets you [get the parsed value by name](how-to-parse-and-invoke.md#getvalue):

```csharp
RootCommand command = new("The description.")
{
    new Option<int>("--number")
};

ParseResult parseResult = command.Parse(args);
int number = parseResult.GetValue<int>("--number");
```

### Creating options with aliases

In the past, <xref:System.CommandLine.Option`1> exposed many constructors, some of which accepted the name. Since the name is now mandatory and aliases will frequently be provided for `Option<T>`, there's only a single constructor. It accepts the name and a `params` array of aliases.

Before 2.0.0-beta5, `Option<T>` had a constructor that took a name and a description. Because of that, the second argument might now be treated as an alias rather than a description. It's the only known breaking change in the API that doesn't cause a compiler error.

Update any code that passed a description to the constructor to use the new constructor that takes a name and aliases, and then set the `Description` property separately. For example:

```csharp
Option<bool> beta4 = new("--help", "An option with aliases.");
beta4b.Aliases.Add("-h");
beta4b.Aliases.Add("/h");

Option<bool> beta5 = new("--help", "-h", "/h")
{
    Description = "An option with aliases."
};
```

## Default values and custom parsing

In 2.0.0-beta4, you could set default values for options and arguments by using the `SetDefaultValue` methods. Those methods accepted an `object` value, which wasn't type safe and could lead to run-time errors if the value wasn't compatible with the option or argument type:

```csharp
Option<int> option = new("--number");
// This is not type safe, as the value is a string, not an int:
option.SetDefaultValue("text");
```

Moreover, some of the `Option` and `Argument` constructors accepted a parse delegate and a Boolean indicating whether the delegate was a custom parser or a default value provider, which was confusing.

`Option<T>` and `Argument<T>` classes now have a <xref:System.CommandLine.Option`1.DefaultValueFactory> property that you can use to set a delegate that can be called to get the default value for the option or argument. This delegate is invoked when the option or argument isn't found in the parsed command-line input.

```csharp
Option<int> number = new("--number")
{
    DefaultValueFactory = _ => 42
};
```

`Argument<T>` and `Option<T>` also come with a <xref:System.CommandLine.Option`1.CustomParser> property that you can use to set a custom parser for the symbol:

```csharp
Argument<Uri> uri = new("arg")
{
    CustomParser = result =>
    {
        if (!Uri.TryCreate(result.Tokens.Single().Value, UriKind.RelativeOrAbsolute, out var uriValue))
        {
            result.AddError("Invalid URI format.");
            return null;
        }

        return uriValue;
    }
};
```

Moreover, `CustomParser` accepts a delegate of type `Func<ParseResult,T>`, rather than the previous `ParseArgument` delegate. This and a few other custom delegates were removed to simplify the API and reduce the number of types exposed by the API, which reduces startup time spent during JIT compilation.

For more examples of how to use `DefaultValueFactory` and `CustomParser`, see [How to customize parsing and validation in System.CommandLine](how-to-customize-parsing-and-validation.md).

## Separation of parsing and invocation

In 2.0.0-beta4, it was possible to separate the parsing and invoking of commands, but it wasn't clear how to do it. `Command` didn't expose a `Parse` method, but `CommandExtensions` provided `Parse`, `Invoke`, and `InvokeAsync` extension methods for `Command`. This was confusing, as it wasn't clear which method to use and when. The following changes were made to simplify the API:

- <xref:System.CommandLine.Command> now exposes a `Parse` method that returns a `ParseResult` object. This method is used to parse the command-line input and return the result of the parse operation. Moreover, it makes it clear that the command isn't invoked but parsed, and only in synchronous manner.
- `ParseResult` now exposes both `Invoke` and `InvokeAsync` methods that you can use to invoke the command. This pattern makes it clear that the command is invoked after parsing, and allows for both synchronous and asynchronous invocation.
- The `CommandExtensions` class was removed, as it's no longer needed.

### Configuration

Before 2.0.0-beta5, it was possible to customize the parsing, but only with some of the public `Parse` methods. There was a `Parser` class that exposed two public constructors: one accepting a `Command` and another accepting a `CommandLineConfiguration`. `CommandLineConfiguration` was immutable, and to create it, you had to use a builder pattern exposed by the `CommandLineBuilder` class. The following changes were made to simplify the API:

- `CommandLineConfiguration` was split into two *mutable* classes (in 2.0.0-beta7): <xref:System.CommandLine.ParserConfiguration> and <xref:System.CommandLine.InvocationConfiguration>. Creating an invocation configuration is now as simple as creating an instance of `InvocationConfiguration` and setting the properties you want to customize.
- Every `Parse` method now accepts an optional <xref:System.CommandLine.ParserConfiguration> parameter that you can use to customize the parsing. When it isn't provided, the default configuration is used.
- To avoid name conflicts, `Parser` was renamed to <xref:Microsoft.CodeAnalysis.CommandLineParser> to disambiguate from other parser types. Since it's stateless, it's now a static class with only static methods. It exposes two `Parse` parse methods: one accepting an `IReadOnlyList<string> args` and another accepting a `string args`. The latter uses <xref:System.CommandLine.Parsing.CommandLineParser.SplitCommandLine(System.String)?displayProperty=nameWithType> (also public) to split the command line input into [tokens](syntax.md#tokens) before parsing it.

`CommandLineBuilderExtensions` was also removed. Here is how you can map its methods to the new APIs:

- `CancelOnProcessTermination` is now a property of <xref:System.CommandLine.InvocationConfiguration> called <xref:System.CommandLine.InvocationConfiguration.ProcessTerminationTimeout>. It's enabled by default, with a 2 second timeout. To disable it, set it to `null`. For more information, see [Process termination timeout](how-to-parse-and-invoke.md#process-termination-timeout).
- `EnableDirectives`, `UseEnvironmentVariableDirective`, `UseParseDirective`, and `UseSuggestDirective` were removed. A new [Directive](syntax.md#directives) type was introduced and [RootCommand](syntax.md#root-command) now exposes a <xref:System.CommandLine.RootCommand.Directives> property. You can add, remove, and iterate directives by using this collection. [Suggest directive](syntax.md#suggest-directive) is included by default; you can also use other directives like [DiagramDirective](syntax.md#the-diagram-directive) or <xref:System.CommandLine.EnvironmentVariablesDirective>.
- `EnableLegacyDoubleDashBehavior` was removed. All unmatched tokens are now exposed by the <xref:System.CommandLine.ParseResult.UnmatchedTokens?displayProperty=nameWithType> property. For more information, see [Unmatched tokens](how-to-parse-and-invoke.md#unmatched-tokens).
- `EnablePosixBundling` was removed. The bundling is now enabled by default, you can disable it by setting the <xref:System.CommandLine.ParserConfiguration.EnablePosixBundling?displayProperty=nameWithType> property to `false`. For more information, see [EnablePosixBundling](how-to-configure-the-parser.md#enableposixbundling).
- `RegisterWithDotnetSuggest` was removed as it performed an expensive operation, typically during application startup. Now you must register commands with `dotnet suggest` [manually](how-to-enable-tab-completion.md#enable-tab-completion).
- `UseExceptionHandler` was removed. The default exception handler is now enabled by default; you can disable it by setting the <xref:System.CommandLine.InvocationConfiguration.EnableDefaultExceptionHandler?displayProperty=nameWithType> property to `false`. This is useful when you want to handle exceptions in a custom way, by just wrapping the `Invoke` or `InvokeAsync` methods in a try-catch block. For more information, see [EnableDefaultExceptionHandler](how-to-configure-the-parser.md#enabledefaultexceptionhandler).
- `UseHelp` and `UseVersion` were removed. The help and version are now exposed by the <xref:System.CommandLine.Help.HelpOption> and <xref:System.CommandLine.VersionOption> public types. They are both included by default in the options defined by [RootCommand](syntax.md#root-command). For more information, see [Customize help output](how-to-customize-help.md#customize-help-output) and [Version option](syntax.md#version-option).
- `UseHelpBuilder` was removed. For more information on how to customize the help output, see [How to customize help in System.CommandLine](how-to-customize-help.md).
- `AddMiddleware` was removed. It slowed down the application startup, and features can be expressed without it.
- `UseParseErrorReporting` and `UseTypoCorrections` were removed. The parse errors are now reported by default when invoking `ParseResult`. You can configure it by using the <xref:System.CommandLine.Invocation.ParseErrorAction> action exposed by the <xref:System.CommandLine.ParseResult.Action?displayProperty=nameWithType> property.

  ```csharp
  ParseResult result = rootCommand.Parse("myArgs", config);
  if (result.Action is ParseErrorAction parseError)
  {
      parseError.ShowTypoCorrections = true;
      parseError.ShowHelp = false;
  }
  ```

- `UseLocalizationResources` and `LocalizationResources` were removed. This feature was used mostly by the `dotnet` CLI to add missing translations to `System.CommandLine`. All those translations were moved to the System.CommandLine itself, so this feature is no longer needed. If support for your language is missing, please [report an issue](https://github.com/dotnet/command-line-api/issues/new/choose).
- `UseTokenReplacer` was removed. [Response files](syntax.md#response-files) are enabled by default, but you can disable them by setting the <xref:System.CommandLine.ParserConfiguration.ResponseFileTokenReplacer> property to `null`. You can also provide a custom implementation to customize how response files are processed.

Last but not least, the `IConsole` and all related interfaces (`IStandardOut`, `IStandardError`, `IStandardIn`) were removed. <xref:System.CommandLine.InvocationConfiguration> exposes two `TextWriter` properties: <xref:System.CommandLine.InvocationConfiguration.Output> and <xref:System.CommandLine.InvocationConfiguration.Error>. You can set these properties to any <xref:System.IO.TextWriter> instance, such as a `StringWriter`, which you can use to capture output for testing. The motivation for this change was to expose fewer types and reuse existing abstractions.

### Invocation

In 2.0.0-beta4, the `ICommandHandler` interface exposed `Invoke` and `InvokeAsync` methods that were used to invoke the parsed command. This made it easy to mix synchronous and asynchronous code, for example by defining a synchronous handler for a command and then invoking it asynchronously (which could lead to a [deadlock](../../csharp/asynchronous-programming/index.md#dont-block-await-instead)). Moreover, it was possible to define a handler only for a command, but not for an option (like help, which displays help) or a directive.

A new abstract base class <xref:System.CommandLine.Invocation.CommandLineAction> and two derived classes, `SynchronousCommandLineAction` and `AsynchronousCommandLineAction`, have been introduced. The former is used for synchronous actions that return an `int` exit code, while the latter is used for asynchronous actions that return a `Task<int>` exit code.

You don't need to create a derived type to define an action. You can use the <xref:System.CommandLine.Command.SetAction*?displayProperty=nameWithType> method to set an action for a command. The synchronous action can be a delegate that takes a `System.CommandLine.ParseResult` parameter and returns an `int` exit code (or nothing, and then a default `0` exit code is returned). The asynchronous action can be a delegate that takes a `System.CommandLine.ParseResult` and <xref:System.Threading.CancellationToken> parameters and returns a `Task<int>` (or `Task` to get default exit code returned).

```csharp
rootCommand.SetAction(ParseResult parseResult =>
{
    FileInfo parsedFile = parseResult.GetValue(fileOption);
    ReadFile(parsedFile);
});
```

In the past, the `CancellationToken` passed to `InvokeAsync` was exposed to handler via a method of `InvocationContext`:

```csharp
rootCommand.SetHandler(async (InvocationContext context) =>
{
    string? urlOptionValue = context.ParseResult.GetValueForOption(urlOption);
    var token = context.GetCancellationToken();
    returnCode = await DoRootCommand(urlOptionValue, token);
});
```

Most users weren't obtaining this token and passing it further. `CancellationToken` is now a mandatory argument for asynchronous actions, such that the compiler produces a warning when it's not passed further (see [CA2016](../../fundamentals/code-analysis/quality-rules/ca2016.md)).

```csharp
rootCommand.SetAction((ParseResult parseResult, CancellationToken token) =>
{
    string? urlOptionValue = parseResult.GetValue(urlOption);
    return DoRootCommandAsync(urlOptionValue, token);
});
```

As a result of these and other aforementioned changes, the `InvocationContext` class got also removed. The `ParseResult` is now passed directly to the action, so you can access the parsed values and options directly from it.

To summarize these changes:

- The `ICommandHandler` interface was removed. `SynchronousCommandLineAction` and `AsynchronousCommandLineAction` were introduced.
- The `Command.SetHandler` method was renamed to <xref:System.CommandLine.Command.SetAction*>.
- The `Command.Handler` property was renamed to <xref:System.CommandLine.Command.Action?displayProperty=nameWithType>. `Option` was extended with <xref:System.CommandLine.Option.Action?displayProperty=nameWithType>.
- `InvocationContext` was removed. The `ParseResult` is now passed directly to the action.

For more details about how to use actions, see [How to parse and invoke commands in System.CommandLine](how-to-parse-and-invoke.md).

## The benefits of the simplified API

The changes made in 2.0.0-beta5 make the API more consistent, future-proof, and easier to use for existing and new users.

New users need to learn fewer concepts and types, as the number of public interfaces decreased from 11 to 0, and public classes (and structs) decreased from 56 to 38. The public method count dropped from 378 to 235, and public properties from 118 to 99.

The number of assemblies referenced by System.CommandLine is reduced from 11 to 6:

```diff
System.Collections
- System.Collections.Concurrent
- System.ComponentModel
System.Console
- System.Diagnostics.Process
System.Linq
System.Memory
- System.Net.Primitives
System.Runtime
- System.Runtime.Serialization.Formatters
+ System.Runtime.InteropServices
- System.Threading
```

The size of the library is reduced (by 32%) and so is the size of NativeAOT apps that use the library.

Simplicity has also improved the performance of the library (it's a side effect of the work, not the main goal of it). The [benchmarks](https://github.com/adamsitnik/commandline-perf/tree/update) show that the parsing and invoking of commands is now faster than in 2.0.0-beta4, especially for large commands with many options and arguments. The performance improvements are visible in both synchronous and asynchronous scenarios.

The simplest app, presented previously, produces the following results:

```ini
BenchmarkDotNet v0.15.0, Windows 11 (10.0.26100.4061/24H2/2024Update/HudsonValley)
AMD Ryzen Threadripper PRO 3945WX 12-Cores 3.99GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  Job-JJVAFK : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

EvaluateOverhead=False  OutlierMode=DontRemove  InvocationCount=1
IterationCount=100  UnrollFactor=1  WarmupCount=3

| Method                  | Args           | Mean      | StdDev   | Ratio |
|------------------------ |--------------- |----------:|---------:|------:|
| Empty                   | --bool -s test |  63.58 ms | 0.825 ms |  0.83 |
| EmptyAOT                | --bool -s test |  14.39 ms | 0.507 ms |  0.19 |
| SystemCommandLineBeta4  | --bool -s test |  85.80 ms | 1.007 ms |  1.12 |
| SystemCommandLineNow    | --bool -s test |  76.74 ms | 1.099 ms |  1.00 |
| SystemCommandLineNowR2R | --bool -s test |  69.35 ms | 1.127 ms |  0.90 |
| SystemCommandLineNowAOT | --bool -s test |  17.35 ms | 0.487 ms |  0.23 |
```

As you can see, the startup time (the benchmarks report the time required to run given executable) has improved by 12% compared to 2.0.0-beta4. If you compile the app with NativeAOT, it's just 3 ms slower than a NativeAOT app that does not parse the args at all (EmptyAOT in the table above). Also, if you exclude the overhead of an empty app (63.58 ms), the parsing is 40% faster than in 2.0.0-beta4 (22.22 ms vs 13.66 ms).

## See also

- [System.CommandLine overview](index.md)
