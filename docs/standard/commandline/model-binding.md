---
title: How to bind arguments to handlers in System.CommandLine
description: "Learn how to do model-binding in apps that are built with the System.Commandline library."
ms.date: 03/16/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to bind arguments to handlers in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

The process of parsing arguments and providing them to command handler code is called *model binding*. `System.CommandLine` has the ability to bind many argument types built in. For example, integers, enums, and file system objects such as `FileInfo` and `DirectoryInfo` can be bound. `FileInfo` and `DirectoryInfo` are examples of a general convention whereby any type that has a constructor that takes a single `string` parameter can be bound without your having to write any custom code. Several `System.CommandLine` types can also be bound.

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

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstring" highlight="10-15" :::

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="intandstringhandler" :::

The lambda parameters are variables that represent the values of options and arguments:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="lambda" :::

The variables that follow the lambda represent the option and argument objects that are the sources of the option and argument values:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="services" :::

 The options and arguments must be declared in the same order in the lambda and in the parameters that follow the lambda. If the order is not consistent, one of the following scenarios will result:

* If the out-of-order options or arguments are of different types, a run-time exception is thrown. For example, an `int` might appear where a `string` should be in the list of sources.
* If the out-of-order options or arguments are of the same type, the handler silently gets the wrong values in the parameters provided to it. For example, `string` option `x` might appear where `string` option `y` should be in the list of sources. In that case, the variable for the option `y` value gets the option `x` value.

There are overloads of `SetHandler` that support up to 16 parameters, with both synchronous and asynchronous signatures.

## Model binding more than 16 options and arguments

To handle more than 16 options, or to construct a custom type from multiple options, create a *custom binder*. The binder lets you combine multiple option or argument values into a complex type and pass that into a single handler parameter. Suppose you have a `Person` type:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="persontype" :::

Create a class derived from `BinderBase<T>`, where `T` is the type to construct based on command line input:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="personbinder" :::

With the custom binder, you can get your custom type passed to your handler the same way you get values for options and arguments:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="sethandler" :::

Here's the complete program that the preceding examples are taken from:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="all" :::

## Set exit codes

There are `Task`-returning `Func` overloads of `SetHandler`. If your handler is called from async code, you can return a `Task<int>` from a handler that uses one of these, and use the `int` value to set the process exit code, as in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/ReturnExitCode.cs" id="returnexitcode" :::

However, if the lambda itself needs to be async, you can't return a `Task<int>`. In that case, use `InvocationContext.ExitCode`. You can get the `InvocationContext` instance injected into your lambda just by including it as one of the parameters, as in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/ContextExitCode.cs" id="contextexitcode" :::

If you don't have asynchronous work to do, you can use the `Action` overloads. In that case, set the exit code by using `InvocationContext.ExitCode` the same way you would with an async lambda.

The exit code defaults to 1. If you don't set it explicitly, its value is set to 0 when your handler exits normally. If an exception is thrown, it keeps the default value.

## Supported types

The following examples show code that binds some commonly used types.

### Enums

The values of `enum` types are bound by name, and the binding is case insensitive:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="enum" :::

Here's sample command-line input and resulting output from the preceding example:

```console
myapp --color red
myapp --color RED
```

```output
Red
Red
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

Command line applications that work with the file system can use the <xref:System.IO.FileSystemInfo>, <xref:System.IO.FileInfo>, and <xref:System.IO.DirectoryInfo> types. The following example shows the use of `FileSystemInfo`:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="filesysteminfo" :::

With `FileInfo` and `DirectoryInfo` the pattern matching code is not required:

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="filesysteminfo" :::

### Anything with a string constructor

The file system types aren't special cases. Any type having a constructor that takes a single string parameter can be bound in this way. For example, code that would work with `FileInfo` works with a <xref:System.Uri> instead.

:::code language="csharp" source="snippets/model-binding/csharp/Program.cs" id="uri" :::

## Inject System.CommandLine types

`System.CommandLine` allows you to use some types in handlers by adding parameters for them to the handler signature. The available types include:

* `CancellationToken`
* `IConsole`
* `InvocationContext`
* `ParseResult`

Other types can be injected by using custom binders. For more information, see [Dependency injection](dependency-injection.md).

### `CancellationToken`

For information about how to use `CancellationToken`, see [How to handle termination](handle-termination.md).

### `IConsole`

`IConsole` makes testing as well as many extensibility scenarios easier than using `System.Console`.

### `InvocationContext`

For an example, see [Set exit codes](#set-exit-codes).

### `ParseResult`

`ParseResult` is a singleton structure that represents the results of parsing the command line input. You can use it to check for the presence of options or arguments on the command line or to get the `ParseResult.UnmatchedTokens` property. This property contains a list of the [tokens](syntax.md#tokens) that were parsed but didn't match any configured command, option, or argument.

The list of unmatched tokens is useful in commands that behave like wrappers. A wrapper command takes a set of [tokens](syntax.md#tokens) and forwards them to another command or app.  The `sudo` command in Linux is an example. It takes the name of a user to impersonate followed by a command to run. For example:

```console
sudo -u admin apt update 
```

This command line would run the `apt update` command as the user `admin`.

To implement a wrapper command like this one, set the command property `TreatUnmatchedTokensAsError` to `false`. Then the `ParseResult.UnmatchedTokens` property will contain all of the arguments that don't explicitly belong to the command. In the preceding example, `ParseResult.UnmatchedTokens` would contain the `apt` and `update` tokens. Your command handler could then forward the `UnmatchedTokens` to a new shell invocation, for example.

## Custom validation and binding

To provide custom validation code, call `AddValidator` on your option or argument, as shown in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/AddValidator.cs" id="delayOption" :::

If you want to parse as well as validate the input, use a `ParseArgument<T>` delegate, as shown in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="delayOption" :::

The preceding code sets `isDefault` to `true` so that the `parseArgument` delegate will be called even if the user didn't enter a value for this option.

Here are some examples of what you can do with `ParseArgument<T>` that you can't do with `AddValidator`:

* Parsing of custom types, such as the `Person` class in the following example:

  :::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="persontype" :::

  :::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="personoption" :::

* Parsing of other kinds of input strings (for example, parse "1,2,3" into `int[]`).

* Dynamic arity. For example, you have two arguments that are defined as string arrays, and you have to handle a sequence of strings in the command line input. The `ArgumentResult.OnlyTake` method enables you to dynamically divide up the input strings between the arguments.

## See also

[System.CommandLine overview](index.md)
