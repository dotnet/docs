### Globalization APIs use ICU libraries on Windows

.NET 5.0 and later versions use [International Components for Unicode (ICU)](http://site.icu-project.org/home) libraries for globalization functionality when running on Windows 10 May 2019 Update or later.

#### Change description

Previously, .NET libraries used [National Language Support (NLS)](/windows/win32/intl/national-language-support) APIs for globalization functionality. For example, NLS functions were used to get culture data, such as date and time format patterns, compare strings, and perform string casing in the appropriate culture.

Starting in .NET 5.0, if an app is running on Windows 10 May 2019 Update or later, .NET libraries use [ICU](http://site.icu-project.org/home) globalization APIs.

> [!NOTE]
> Windows 10 May 2019 Update and later versions ship with the ICU native library. If the .NET runtime can't load ICU, it uses NLS instead.

#### Behavioral differences

You might see changes in your app even if you don't realize you're using globalization facilities.

#### Reason for change

This change was introduced for two reasons:

- Apps have the same globalization behavior across platforms, including Linux, macOS, and Windows.
- Apps can control globalization behavior by using custom ICU libraries.

#### Version introduced

.NET 5.0 Preview 4

#### Recommended action

No action is required on the part of the developer. However, if you wish to continue using NLS globalization APIs, you can set a [run-time switch](../../../../docs/core/run-time-config/globalization.md#nls) to revert to that behavior. For more information about the available switches, see the [.NET globalization and ICU](../../../../docs/standard/globalization-localization/globalization-icu.md) article.

#### Category

- Core .NET libraries
- Globalization

#### Affected APIs

- <xref:System.Span%601?displayProperty=fullName>
- <xref:System.String?displayProperty=fullName>
- Most types in the <xref:System.Globalization?displayProperty=fullName> namespace
- <xref:System.Array.Sort%2A?displayProperty=fullName> (when sorting an array of strings)
- <xref:System.Collections.Generic.List%601.Sort?displayProperty=fullName> (when the list elements are strings)
- <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.SortedList%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedSet%601?displayProperty=fullName> (when the set contains strings)

<!--

#### Affected APIs

- ``T:System.Span`1``
- `T:System.String`
- `N:System.Globalization`
- `Overload:System.Array.Sort`
- ``M:System.Collections.Generic.List`1.Sort``
- ``T:System.Collections.Generic.SortedDictionary`2``
- ``T:System.Collections.Generic.SortedList`2``
- ``T:System.Collections.Generic.SortedSet`1``

-->
