---
title: "Plain Text Formatting"
description: Learn how to use printf and other plain text formatting in F# applications and scripts.
ms.date: 05/28/2021
---

# Plain text formatting

F# supports type-checked formatting of plain text using `printf`, `printfn`, `sprintf`, and related functions.
For example,

```console
dotnet fsi

> printfn "Hello %s, %d + %d is %d" "world" 2 2 (2+2);;
```

gives the output

```fsharp
Hello world, 2 + 2 is 4
```

F# also allows structured values to be formatted as plain text.
For example, consider the following example that formats the output as a matrix-like display of tuples.

```console
dotnet fsi

> printfn "%A" [ for i in 1 .. 5 -> [ for j in 1 .. 5 -> (i, j) ] ];;

[[(1, 1); (1, 2); (1, 3); (1, 4); (1, 5)];
 [(2, 1); (2, 2); (2, 3); (2, 4); (2, 5)];
 [(3, 1); (3, 2); (3, 3); (3, 4); (3, 5)];
 [(4, 1); (4, 2); (4, 3); (4, 4); (4, 5)];
 [(5, 1); (5, 2); (5, 3); (5, 4); (5, 5)]]
```

Structured plain text formatting is activated when you use the `%A` format in `printf` formatting strings.
It's also activated when formatting the output of values in F# interactive, where the output includes extra information and is additionally customizable.
Plain text formatting is also observable through any calls to `x.ToString()` on F# union and record values, including those
that occur implicitly in debugging, logging, and other tooling.

## Checking of `printf`-format strings

A compile-time error will be reported if a `printf` formatting function is used with an argument that doesn't match the printf format
specifiers in the format string.  For example,

```fsharp
sprintf "Hello %s" (2+2)
```

gives the output

```console
  sprintf "Hello %s" (2+2)
  ----------------------^

stdin(3,25): error FS0001: The type 'string' does not match the type 'int'
```

Technically speaking, when using `printf` and other related functions, a special rule in the F# compiler
checks the string literal passed as the format string, ensuring the subsequent arguments applied are of
the correct type to match the format specifiers used.

## Format specifiers for `printf`

Format specifications for `printf` formats are strings with `%` markers that indicate format. Format placeholders consist of `%[flags][width][.precision][type]`
where the type is interpreted as follows:

| Format specifier   | Type(s)        | Remarks                      |
|:-------------------|:---------------|:-----------------------------|
| `%b`               | `bool` (`System.Boolean`) | Formatted as `true` or `false`                |
| `%s`               | `string` (`System.String`) | Formatted as its unescaped contents         |
| `%c`               | `char` (`System.Char`) | Formatted as the character literal  |
| `%d`, `%i`         | a basic integer type | Formatted as a decimal integer, signed if the basic integer type is signed |
| `%u`               | a basic integer type | Formatted as an unsigned decimal integer   |
| `%x`, `%X`         | a basic integer type | Formatted as an unsigned hexadecimal number (a-f or A-F for hex digits respectively)  |
|  `%o`              | a basic integer type | Formatted as an unsigned octal number |
|  `%B`              | a basic integer type | Formatted as an unsigned binary number |
| `%e`, `%E`         | a basic floating point type | Formatted as a signed value having the form `[-]d.dddde[sign]ddd` where d is a single decimal digit, dddd is one or more decimal digits, ddd is exactly three decimal digits, and sign is `+` or `-` |
| `%f`, `%F`         | a basic floating point type | Formatted as a signed value having the form `[-]dddd.dddd`, where `dddd` is one or more decimal digits. The number of digits before the decimal point depends on the magnitude of the number, and the number of digits after the decimal point depends on the requested precision. |
| `%g`, `%G` | a basic floating point type |  Formatted using as a signed value printed in `%f` or `%e` format, whichever is more compact for the given value and precision. |
| `%M` | a `decimal` (`System.Decimal`) value |    Formatted using the `"G"` format specifier for `System.Decimal.ToString(format)` |
| `%O` | any value  |   Formatted by boxing the object and calling its `System.Object.ToString()` method |
| `%A` | any value  |   Formatted using [structured plain text formatting](plaintext-formatting.md) with the default layout settings |
| `%a` | any value  |   Requires two arguments: a formatting function accepting a context parameter and the value, and the particular value to print |
| `%t` | any value  |   Requires one argument: a formatting function accepting a context parameter that either outputs or returns the appropriate text |
| `%%` | (none)  |   Requires no arguments and prints a plain percent sign: `%` |

Basic integer types are `byte` (`System.Byte`), `sbyte` (`System.SByte`), `int16` (`System.Int16`), `uint16` (`System.UInt16`), `int32` (`System.Int32`), `uint32` (`System.UInt32`), `int64` (`System.Int64`), `uint64` (`System.UInt64`), `nativeint`  (`System.IntPtr`), and `unativeint`  (`System.UIntPtr`).
 Basic floating point types are `float` (`System.Double`), `float32` (`System.Single`), and `decimal` (`System.Decimal`).

The optional width is an integer indicating the minimal width of the result. For instance, `%6d` prints an integer, prefixing it with spaces
to fill at least six characters. If width is `*`, then an extra integer  argument is taken to specify the corresponding width.

Valid flags are:

| Flag   | Effect        | Remarks                      |
|:-------------------|:---------------|:-----------------------------|
| `0`  | Add zeros instead of spaces to make up the required width |    |
| `-` |  Left justify the result within the specified width |   |
| `+`  | Add a `+` character if the number is positive (to match a `-` sign for negatives) |   |
| space character | Add an extra space if the number is positive (to match a '-' sign for negatives) |

