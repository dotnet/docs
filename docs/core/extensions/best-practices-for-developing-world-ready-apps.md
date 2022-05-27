---
description: "Learn more about: Best practices for developing world-ready applications"
title: "Best Practices for Developing World-Ready Applications"
ms.date: 08/11/2021
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

2. Use the culture-aware classes provided by the <xref:System.Globalization> namespace to manipulate and format data.

    - For sorting, use the <xref:System.Globalization.SortKey> class and the <xref:System.Globalization.CompareInfo> class.

    - For string comparisons, use the <xref:System.Globalization.CompareInfo> class.

    - For date and time formatting, use the <xref:System.Globalization.DateTimeFormatInfo> class.

    - For numeric formatting, use the <xref:System.Globalization.NumberFormatInfo> class.

    - For Gregorian and non-Gregorian calendars, use the <xref:System.Globalization.Calendar> class or one of the specific calendar implementations.

3. Use the culture property settings provided by the <xref:System.Globalization.CultureInfo?displayProperty=nameWithType> class in the appropriate situations. Use the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property for formatting tasks, such as date and time or numeric formatting. Use the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property to retrieve resources. Note that the `CurrentCulture` and `CurrentUICulture` properties can be set per thread.

4. Enable your application to read and write data to and from a variety of encodings by using the encoding classes in the <xref:System.Text> namespace. Do not assume ASCII data. Assume that international characters will be supplied anywhere a user can enter text. For example, the application should accept international characters in server names, directories, file names, user names, and URLs.

5. When using the <xref:System.Text.UTF8Encoding> class, for security reasons, use the error detection feature offered by this class. To turn on the error detection feature, create an instance of the class using the constructor that takes a `throwOnInvalidBytes` parameter and set the value of this parameter to `true`.

6. Whenever possible, handle strings as entire strings instead of as a series of individual characters. This is especially important when sorting or searching for substrings. This will prevent problems associated with parsing combined characters. You can also work with units of text rather than single characters by using the <xref:System.Globalization.StringInfo?displayProperty=nameWithType> class.

7. Display text using the classes provided by the <xref:System.Drawing> namespace.

8. For consistency across operating systems, do not allow user settings to override <xref:System.Globalization.CultureInfo>. Use the `CultureInfo` constructor that accepts a `useUserOverride` parameter and set it to `false`.

9. Test your application functionality on international operating system versions, using international data.

10. If a security decision is based on the result of a string comparison or case change operation, use a culture-insensitive string operation. This practice ensures that the result is not affected by the value of `CultureInfo.CurrentCulture`. See the ["String Comparisons that Use the Current Culture"](../../standard/base-types/best-practices-strings.md#string-comparisons-that-use-the-current-culture) section of [Best Practices for Using Strings](../../standard/base-types/best-practices-strings.md) for an example that demonstrates how culture-sensitive string comparisons can produce inconsistent results.

## Localization best practices

1. Move all localizable resources to separate resource-only DLLs. Localizable resources include user interface elements, such as strings, error messages, dialog boxes, menus, and embedded object resources.

2. Do not hardcode strings or user interface resources.

3. Do not put non-localizable resources into the resource-only DLLs. This causes confusion for translators.

4. Do not use composite strings that are built at run time from concatenated phrases. Composite strings are difficult to localize because they often assume an English grammatical order that does not apply to all languages.

5. Avoid ambiguous constructs such as "Empty Folder" where the strings can be translated differently depending on the grammatical roles of the string components. For example, "empty" can be either a verb or an adjective, which can lead to different translations in languages such as Italian or French.

6. Avoid using images and icons that contain text in your application. They are expensive to localize.

7. Allow plenty of room for the length of strings to expand in the user interface. In some languages, phrases can require 50-75 percent more space than they need in other languages.

8. Use the <xref:System.Resources.ResourceManager?displayProperty=nameWithType> class to retrieve resources based on culture.

9. Use [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link) to create Windows Forms dialog boxes so they can be localized using the [Windows Forms Resource Editor (Winres.exe)](../../framework/tools/winres-exe-windows-forms-resource-editor.md). Do not code Windows Forms dialog boxes by hand.

10. Arrange for professional localization (translation).

11. For a complete description of creating and localizing resources, see [Resources in .NET apps](resources.md).

## Globalization best practices for ASP.NET applications

1. Explicitly set the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> and <xref:System.Globalization.CultureInfo.CurrentCulture%2A> properties in your application. Do not rely on defaults.

2. Note that ASP.NET applications are managed applications and therefore can use the same classes as other managed applications for retrieving, displaying, and manipulating information based on culture.

3. Be aware that you can specify the following three types of encodings in ASP.NET:

    - requestEncoding specifies the encoding received from the client's browser.

    - responseEncoding specifies the encoding to send to the client browser. In most situations, this encoding should be the same as that specified for requestEncoding.

    - fileEncoding specifies the default encoding for .aspx, .asmx, and .asax file parsing.

4. Specify the values for the requestEncoding, responseEncoding, fileEncoding, culture, and uiCulture attributes in the following three places in an ASP.NET application:

    - In the globalization section of a Web.config file. This file is external to the ASP.NET application. For more information, see [\<globalization> element](/previous-versions/dotnet/netframework-4.0/hy4kkhe0(v=vs.100)).

    - In a page directive. Note that, when an application is in a page, the file has already been read. Therefore, it is too late to specify fileEncoding and requestEncoding. Only uiCulture, Culture, and responseEncoding can be specified in a page directive.

    - Programmatically in application code. This setting can vary per request. As with a page directive, by the time the application's code is reached it is too late to specify fileEncoding and requestEncoding. Only uiCulture, Culture, and responseEncoding can be specified in application code.

5. Note that the uiCulture value can be set to the browser accept language.

## See also

- [Globalization and Localization](globalization-and-localization.md)
- [Resources in .NET apps](resources.md)
