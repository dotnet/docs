---
title: "Breaking change: String.Trim*(params ReadOnlySpan<char>) overloads removed"
description: Learn about the breaking change in core .NET libraries where the String.Trim*(params ReadOnlySpan<char>) methods have been removed due to potential behavioral changes.
ms.date: 11/5/2024
---

# String.Trim*(params ReadOnlySpan\<char>) overloads removed

In the .NET ecosystem, `ReadOnlySpan<char>` can represent:

- A specific sequence of characters, often as a slice of a larger <xref:System.String?displayProperty=fullName> instance.
- A collection of single characters, often as a slice of a `char[]`.

Earlier releases of .NET 9 added `params ReadOnlySpan<T>` overloads to method groups that already had a `params T[]` overload. While this overload was a positive addition for some method groups, the dual nature of `ReadOnlySpan<char>` can cause confusion for a method group that accepts a `char[]` and a <xref:System.String> (in the same position) and they're treated differently. As an example, `public static string [String::]Split(string separator, StringSplitOptions options)` considers the sequence of characters as one separator. For example, `"[]ne]-[Tw[]".Split("]-[", StringSplitOptions.None)` splits into `new string[] { "[]ne", "Tw[]" };`. On the other hand, `public static [String::]Split(char[] separator, StringSplitOptions options)` considers each character in `separator` as a distinct separator, so the array-equivalent split yields `new string[] { "", "", "ne", "", "", "Tw", "", "" }`. Therefore, any new overload that accepts a `ReadOnlySpan<char>` has to decide if it is string-like or array-like. Generally speaking, .NET conforms to the array-like behavior.

Consider the following new <xref:System.String> overloads that accept a `ReadOnlySpan<char>` argument as proposed in [dotnet/runtime#77873](https://github.com/dotnet/runtime/issues/77873):

```csharp
public string[] Split(params ReadOnlySpan<char> separator);
public string Trim(params ReadOnlySpan<char> trimChars);
public string TrimStart(params ReadOnlySpan<char> trimChars);
public string TrimEnd(params ReadOnlySpan<char> trimChars);
```

In addition, consider the following commonly defined extension method:

```csharp
public static class SomeExtensions {
    public static string TrimEnd(this string target, string trimString) {
        if (target.EndsWith(trimString) {
            return target.Substring(0, target.Length - trimString.Length);
        }

        return target;
    }
}
```

For existing .NET runtimes, this extension method removes the specified sequence from the end of the string. However, due to the overload resolution rules of C#, `"12345!!!!".TrimEnd("!!!")` will prefer the new `TrimEnd` overload over the existing extension method, and change the result from `"12345!"` (removing only a full set of three exclamation marks) to `"12345"` (removing all exclamation marks from the end).

To resolve this break, there were two possible paths: Introduce an instance method `public string TrimEnd(string trimString)` that's an even better target, or remove the new method. The first option carries additional risk, as it needs to decide whether it returns one instance of the target string or all of them. And there are undoubtedly callers with existing code that uses each approach. Therefore, the second option was the most appropriate choice for this stage of the release cycle.

Callers of <xref:System.String.Trim*?displayProperty=nameWithType> who pass in individual characters using the `params` feature, for example, `str.Trim(';', ',', '.')`, won't see a break. Your code will have automatically switched from calling `string.Trim(params char[])` to `string.Trim(params ReadOnlySpan<char>)`. When you rebuild against the GA release of .NET 9, the compiler will automatically switch back to the `char[]` overload.

Callers of <xref:System.String.Trim*?displayProperty=nameWithType> who explicitly pass in a `ReadOnlySpan<char>` (or a type that's convertible to `ReadOnlySpan<char>` that's not also convertible to `char[]`) must change their code to successfully call `Trim` after this change.

As for <xref:System.String.Split*?displayProperty=nameWithType>, unlike with <xref:System.String.Trim*?displayProperty=nameWithType>, this method already has an [overload](xref:System.String.Split(System.String,System.StringSplitOptions)) that's both preferred over an extension method accepting a single string parameter and the newly added `ReadOnlySpan<char>` overload. For this reason, the new overload of <xref:System.String.Split*?displayProperty=nameWithType> was preserved.

> [!NOTE]
> You should rebuild any assembly built against .NET 9 Preview 6, .NET 9 Preview 7, .NET 9 RC1, or .NET 9 RC2 to ensure that any calls to the removed method are removed. Failure to do so might result in a <xref:System.MissingMethodException> at run time.

## Version introduced

.NET 9 GA

## Previous behavior

The following code compiled in .NET 9 Preview 6, .NET 9 Preview 7, .NET 9 RC1, and .NET 9 RC2:

```csharp
private static readonly char[] s_allowedWhitespace = { ' ', '\t', '\u00A0', '\u2000' };

// Only remove the ASCII whitespace.
str = str.Trim(s_allowedWhitespace.AsSpan(0, 2));
```

Prior to .NET 9 Preview 6, the following code yielded `"prefixinfix"`. For .NET 9 Preview 6 through .NET 9 RC2, it instead yielded `"prefixin"`:

```csharp
internal static string TrimEnd(this string target, string suffix)
{
    if (target.EndsWith(suffix))
    {
        return target.Substring(0, target.Length - suffix.Length);
    }

    return target;
}

...
return "prefixinfixsuffix".TrimEnd("suffix");
```

## New behavior

The following code that explicitly uses a slice of an array no longer compiles, as there's no suitable overload for it to call:

```csharp
private static readonly char[] s_allowedWhitespace = { ' ', '\t', '\u00A0', '\u2000' };

// Only remove the ASCII whitespace.
str = str.Trim(s_allowedWhitespace.AsSpan(0, 2));
```

Code that features an extension method `string TrimEnd(this string target, this string suffix)` now has the same behavior it had in .NET 8 and previous versions. That is, it yields `"prefixinfix"`.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Many projects have extension methods that experience behavioral changes after recompiling. The negative impact of these new instance methods was deemed to outweigh their positive benefit.

## Recommended action

Recompile any projects that were built against .NET 9 Preview 6, .NET 9 Preview 7, .NET 9 RC1, or .NET 9 RC2. If the project compiles with no errors, no further work is required. If the project no longer compiles, adjust your code. One possible substitution example is shown here:

```csharp
-private static ReadOnlySpan<char> s_trimChars = [ ';', ',', '.' ];
+private static readonly char[] s_trimChars = [ ';', ',', '.' ];

...

return input.Trim(s_trimChars);
```

## Affected APIs

- `System.String.Trim(System.ReadOnlySpan{System.Char})`
- `System.String.TrimEnd(System.ReadOnlySpan{System.Char})`
- `System.String.TrimStart(System.ReadOnlySpan{System.Char})`
