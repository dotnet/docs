### Globalization APIs use ICU libraries on Windows

.NET 5.0 and later versions use [International Components for Unicode (ICU)](http://site.icu-project.org/home) libraries for globalization functionality when running on Windows 10 May 2019 Update or later.

#### Change description

Previously, .NET libraries used [National Language Support (NLS)](/windows/win32/intl/national-language-support) APIs for globalization functionality. For example, NLS functions were used to set the user's locale, sort strings, and format dates and times in the appropriate culture.

Starting in .NET 5.0, if an app is running on Windows 10 May 2019 Update or later, .NET libraries use [ICU](http://site.icu-project.org/home) globalization APIs. Windows 10 May 2019 Update and later versions ship with the ICU native library. If the .NET runtime can't load ICU, it uses NLS instead.

This change was introduced for two reasons:

- Apps have the same globalization behavior across platforms, including Linux, MacOS, and Windows.
- Apps can control globalization behavior by using custom ICU libraries.

#### Version introduced

.NET 5.0 Preview 4

### Recommended action

No action is required on the part of the developer. However, if you wish to continue using NLS globalization APIs, you can set a [run-time switch](../../../../docs/core/run-time-config/globalization.md#nls) to revert to that behavior.

### Category

Globalization

### Affected APIs

- <xref:System.String?displayProperty=fullName>
- <xref:System.Span%601?displayProperty=fullName>
- <xref:System.Globalization.CompareInfo?displayProperty=fullName>
- <xref:System.Globalization.IdnMapping?displayProperty=fullName>
- <xref:System.Globalization.CultureInfo?displayProperty=fullName>
- <xref:System.Globalization.JapaneseCalendar?displayProperty=fullName>

<!--

- `T:System.String`
- `T:System.Span%601`
- `T:System.Globalization.CompareInfo`
- `T:System.Globalization.IdnMapping`
- `T:System.Globalization.CultureInfo`
- `T:System.Globalization.JapaneseCalendar`

-->
