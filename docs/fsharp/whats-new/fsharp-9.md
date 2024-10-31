---
title: What's new in F# 9 - F# Guide
description: Find information on the new features available in F# 9.
ms.date: 11/12/2024
ms.topic: whats-new
---

# What's new in F# 9

F# 9 introduces a range of enhancements that make your programs safer, more resilient, and performant. This article highlights the major changes in F# 9, developed in the [F#'s open source code repository](https://github.com/dotnet/fsharp).

You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## F# language changes

This section describes updates to the language itself, changes you will notice when writing or reading F# code.

### Nullable reference types

Although F# is designed to avoid `null`, it can creep in when interfacing with .NET libraries written in C#. F# now provides a type-safe way to deal with reference types that can have `null` as a valid value.

For more details, watch out for an [upcoming blog post about this feature](https://devblogs.microsoft.com/dotnet/tag/f/).

Here are some examples:

```fsharp
// Declared type at let-binding
let notAValue: string | null = null

let isAValue: string | null = "hello world"

let isNotAValue2: string = null // gives a nullability warning

let getLength (x: string | null) = x.Length // gives a nullability warning since x is a nullable string

// Parameter to a function
let len (str: string | null) =
    match str with
    | null -> -1
    | NonNull s -> s.Length  // binds a non-null result

// Parameter to a function
let len (str: string | null) =
    let s = nullArgCheck "str" str // Returns a non-null string
    s.Length  // binds a non-null result

// Declared type at let-binding
let maybeAValue: string | null = hopefullyGetAString()

// Array type signature
let f (arr: (string | null)[]) = ()

// Generic code, note 'T must be constrained to be a reference type
let findOrNull (index: int) (list: 'T list) : 'T | null when 'T : not struct =
    match List.tryItem index list with
    | Some item -> item
    | None -> null
```

### Discriminated union `.Is*` properties

Discriminated unions now have auto-generated properties for each case, allowing you to check if a value is of a particular case. For example, for the following type:

```fsharp
type Contact =
    | Email of address: string
    | Phone of countryCode: int * number: string

type Person = { name: string; contact: Contact }
```

Previously, you had to write something like:

```fsharp
let canSendEmailTo person =
    match person.contact with
    | Email _ -> true
    | _ -> false
```

Now, you can instead write:

```fsharp
let canSendEmailTo person =
    person.contact.IsEmail
```

### Partial active patterns can return `bool` instead of `unit option`

Previously, partial active patterns returned `Some ()` to indicate a match and `None` otherwise. Now, they can also return `bool`.

For example, the active pattern for the following:
```fsharp
match key with
| CaseInsensitive "foo" -> ...
| CaseInsensitive "bar" -> ...
```

Was previously written as:

```fsharp
let (|CaseInsensitive|_|) (pattern: string) (value: string) =
    if String.Equals(value, pattern, StringComparison.OrdinalIgnoreCase) then
        Some ()
    else
        None
```

Now, you can instead write:

```fsharp
let (|CaseInsensitive|_|) (pattern: string) (value: string) =
    String.Equals(value, pattern, StringComparison.OrdinalIgnoreCase)
```

### Prefer extension methods to intrinsic properties when arguments are provided

To align with a pattern seen in some .NET libraries, where extension methods are defined with the same names as intrinsic properties of a type, F# now resolves these extension methods instead of failing the type check.

Example:

```fsharp
type Foo() =
    member val X : int = 0 with get, set

[&ltExtension&gt;]
type FooExt =
    [&ltExtension&gt;]
    static member X (f: Foo, i: int) = f.X <- i; f

let f = Foo()

f.X(1) // We can now call the extension method to set the property and chain further calls
```

### Support for empty-bodied computation expressions

F# now supports empty [computation expressions](../language-reference/computation-expressions.md).

<pre class="language-fsharp"><code>let xs = seq { } // Empty sequence```

```fsharp
let html =
    div {
        p { "Some content." }
        p { } // Empty paragraph
    }```

Writing an empty computation expression will result in a call to the CE builder's `Zero` method.

This is a more natural syntax compared to the previously available `builder { () }`.

### Hash directives are allowed to take non-string arguments

Hash directives for the compiler previously only allowed string arguments passed in quotes. Now, they can take any type of argument.

Previously, you had:
```fsharp
#nowarn "0070"
#time "on"```

Now, you can write:
```fsharp
#nowarn 0070
#time on```

This also ties into the next two changes.

### Extended #help directive in fsi to show documentation in the REPL

The `#help` directive in F# Interactive now shows documentation for a given object or function, which you can now pass without quotes.

<pre><code>&gt; #help List.map;;

Description:
Builds a new collection whose elements are the results of applying the given function
to each of the elements of the collection.

Parameters:
- mapping: The function to transform elements from the input list.
- list: The input list.
Returns:
The list of transformed elements.

Examples:
let inputs = [ "a"; "bbb"; "cc" ]

inputs |> List.map (fun x -> x.Length)
// Evaluates to [ 1; 3; 2 ]

Full name: Microsoft.FSharp.Collections.ListModule.map
Assembly: FSharp.Core.dll
```

### Allow #nowarn to support the FS prefix on error codes to disable warnings

Previously, when you wanted to disable a warning and wrote `#nowarn "FS0057"`, you would get an `Invalid warning number 'FS0057'`. Even though the warning number is correct, it just wasn't supposed to have the `FS` prefix.

Now, you won't have to spend time figuring that out because the warning numbers are accepted even with the prefix.

All of these will now work:
```fsharp
#nowarn 57
#nowarn 0057
#nowarn FS0057

#nowarn "57"
#nowarn "0057"
#nowarn "FS0057"
```

It's a good idea to use the same style throughout your project.

### Warning about TailCall attribute on non-rec functions or let-bound values

F# now emits a warning when you put the `[<TailCall>]` attribute somewhere it doesn't belong. While it has no effect on what the code does, it could confuse someone reading it.

For example, these usages will now emit a warning:
```fsharp
[&lt;TailCall&gt;]
let someNonRecFun x = x + x

[&lt;TailCall&gt;]
let someX = 23

[&lt;TailCall&gt;]
let rec someRecLetBoundValue = nameof(someRecLetBoundValue)
```

### Enforce attribute targets

The compiler now correctly enforces the `AttributeTargets` on let values, functions, union case declarations, implicit constructors, structs, and classes. This can prevent some hard-to-notice bugs, such as forgetting to add the unit argument to an Xunit test.

Previously, you could write:

```fsharp
[&lt;Fact&gt;]
let ``this test always fails`` =
  Assert.True(false)
```

When you ran the tests with `dotnet test`, they would pass. Since the test function is not actually a function, it was ignored by the test runner.

Now, with correct attribute enforcement, you will get an `error FS0842: This attribute is not valid for use on this language element`.

## Updates to the standard library (FSharp.Core)

### Random functions for collections

The `List`, `Array`, and `Seq` modules have new functions for random sampling and shuffling. This makes F# easier to use for common data science, machine learning, game development, and other scenarios where randomness is needed.

All functions have the following variants:

* One that uses an implicit, thread-safe, shared <xref:System.Random> instance
* One that takes a `Random` instance as an argument
* One that takes a custom `randomizer` function, which should return a float value greater than or equal to 0.0 and less than 1.0

There are four functions (each with three variants) available: `Shuffle`, `Choice`, `Choices`, and `Sample`.

#### Shuffle

The `Shuffle` functions return a new collection of the same type and size, with each item in a randomly mixed position. The chance to end up in any position is weighted evenly on the length of the collection.

```fsharp
let allPlayers = [ "Alice"; "Bob"; "Charlie"; "Dave" ]
let round1Order = allPlayers |> List.randomShuffle // [ "Charlie"; "Dave"; "Alice"; "Bob" ]
```

For arrays, there are also `InPlace` variants that shuffle the array in place.

#### Choice

The `Choice` functions return a single random element from the given collection. The random choice is weighted evenly on the size of the collection.

```fsharp
let allPlayers = [ "Alice"; "Bob"; "Charlie"; "Dave" ]
let randomPlayer = allPlayers |> List.randomChoice // "Charlie"
```

#### Choices

The `Choices` functions select N elements from the input collection in random order, allowing elements to be selected more than once.

```fsharp
let weather = [ "Raining"; "Sunny"; "Snowing"; "Windy" ]
let forecastForNext3Days = weather |> List.randomChoices 3 // [ "Windy"; "Snowing"; "Windy" ]
```

#### Sample

The `Sample` functions select N elements from the input collection in random order, without allowing elements to be selected more than once. N cannot be greater than the collection length.

```fsharp
let foods = [ "Apple"; "Banana"; "Carrot"; "Donut"; "Egg" ]
let today'sMenu = foods |> List.randomSample 3 // [ "Donut"; "Apple"; "Egg" ]
```

For a full list of functions and their variants, see ([RFC #1135](https://github.com/fsharp/fslang-design/blob/main/RFCs/FS-1135-random-functions-for-collections.md)).

### Parameterless constructor for `CustomOperationAttribute`

This constructor makes it easier to create a custom operation for a computation expression builder. It uses the name of the method instead of having to explicitly name it (when in most cases the name matches the method name already).

```fsharp
type FooBuilder() =
    [&lt;CustomOperation&gt;]  // Previously had to be [&lt;CustomOperation("bar")&gt;]
    member _.bar(state) = state
```

### C# collection expression support for F# lists and sets

When using F# lists and sets from C#, you can now use collection expressions to initialize them.

Instead of:

```csharp
FSharpSet&lt;int&gt; mySet = SetModule.FromArray([1, 2, 3]);
```

You can now write:

```csharp
FSharpSet&lt;int&gt; mySet = [ 1, 2, 3 ];
```

Collection expressions make it easier to use the F# immutable collections from C#. You might want to use the F# collections when you need their structural equality, which <xref:System.Collections.Immutable> collections don't have.

## Quality of life improvements

### Parser recovery

There have been continuous improvements in parser recovery, meaning that tooling (for example, syntax highlighting) still works with code when you're in the middle of editing it and it might not be syntactically correct at all times.

For example, the parser will now recover on unfinished `as` patterns, object expressions, enum case declarations, record declarations, complex primary constructor patterns, unresolved long identifiers, empty match clauses, missing union case fields, and missing union case field types.

### Diagnostics

Diagnostics, or understanding what the compiler doesn't like about your code, are an important part of the user experience with F#. There are a number of new or improved diagnostic messages or more precise diagnostic locations in F# 9.

These include:

- Ambiguous override method in object expression
- Abstract members when used in non-abstract classes
- Property that has the same name as a discriminated union case
- Active pattern argument count mismatch
- Unions with duplicated fields
- Using `use!` with `and!` in computation expressions

There is also a new compile-time error for classes with over 65,520 methods in generated [IL](../../standard/managed-code.md#intermediate-language--execution). Such classes aren't loadable by the CLR and would result in a run-time error. (Not that you would ever really want to have so many methods, but there have been cases with generated code.)

### Real visibility

There is a quirk with how F# generates assemblies that results in private members being written to [IL](../../standard/managed-code.md#intermediate-language--execution) as internal. This allows inappropriate access to private members from non-F# projects that have access to an F# project via [`InternalsVisibleTo`](xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute).

Now, there is an opt-in fix for this behavior available via the `--realsig+` compiler flag. Try it in your solution to see if any of your projects depend on this behavior. You can add it to your `.fsproj` files like this:

```xml
<PropertyGroup>
    &lt;OtherFlags&gt;--realsig+&lt;/OtherFlags&gt;
&lt;/PropertyGroup&gt;
```

## Performance improvements

### Optimized equality checks

Equality checks are now faster and allocate less memory.

For example:

```fsharp
[&lt;Struct&gt;]
type MyId =
    val Id: int
    new id = { Id = id }

let ids = Array.init 1000 MyId
let missingId = MyId -1

// used to box 1000 times, doesn't box anymore
let _ = ids |> Array.contains missingId
```

You can read all the details here: [F# Developer Stories: How we’ve finally fixed a 9-year-old performance issue](https://devblogs.microsoft.com/dotnet/fsharp-developer-stories-how-weve-finally-fixed-a-9yearold-performance-issue/).

### Field sharing for struct discriminated unions

If fields in multiple cases of a struct discriminated union have the same name and type, they can share the same location, reducing the struct's memory footprint. (Previously, same field names weren't allowed, so there are no issues with binary compatibility.)

### Integral range optimizations

The compiler now generates optimized code for more instances of `start..finish` and `start..step..finish` expressions. Previously, these were only optimized when the type was `int`/`int32` and the step was a constant `1` or `-1`. Other integral types and different step values used an inefficient `IEnumerable`-based implementation. Now, all of these are optimized.

This leads to anywhere from 1.25× up to 8× speed up in loops:

```fsharp
for … in start..finish do …
```

List/array expressions:

```fsharp
[start..step..finish]
```

and comprehensions:

```fsharp
[for n in start..finish -> f n]
```

### Optimized `for x in xs -> …` in list and array comprehensions

On a related note, comprehensions with `for x in xs -> …` have been optimized for lists and arrays, with notable improvements especially for arrays, with speedups up to 10× and ⅓ to ¼ allocation size.

## Improvements in tooling

### Live buffers in Visual Studio

This previously opt-in feature has been thoroughly tested and is now enabled by default. The background compiler powering the IDE now works with live file buffers, meaning you don't have to save the files to disk to get the changes applied. Previously, this could cause some unexpected behavior. (Most notoriously when you tried to rename a symbol present in a file that had been edited but not saved.)

### Analyzer and code fix for removing unnecessary parentheses

Sometimes extra parentheses are used for clarity, but sometimes they are just noise. For the latter case, you now get a code fix in Visual Studio to remove them.

For example:
```fsharp
let f (x) = x // -> let f x = x
let _ = (2 * 2) + 3 // -> let _ = 2 * 2 + 3
```

### Custom visualizer support for F# in Visual Studio

The debugger visualizer in Visual Studio now works with F# projects.

![debug visualizer](../media/whats-new/fsharp-9/vs-visualizer.gif)

### Signature tooltips shown mid-pipeline

Previously, no signature help was offered in a situation like the following, where a function in the middle of a pipeline already had a complex curried parameter (for example, a lambda) applied to it. Now, the signature tooltip shows up for the next parameter (`state`):

![tooltip](../media/whats-new/fsharp-9/help.png)