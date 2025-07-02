---
title: System.Globalization.CultureAndRegionInfoBuilder class
description: Learn more about the System.Globalization.CultureAndRegionInfoBuilder class.
ms.date: 01/09/2024
ms.topic: concept-article
---
# <xref:System.Globalization.CultureAndRegionInfoBuilder> class

[!INCLUDE [context](includes/context.md)]

> [!NOTE]
> The <xref:System.Globalization.CultureAndRegionInfoBuilder> class is useful only for Windows operating systems. The generated *.nlp* files aren't supported on non-Windows operating systems. Also, even on Windows, the generated *.nlp* files are supported only on .NET Framework (or in .NET Core when using [NLS globalization mode](../../core/runtime-config/globalization.md#nls)).

The <xref:System.Globalization.CultureInfo> class holds culture-specific information, such as the associated language, sublanguage, country/region, calendar, and cultural conventions. This class also provides culture-specific instances of the <xref:System.Globalization.DateTimeFormatInfo>, <xref:System.Globalization.NumberFormatInfo>, <xref:System.Globalization.CompareInfo>, and <xref:System.Globalization.TextInfo> classes, which are required for culture-specific operations such as casing, formatting and parsing dates and numbers, and comparing strings.

By default, .NET supports <xref:System.Globalization.CultureInfo> objects that represent a predefined set of cultures. For a list of these cultures available on Windows systems, see the **Language tag** column in the [list of language/region names supported by Windows](/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c). Culture names follow the standard defined by [BCP 47](https://tools.ietf.org/html/bcp47). The <xref:System.Globalization.CultureAndRegionInfoBuilder> class enables you to create a custom culture that is completely new or that overrides a predefined culture. When a custom culture is installed and registered on a particular computer, it becomes indistinguishable from predefined <xref:System.Globalization.CultureInfo> objects, and can be instantiated and used just like those objects.

> [!IMPORTANT]
> The <xref:System.Globalization.CultureAndRegionInfoBuilder> class is found in an assembly named *sysglobl.dll*. To successfully compile code that uses this type, you must add a reference to *sysglobl.dll*.

A custom culture can be registered on a computer only by a user who has administrative rights on that computer. Consequently, apps typically do not create and install custom cultures. Instead, you can use the <xref:System.Globalization.CultureAndRegionInfoBuilder> class to create a special-purpose tool that an administrator can use to create, install, and register a custom culture. After the custom culture is registered on a computer, you can use the <xref:System.Globalization.CultureInfo> class in your app to create instances of the custom culture just as you would for a predefined culture.

If you parse date and time strings generated for a custom culture, you should use the <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> or <xref:System.DateTime.TryParseExact%2A?displayProperty=nameWithType> method instead of the <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> or <xref:System.DateTime.TryParse%2A?displayProperty=nameWithType> method to improve the probability that the parse operation will succeed. A date and time string for a custom culture can be complicated and therefore difficult to parse. The <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.TryParse%2A> methods try to parse a string with several implicit parse patterns, all of which might fail. The <xref:System.DateTime.TryParseExact%2A> method, in contrast, requires the application to explicitly designate one or more exact parse patterns that are likely to succeed.

## Define and create a custom culture

You use the <xref:System.Globalization.CultureAndRegionInfoBuilder> class to define and name a custom culture. The custom culture can be an entirely new culture, a new culture that is based on an existing culture (that is, a supplemental culture), or a culture that replaces an existing .NET culture. In each case, the basic steps are the same:

1. Instantiate a <xref:System.Globalization.CultureAndRegionInfoBuilder> object by calling its <xref:System.Globalization.CultureAndRegionInfoBuilder.%23ctor%28System.String%2CSystem.Globalization.CultureAndRegionModifiers%29> constructor. To replace an existing culture, pass that culture's name and the <xref:System.Globalization.CultureAndRegionModifiers.Replacement?displayProperty=nameWithType> enumeration value to the constructor. To create a new culture or a supplemental culture, pass a unique culture name and either the <xref:System.Globalization.CultureAndRegionModifiers.Neutral?displayProperty=nameWithType> or <xref:System.Globalization.CultureAndRegionModifiers.None?displayProperty=nameWithType> enumeration value.

   > [!NOTE]
   > If you use the <xref:System.Globalization.CultureAndRegionModifiers.Replacement?displayProperty=nameWithType> enumeration value to instantiate a <xref:System.Globalization.CultureAndRegionInfoBuilder> object, the <xref:System.Globalization.CultureAndRegionInfoBuilder> object's properties are automatically populated with values from the <xref:System.Globalization.CultureInfo> object to be replaced.

2. If you're creating a new or supplemental culture:

   - Populate the <xref:System.Globalization.CultureAndRegionInfoBuilder> object's properties by calling the <xref:System.Globalization.CultureAndRegionInfoBuilder.LoadDataFromCultureInfo%2A> method and passing a <xref:System.Globalization.CultureInfo> object whose property values are similar to your new object.
   - Populate the <xref:System.Globalization.CultureAndRegionInfoBuilder> object's regional properties by calling the <xref:System.Globalization.CultureAndRegionInfoBuilder.LoadDataFromRegionInfo%2A> method and passing a <xref:System.Globalization.RegionInfo> object that represents the region of your custom culture.

3. Modify the properties of the <xref:System.Globalization.CultureAndRegionInfoBuilder> object as necessary.

4. If you are planning to register the custom culture in a separate routine, call the <xref:System.Globalization.CultureAndRegionInfoBuilder.Save%2A> method. This generates an XML file that you can load and register in a separate custom culture installation routine.

## Register a custom culture

If you are developing a registration application for a custom culture that is separate from the application that creates the culture, you call the <xref:System.Globalization.CultureAndRegionInfoBuilder.CreateFromLdml%2A> method to load the XML file that contains the custom culture's definition and instantiate the <xref:System.Globalization.CultureAndRegionInfoBuilder> object. To handle the registration, call the <xref:System.Globalization.CultureAndRegionInfoBuilder.Register%2A> method. For the registration to succeed, the application that registers the custom culture must be running with administrative privileges on the target system; otherwise, the call to <xref:System.Globalization.CultureAndRegionInfoBuilder.Register%2A> throws an <xref:System.UnauthorizedAccessException> exception.

> [!WARNING]
> Culture data can differ between systems. If you're using the <xref:System.Globalization.CultureAndRegionInfoBuilder> class to create a custom culture that is uniform across multiple systems and you are creating your custom culture by loading data from existing <xref:System.Globalization.CultureInfo> and <xref:System.Globalization.RegionInfo> objects and customizing it, you should develop two different utilities. The first creates the custom culture and saves it to an XML file. The second uses the <xref:System.Globalization.CultureAndRegionInfoBuilder.CreateFromLdml%2A> method to load the custom culture from an XML file and register it on the target computer.

The registration process performs the following tasks:

- Creates an *.nlp* file that contains the information that's defined in the <xref:System.Globalization.CultureAndRegionInfoBuilder> object.
- Stores the *.nlp* file in the %windir%\Globalization system directory on the target computer. This enables the custom culture's settings to persist between sessions. (The <xref:System.Globalization.CultureAndRegionInfoBuilder> method requires administrative privileges because the *.nlp* file is stored in a system directory.)
- Prepares .NET to search the %windir%\Globalization system directory instead of an internal cache the next time there's a request to create your new custom culture.

When a custom culture is successfully registered, it's indistinguishable from the cultures that are predefined by .NET. The custom culture is available until a call to the <xref:System.Globalization.CultureAndRegionInfoBuilder> method removes the *.nlp* file from the local computer.

## Instantiate a custom culture

You can create an instance of the custom culture in one of the following ways:

- By invoking the <xref:System.Globalization.CultureInfo.%23ctor%2A?displayProperty=nameWithType> constructor with the culture name.
- By calling the <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method with the culture name.
- By calling the <xref:System.Globalization.CultureInfo.GetCultureInfo%2A?displayProperty=nameWithType> method with the culture name.

In addition, the array of <xref:System.Globalization.CultureInfo> objects that is returned by the <xref:System.Globalization.CultureInfo.GetCultures%2A?displayProperty=nameWithType> method includes the custom culture.
