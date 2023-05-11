---
title: Interpolated strings
description: Learn about interpolated strings, a special form of string that allows you to embed F# expressions directly inside them.
ms.date: 11/12/2020
---

# Interpolated strings

Interpolated strings are [strings](strings.md) that allow you to embed F# expressions into them. They are helpful in a wide range of scenarios where the value of a string may change based on the result of a value or expression.

## Syntax

```fsharp
$"string-text {expr}"
$"string-text %format-specifier{expr}"
$"""string-text {"embedded string literal"}"""
```

## Remarks

Interpolated strings let you write code in "holes" inside of a string literal. Here's a basic example:

```fsharp
let name = "Phillip"
let age = 30
printfn $"Name: {name}, Age: {age}"

printfn $"I think {3.0 + 0.14} is close to {System.Math.PI}!"
```

The contents in between each `{}` brace pair can be any F# expression.

To escape a `{}` brace pair, write two of them like so:

```fsharp
let str = $"A pair of braces: {{}}"
// "A pair of braces: {}"
```

## Typed interpolated strings

Interpolated strings can also have F# format specifiers to enforce type safety.

```fsharp
let name = "Phillip"
let age = 30

printfn $"Name: %s{name}, Age: %d{age}"

// Error: type mismatch
printfn $"Name: %s{age}, Age: %d{name}"
```

In the previous example, the code mistakenly passes the `age` value where `name` should be, and vice/versa. Because the interpolated strings use format specifiers, this is a compile error instead of a subtle runtime bug.

## Verbatim interpolated strings

F# supports verbatim interpolated strings with triple quotes so that you can embed string literals.

```fsharp
let age = 30

printfn $"""Name: {"Phillip"}, Age: %d{age}"""
```

## Format specifiers

Format specifiers can either be printf-style or .NET-style. Printf-style specifiers are those covered in [plaintext formatting](plaintext-formatting.md), placed before the braces. For example:

```fsharp
let pi = $"%0.3f{System.Math.PI}"  // "3.142"
let code = $"0x%08x{43962}"  // "0x0000abba"
```

The format specifier `%A` is particularly useful for producing diagnostic output of structured F# data.

```fsharp
let data = [0..4]
let output = $"The data is %A{data}"  // "The data is [0; 1; 2; 3; 4]"
```

.NET-style specifiers are those usable with <xref:System.String.Format%2A?displayProperty=nameWithType>, placed after a `:` within the braces. For example:

```fsharp
let pi = $"{System.Math.PI:N4}"  // "3.1416"
let now = $"{System.DateTime.UtcNow:``yyyyMMdd``}" // e.g. "20220210"
```

If a .NET-style specifier contains an unusual character, then it can be escaped using double-backticks:

```fsharp
let nowDashes = $"{System.DateTime.UtcNow:``yyyy-MM-dd``}" // e.g. "2022-02-10"
```

## Aligning expressions in interpolated strings

You can left-align or right-align expressions inside interpolated strings with `|` and a specification of how many spaces. The following interpolated string aligns the left and right expressions to the left and right, respectively, by seven spaces.

```fsharp
printfn $"""|{"Left",-7}|{"Right",7}|"""
// |Left   |  Right|
```

## Interpolated strings and `FormattableString` formatting

You can also apply formatting that adheres to the rules for <xref:System.FormattableString>:

```fsharp
let speedOfLight = 299792.458
printfn $"The speed of light is {speedOfLight:N3} km/s."
// "The speed of light is 299,792.458 km/s."
```

Additionally, an interpolated string can also be type checked as a <xref:System.FormattableString> via a type annotation:

```fsharp
let frmtStr = $"The speed of light is {speedOfLight:N3} km/s." : FormattableString
// Type: FormattableString
// The speed of light is 299,792.458 km/s.
```

Note that the type annotation must be on the interpolated string expression itself. F# does not implicitly convert an interpolated string into a <xref:System.FormattableString>.

## See also

* [Strings](strings.md)
* [F# RFC FS-1001 - Interpolated strings](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1001-StringInterpolation.md)
