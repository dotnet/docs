---
description: "Learn more about: Best practices for developing world-ready applications"
title: "Best Practices for Developing World-Ready Applications"
ms.date: 03/13/2023
helpviewer_keywords:
  - "global applications, best practices"
  - "world-ready applications, best practices"
  - "globalization [.NET], best practices"
  - "international applications [.NET], best practices"
ms.assetid: f08169c7-aad8-4ec3-9a21-9ebd3b89986c
---

# Best practices for developing world-ready applications

This section describes the best practices to follow when developing world-ready applications.

## Globalization best practices

1. Make your application Unicode internally.

1. Use the culture-aware classes provided by the <xref:System.Globalization> namespace to manipulate and format data.

    - For sorting, use the <xref:System.Globalization.SortKey> class and the <xref:System.Globalization.CompareInfo> class.
    - For string comparisons, use the <xref:System.Globalization.CompareInfo> class.
    - For date and time formatting, use the <xref:System.Globalization.DateTimeFormatInfo> class.
    - For numeric formatting, use the <xref:System.Globalization.NumberFormatInfo> class.
    - For Gregorian and non-Gregorian calendars, use the <xref:System.Globalization.Calendar> class or one of the specific calendar implementations.

1. Use the culture property settings provided by the <xref:System.Globalization.CultureInfo?displayProperty=nameWithType> class in the appropriate situations. Use the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property for formatting tasks, such as date and time or numeric formatting. Use the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property to retrieve resources. Note that the `CurrentCulture` and `CurrentUICulture` properties can be set per thread.

1. Enable your application to read and write data to and from a variety of encodings by using the encoding classes in the <xref:System.Text> namespace. Do not assume ASCII data. Assume that international characters will be supplied anywhere a user can enter text. For example, the application should accept international characters in server names, directories, file names, user names, and URLs.

1. When using the <xref:System.Text.UTF8Encoding> class, for security reasons, use the error detection feature offered by this class. To turn on the error detection feature, create an instance of the class using the constructor that takes a `throwOnInvalidBytes` parameter and set the value of this parameter to `true`.

1. Whenever possible, handle strings as entire strings instead of as a series of individual characters. This is especially important when sorting or searching for substrings. This will prevent problems associated with parsing combined characters. You can also work with units of text rather than single characters by using the <xref:System.Globalization.StringInfo?displayProperty=nameWithType> class.

1. Display text using the classes provided by the <xref:System.Drawing> namespace.

1. For consistency across operating systems, do not allow user settings to override <xref:System.Globalization.CultureInfo>. Use the `CultureInfo` constructor that accepts a `useUserOverride` parameter and set it to `false`.

1. Test your application functionality on international operating system versions, using international data.

