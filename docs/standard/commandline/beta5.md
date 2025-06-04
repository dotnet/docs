---
title: System.CommandLine beta5 breaking changes
description: "Learn what breaking changes were introduced in beta5 and why."
ms.date: 16/06/2025
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---

# Breaking changes in beta5

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

Our main focus for beta5 was to improve the API, by simplifying it, making it more consistent and coherent with [Framework design guidelines](../design-guidelines/index.md). This article describes the changes that you need to make to your code to use beta5.

## Renaming

For type names, we wanted to disambiguate from other single-word types to avoid name conflicts. We also renamed some properties to make them follow the [guidelines for property names](../design-guidelines/names-of-type-members.md#names-of-properties). The following table shows the old and new names:

| Old name                                                    | New name                                                       |
|-------------------------------------------------------------|----------------------------------------------------------------|
| `System.CommandLine.Parsing.Parser`                      | `System.CommandLine.Parsing.CommandLineParser`             |
| `System.CommandLine.Parsing.OptionResult.IsImplicit`    | `System.CommandLine.Parsing.OptionResult.Implicit`         |
| `System.CommandLine.Option.IsRequired`                   | `System.CommandLine.Option.Required`                        |
| `System.CommandLine.Symbol.IsHidden`                     | `System.CommandLine.Symbol.Hidden`                          |
| `System.CommandLine.Option.ArgumentHelpName`            | `System.CommandLine.Option.HelpName`                        |
| `System.CommandLine.Parsing.OptionResult.Token`         | `System.CommandLine.Parsing.OptionResult.IdentifierToken` |
| `System.CommandLine.Parsing.ParseResult.FindResultFor` | `System.CommandLine.Parsing.ParseResult.GetResult`         |
| `System.CommandLine.Parsing.SymbolResult.ErrorMessage` | `System.CommandLine.Parsing.SymbolResult.AddError`         |

In case of the `ErrorMessage` property, we changed the name to `AddError` and made it a method. The goal was to allow to report multiple errors for the same symbol, which is useful when you want to report validation errors.

## Exposing mutable collections

In beta5, we changed the API to expose mutable collections instead of `Add` methods and (sometimes) readonly collections. This allows you to not only add items or enumerate them, but also remove them. The following table shows the old method and new property names:

| Old method name                                             | New property                                                   |
|-------------------------------------------------------------|----------------------------------------------------------------|
| `System.CommandLine.Command.AddArgument`                | `System.CommandLine.Command.Arguments`             |
| `System.CommandLine.Command.AddOption`                  | `System.CommandLine.Command.Options`             |
| `System.CommandLine.Command.AddCommand`                 | `System.CommandLine.Command.Subcommands`             |
| `System.CommandLine.Command.AddValidator`               | `System.CommandLine.Command.Validators`             |
| `System.CommandLine.Option.AddValidator`                | `System.CommandLine.Option.Validators`             |
| `System.CommandLine.Argument.AddValidator`              | `System.CommandLine.Argument.Validators`             |
| `System.CommandLine.Command.AddCompletions`             | `System.CommandLine.Command.CompletionSources`             |
| `System.CommandLine.Option.AddCompletions`              | `System.CommandLine.Option.CompletionSources`             |
| `System.CommandLine.Argument.AddCompletions`            | `System.CommandLine.Argument.CompletionSources`             |
| `System.CommandLine.Command.AddAlias`                   | `System.CommandLine.Command.Aliases`             |
| `System.CommandLine.Option.AddAlias`                    | `System.CommandLine.Option.Aliases`             |

## Names and aliases

Before beta5, the `System.CommandLine.Parsing.IdentifierSymbol` class was used to represent a base class for symbols that could be identified by a name and/or aliases (`Option` and `Command`). In beta5, every `Symbol` must provide a name, and only `Option` and `Command` support aliases. As a result, we made the following changes:

- `name` is now a mandatory argument for every public constructor of `Argument`, `Option`, and `Command`. In case of `Argument`, it is not used for parsing, but to generate the help and completions text. In case of `Option` and `Command`, it is used to identify the symbol during parsing and also for help and completions.
- `Symbol.Name` is no longer `virtual`, it's also readonly now and it returns the name as it was provided when the symbol was created. Because of that, `Symbol.DefaultName` was removed and `Option.Name` no longer removes the `--`, `-` or `/` or any other prefix from the longest alias.
- The `Aliases` property exposed by `Option` and `Command` is now exposing a mutable collection. This collection no longer includes the name of the symbol.
- `System.CommandLine.Parsing.IdentifierSymbol` was removed.

Having the name always present allows for [getting the parsed value by name](parse-and-invoke.md#getvalue):

```csharp
RootCommand command = new("The description.")
{
    new Option<int>("--number")
};

ParseResult parseResult = command.Parse(args);
int number = parseResult.GetValue<int>("--number");
```

### Creating options with aliases

We expect that most of the time, you will want to create options with aliases. In beta5, you can do this by using the `Option<T>` constructor that takes a name and `params` array of aliases.

In the past, `Option<T>` had a constructor that took a name and a description. Because of that, the second argument might now be treated as an alias rather than a description. It's the only known breaking change in the API that is not going to cause a compiler error.

Old code that used the constructor with a description should be updated to use the new constructor that takes a name and aliases, and then set the `Description` property separately. For example:

```csharp
Option<bool> beta4 = new("--help", "An option with aliases.");
beta4b.Aliases.Add("-h");
beta4b.Aliases.Add("/h");

Option<bool> beta5 = new("--help", "-h", "/h")
{
    Description = "An option with aliases."
};
```

## Default values

In beta4, users could set default values for options and arguments by using the `SetDefaultValue` methods. Those methods were accepting an `object` value, which was not type-safe and could lead to runtime errors if the value was not compatible with the option or argument type:

```csharp
Option<int> option = new("--number");
option.SetDefaultValue("text"); // This is not type-safe, as the value is a string, not an int.
```

Moreover, some of the `Option` and `Argument` constructors accepted a parse delegate and a boolean indicating whether the delegate was a custom parser or a default value provider. This was confusing.

`Option<T>` and `Argument<T>` classes now have a `DefaultValueFactory` property that can be used to set the default value for the symbol. This property is invoked when the symbol is not provided in the command line input.

```csharp
Option<int> number = new("--number")
{
    DefaultValueFactory = _ => 42
};
```

`Argument<T>` and `Option<T>` also come with a `CustomParser` property that can be used to set a custom parser for the symbol:

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

Moreover, `CustomParser` accepts  `Func<ParseResult, T>` delegate, rather than dedicated `ParseArgument` delegate (it got removed).

For more examples of how to use `DefaultValueFactory` and `CustomParser`, see the [How to customize parsing and validation in System.CommandLine](parsing-and-validation.md) document.

## The benefits of the simplified API

PERF
AOT

## See also

- [System.CommandLine overview](index.md)
