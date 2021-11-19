---
title: Behavior changes when comparing strings on .NET 5+
description: Learn about string-comparison behavior changes in .NET 5 and later versions on Windows.
ms.topic: conceptual
ms.date: 12/07/2020
---

# Behavior changes when comparing strings on .NET 5+

.NET 5.0 introduces a runtime behavioral change where globalization APIs [now use ICU by default](../../core/compatibility/globalization/5.0/icu-globalization-api.md) across all supported platforms. This is a departure from earlier versions of .NET Core and from .NET Framework, which utilize the operating system's national language support (NLS) functionality when running on Windows. For more information on these changes, including compatibility switches that can revert the behavior change, see [.NET globalization and ICU](../../core/extensions/globalization-icu.md).

## Reason for change

This change was introduced to unify .NET's globalization behavior across all supported operating systems. It also provides the ability for applications to bundle their own globalization libraries rather than depend on the OS's built-in libraries. For more information, see [the breaking change notification](../../core/compatibility/globalization/5.0/icu-globalization-api.md).

## Behavioral differences

If you use functions like `string.IndexOf(string)` without calling the overload that takes a <xref:System.StringComparison> argument, you might intend to perform an *ordinal* search, but instead you inadvertently take a dependency on culture-specific behavior. Since NLS and ICU implement different logic in their linguistic comparers, the results of methods like `string.IndexOf(string)` can return unexpected values.

This can manifest itself even in places where you aren't always expecting globalization facilities to be active. For example, the following code can produce a different answer depending on the current runtime.

```cs
string s = "Hello\r\nworld!";
int idx = s.IndexOf("\n");
Console.WriteLine(idx);

// The snippet prints:
//
// '6' when running on .NET Framework (Windows)
// '6' when running on .NET Core 2.x - 3.x (Windows)
// '-1' when running on .NET 5 (Windows)
// '-1' when running on .NET Core 2.x - 3.x or .NET 5 (non-Windows)
// '6' when running on .NET Core 2.x or .NET 5 (in invariant mode)
```

## Guard against unexpected behavior

This section provides two options for dealing with unexpected behavior changes in .NET 5.0.

### Enable code analyzers

[Code analyzers](../../fundamentals/code-analysis/overview.md) can detect possibly buggy call sites. To help guard against any surprising behaviors, we recommend enabling .NET compiler platform (Roslyn) analyzers in your project. The analyzers help flag code that might inadvertently be using a linguistic comparer when an ordinal comparer was likely intended. The following rules should help flag these issues:

- [CA1307: Specify StringComparison for clarity](../../fundamentals/code-analysis/quality-rules/ca1307.md)
- [CA1309: Use ordinal StringComparison](../../fundamentals/code-analysis/quality-rules/ca1309.md)
- [CA1310: Specify StringComparison for correctness](../../fundamentals/code-analysis/quality-rules/ca1310.md)

These specific rules aren't enabled by default. To enable them and show any violations as build errors, set the following properties in your project file:

```xml
<PropertyGroup>
  <AnalysisMode>All</AnalysisMode>
  <WarningsAsErrors>$(WarningsAsErrors);CA1307;CA1309;CA1310</WarningsAsErrors>
</PropertyGroup>
```

The following snippet shows examples of code that produces the relevant code analyzer warnings or errors.

```cs
//
// Potentially incorrect code - answer might vary based on locale.
//
string s = GetString();
// Produces analyzer warning CA1310 for string; CA1307 matches on char ','
int idx = s.IndexOf(",");
Console.WriteLine(idx);

//
// Corrected code - matches the literal substring ",".
//
string s = GetString();
int idx = s.IndexOf(",", StringComparison.Ordinal);
Console.WriteLine(idx);

//
// Corrected code (alternative) - searches for the literal ',' character.
//
string s = GetString();
int idx = s.IndexOf(',');
Console.WriteLine(idx);
```

Similarly, when instantiating a sorted collection of strings or sorting an existing string-based collection, specify an explicit comparer.

```cs
//
// Potentially incorrect code - behavior might vary based on locale.
//
SortedSet<string> mySet = new SortedSet<string>();
List<string> list = GetListOfStrings();
list.Sort();

//
// Corrected code - uses ordinal sorting; doesn't vary by locale.
//
SortedSet<string> mySet = new SortedSet<string>(StringComparer.Ordinal);
List<string> list = GetListOfStrings();
list.Sort(StringComparer.Ordinal);
```

