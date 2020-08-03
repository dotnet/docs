### Globalization APIs use ICU libraries on Windows

.NET 5.0 and later versions use [International Components for Unicode (ICU)](http://site.icu-project.org/home) libraries for globalization functionality when running on Windows 10 May 2019 Update or later.

#### Change description

Previously, .NET libraries used [National Language Support (NLS)](/windows/win32/intl/national-language-support) APIs for globalization functionality. For example, NLS functions were used to get culture data, such as date and time format patterns, compare strings, and perform string casing in the appropriate culture.

Starting in .NET 5.0, if an app is running on Windows 10 May 2019 Update or later, .NET libraries use [ICU](http://site.icu-project.org/home) globalization APIs. Windows 10 May 2019 Update and later versions ship with the ICU native library. If the .NET runtime can't load ICU, it uses NLS instead.

This change was introduced for two reasons:

- Apps have the same globalization behavior across platforms, including Linux, macOS, and Windows.
- Apps can control globalization behavior by using custom ICU libraries.

#### Version introduced

.NET 5.0 Preview 4

#### Recommended action

No action is required on the part of the developer. However, if you wish to continue using NLS globalization APIs, you can set a [run-time switch](../../../../docs/core/run-time-config/globalization.md#nls) to revert to that behavior. For more information about the available switches, see the [.NET globalization and ICU](/dotnet/standard/globalization-localization/globalization-icu) article.

#### Category

Globalization

#### Affected APIs

- <xref:System.Span%601?displayProperty=fullName>
- <xref:System.String?displayProperty=fullName>
- Most types in the <xref:System.Globalization?displayProperty=fullName> namespace

<!--

#### Affected APIs

- ``T:System.Span`1``
- `T:System.String`
- `N:System.Globalization`

-->