The printf `#` flag is invalid and a compile-time error will be reported if it is used.

Values are formatted using invariant culture. Culture settings are irrelevant to `printf` formatting except
when they affect the results of `%O` and `%A` formatting. For more information, see [structured plain text formatting](plaintext-formatting.md).

## `%A` formatting

The `%A` format specifier is used to format values in a human-readable way, and can also be useful for reporting diagnostic information.

### Primitive values

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

### .NET values

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

### Structured values

When formatting plain text using the `%A` specifier, block indentation is used for F# lists and tuples. This shown in the previous example.
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

The default print width is 80.  This width can be customized by using a print width in the format specifier. For example,

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

Specifying a print width of 0 results in no print width being used. A single line of text will result, except where embedded strings in the
output contain line breaks.  For example

```fsharp
printfn "%0A" [| for i in 1 .. 5 -> (i, i*i) |]

printfn "%0A" [| for i in 1 .. 5 -> "abc\ndef" |]
```

produces

```console
[|(1, 1); (2, 4); (3, 9); (4, 16); (5, 25)|]
[|"abc
def"; "abc
def"; "abc
def"; "abc
def"; "abc
def"|]
```

A depth limit of 4 is used for sequence (`IEnumerable`) values, which are shown as `seq { ...}`. A depth limit of 100 is used for list and array values.
For example,

```fsharp
printfn "%A" (seq { for i in 1 .. 10 -> (i, i*i) })
```

produces

```console
seq [(1, 1); (2, 4); (3, 9); (4, 16); ...]
```

Block indentation is also used for the structure of public record and union values. For example,

```fsharp
type R = { X : int list; Y : string list }

printfn "%A" { X =  [ 1;2;3 ]; Y = ["one"; "two"; "three"] }
```

produces

```console
{ X = [1; 2; 3]
  Y = ["one"; "two"; "three"] }
```

If `%+A` is used, then the private structure of records and unions
is also revealed by using reflection. For example

```fsharp
type internal R =
    { X : int list; Y : string list }
    override _.ToString() = "R"

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

### Large, cyclic, or deeply nested values

Large structured values are formatted to a maximum overall object node count of 10000.
Deeply nested values are formatted to a depth of 100.  In both cases `...` is used
to elide some of the output.  For example,

```fsharp
type Tree =
    | Tip
    | Node of Tree * Tree

let rec make n =
    if n = 0 then
        Tip
    else
        Node(Tip, make (n-1))

printfn "%A" (make 1000)
```

produces a large output with some parts elided:

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

### Lazy, null, and function values

Lazy values are printed as `Value is not created` or equivalent text when the value has not yet been evaluated.

Null values are printed as `null` unless the static type of the value is determined to be a union type where `null` is
a permitted representation.

F# function values are printed as their internally generated closure name, for example, `<fun:it@43-7>`.

### Customize plain text formatting with `StructuredFormatDisplay`

When using the `%A` specifier, the presence of the `StructuredFormatDisplay` attribute on type declarations is respected.  This can
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

### Customize plain text formatting by overriding `ToString`

The default implementation of `ToString` is observable in F# programming. Often, the default results
aren't suitable for use in either programmer-facing information display or user output, and as a result it
is common to override the default implementation.  

By default, F# record and union types override the implementation of `ToString` with an implementation that
uses `sprintf "%+A"`.  For example,

```fsharp
type Counts = { Clicks:int list }

printfn "%s" ({Clicks=[0..10]}.ToString())
```

produces

```console
{ Clicks = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10] }
```

For class types, no default implementation of `ToString` is provided and the .NET default is used, which reports the
name of the type. For example,

```fsharp
type MyClassType(clicks: int list) =
   member _.Clicks = clicks

let data = [ MyClassType([1..5]); MyClassType([1..5]) ]
printfn "Default structured print gives this:\n%A" data
printfn "Default ToString gives:\n%s" (data.ToString())
```

produces

```console
Default structured print gives this:
[MyClassType; MyClassType]
Default ToString gives:
[MyClassType; MyClassType]
```

Adding an override for `ToString` can give better formatting.

```fsharp
type MyClassType(clicks: int list) =
   member _.Clicks = clicks
   override _.ToString() = sprintf "MyClassType(%0A)" clicks

let data = [ MyClassType([1..5]); MyClassType([1..5]) ]
printfn "Now structured print gives this:\n%A" data
printfn "Now ToString gives:\n%s" (data.ToString())
```

produces

```console
Now structured print gives this:
[MyClassType([1; 2; 3; 4; 5]); MyClassType([1; 2; 3; 4; 5])]
Now ToString gives:
[MyClassType([1; 2; 3; 4; 5]); MyClassType([1; 2; 3; 4; 5])]
```

## F# Interactive structured printing

F# Interactive (`dotnet fsi`) uses an extended version of structured plain text formatting to
report values and allows additional customizability. For more information, see [F# Interactive](fsharp-interactive-options.md).

## Customize debug displays

Debuggers for .NET respect the use of attributes such as `DebuggerDisplay` and `DebuggerTypeProxy`,
and these affect the structured display of objects in debugger inspection windows.
The F# compiler automatically generated these attributes for discriminated union and record types, but
not class, interface, or struct types.

These attributes are ignored in F# plain text formatting, but it can be useful to implement
these methods to improve displays when debugging F# types.

## See also

- [Strings](strings.md)
- [Records](records.md)
- [Discriminated Unions](discriminated-unions.md)
- [F# Interactive](fsharp-interactive-options.md)
