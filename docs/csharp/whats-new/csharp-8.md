---
title: What's New in C# 8.0 - C# Guide
description: Get an overview of the new features available in C# 8.0. This article is up-to-date with preview 2.
ms.date: 02/12/2019
---
# What's new in C# 8.0

There are many enhancements to the C# language that you can try out already with preview 2. The new features added in preview 2 are:

- [Pattern matching enhancements](#more-patterns-in-more-places):
  * [Switch expressions](#switch-expressions)
  * [Property patterns](#property-patterns)
  * [Tuple patterns](#tuple-patterns)
  * [Positional patterns](#positional-patterns)
- [Using declarations](#using-declarations)
- [Static local functions](#static-local-functions)
- [Disposable ref structs](#disposable-ref-structs)

The following language features first appeared in C# 8.0 preview 1:

- [Nullable reference types](#nullable-reference-types)
- [Asynchronous streams](#asynchronous-streams)
- [Indices and ranges](#indices-and-ranges)

> [!NOTE]
> This article was last updated for C# 8.0 preview 2.

The remainder of this article briefly describes these features. Where in-depth articles are available, links to those tutorials and overviews are provided.

## More patterns in more places

**Pattern matching** gives tools to provide shape-dependent functionality across related but different kinds of data. C# 7.0 introduced syntax for type patterns and constant patterns by using the [`is`](../language-reference/keywords/is.md) expression and the [`switch`](../language-reference/keywords/switch.md) statement. These features represented the first tentative steps toward supporting programming paradigms where data and functionality live apart. As the industry moves toward more microservices and other cloud-based architectures, other language tools are needed.

C# 8.0 expands this vocabulary so you can use more pattern expressions in more places in your code. Consider these features when your data and functionality are separate. Consider pattern matching when your algorithms depend on a fact other than the runtime type of an object. These techniques provide another way to express designs.

In addition to new patterns in new places, C# 8.0 adds **recursive patterns**. The result of any pattern expression is an expression. A recursive pattern is simply a pattern expression applied to the output of another pattern expression.

### switch expressions

Often, a [`switch`](../language-reference/keywords/switch.md) statement produces a value in each of its `case` blocks. **Switch expressions** enable you to use more concise expression syntax. There are fewer repetitive `case` and `break` keywords, and fewer curly braces.  As an example, consider the following enum that lists the colors of the rainbow:

```csharp
public enum Rainbow
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Indigo,
    Violet
}
```

You could convert a `Rainbow` value to its RGB values using the following method containing a switch expression:

```csharp
public static RGBColor FromRainbow(Rainbow colorBand) =>
    colorBand switch
    {
        Rainbow.Red    => new RGBColor(0xFF, 0x00, 0x00),
        Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
        Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
        Rainbow.Green  => new RGBColor(0x00, 0xFF, 0x00),
        Rainbow.Blue   => new RGBColor(0x00, 0x00, 0xFF),
        Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
        Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
        _              => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
    };
```

There are several syntax improvements here:

- The variable comes before the `switch` keyword. The different order makes it visually easy to distinguish the switch expression from the switch statement.
- The `case` and `:` elements are replaced with `=>`. It's more concise and intuitive.
- The `default` case is replaced with a `_` discard.
- The bodies are expressions, not statements.

Contrast that with the equivalent code using the classic `switch` statement:

```csharp
public static RGBColor FromRainbowClassic(Rainbow colorBand)
{
    switch (colorBand)
    {
        case Rainbow.Red:
            return new RGBColor(0xFF, 0x00, 0x00);
        case Rainbow.Orange:
            return new RGBColor(0xFF, 0x7F, 0x00);
        case Rainbow.Yellow:
            return new RGBColor(0xFF, 0xFF, 0x00);
        case Rainbow.Green:
            return new RGBColor(0x00, 0xFF, 0x00);
        case Rainbow.Blue:
            return new RGBColor(0x00, 0x00, 0xFF);
        case Rainbow.Indigo:
            return new RGBColor(0x4B, 0x00, 0x82);
        case Rainbow.Violet:
            return new RGBColor(0x94, 0x00, 0xD3);
        default:
            throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
    };
}
```

### Property patterns

The **property pattern** enables you to match on properties of the object examined. Consider an eCommerce site that must compute sales tax based on the buyer's address. That computation is not a core responsibility of an `Address` class. It will change over time, likely more often than address format changes. The amount of sales tax depends on the `State` property of the address. The following method uses the property pattern to compute the sales tax from the address and the price:

```csharp
public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
    location switch
    {
        { State: "WA" } => salePrice * 0.06M,
        { State: "MN" } => salePrice * 0.75M,
        { State: "MI" } => salePrice * 0.05M,
        // other cases removed for brevity...
        _ => 0M
    };
```

Pattern matching creates a concise syntax for expressing this algorithm.

### Tuple patterns

Some algorithms depend on multiple inputs. **Tuple patterns** allow you to switch based on multiple values expressed as a [tuple](../tuples.md).  The following code shows a switch expression for the game *rock, paper, scissors*:

```csharp
public static string RockPaperScissors(string first, string second)
    => (first, second) switch
    {
        ("rock", "paper") => "rock is covered by paper. Paper wins.",
        ("rock", "scissors") => "rock breaks scissors. Rock wins.",
        ("paper", "rock") => "paper covers rock. Paper wins.",
        ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
        ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
        ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
        (_, _) => "tie"
    };
```

The messages indicate the winner. The discard case represents the three combinations for ties, or other text inputs.

### Positional patterns

Some types include a `Deconstruct` method that deconstructs its properties into discrete variables. When a `Deconstruct` method is accessible, you can use **positional patterns** to inspect properties of the object and use those properties for a pattern.  Consider the following `Point` class that includes a `Deconstruct` method to create discrete variables for `X` and `Y`:

```csharp
public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) =>
        (x, y) = (X, Y);
}
```

Additionally, consider the following enum that represents various positions of a quadrant:

```csharp
public enum Quadrant
{
    Unknown,
    Origin,
    One,
    Two,
    Three,
    Four,
    OnBorder
}
```

The following method uses the **positional pattern** to extract the values of `x` and `y`. Then, it uses a `when` clause to determine the `Quadrant` of the point:

```csharp
static Quadrant GetQuadrant(Point point) => point switch
{
    (0, 0) => Quadrant.Origin,
    var (x, y) when x > 0 && y > 0 => Quadrant.One,
    var (x, y) when x < 0 && y > 0 => Quadrant.Two,
    var (x, y) when x < 0 && y < 0 => Quadrant.Three,
    var (x, y) when x > 0 && y < 0 => Quadrant.Four,
    var (_, _) => Quadrant.OnBorder,
    _ => Quadrant.Unknown
};
```

The discard pattern in the preceding switch matches when either `x` or `y` is 0, but not both. A switch expression must either produce a value or throw an exception. If none of the cases match, the switch expression throws an exception. The compiler generates a warning for you if you do not cover all possible cases in your switch expression.

You can explore pattern matching techniques in this [advanced tutorial on pattern matching](../tutorials/pattern-matching.md).

## using declarations

A **using declaration** is a variable declaration preceded by the `using` keyword. It tells the compiler that the variable being declared should be disposed at the end of the enclosing scope. For example, consider the following code that writes a text file:

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

In the preceding example, the file is disposed when the closing brace for the method is reached. That's the end of the scope in which `file` is declared. The preceding code is equivalent to the following code using the classic [using statements](../language-reference/keywords/using-statement.md) statement:

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

In the preceding example, the file is disposed when the closing brace associated with the `using` statement is reached.

In both cases, the compiler generates the call to `Dispose()`. The compiler generates an error if the expression in the using statement is not disposable.

## Static local functions

You can now add the `static` modifier to local functions to ensure that local function doesn't capture (reference) any variables from the enclosing scope. Doing so generates `CS8421`, "A static local function can't contain a reference to \<variable>." 

Consider the following code. The local function `LocalFunction` accesses the variable `y`, declared in the enclosing scope (the method `M`). Therefore, `LocalFunction` can't be declared with the `static` modifier:

```csharp
int M()
{
    int y;
    LocalFunction();
    return y;

    void LocalFunction() => y = 0;
}
```

The following code contains a static local function. It can be static because it doesn't access any variables in the enclosing scope:

```csharp
int M()
{
    int y = 5;
    int x = 7;
    return Add(x, y);

    static int Add(int left, int right) => left + right;
}
```

## Disposable ref structs

A `struct` declared with the `ref` modifier may not implement any interfaces and so cannot implement <xref:System.IDisposable>. Therefore, to enable a `ref struct` to be disposed, it must have an accessible `void Dispose()` method. This also applies to `readonly ref struct` declarations.

## Nullable reference types

Inside a nullable annotation context, any variable of a reference type is considered to be a **nonnullable reference type**. If you want to indicate that a variable may be null, you must append the type name with the `?` to declare the variable as a **nullable reference type**.

For nonnullable reference types, the compiler uses flow analysis to ensure that local variables are initialized to a non-null value when declared. Fields must be initialized during construction. The compiler generates a warning if the variable is not set by a call to any of the available constructors or by an initializer. Furthermore, nonnullable reference types can't be assigned a value that could be null.

Nullable reference types aren't checked to ensure they aren't assigned or initialized to null. However, the compiler uses flow analysis to ensure that any variable of a nullable reference type is checked against null before it's accessed or assigned to a nonnullable reference type.

You can learn more about the feature in the overview of [nullable reference types](../nullable-references.md). Try it yourself in a new application in this [nullable reference types tutorial](../tutorials/nullable-reference-types.md). Learn about the steps to migrate an existing codebase to make use of nullable reference types in the [migrating an application to use nullable reference types tutorial](../tutorials/upgrade-to-nullable-references.md).

## Asynchronous streams

Starting with C# 8.0, you can create and consume streams asynchronously. A method that returns an asynchronous stream has three properties:

1. It's declared with the `async` modifier.
1. It returns an <xref:System.Collections.Generic.IAsyncEnumerable%601>.
1. The method contains `yield return` statements to return successive elements in the asynchronous stream.

Consuming an asynchronous stream requires you to add the `await` keyword before the `foreach` keyword when you enumerate the elements of the stream. Adding the `await` keyword requires the method that enumerates the asynchronous stream to be declared with the `async` modifier and to return a type allowed for an `async` method. Typically that means returning a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>. It can also be a <xref:System.Threading.Tasks.ValueTask> or <xref:System.Threading.Tasks.ValueTask%601>. A method can both consume and produce an asynchronous stream, which means it would return an <xref:System.Collections.Generic.IAsyncEnumerable%601>. The following code generates a sequence from 0 to 19, waiting 100 ms between generating each number:

```csharp
public static async System.Collections.Generic.IAsyncEnumerable<int> GenerateSequence()
{
    for (int i = 0; i < 20; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}
```

You would enumerate the sequence using the `await foreach` statement:

```csharp
await foreach (var number in GenerateSequence())
{
    Console.WriteLine(number);
}
```

You can try asynchronous streams yourself in our tutorial on [creating and consuming async streams](../tutorials/generate-consume-asynchronous-stream.md).

## Indices and ranges

Ranges and indices provide a succinct syntax for specifying subranges in an array, <xref:System.Span%601>, or <xref:System.ReadOnlySpan%601>.

You can specify an index **from the end**. You specify **from the end** using the `^` operator. You are familiar with `array[2]` meaning the element "2 from the start". Now, `array[^2]` means the element "2 from the end". The index `^0` means "the end", or the index that follows the last element.

You can specify a **range** with the **range operator**: `..`. For example, `0..^0` specifies the entire range of the array: 0 from the start up to, but not including 0 from the end. Either operand may use "from the start" or "from the end". Furthermore, either operand may be omitted. The defaults are `0` for the start index, and `^0` for the end index.

Let's look at a few examples. Consider the following array, annotated with its index from the start and from the end:

```csharp
var words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumped",   // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};
```

The index of each element reinforces the concept of "from the start", and "from the end", and that ranges are exclusive of the end of the range. The "start" of the entire array is the first element. The "end" of the entire array is *past* the last element.

You can retrieve the last word with the `^1` index:

```csharp
Console.WriteLine($"The last word is {words[^1]}");
// writes "dog"
```

The following code creates a subrange with the words "quick", "brown", and "fox". It includes `words[1]` through `words[3]`. The element `words[4]` is not in the range.

```csharp
var quickBrownFox = words[1..4];
```

The following code creates a subrange with "lazy" and "dog". It includes `words[^2]` and `words[^1]`. The end index `words[^0]` is not included:

```csharp
var lazyDog = words[^2..^0];
```

The following examples create ranges that are open ended for the start, end, or both:

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
