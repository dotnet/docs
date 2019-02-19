---
title: What's New in C# 8.0 - C# Guide
description: Get an overview of the new features available in C# 8.0. This article is up to date with preview 2.
ms.date: 02/12/2019
---
# What's new in C# 8.0

> [!NOTE]
> This article was last updated for C# 8.0 preview 2.

There are numerous enhancements to the C# language that you can try out already with preview 2. The new features added in preview 2 are:

- Pattern matching enhancements:
  * Switch expressions
  * Property patterns
  * positional patterns
  * Tuple patterns
- [Using declarations](#using-declarations)
- [Static local functions](#static-local-functions)
- [Disposable ref structs](#disposable-ref-structs)

The following language features first appeared in C# 8.0 preview 1:

- [Nullable reference types](#nullable-reference-types)
- [Asynchronous streams](#asynchronous-streams)
- [Ranges and indices](#ranges-and-indices)

The remainder of this article briefly describes these features. Where in-depth articles are available, links to those tutorials and overviews are provided.

## More patterns in more places

C# 7.0 introduced syntax for **pattern matching** to C#. The first tentative steps 


<< Nice intro, work with data based on its shape>>

<< describe recursive patterns here, because it spans all of them>>
- Recursive patterns are simply patterns applied to the output of a pattern.
 
### switch expressions

<< just use an enum. The syntax is simple and clean. >>
- colors of the rainbow

### property patterns

<< Type pattern followed by deconstruction >>
- All folks with the same last name.? points in a quadrant?
- missing properties on a type. 

### positional patterns

<< Just for deconstruction>>
- Key / Value pair in dictionary

### tuple patterns

<< Tuples and multiple inputs. Think state machine.>>
- traffic light
- indicator


## using declarations

A **using declaration** is a variable declaration preceded by the `using` keyword. It tells the compiler that the variable being declared should be disposed at the end of the enclosing scope. For example, consider the following code that writes a text file:

```csharp
static void WriteLinesToFile(IEnumerable<string> lines)
{
    using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
    {
        foreach (string line in lines)
        {
            // If the line doesn't contain the word 'Second', write the line to the file.
            if (!line.Contains("Second"))
            {
                file.WriteLine(line);
            }
        }
    } // file is disposed here
}
```

A few braces are removed by replacing the `using` statement with a `using` declaration:

```csharp
static void WriteLinesToFile(IEnumerable<string> lines)
{
    using var file = new System.IO.StreamWriter("WriteLines2.txt");
    foreach (string line in lines)
    {
        // If the line doesn't contain the word 'Second', write the line to the file.
        if (!line.Contains("Second"))
        {
            file.WriteLine(line);
        }
    }
// file is disposed here
}
```

Using declarations provide the same behavior when exceptions are thrown: the `Dispose()` call is in a `finally` block.s

## Static local functions

You can now add the `static` modifier to local functions to ensure that local function does not capture (reference) any variables from the enclosing scope. Doing so generates `CS8421`, "A static local function cannot contain a reference to <variable>." 

Consider the following code. The local function `LocalFunction` accesses the variable `y`, declared in the enclosing scope (the method `M`). Therefore, `LocalFunction` cannot be declared with the `static` modifier:

```csharp
int M()
{
    int y;
    LocalFunction();
    return y;

    void LocalFunction() => y = 0;
}
```

## Disposable ref structs

A `struct` declared with the `ref` modifier may not implement any interfaces. Therefore, to enable a `ref struct` to be disposed, it need not implement <xref:System.IDisposable>, but it must have an accessible `void Dispose()` method.

## Nullable reference types

Inside a nullable annotation context, any variable of a reference type is considered to be a **nonnullable reference type**. If you want to indicate that a variable may be null, you must append the type name with the `?` to declare the variable as a **nullable reference type**.

For nonnullable reference types, the compiler uses flow analysis to ensure that local variables are initialized to a non-null value when declared. Fields must be initialized to a non-null value either with an initializer or in all constructors. Furthermore, nonnullable reference types cannot be assigned a value that could be null.

Nullable reference types are not checked to ensure that they are not assigned or initialized to null. However, the compiler uses flow analysis to ensure that any variable of a nullable reference type is checked against null before it is accessed, or assigned to a nonnullable reference type.

You can learn more about the feature in the overview of [nullable reference types](../nullable-references.md). You can try it your self in a new application in this [nullable reference types tutorial](../tutorials/nullable-reference-types.md). You can learn about the steps to migrate an existing codebase to make use of nullable reference types in this tutorial for [migrating an application to use nullable reference types]../tutorials/upgrade-to-nullable-references.md).

## Asynchronous streams

Starting with C# 8.0, you can create and consume streams asynchronously. A method that returns an asynchronous stream has three properties:

1. It was declared with the `async` modifier.
1. It returns an `IAsyncEnumerable<T>`.
1. The method contains `yield return` statements to return successive elements in the asynchronous stream.

Consuming an asynchronous stream requires you to add the `await` keyword before the `foreach` keyword when you enumerate the elements of the stream. Adding the `await` keyword requires the method that enumerates the asynchronous stream was declared with the `async` modifier and returns a type allowed for an `async` method. Typically this is a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>. It can also be a <xref:System.Threading.Tasks.ValueTask> or <xref:System.Threading.Tasks.ValueTask%601>. A method can both consume and produce an asynchronous stream, which means it would return an `IAsyncEnumerable<T>`.

You can try asynchronous streams yourself in our tutorial on [creating and consuming async streams](../tutorials/generate-consume-asynchronous-stream.md).

## Ranges and indices

Ranges and indices provide a succinct syntax for specifying sub-ranges in an array, <xref:System.Span%601>, or <xref:System.ReadonlySpan%601>. Consider the following array:

```csharp
var words = new string[]
{
    "The",
    "quick",
    "brown",
    "fox",
    "jumped",
    "over",
    "the",
    "lazy",
    "dog"
};
```

You can retrieve the last word by prefixing the index `1` with `^`:

```csharp
Console.WriteLine($"The last word is {words[^1]}");
```

Note that when you take only a single element and specify from the end, indexing starts at 1.

You can also specify ranges of a array. The following code creates a sub-range with the words "quick", "brown", and "fox":

```csharp
var brownFox = words[1..4];
```

Ranges can be specified from the end as well as the beginning. The following code creates a sub-range with "lazy" and "dog":

```csharp
var lazyDog = words[^2..^0];
```

You can also also create ranges that are open ended for the start, end, or both, as in the following code:

```csharp
var allWords = words[..]; // contains "The" through "dog".
var firstPhrase = words[..4]; // contains "The" through "fox"
var lastPhrase = words[6..]; // contains "the, "lazy" and "dog"
```

You can also declare ranges as variables:

```csharp
Range phrase = 1..4;
```

The range can then be used inside the `[` and `]` characters:

```csharp
var text = words[phrase];
```

