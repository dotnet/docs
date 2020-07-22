---
title: "Tutorial: Plain Text Formatting"
description: Learn how to use structured formatted plain text in F# applications and scripts.
ms.date: 07/22/2020
---

# Plain Text Formatting

F# allows values to be formatted as structured plain text in a compositional way.
As a simple example, consider the following and note how the otuput has been formatted as a matrix-like display of tuples.

```console
dotnet fsi

> let data = [ for i in 1 .. 3 -> [ for j in 1 .. 3 -> (i, j) ] ];;

val data : (int * int) list list =
  [[(1, 1); (1, 2); (1, 3); (1, 4); (1, 5)];
   [(2, 1); (2, 2); (2, 3); (2, 4); (2, 5)];
   [(3, 1); (3, 2); (3, 3); (3, 4); (3, 5)];
   [(4, 1); (4, 2); (4, 3); (4, 4); (4, 5)];
   [(5, 1); (5, 2); (5, 3); (5, 4); (5, 5)]]

>  printfn "%A" data;;
[[(1, 1); (1, 2); (1, 3); (1, 4); (1, 5)];
 [(2, 1); (2, 2); (2, 3); (2, 4); (2, 5)];
 [(3, 1); (3, 2); (3, 3); (3, 4); (3, 5)];
 [(4, 1); (4, 2); (4, 3); (4, 4); (4, 5)];
 [(5, 1); (5, 2); (5, 3); (5, 4); (5, 5)]]
```

Plain text formatting is activated when using the `%A` format in printf formatting strings. This has limited customizability.
It is also used when formatting the output of values in F# interactive, when the output includes extra information and is additionally customizable.
Plain text formatting is observable through the following:

1. The default results of `x.ToString()` on F# union and record values, when `sprintf "%+A"` is used.

2. The default debug text of F# union and record values (and structured values containing these), when `sprintf "%+A"` is also used.

## `%A` formatting

The `%A` format specifier is used to format values in a human-readable way suitable for interpretation by the F#
programmer.  It is not suitable for formatting results for other users and should not generally be used to format
results in a user interface or web programming service.  It is often useful for reporting diagnostic information.

### `%A` formatting of primitive values

When formatting plain text using the `%A` specifier, F# numeric values are formatted
with their suffix and invariant culture. Floating point values are formatted using
10 places of floating point precision. For example,

```fsharp
printfn "%A" (1L, 3n, 5u, 7, 4.03f, 5.000000001, 5.0000000001)
```

produces

```console
(1L, 3n, 5u, 7, 4.03000021f, 5.000000001, 5.0)
```

When using the `%A` specifier, strings are formatted using quotes. Escape codes are not added and instead the raw characters are printed. For example,

```fsharp
printfn "%A" ("abc", "a\tb\nc\"d")

```

produces

```console
("abc", "a      b
c"d")
```

### `%A` formatting of .NET values

When formatting plain text using the `%A` specifier, non-F# .NET objects are formatted by using `x.ToString()` using the default settings of .NET given by
`System.Globalization.CultureInfo.CurrentCulture` and `System.Globalization.CultureInfo.CurrentUICulture`.  For example,

```fsharp
open System.Globalization

let date = System.DateTime(1999, 12, 31)

CultureInfo.CurrentCulture <- CultureInfo.GetCultureInfo("de-DE")
printfn "Culture 1: %A" date

CultureInfo.CurrentCulture <- CultureInfo.GetCultureInfo("en-US")
printfn "Culture 2: %A" date
```

produces

```console
Culture 1: 31.12.1999 00:00:00
Culture 2: 12/31/1999 12:00:00 AM
```

### `%A` formatting of structured values

When formatting plain text using the `%A` specifier, block indentation is used for F# lists and tuples. The is shown in the example above.
The structure of arrays is also used, including multi-dimensional arrays.  Single-dimensional arrays are shown with `[| ... |]` syntax. For example,

```fsharp
printfn "%A" [| for i in 1 .. 20 -> (i, i*i) |]
```

produces

```console
[|(1, 1); (2, 4); (3, 9); (4, 16); (5, 25); (6, 36); (7, 49); (8, 64); (9, 81);
  (10, 100); (11, 121); (12, 144); (13, 169); (14, 196); (15, 225); (16, 256);
  (17, 289); (18, 324); (19, 361); (20, 400)|]
```

A default print width of 80 is used.  This can be customized by using a print width in the format specifier. For example,

```fsharp
printfn "%10A" [| for i in 1 .. 5 -> (i, i*i) |]

printfn "%20A" [| for i in 1 .. 5 -> (i, i*i) |]

printfn "%50A" [| for i in 1 .. 5 -> (i, i*i) |]
```

produces

```console
[|(1, 1);
  (2, 4);
  (3, 9);
  (4, 16);
  (5, 25)|]
[|(1, 1); (2, 4);
  (3, 9); (4, 16);
  (5, 25)|]
[|(1, 1); (2, 4); (3, 9); (4, 16); (5, 25)|]
```

A depth limit of 4 is used for sequence (IEnumerable) values, which are shown as `seq { ...}`, and a depth limit of 100 is used for list and array values.
For example,

