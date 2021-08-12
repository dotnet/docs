---
title: "Breaking change: Globalization APIs use ICU libraries on Windows"
description: Learn about the globalization breaking change in .NET 5 where ICU libraries are used for globalization functionality instead of NLS.
ms.date: 05/19/2020
---
# Globalization APIs use ICU libraries on Windows

.NET 5 and later versions use [International Components for Unicode (ICU)](http://site.icu-project.org/home) libraries for globalization functionality when running on Windows 10 May 2019 Update or later.

## Change description

In .NET Core 1.0 - 3.1 and .NET Framework 4 and later, .NET libraries use [National Language Support (NLS)](/windows/win32/intl/national-language-support) APIs for globalization functionality on Windows. For example, NLS functions were used to compare strings, get culture information, and perform string casing in the appropriate culture.

Starting in .NET 5, if an app is running on Windows 10 May 2019 Update or later, .NET libraries use [ICU](http://site.icu-project.org/home) globalization APIs, by default.

> [!NOTE]
> Windows 10 May 2019 Update and later versions ship with the ICU native library. If the .NET runtime can't load ICU, it uses NLS instead.

## Behavioral differences

You might see changes in your app even if you don't realize you're using globalization facilities. This section lists a couple of the behavioral changes you might see, but there are others too.

### String.IndexOf

Consider the following code that calls <xref:System.String.IndexOf(System.String)?displayProperty=nameWithType> to find the index of the newline character in a string.

```csharp
string s = "Hello\r\nworld!";
int idx = s.IndexOf("\n");
Console.WriteLine(idx);
```

- In previous versions of .NET on Windows, the snippet prints `6`.
- In .NET 5 and later versions on Windows 19H1 and later versions, the snippet prints `-1`.

To fix this code by conducting an ordinal search instead of a culture-sensitive search, call the <xref:System.String.IndexOf(System.String,System.StringComparison)> overload and pass in <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> as an argument.

You can run code analysis rules [CA1307: Specify StringComparison for clarity](../../../../fundamentals/code-analysis/quality-rules/ca1307.md) and [CA1309: Use ordinal StringComparison](../../../../fundamentals/code-analysis/quality-rules/ca1309.md) to find these call sites in your code.

For more information, see [Behavior changes when comparing strings on .NET 5+](../../../../standard/base-types/string-comparison-net-5-plus.md).

### Currency symbol

Consider the following code that formats a string using the currency format specifier `C`. The current thread's culture is set to a culture that includes only the language and not the country.

```csharp
System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de");
string text = string.Format("{0:C}", 100);
```

- In previous versions of .NET on Windows, the value of text is `"100,00 €"`.
- In .NET 5 and later versions on Windows 19H1 and later versions, the value of text is `"100,00 ¤"`, which uses the international currency symbol instead of the euro. In ICU, the design is that a currency is a property of a country or region, not a language.

## Reason for change

This change was introduced to unify .NET's globalization behavior across all supported operating systems. It also provides the ability for applications to bundle their own globalization libraries rather than depend on the operating system's built-in libraries.

## Version introduced

.NET 5.0

## Recommended action

No action is required on the part of the developer. However, if you wish to continue using NLS globalization APIs, you can set a [run-time switch](../../../run-time-config/globalization.md#nls) to revert to that behavior. For more information about the available switches, see the [.NET globalization and ICU](../../../../core/extensions/globalization-icu.md) article.

## Affected APIs

- <xref:System.Span%601?displayProperty=fullName>
- <xref:System.String?displayProperty=fullName>
- Most types in the <xref:System.Globalization?displayProperty=fullName> namespace
- <xref:System.Array.Sort%2A?displayProperty=fullName> (when sorting an array of strings)
- <xref:System.Collections.Generic.List%601.Sort?displayProperty=fullName> (when the list elements are strings)
- <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedList%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedSet%601?displayProperty=fullName> (when the set contains strings)

<!--

### Affected APIs

- ``T:System.Span`1``
- `T:System.String`
- `N:System.Globalization`
- `Overload:System.Array.Sort`
- ``M:System.Collections.Generic.List`1.Sort``
- ``T:System.Collections.Generic.SortedDictionary`2``
- ``T:System.Collections.Generic.SortedList`2``
- ``T:System.Collections.Generic.SortedSet`1``

### Category

- Core .NET libraries
- Globalization

-->
