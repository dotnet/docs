---
title: What's new in C# 7.1
description: An overview of new features in C# 7.1.
ms.date: 04/09/2019
---
# What's new in C# 7.1

C# 7.1 is the first point release to the C# language. It marks an increased
release cadence for the language. You can use the new features sooner, ideally
when each new feature is ready. C# 7.1 adds the ability to configure
the compiler to match a specified version of the language. That enables you to
separate the decision to upgrade tools from the decision to upgrade language
versions.

C# 7.1 adds the [language version selection](../language-reference/configure-language-version.md)
configuration element, three new language features, and new compiler behavior.

The new language features in this release are:

- [`async` `Main` method](#async-main)
  - The entry point for an application can have the `async` modifier.
- [`default` literal expressions](#default-literal-expressions)
  - You can use default literal expressions in default value expressions when the target type can be inferred.
- [Inferred tuple element names](#inferred-tuple-element-names)
  - The names of tuple elements can be inferred from tuple initialization in many cases.
- [Pattern matching on generic type parameters](#pattern-matching-on-generic-type-parameters)
  - You can use pattern match expressions on variables whose type is a generic type parameter.

Finally, the compiler has two options `-refout` and `-refonly` that
control [reference assembly generation](#reference-assembly-generation).

To use the latest features in a point release, you need to [configure the compiler language version](../language-reference/configure-language-version.md) and select the version.

The remainder of this article provides an overview of each feature. For each feature,
you'll learn the reasoning behind it. You'll learn the syntax. You can explore these features in your environment using the `dotnet try` global tool:

1. Install the [dotnet-try](https://github.com/dotnet/try/blob/master/README.md#setup) global tool.
1. Clone the [dotnet/try-samples](https://github.com/dotnet/try-samples) repository.
1. Set the current directory to the *csharp7* subdirectory for the *try-samples* repository.
1. Run `dotnet try`.

## Async main

An *async main* method enables you to use `await` in your `Main` method.
Previously you would need to write:

```csharp
static int Main()
{
    return DoAsyncWork().GetAwaiter().GetResult();
}
```

You can now write:

```csharp
static async Task<int> Main()
{
    // This could also be replaced with the body
    // DoAsyncWork, including its await expressions:
    return await DoAsyncWork();
}
```

If your program doesn't return an exit code, you can declare a `Main` method
that returns a <xref:System.Threading.Tasks.Task>:

```csharp
static async Task Main()
{
    await SomeAsyncMethod();
}
```

You can read more about the details in the
[async main](../programming-guide/main-and-command-args/index.md) article
in the programming guide.

## Default literal expressions

Default literal expressions are an enhancement to default value expressions.
These expressions initialize a variable to the default value. Where you previously
would write:

```csharp
Func<string, bool> whereClause = default(Func<string, bool>);
```

You can now omit the type on the right-hand side of the initialization:

```csharp
Func<string, bool> whereClause = default;
```

For more information, see the [default literal](../language-reference/operators/default.md#default-literal) section of the [default operator](../language-reference/operators/default.md) article.

## Inferred tuple element names

This feature is a small enhancement to the tuples feature introduced in
C# 7.0. Many times when you initialize a tuple, the variables used for the
right side of the assignment are the same as the names you'd like for the
tuple elements:

```csharp
int count = 5;
string label = "Colors used in the map";
var pair = (count: count, label: label);
```

The names of tuple elements can be inferred from the variables used to initialize
the tuple in C# 7.1:

```csharp
int count = 5;
string label = "Colors used in the map";
var pair = (count, label); // element names are "count" and "label"
```

You can learn more about this feature in the [Tuples](../tuples.md) article.

## Pattern matching on generic type parameters

Beginning with C# 7.1, the pattern expression for `is` and the `switch` type pattern may have the type of a generic type parameter. This can be most useful when checking types that may be either `struct` or `class` types, and you want to avoid boxing.

## Reference assembly generation

There are two new compiler options that generate *reference-only assemblies*:
[-refout](../language-reference/compiler-options/refout-compiler-option.md)
and [-refonly](../language-reference/compiler-options/refonly-compiler-option.md).
The linked articles explain these options and reference assemblies in more detail.
