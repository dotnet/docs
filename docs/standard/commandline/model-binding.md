---
title: How to bind arguments to handlers in System.CommandLine
description: "Learn how to do model-binding in apps that are built with the System.Commandline library."
ms.date: 02/03/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to bind arguments to handlers in System.CommandLine

The process of parsing arguments and providing them to command handler code is called *model binding*. `System.CommandLine` has the ability to bind many argument types built in. For example, integers, enums, and file system objects such as `FileInfo` and `DirectoryInfo` can be bound. `FileInfo` and `DirectoryInfo` are examples of a more general convention whereby any type that has a constructor that takes a single `string` parameter can be bound without your having to write any custom code. Several `System.CommandLine` types can also be bound.

## Built-in argument validation

Arguments have expected types and [arity](syntax.md#argument-arity). `System.CommandLine` rejects arguments that don't match these expectations.

For example, a parse error is displayed if the argument for an integer option isn't an integer.

```console
myapp --delay not-an-int
```

```output
Cannot parse argument 'not-an-int' as System.Int32.
```

An arity error is displayed if multiple arguments are passed to an option that has maximum arity of one:

```console
myapp --delay-option 1 --delay-option 2
```

```output
Option '--delay' expects a single argument but 2 were provided.
```

This behavior can be overridden by setting `Option.AllowMultipleArgumentsPerToken` to `true`. In that case you can repeat an option that has maximum arity of one, but only the last value on the line is accepted. In the following example, the value `three` would be passed to the app.

```console
myapp --item one --item two --item three
```

## Model binding up to 16 options and arguments

The following example shows how to bind options to command handler parameters, by calling `SetHandler`:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstring" highlight="9-13":::

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstringhandler" :::

There are overloads of `SetHandler` that support up to 16 parameters, with both synchronous and asynchronous signatures.

## Model binding more than 16 options and arguments

To handle more than 16 options, or to construct a custom type from multiple options, create a *custom binder*. The binder lets you combine multiple option or argument values into a more complex type and pass that into a single handler parameter. Suppose you have a `Person` type:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="persontype" :::

Create a class derived from `BinderBase<T>`, where `T` is the type to construct based on command line input:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="personbinder" :::

With the custom binder, you can get your custom type passed to your handler the same way you get values for options and arguments:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="sethandler" :::

Here's the complete program that the preceding examples are taken from:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="all" :::

## Set exit codes

If you return a `Task<int>` from a handler, it's used to set the process exit code. If you don't have asynchronous work to do, you can use the `Action` overloads. You can still set the process exit code with `Action` overloads by accepting a parameter of type `InvocationContext` and setting `InvocationContext.ExitCode` to the desired value. If you don't explicitly set it, and your handler exits normally, the exit code is set to 0. If an exception is thrown, the exit code is set to 1.

## Supported types

The following examples show code that binds some commonly used types.

### Enums

The values of `enum` types are bound by name, and the binding is case insensitive:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="enum" :::

Here's sample command-line input and resulting output from the preceding example:

```console
myapp --enum red
myapp --enum RED
```

```output
Read
Read
```

### Arrays and lists

Many common types that implement `IEnumerable` are supported. For example:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="ienumerable" :::

Here's sample command-line input and resulting output from the preceding example:

```console
--items one --items two --items three
```

```output
System.Collections.Generic.List`1[System.String]
one
two
three
```

Because `AllowMultipleArgumentsPerToken` is set to `true`, the following input results in the same output:

```console
--items one two three
```

### File system types

Since command line applications often have to work with the file system, `FileInfo` and `DirectoryInfo` are supported. The following example shows the use of `FileInfo`, but it would work also with `DirectoryInfo`.

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="fileinfo" :::

### Anything with a string constructor

`FileInfo` and `DirectoryInfo` aren't special cases. Any type having a constructor that takes a single string parameter can be bound in this way. For example, the same code works with a `Uri` instead.

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="uri" :::

## System.CommandLine types

`System.CommandLine` allows you to use some types in handlers by adding parameters for them to the handler signature. The available types are:

* `CancellationToken`
* `HelpBuilder`
* `IConsole`
* `ParseResult`

Other types can be injected by using custom binders. For more information, see [Dependency injection](dependency-injection.md).

### `CancellationToken`

For information about how to use `CancellationToken`, see [How to handle termination](handle-termination.md).

### `IConsole`

`IConsole` makes testing as well as many extensibility scenarios easier than using `System.Console`.

### `ParseResult`

`ParseResult` is a singleton structure that represents the results of parsing the command line input. You can use it to check for the presence of options or arguments on the command line or to get one of the following properties:

* `ParseResult.Errors`
* `ParseResult.UnmatchedTokens` - A list of the [tokens](syntax.md#tokens) that were parsed but didn't match any configured command, option, or argument.
* `ParseResult.UnparsedTokens` - A list of all tokens that were on the right-hand side of the special `--` token. This token is widely understood as a 'separator' between arguments for a main command and subcommands.

The `ParseResult.UnmatchedTokens` and `ParseResult.UnparsedTokens` properties are useful in commands that behave like wrappers. A wrapper command takes a set of [tokens](syntax.md#tokens) and forwards some of them to another command or app.  The `sudo` command in Linux is an example. It takes the name of a user to impersonate followed by a command to run. For example:

```console
sudo -u admin apt update 
```

This command line would run the `apt update` command as the user `admin`.

To implement a wrapper command like this one, set the command property `TreatUnmatchedTokensAsError` to `false`. Then the `ParseResult.UnmatchedTokens` property will contain all of the arguments that don't explicitly belong to the command. In the preceding example, `ParseResult.UnmatchedTokens` would contain the `apt` and `update` tokens. Your command handler could then forward the `UnmatchedTokens` to a new shell invocation, for example.

Another example of a wrapper command is `dotnet run`:

```dotnetcli
dotnet run -- --message "Hello world!"
```

In this example, the `--message` option and its argument would be in `ParseResult.UnparsedTokens` because they follow the `--` token. From there these tokens can be passed to the app that is run by the `dotnet run` command.

## Custom validation and binding

The `Option` type's constructor includes a `parseArgument` parameter that lets you provide a delegate for parsing and validating an argument, as in the following example for a `FileInfo` option.

:::code language="csharp" source="snippets/model-binding/csharp/CustomValidation.cs" id="fileoption" :::

The preceding code sets `isDefault` to `true` so that the `parseArgument` delegate will be called even if the user didn't enter a value for this option.

You can use similar code to work with types that don't have built-in support, such as the `Person` class in the following example.

:::code language="csharp" source="snippets/model-binding/csharp/CustomValidation.cs" id="persontype" :::

:::code language="csharp" source="snippets/model-binding/csharp/CustomValidation.cs" id="personoption" :::

Here's the complete program that contains the preceding examples.

:::code language="csharp" source="snippets/model-binding/csharp/CustomValidation.cs" id="all" :::

## See also

[System.CommandLine overview](index.md)
