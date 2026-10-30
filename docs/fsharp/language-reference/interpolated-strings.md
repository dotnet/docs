---
title: Interpolated strings
description: Learn about interpolated strings, a special form of string that allows you to embed F# expressions directly inside them.
ms.date: 09/25/2026
ai-usage: ai-assisted
---

# Interpolated strings

Interpolated strings are [strings](strings.md) that allow you to embed F# expressions into them. They are helpful in a wide range of scenarios where the value of a string may change based on the result of a value or expression.

## Syntax

```fsharp
$"string-text {expr}"
$"string-text %format-specifier{expr}"
$@"string-text {expr}"
@$"string-text {expr}"
$"""string-text {"embedded string literal"}"""
$$"""string-text %%format-specifier{{expr}}"""
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

For string-valued interpolation in F# 11, an unformatted expression uses F#'s `string` conversion. If the expression evaluates to `null`, an empty string is used. Earlier compilers could optimize some string-only interpolations, but otherwise used printf formatting; see [Native AOT and string-valued interpolation](#native-aot-and-string-valued-interpolation) for formatting differences.

For typed interpolated strings with format specifiers (such as `%s{expr}` or `%d{expr}`), the conversion follows the rules defined for that specific format specifier.
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

F# supports verbatim interpolated strings in two ways:

### Using `$@` or `@$` prefix

You can combine the interpolation prefix `$` with the verbatim string prefix `@` in any order. Verbatim strings ignore escape sequences (except for `""` to represent a quotation mark) and can span multiple lines. This is especially useful when working with file paths or strings containing backslashes and quotes.

```fsharp
let name = "Alice"
let path = @"C:\Users\Alice\Documents"

// Using $@ prefix
printfn $@"User {name} has files in: {path}"

// Using @$ prefix (also valid)
printfn @$"User {name} has files in: {path}"

// Embedding quotes - use "" to represent a single "
let message = $@"He said ""{name}"" is here"
```

### Using triple quotes

F# also supports verbatim interpolated strings with triple quotes so that you can embed string literals without escaping.

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

.NET-style specifiers are those usable with <xref:System.String.Format*?displayProperty=nameWithType>, placed after a `:` within the braces. For example:

```fsharp
let pi = $"{System.Math.PI:N4}"  // "3.1416"
let now = $"{System.DateTime.UtcNow:``yyyyMMdd``}" // for example, "20220210"
```

If a .NET-style specifier contains an unusual character, then it can be escaped using double-backticks:

```fsharp
let nowDashes = $"{System.DateTime.UtcNow:``yyyy-MM-dd``}" // for example, "2022-02-10"
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

## Extended syntax for string interpolation

Beginning with F# 8, when you work with text containing multiple `{`, `}` or `%` characters already, you can use extended string interpolation syntax to remove the need for escaping.

Triple quote string literals can start with multiple `$` characters, which changes how many braces are required to open and close interpolation.
In these string literals, `{` and `}` characters don't need to be escaped:

```fsharp
let str = $$"""A string containing some {curly braces} and an {{"F#" + " " + "expression"}}."""
// "A string containing some {curly braces} and an F# expression."
let another = $$$"""A string with pairs of {{ and }} characters and {{{ "an F# expression" }}}."""
// "A string with pairs of {{ and }} characters and an F# expression."""
```

The number of `%` characters needed for format specifiers is affected in the same way:

```fsharp
let percent = $$"""50% of 20 is %%.1f{{20m * 0.5m}}"""
// "50% of 20 is 10.0"
```

## Native AOT and string-valued interpolation

To format text without a reflection-based formatting engine, use string-valued interpolation with plain or .NET-format holes:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Interpolation":::

F# 11 uses direct conversions and `System.String.Concat` for more string-valued interpolations. A .NET-format hole uses invariant `String.Format` and boxes its argument. These compiler changes support [Native AOT](../../core/deploying/native-aot/index.md) without requiring the modern Core build; other application code can still need reflection.

Printf-style holes requiring printf formatting, such as `%04d{number}` or `%A{record}`, can still use the reflection-based path. Bare `%s`, `%c`, `%d`, `%i`, and `%M` holes retain their type checks and avoid printf formatting. Other specifiers, including `%u`, aren't covered by that optimization. An interpolation used as a `PrintfFormat` value is also distinct from one whose result type is `string`.

### Culture and format compatibility

Plain holes use F#'s `string` conversion; .NET-format holes use invariant formatting. To produce localized output, select the culture explicitly:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Culture":::

Check localized output when upgrading. `FormattableString` retains its arguments for later provider-based formatting instead of following this concatenation path.

Warning FS3884 identifies an unapplied function or delegate in an interpolation hole. Apply the function if you intended its result:

```fsharp
let weight () = 12.5m
let text: string = $"Weight: {weight ()} kg"
```

### Write a value to standard output

To write a value without a printf format, FSharp.Core 11 adds `print` and `printn`. They use `string` conversion; `printn` adds a newline:

```fsharp
print "Parcels: "
printn 3
```

For structural `%A` output, use [plaintext formatting](plaintext-formatting.md).

### Record and union output without reflection

With `--reflectionfree`, F# 11 can generate meaningful `ToString` implementations for records and unions instead of displaying only the type name:

:::code language="fsharp" source="snippets/interpolated-strings/ReflectionFree.fs" id="ReflectionFree":::

The [sample project](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/interpolated-strings/ReflectionFree.fsproj) enables the flag. Output differs from `%A`; field types also need suitable `ToString` implementations.

## See also

* [Strings](strings.md)
* [F# RFC FS-1001 - Interpolated strings](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1001-StringInterpolation.md)
* [F# RFC FS-1132 - Extended syntax for interpolated strings](https://github.com/fsharp/fslang-design/blob/main/FSharp-8.0/FS-1132-better-interpolated-triple-quoted-strings.md)
