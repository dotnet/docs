---
title: "Breaking change: Globalization APIs use ICU libraries on Windows Server"
description: Learn about the globalization breaking change in .NET 7 where ICU libraries are used for globalization functionality instead of NLS on Windows Server.
ms.date: 09/01/2022
---
# Globalization APIs use ICU libraries on Windows Server

.NET 7 and later versions use [International Components for Unicode (ICU)](http://site.icu-project.org/home) libraries for globalization functionality when running on Windows Server 2019 or later. (Non-server Windows versions have already been [using ICU since .NET 5](../5.0/icu-globalization-api.md).)

## Previous behavior

In .NET 5 and .NET 6, the .NET libraries used [National Language Support (NLS)](/windows/win32/intl/national-language-support) APIs for globalization functionality on Windows Server 2019. For example, NLS functions were used to compare strings, get culture information, and perform string casing in the appropriate culture.

## New behavior

Starting in .NET 7, if an app is running on Windows Server 2019 or later, .NET libraries use [ICU](http://site.icu-project.org/home) globalization APIs, by default. (Non-server Windows versions have already been [using ICU since .NET 5](../5.0/icu-globalization-api.md), so there is no change for these versions.)

## Behavioral differences

You might see changes in your app even if you don't realize you're using globalization facilities. The following example shows one of the behavioral changes you might see, but there are others too.

### Currency symbol

Consider the following code that formats a string using the currency format specifier `C`. The current thread's culture is set to a culture that includes only the language and not the country or region.

```csharp
System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de");
string text = string.Format("{0:C}", 100);
```

- In .NET 5 and .NET 6 on Windows Server 2019, the value of text is `"100,00 €"`.
- In .NET 7 on Windows Server 2019, the value of text is `"100,00 ¤"`, which uses the international currency symbol instead of the euro. In ICU, the design is that a currency is a property of a country or region, not a language.

## Reason for change

- .NET introduced some APIs that depend on ICU libraries, for example, <xref:System.TimeZoneInfo.TryConvertIanaIdToWindowsId(System.String,System.String@)?displayProperty=nameWithType>. Users who wanted to use such APIs on Windows Server 2019 were required to manually deploy ICU libraries with their binaries, using the ICU App Local feature. This wasn't a great solution, because the code can be in a library that can't control forcing ICU libraries to be installed with whatever app or service is using the library.
- If Windows Server 2019 is automatically provided by a cloud platform (like Azure), the deployed service doesn't necessarily know it's going to run on such a server. Also, the service owner has to manage if/when to deploy ICU binaries. In addition, every service deployed to the cloud using Windows Server 2019 that wants to use the new .NET ICU-dependent APIs needs to deploy the ICU binaries with the service. This can bloat the size on the disk on the server.
- Some users prefer using ICU by default because it conforms more to the Unicode Standard.

## Version introduced

.NET 7

## Recommended action

If you're using .NET 7.0 on Windows Server 2019, we recommend testing your app or service before shipping it to ensure the behavior is as expected and doesn't break any users.

If you wish to continue using NLS globalization APIs, you can set a [run-time switch](../../../runtime-config/globalization.md#nls) to revert to that behavior. For more information about the available switches, see the [.NET globalization and ICU](../../../../core/extensions/globalization-icu.md) article.

## Affected APIs

- <xref:System.Span%601?displayProperty=fullName>
- <xref:System.String?displayProperty=fullName>
- Most types in the <xref:System.Globalization?displayProperty=fullName> namespace
- <xref:System.Array.Sort%2A?displayProperty=fullName> (when sorting an array of strings)
- <xref:System.Collections.Generic.List%601.Sort?displayProperty=fullName> (when the list elements are strings)
- <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedList%602?displayProperty=fullName> (when the keys are strings)
- <xref:System.Collections.Generic.SortedSet%601?displayProperty=fullName> (when the set contains strings)

## See also

- [Globalization APIs use ICU libraries on Windows 10](../5.0/icu-globalization-api.md)