```fsharp
printfn "%A" (seq { for i in 1 .. 10 -> (i, i*i) })
```

produces

```console
seq [(1, 1); (2, 4); (3, 9); (4, 16); ...]
```

Block indentation is also used for the the structure of public record and union values. For example,

```fsharp
type R = { X : int list; Y : string list }

printfn "%A" { X =  [ 1;2;3 ]; Y = ["one"; "two"; "three"] }
```

produces

```console
{ X = [1; 2; 3]
  Y = ["one"; "two"; "three"] }
```

If `%+A` is used then the private structure of records and unions
is also revealed by using reflection. For example

```fsharp
type internal R =
    { X : int list; Y : string list }
    override x.ToString() = "R"

let internal data = { X = [ 1;2;3 ]; Y = ["one"; "two"; "three"] }

printfn "external view:\n%A" data

printfn "internal view:\n%+A" data

```

produces

```console
external view:
R

internal view:
{ X = [1; 2; 3]
  Y = ["one"; "two"; "three"] }
```

### `%A` formatting of large, cyclic or deeply nested values

Large structured values are formatted to a maximum overall object node count of 10000.
Deeply nested values are formatted to a depth of 100.  In both cases `...` is used
to elide some of the output.  For example,

```fsharp
type Tree = Node of Tree * Tree | Tip

let rec make n = if n = 0 then Tip else Node(Tip, make (n-1))

printfn "%A" (make 1000)
```

produces a large output with some parts elided

```console
Node(Tip, Node(Tip, ....Node (..., ...)...))
```

Cycles are detected in the object graphs and `...` is used at places where cycles are detected. For example

```fsharp
type R = { mutable Links: R list }
let r = { Links = [] }
r.Links <- [r]
printfn "%A" r
```

produces

```console
{ Links = [...] }
```

### `%A` formatting of lazy, null and function values

Lazy values are printed as `Value is not created` or equivalent text when the value has not yet been evaluated.

Null values are printed as `null` unless the static type of the value is determined to be a union type where `null` is
a permitted represenation.

F# function values are printed as their internally generated closure name, for example `<fun:it@43-7>`.

### Customizing plain text formatting with `StructuredFormatDisplayAttribute`

When using the `%A` specifier, the presence of `StructuredFormatDisplayAttribute` on type declarations is respected.  This can
be used to specify surrogate text and property to display a value. For example:

```fsharp
[<StructuredFormatDisplay("Counts({Clicks})")>]
type Counts = { Clicks:int list}

printfn "%20A" {Clicks=[0..20]}
```

produces

```console
Counts([0; 1; 2; 3;
        4; 5; 6; 7;
        8; 9; 10; 11;
        12; 13; 14;
        15; 16; 17;
        18; 19; 20])
```

### Customizing plain text formatting by overriding `ToString`

The default implementation of `x.ToString()` is observable in F# programming. Often the default results
are not suitable for use in either programmer-facing information display nor user output, and as a result it
is common to override the default implementation.  

By default F# record and union types override the implementation of `x.ToString()` with an implementation that
uses `sprintf "%+A"`.  For example,

```fsharp
type Counts = { Clicks:int list }

printfn "%s" ({Clicks=[0..10]}.ToString())
```

produces

```console
{ Clicks = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10] }
```

For class types, no default implementation of `ToString()` is provided and the .NET default is used, which reports the
name of the type. For example,

```fsharp
type MyClassType(clicks: int list) =
   member x.Clicks = clicks

printfn "The default ToString gives --> %s" (MyClassType([1..5]).ToString())
```

produces

```console
The default ToString gives --> MyClassType
```

Sometimes `sprintf "%A"` plus a `StructuredFormatDisplay` attribute makes for a suitable implementation
of `ToString`, e.g.

```fsharp
[<StructuredFormatDisplay("Counts({Clicks})")>]
type MyClassType(clicks: int list) =
   member x.Clicks = clicks
   override x.ToString() = sprintf "%A" x

printfn "ToString now gives --> %s" (MyClassType([1..5]).ToString())
```

produces

```console
ToString now gives --> Counts([1; 2; 3; 4; 5])
```

## F# Interactive Structured Printing

F# Interactive (`dotnet fsi`) uses an extended version of structured plain text formatting to
report values and allows additional customizability. See [F# Interactive](fsharp-interactive-options.md)
for details.

## Customizing debug displays using DebuggerDisplayAttribute, DebuggerTypeProxyAttribute and other attributes

Debuggers for .NET respect the use of attributes such as `DebuggerDisplayAttribute` and `DebuggerTypeProxyAttribute`
and these affect the structured display of objects in debugger inspection windows.
The F# compiler automatically generated these attributes for discriminated union and record types, but
not class, interface or struct types.

These attributed are ignored in F# plain text formatting, but it can be useful to implement
these methods to improve displays when debugging F# types.

## See also

- [Strings](strings.md)
- [Records](records.md)
- [Discriminated Unions](discriminated-unions.md)
- [F# Interactive](fsharp-interactive-options.md)