### Revert back to NLS behaviors

To revert .NET 5 applications back to older NLS behaviors when running on Windows, follow the steps in [.NET Globalization and ICU](../../core/extensions/globalization-icu.md). This application-wide compatibility switch must be set at the application level. Individual libraries cannot opt-in or opt-out of this behavior.

> [!TIP]
> We strongly recommend you enable the [CA1307](../../fundamentals/code-analysis/quality-rules/ca1307.md), [CA1309](../../fundamentals/code-analysis/quality-rules/ca1309.md), and [CA1310](../../fundamentals/code-analysis/quality-rules/ca1310.md) code analysis rules to help improve code hygiene and discover any existing latent bugs. For more information, see [Enable code analyzers](#enable-code-analyzers).

## Affected APIs

Most .NET applications won't encounter any unexpected behaviors due to the changes in .NET 5. However, due to the number of affected APIs and how foundational these APIs are to the wider .NET ecosystem, you should be aware of the potential for .NET 5 to introduce unwanted behaviors or to expose latent bugs that already exist in your application.

The affected APIs include:

- <xref:System.String.Compare%2A?displayProperty=fullName>
- <xref:System.String.EndsWith%2A?displayProperty=fullName>
- <xref:System.String.IndexOf%2A?displayProperty=fullName>
- <xref:System.String.StartsWith%2A?displayProperty=fullName>
- <xref:System.String.ToLower%2A?displayProperty=fullName>
- <xref:System.String.ToLowerInvariant%2A?displayProperty=fullName>
- <xref:System.String.ToUpper%2A?displayProperty=fullName>
- <xref:System.String.ToUpperInvariant%2A?displayProperty=fullName>
- <xref:System.Globalization.TextInfo?displayProperty=fullName> (most members)
- <xref:System.Globalization.CompareInfo?displayProperty=fullName> (most members)
- <xref:System.Array.Sort%2A?displayProperty=fullName> (when sorting arrays of strings)
- <xref:System.Collections.Generic.List%601.Sort?displayProperty=fullName> (when the list elements are strings)
- <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedList%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedSet%601?displayProperty=fullName> (when the set contains strings)

> [!NOTE]
> This is not an exhaustive list of affected APIs.

All of the above APIs use *linguistic* string searching and comparison using the thread's [current culture](xref:System.Threading.Thread.CurrentCulture), by default. The differences between *linguistic* and *ordinal* search and comparison are called out in the [Ordinal vs. linguistic search and comparison](#ordinal-vs-linguistic-search-and-comparison).

Because ICU implements linguistic string comparisons differently from NLS, Windows-based applications that upgrade to .NET 5 from an earlier version of .NET Core or .NET Framework and that call one of the affected APIs may notice that the APIs begin exhibiting different behaviors.

### Exceptions

* If an API accepts an explicit `StringComparison` or `CultureInfo` parameter, that parameter overrides the API's default behavior.
* `System.String` members where the first parameter is of type `char` (for example, <xref:System.String.IndexOf(System.Char)?displayProperty=nameWithType>) use ordinal searching, unless the caller passes an explicit `StringComparison` argument that specifies `CurrentCulture[IgnoreCase]` or `InvariantCulture[IgnoreCase]`.

For a more detailed analysis of the default behavior of each <xref:System.String> API, see the [Default search and comparison types](#default-search-and-comparison-types) section.

## Ordinal vs. linguistic search and comparison

*Ordinal* (also known as *non-linguistic*) search and comparison decomposes a string into its individual `char` elements and performs a char-by-char search or comparison. For example, the strings `"dog"` and `"dog"` compare as *equal* under an `Ordinal` comparer, since the two strings consist of the exact same sequence of chars. However, `"dog"` and `"Dog"` compare as *not equal* under an `Ordinal` comparer, because they don't consist of the exact same sequence of chars. That is, uppercase `'D'`'s code point `U+0044` occurs before lowercase `'d'`'s code point `U+0064`, resulting in `"dog"` sorting before `"Dog"`.

An `OrdinalIgnoreCase` comparer still operates on a char-by-char basis, but it eliminates case differences while performing the operation. Under an `OrdinalIgnoreCase` comparer, the char pairs `'d'` and `'D'` compare as *equal*, as do the char pairs `'á'` and `'Á'`. But the unaccented char `'a'` compares as *not equal* to the accented char `'á'`.

Some examples of this are provided in the following table:

| String 1 | String 2 | `Ordinal` comparison | `OrdinalIgnoreCase` comparison |
|---|---|---|---|
| `"dog"` | `"dog"` | equal | equal |
| `"dog"` | `"Dog"` | not equal | equal |
| `"resume"` | `"Resume"` | not equal | equal |
| `"resume"` | `"résumé"` | not equal | not equal |

Unicode also allows strings to have several different in-memory representations. For example, an e-acute (é) can be represented in two possible ways:

* A single literal `'é'` character (also written as `'\u00E9'`).
* A literal unaccented `'e'` character, followed by a combining accent modifier character `'\u0301'`.

This means that the following _four_ strings all result in `"résumé"` when displayed, even though their constituent pieces are different. The strings use a combination of literal `'é'` characters or literal unaccented `'e'` characters plus the combining accent modifier `'\u0301'`.

* `"r\u00E9sum\u00E9"`
* `"r\u00E9sume\u0301"`
* `"re\u0301sum\u00E9"`
* `"re\u0301sume\u0301"`

Under an ordinal comparer, none of these strings compare as equal to each other. This is because they all contain different underlying char sequences, even though when they're rendered to the screen, they all look the same.

When performing a `string.IndexOf(..., StringComparison.Ordinal)` operation, the runtime looks for an exact substring match. The results are as follows.

```cs
Console.WriteLine("resume".IndexOf("e", StringComparison.Ordinal)); // prints '1'
Console.WriteLine("r\u00E9sum\u00E9".IndexOf("e", StringComparison.Ordinal)); // prints '-1'
Console.WriteLine("r\u00E9sume\u0301".IndexOf("e", StringComparison.Ordinal)); // prints '5'
Console.WriteLine("re\u0301sum\u00E9".IndexOf("e", StringComparison.Ordinal)); // prints '1'
Console.WriteLine("re\u0301sume\u0301".IndexOf("e", StringComparison.Ordinal)); // prints '1'
Console.WriteLine("resume".IndexOf("E", StringComparison.OrdinalIgnoreCase)); // prints '1'
Console.WriteLine("r\u00E9sum\u00E9".IndexOf("E", StringComparison.OrdinalIgnoreCase)); // prints '-1'
Console.WriteLine("r\u00E9sume\u0301".IndexOf("E", StringComparison.OrdinalIgnoreCase)); // prints '5'
Console.WriteLine("re\u0301sum\u00E9".IndexOf("E", StringComparison.OrdinalIgnoreCase)); // prints '1'
Console.WriteLine("re\u0301sume\u0301".IndexOf("E", StringComparison.OrdinalIgnoreCase)); // prints '1'
```

Ordinal search and comparison routines are never affected by the current thread's culture setting.

*Linguistic* search and comparison routines decompose a string into *collation elements* and perform searches or comparisons on these elements. There's not necessarily a 1:1 mapping between a string's characters and its constituent collation elements. For example, a string of length 2 may consist of only a single collation element. When two strings are compared in a linguistic-aware fashion, the comparer checks whether the two strings' collation elements have the same semantic meaning, even if the string's literal characters are different.

Consider again the string `"résumé"` and its four different representations. The following table shows each representation broken down into its collation elements.

| String | As collation elements |
|---|---|
| `"r\u00E9sum\u00E9"` | `"r" + "\u00E9" + "s" + "u" + "m" + "\u00E9"` |
| `"r\u00E9sume\u0301"` | `"r" + "\u00E9" + "s" + "u" + "m" + "e\u0301"` |
| `"re\u0301sum\u00E9"` | `"r" + "e\u0301" + "s" + "u" + "m" + "\u00E9"` |
| `"re\u0301sume\u0301"` | `"r" + "e\u00E9" + "s" + "u" + "m" + "e\u0301"` |

A collation element corresponds loosely to what readers would think of as a single character or cluster of characters. It's conceptually similar to a [grapheme cluster](character-encoding-introduction.md#grapheme-clusters) but encompasses a somewhat larger umbrella.

Under a linguistic comparer, exact matches aren't necessary. Collation elements are instead compared based on their semantic meaning. For example, a linguistic comparer treats the substrings `"\u00E9"` and `"e\u0301"` as equal since they both semantically mean "a lowercase e with an acute accent modifier." This allows the `IndexOf` method to match the substring `"e\u0301"` within a larger string that contains the semantically equivalent substring `"\u00E9"`, as shown in the following code sample.

```cs
Console.WriteLine("r\u00E9sum\u00E9".IndexOf("e")); // prints '-1' (not found)
Console.WriteLine("r\u00E9sum\u00E9".IndexOf("e\u00E9")); // prints '1'
Console.WriteLine("\u00E9".IndexOf("e\u00E9")); // prints '0'
```

As a consequence of this, two strings of different lengths may compare as equal if a linguistic comparison is used. Callers should take care not to special-case logic that deals with string length in such scenarios.

*Culture-aware* search and comparison routines are a special form of linguistic search and comparison routines. Under a culture-aware comparer, the concept of a collation element is extended to include information specific to the specified culture.

For example, [in the Hungarian alphabet](https://en.wikipedia.org/wiki/Hungarian_alphabet), when the two characters \<dz\> appear back-to-back, they are considered their own unique letter distinct from either \<d\> or \<z\>. This means that when \<dz\> is seen in a string, a Hungarian culture-aware comparer treats it as a single collation element.

| String | As collation elements | Remarks |
|---|---|---|
| `"endz"` | `"e" + "n" + "d" + "z"` | (using a standard linguistic comparer) |
| `"endz"` | `"e" + "n" + "dz"` | (using a Hungarian culture-aware comparer) |

When using a Hungarian culture-aware comparer, this means that the string `"endz"` *does not* end with the substring `"z"`, as <\dz\> and <\z\> are considered collation elements with different semantic meaning.

```cs
// Set thread culture to Hungarian
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("hu-HU");
Console.WriteLine("endz".EndsWith("z")); // Prints 'False'

// Set thread culture to invariant culture
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
Console.WriteLine("endz".EndsWith("z")); // Prints 'True'
```

> [!NOTE]
>
> - Behavior: Linguistic and culture-aware comparers can undergo behavioral adjustments from time to time. Both ICU and the older Windows NLS facility are updated to account for how world languages change. For more information, see the blog post [Locale (culture) data churn](/archive/blogs/shawnste/locale-culture-data-churn). The *Ordinal* comparer's behavior will never change since it performs exact bitwise searching and comparison. However, the *OrdinalIgnoreCase* comparer's behavior may change as Unicode grows to encompass more character sets and corrects omissions in existing casing data.
> - Usage: The comparers `StringComparison.InvariantCulture` and `StringComparison.InvariantCultureIgnoreCase` are linguistic comparers that are not culture-aware. That is, these comparers understand concepts such as the accented character é having multiple possible underlying representations, and that all such representations should be treated equal. But non-culture-aware linguistic comparers won't contain special handling for \<dz\> as distinct from \<d\> or \<z\>, as shown above. They also won't special-case characters like the German Eszett (ß).

.NET also offers the *invariant globalization mode*. This opt-in mode disables code paths that deal with linguistic search and comparison routines. In this mode, all operations use *Ordinal* or *OrdinalIgnoreCase* behaviors, regardless of what `CultureInfo` or `StringComparison` argument the caller provides. For more information, see [Runtime configuration options for globalization](../../core/run-time-config/globalization.md) and [.NET Core Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

For more information, see [Best practices for comparing strings in .NET](best-practices-strings.md).

## Security implications

If your app uses an affected API for filtering, we recommend enabling the CA1307 and CA1309 code analysis rules to help locate places where a linguistic search may have inadvertently been used instead of an ordinal search. Code patterns like the following may be susceptible to security exploits.

```cs
//
// THIS SAMPLE CODE IS INCORRECT.
// DO NOT USE IT IN PRODUCTION.
//
public bool ContainsHtmlSensitiveCharacters(string input)
{
    if (input.IndexOf("<") >= 0) { return true; }
    if (input.IndexOf("&") >= 0) { return true; }
    return false;
}
```

Because the `string.IndexOf(string)` method uses a linguistic search by default, it's possible for a string to contain a literal `'<'` or `'&'` character and for the `string.IndexOf(string)` routine to return `-1`, indicating that the search substring was not found. Code analysis rules CA1307 and CA1309 flag such call sites and alert the developer that there's a potential problem.

## Default search and comparison types

The following table lists the default search and comparison types for various string and string-like APIs. If the caller provides an explicit `CultureInfo` or `StringComparison` parameter, that parameter will be honored over any default.

| API | Default behavior | Remarks |
|---|---|---|
| `string.Compare` | CurrentCulture | |
| `string.CompareTo` | CurrentCulture | |
| `string.Contains` | Ordinal | |
| `string.EndsWith` | Ordinal | (when the first parameter is a `char`) |
| `string.EndsWith` | CurrentCulture | (when the first parameter is a `string`) |
| `string.Equals` | Ordinal | |
| `string.GetHashCode` | Ordinal | |
| `string.IndexOf` | Ordinal | (when the first parameter is a `char`) |
| `string.IndexOf` | CurrentCulture | (when the first parameter is a `string`) |
| `string.IndexOfAny` | Ordinal | |
| `string.LastIndexOf` | Ordinal | (when the first parameter is a `char`) |
| `string.LastIndexOf` | CurrentCulture | (when the first parameter is a `string`) |
| `string.LastIndexOfAny` | Ordinal | |
| `string.Replace` | Ordinal | |
| `string.Split` | Ordinal | |
| `string.StartsWith` | Ordinal | (when the first parameter is a `char`) |
| `string.StartsWith` | CurrentCulture | (when the first parameter is a `string`) |
| `string.ToLower` | CurrentCulture | |
| `string.ToLowerInvariant` | InvariantCulture | |
| `string.ToUpper` | CurrentCulture | |
| `string.ToUpperInvariant` | InvariantCulture | |
| `string.Trim` | Ordinal | |
| `string.TrimEnd` | Ordinal | |
| `string.TrimStart` | Ordinal | |
| `string == string` | Ordinal | |
| `string != string` | Ordinal | |

Unlike `string` APIs, all `MemoryExtensions` APIs perform *Ordinal* searches and comparisons by default, with the following exceptions.

| API | Default behavior | Remarks |
|---|---|---|
| `MemoryExtensions.ToLower` | CurrentCulture | (when passed a null `CultureInfo` argument) |
| `MemoryExtensions.ToLowerInvariant` | InvariantCulture | |
| `MemoryExtensions.ToUpper` | CurrentCulture | (when passed a null `CultureInfo` argument) |
| `MemoryExtensions.ToUpperInvariant` | InvariantCulture | |

A consequence is that when converting code from consuming `string` to consuming `ReadOnlySpan<char>`, behavioral changes may be introduced inadvertently. An example of this follows.

```cs
string str = GetString();
if (str.StartsWith("Hello")) { /* do something */ } // this is a CULTURE-AWARE (linguistic) comparison

ReadOnlySpan<char> span = s.AsSpan();
if (span.StartsWith("Hello")) { /* do something */ } // this is an ORDINAL (non-linguistic) comparison
```

The recommended way to address this is to pass an explicit `StringComparison` parameter to these APIs. The code analysis rules CA1307 and CA1309 can assist with this.

```cs
string str = GetString();
if (str.StartsWith("Hello", StringComparison.Ordinal)) { /* do something */ } // ordinal comparison

ReadOnlySpan<char> span = s.AsSpan();
if (span.StartsWith("Hello", StringComparison.Ordinal)) { /* do something */ } // ordinal comparison
```

## See also

- [Globalization breaking changes](../../core/compatibility/globalization.md)
- [Best practices for comparing strings in .NET](best-practices-strings.md)
- [How to compare strings in C#](../../csharp/how-to/compare-strings.md)
- [.NET globalization and ICU](../../core/extensions/globalization-icu.md)
- [Ordinal vs. culture-sensitive string operations](/dotnet/api/system.string#ordinal-vs-culture-sensitive-operations)
- [Overview of .NET source code analysis](../../fundamentals/code-analysis/overview.md)