1. If a security decision is based on the result of a string comparison or case change operation, use a culture-insensitive string operation. This practice ensures that the result is not affected by the value of `CultureInfo.CurrentCulture`. See the ["String Comparisons that Use the Current Culture"](../../standard/base-types/best-practices-strings.md#string-comparisons-that-use-the-current-culture) section of [Best Practices for Using Strings](../../standard/base-types/best-practices-strings.md) for an example that demonstrates how culture-sensitive string comparisons can produce inconsistent results.

1. For any element being used for interchange (for example, a field in a JSON document in an API call) or storage, use the <xref:System.Globalization.CultureInfo?displayProperty=InvariantCulture>; additionally, you should explicitly specify a roundtrip format (such as the [`"O"`, `"o"` date-time format specifier](../../standard/base-types/standard-date-and-time-format-strings.md#the-round-trip-o-o-format-specifier)). Although the format strings for the invariant culture are stable and unlikely to change, specifying an explicit format string helps to clarify the intent of your code.
    - For date/time elements, consider the advice and observations of Noda Time author Jon Skeet, who shares valuable insights. For more information, see [Jon Skeet: _Storing UTC is not a silver bullet_](https://codeblog.jonskeet.uk/2019/03/27/storing-utc-is-not-a-silver-bullet/).

1. Globalization data [is not stable](https://devblogs.microsoft.com/i18n/culture-data-shouldnt-be-considered-stable/), and you should write your application and its tests with this in mind. It's updated several times a year through host OS channels on all supported platforms. This data is typically not distributed with the runtime.

## Localization best practices

1. Move all localizable resources to separate resource-only DLLs. Localizable resources include user interface elements, such as strings, error messages, dialog boxes, menus, and embedded object resources.

1. Do not hardcode strings or user interface resources.

1. Do not put non-localizable resources into the resource-only DLLs. This confuses translators.

1. Do not use composite strings that are built at run time from concatenated phrases. Composite strings are difficult to localize because they often assume an English grammatical order that does not apply to all languages.

1. Avoid ambiguous constructs such as "Empty Folder" where the strings can be translated differently depending on the grammatical roles of the string components. For example, "empty" can be either a verb or an adjective, which can lead to different translations in languages such as Italian or French.

1. Avoid using images and icons that contain text in your application. They are expensive to localize.

1. Allow plenty of room for the length of strings to expand in the user interface. In some languages, phrases can require 50-75 percent more space than they need in other languages.

1. Use the <xref:System.Resources.ResourceManager?displayProperty=nameWithType> class to retrieve resources based on culture.

1. Use [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link) to create Windows Forms dialog boxes so they can be localized using the [Windows Forms Resource Editor (Winres.exe)](../../framework/tools/winres-exe-windows-forms-resource-editor.md). Do not code Windows Forms dialog boxes by hand.

1. Arrange for professional localization (translation).

1. For a complete description of creating and localizing resources, see [Resources in .NET apps](resources.md).

## Globalization best practices for ASP.NET and other server applications

> [!TIP]
> The following best practices are for ASP.NET Framework apps. For ASP.NET Core apps, see [Globalization and localization in ASP.NET Core](/aspnet/core/fundamentals/localization).

1. Explicitly set the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> and <xref:System.Globalization.CultureInfo.CurrentCulture%2A> properties in your application. Do not rely on defaults.

1. Note that ASP.NET applications are managed applications and therefore can use the same classes as other managed applications for retrieving, displaying, and manipulating information based on culture.

1. Be aware that you can specify the following three types of encodings in ASP.NET:

    - `requestEncoding` specifies the encoding received from the client's browser.
    - `responseEncoding` specifies the encoding to send to the client browser. In most situations, this encoding should be the same as that specified for `requestEncoding`.
    - fileEncoding specifies the default encoding for _.aspx_, _.asmx_, and _.asax_ file parsing.

1. Specify the values for the `requestEncoding`, `responseEncoding`, `fileEncoding`, `culture`, and `uiCulture` attributes in the following three places in an ASP.NET application:

    - In the globalization section of a _Web.config_ file. This file is external to the ASP.NET application. For more information, see [\<globalization> element](/previous-versions/dotnet/netframework-4.0/hy4kkhe0(v=vs.100)).
    - In a page directive. Note that, when an application is in a page, the file has already been read. Therefore, it is too late to specify fileEncoding and requestEncoding. Only `uiCulture`, `culture`, and `responseEncoding` can be specified in a page directive.
    - Programmatically in application code. This setting can vary per request. As with a page directive, by the time the application's code is reached, it is too late to specify `fileEncoding` and `requestEncoding`. Only `uiCulture`, `culture`, and `responseEncoding` can be specified in the application code.

1. Note that the uiCulture value can be set to the browser accept language.

1. For applications that are distributed, allow zero-downtime updates (for example, Azure Container Apps), or similar you must plan for situations where there may be multiple instances of the application with different format rules or other culture data, most relevantly time zone rules.
    - If your application deployment includes a database, remember that the database will have its own globalization rules. In most cases you should avoid performing any globalization-related functions in the database.
    - If your application deployment includes a client application or web frontend using client globalization resources, assume that the client resources differ from the resources available to your server. Consider exclusively performing globalization functions on the client.

## Recommendations for robust testing

1. To make dependencies more explicit and testing potentially easier and parallelizable, you _should consider_ explicitly passing culture-relevant settings, such as `CultureInfo` parameters, to methods that perform formatting, and `TimeZoneInfo` to methods that work with dates and times. You _should also_ use <xref:System.TimeProvider> or a similar type when retrieving the time.

1. For most tests, you _shouldn't_ explicitly validate the exact output of a given formatting operation or the exact offset of a time zone. Formatting and time zone data may change at any time and may differ between two otherwise identical instances of an operating system (and potentially different processes on the same machine). Relying on an exact value makes tests brittle.
    - Generally, validating that some output was received will be sufficient (for example, non-empty strings when formatting).
    - For some data elements and formats, validating that the data parses to the input value may be used instead (roundtripping). Care needs to be taken for cases where fields are dropped (for example, year for some date-related fields) or the value truncated or rounded (such as for floating-point output).
    - If you have explicit requirements to validate all localized format output, you _should consider_ creating and using a custom culture during test setup. For most simple cases this can be done by instantiating a `CultureInfo` object with its constructor `new CultureInfo(..)` and setting the `DateTimeFormat` and `NumberFormat` properties. For more complicated cases, subclassing the type allows overriding additional properties. There are potential additional benefits to this, such as enabling [pseudolocalization](/globalization/methodology/pseudolocalization) with resource files.
    - If you have explicit requirements to validate the results of all date/time operations, you _should consider_ creating and using a custom `TimeZoneInfo` instance during test setup. There are potential additional benefits to this, such as enabling stable testing of certain edge cases (for example, changes to DST rules).

## See also

- [Globalization and Localization](globalization-and-localization.md)
- [Resources in .NET apps](resources.md)
