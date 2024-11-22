---
title: System.Globalization.CultureInfo class
description: Learn more about the System.Globalization.CultureInfo class.
ms.date: 12/28/2023
ms.topic: conceptual
---
# <xref:System.Globalization.CultureInfo> class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Globalization.CultureInfo> class provides culture-specific information, such as the language, sublanguage, country/region, calendar, and conventions associated with a particular culture. This class also provides access to culture-specific instances of the <xref:System.Globalization.DateTimeFormatInfo>, <xref:System.Globalization.NumberFormatInfo>, <xref:System.Globalization.CompareInfo>, and <xref:System.Globalization.TextInfo> objects. These objects contain the information required for culture-specific operations, such as casing, formatting dates and numbers, and comparing strings. The <xref:System.Globalization.CultureInfo> class is used either directly or indirectly by classes that format, parse, or manipulate culture-specific data, such as <xref:System.String>, <xref:System.DateTime>, <xref:System.DateTimeOffset>, and the numeric types.

## Culture names and identifiers

The <xref:System.Globalization.CultureInfo> class specifies a unique name for each culture, based on RFC 4646. The name is a combination of an ISO 639 two-letter or three-letter lowercase culture code associated with a language and an ISO 3166 two-letter uppercase subculture code associated with a country or region. In addition, for apps that are running under Windows 10 or later, culture names that correspond to valid BCP-47 language tags are supported.

> [!NOTE]
> When a culture name is passed to a class constructor or a method such as <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A> or <xref:System.Globalization.CultureInfo>, its case is not significant.

The format for the culture name based on RFC 4646 is *`languagecode2`*-*`country/regioncode2`*, where *`languagecode2`* is the two-letter language code and *`country/regioncode2`* is the two-letter subculture code. Examples include `ja-JP` for Japanese (Japan) and `en-US` for English (United States). In cases where a two-letter language code is not available, a three-letter code as defined in ISO 639-3 is used.

Some culture names also specify an ISO 15924 script. For example, Cyrl specifies the Cyrillic script and Latn specifies the Latin script. A culture name that includes a script uses the pattern *`languagecode2`*-*`scripttag`*-*`country/regioncode2`*. An example of this type of culture name is `uz-Cyrl-UZ` for Uzbek (Cyrillic, Uzbekistan). On Windows operating systems before Windows Vista, a culture name that includes a script uses the pattern *`languagecode2`*-*`country/regioncode2`*-*`scripttag`*, for example, `uz-UZ-Cyrl` for Uzbek (Cyrillic, Uzbekistan).

A neutral culture is specified by only the two-letter, lowercase language code. For example, `fr` specifies the neutral culture for French, and `de` specifies the neutral culture for German.

> [!NOTE]
> There are two culture names that contradict this rule. The cultures Chinese (Simplified), named `zh-Hans`, and Chinese (Traditional), named `zh-Hant`, are neutral cultures. The culture names represent the current standard and should be used unless you have a reason for using the older names `zh-CHS` and `zh-CHT`.

A culture identifier is a standard international numeric abbreviation and has the components necessary to uniquely identify one of the installed cultures. Your application can use predefined culture identifiers or define custom identifiers.

Certain predefined culture names and identifiers are used by this and other classes in the <xref:System.Globalization?displayProperty=fullName> namespace. For detailed culture information for Windows systems, see the **Language tag** column in the [list of language/region names supported by Windows](/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c). Culture names follow the standard defined by [BCP 47](https://tools.ietf.org/html/bcp47).

The culture names and identifiers represent only a subset of cultures that can be found on a particular computer. Windows versions or service packs can change the available cultures. Applications can add custom cultures using the <xref:System.Globalization.CultureAndRegionInfoBuilder> class. Users can add their own custom cultures using the [Microsoft Locale Builder](https://www.microsoft.com/download/details.aspx?id=41158) tool. Microsoft Locale Builder is written in managed code using the `CultureAndRegionInfoBuilder` class.

Several distinct names are closely associated with a culture, notably the names associated with the following class members:

- <xref:System.Globalization.CultureInfo.ToString%2A?displayProperty=nameWithType>
- <xref:System.Globalization.CultureInfo.Name%2A?displayProperty=nameWithType>
- <xref:System.Globalization.CompareInfo.Name%2A?displayProperty=nameWithType>

## Invariant, neutral, and specific cultures

The cultures are generally grouped into three sets: invariant cultures, neutral cultures, and specific cultures.

An invariant culture is culture-insensitive. Your application specifies the invariant culture by name using an empty string ("") or by its identifier. <xref:System.Globalization.CultureInfo.InvariantCulture%2A> defines an instance of the invariant culture. It is associated with the English language but not with any country/region. It is used in almost any method in the `Globalization` namespace that requires a culture.

A neutral culture is a culture that is associated with a language but not with a country/region. A specific culture is a culture that is associated with a language and a country/region. For example, `fr` is the neutral name for the French culture, and `fr-FR` is the name of the specific French (France) culture. Note that Chinese (Simplified) and Chinese (Traditional) are also considered neutral cultures.

Creating an instance of a <xref:System.Globalization.CompareInfo> class for a neutral culture is not recommended because the data it contains is arbitrary. To display and sort data, specify both the language and region. Additionally, the <xref:System.Globalization.CompareInfo.Name%2A> property of a <xref:System.Globalization.CompareInfo> object created for a neutral culture returns only the country and does not include the region.

The defined cultures have a hierarchy in which the parent of a specific culture is a neutral culture and the parent of a neutral culture is the invariant culture. The <xref:System.Globalization.CultureInfo.Parent%2A> property contains the neutral culture associated with a specific culture. Custom cultures should define the <xref:System.Globalization.CultureInfo.Parent%2A> property in conformance with this pattern.

If the resources for a specific culture are not available in the operating system, the resources for the associated neutral culture are used. If the resources for the neutral culture are not available, the resources embedded in the main assembly are used. For more information on the resource fallback process, see [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps).

The list of locales in the Windows API is slightly different from the list of cultures supported by .NET. If interoperability with Windows is required, for example, through the p/invoke mechanism, the application should use a specific culture that's defined for the operating system. Use of the specific culture ensures consistency with the equivalent Windows locale, which is identified with a locale identifier that is the same as <xref:System.Globalization.CultureInfo.LCID%2A>.

A <xref:System.Globalization.DateTimeFormatInfo> or a <xref:System.Globalization.NumberFormatInfo> can be created only for the invariant culture or for specific cultures, not for neutral cultures.

If <xref:System.Globalization.DateTimeFormatInfo.Calendar%2A?displayProperty=nameWithType> is the <xref:System.Globalization.TaiwanCalendar> but the <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> is not set to `zh-TW`, then <xref:System.Globalization.DateTimeFormatInfo.NativeCalendarName%2A?displayProperty=nameWithType>, <xref:System.Globalization.DateTimeFormatInfo.GetEraName%2A?displayProperty=nameWithType>, and <xref:System.Globalization.DateTimeFormatInfo.GetAbbreviatedEraName%2A?displayProperty=nameWithType> return an empty string ("").

## Custom cultures

On Windows, you can create custom locales. For more information, see [Custom locales](/windows/win32/intl/custom-locales).

## CultureInfo and cultural data

.NET derives its cultural data from a one of a variety of sources, depending on implementation, platform, and version:

- In all versions of .NET (Core) running on Unix platforms or Windows 10 and later versions, cultural data is provided by the [International Components for Unicode (ICU) Library](https://icu.unicode.org/). The specific version of the ICU Library depends on the individual operating system.
- In all versions of .NET (Core) running on Windows 9 and earlier versions, cultural data is provided by the Windows operating system.
- In .NET Framework 4 and later versions, cultural data is provided by the Windows operating system.

Because of this, a culture available on a particular .NET implementation, platform, or version may not be available on a different .NET implementation, platform, or version.

Some `CultureInfo` objects differ depending on the underlying platform. In particular, `zh-CN`, or Chinese (Simplified, China) and `zh-TW`, or Chinese (Traditional, Taiwan), are available cultures on Windows systems, but they are aliased cultures on Unix systems. "zh-CN" is an alias for the "zh-Hans-CN" culture, and "zh-TW" is an alias for the "zh-Hant-TW" culture. Aliased cultures are not returned by calls to the <xref:System.Globalization.CultureInfo.GetCultures%2A> method and may have different property values, including different <xref:System.Globalization.CultureInfo.Parent> cultures, than their Windows counterparts. For the `zh-CN` and `zh-TW` cultures, these differences include the following:

- On Windows systems, the parent culture of the "zh-CN" culture is "zh-Hans", and the parent culture of the "zh-TW" culture is "zh-Hant". The parent culture of both these cultures is "zh". On Unix systems, the parents of both cultures are "zh". This means that, if you don't provide culture-specific resources for the "zh-CN" or "zh-TW" cultures but do provide a resources for the neutral "zh-Hans" or "zh-Hant" culture, your application will load the resources for the neutral culture on Windows but not on Unix. On Unix systems, you must explicitly set the thread's <xref:System.Globalization.CultureInfo.CurrentUICulture> to either "zh-Hans" or "zh-Hant".

- On Windows systems, calling <xref:System.Globalization.CultureInfo.Equals%2A?displayProperty=nameWithType> on an instance that represents the "zh-CN" culture and passing it a "zh-Hans-CN" instance returns `true`. On Unix systems, the method call returns `false`. This behavior also applies to calling <xref:System.Globalization.CultureInfo.Equals%2A> on a "zh-TW" <xref:System.Globalization.CultureInfo> instance and passing it a "zh-Hant-Tw" instance.

## Dynamic culture data

Except for the invariant culture, culture data is dynamic. This is true even for the predefined cultures. For example, countries or regions adopt new currencies, change their spellings of words, or change their preferred calendar, and culture definitions change to track this. Custom cultures are subject to change without notice, and any specific culture might be overridden by a custom replacement culture. Also, as discussed below, an individual user can override cultural preferences. Applications should always obtain culture data at run time.

> [!CAUTION]
> When saving data, your application should use the invariant culture, a binary format, or a specific culture-independent format. Data saved according to the current values associated with a particular culture, other than the invariant culture, might become unreadable or might change in meaning if that culture changes.

## The current culture and current UI culture

Every thread in a .NET application has a current culture and a current UI culture. The current culture determines the formatting conventions for dates, times, numbers, and currency values, the sort order of text, casing conventions, and the ways in which strings are compared. The current UI culture is used to retrieve culture-specific resources at run time.

> [!NOTE]
> For information on how the current and current UI culture is determined on a per-thread basis, see the  [Culture and threads](#culture-and-threads) section. For information on how the current and current UI culture is determined on threads executing in a new application domain, and on threads that cross application domain boundaries, see the [Culture and application domains](#culture-and-application-domains) section. For information on how the current and current UI culture is determined on  threads performing task-based asynchronous operations, see the [Culture and task-based asynchronous operations](#culture-and-task-based-asynchronous-operations) section.

For more detailed information on the current culture, see the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property. For more detailed information on the current UI culture, see the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property topic.

### Retrieve the current and current UI cultures

You can get a <xref:System.Globalization.CultureInfo> object that represents the current culture in either of two ways:

- By retrieving the value of the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property.
- By retrieving the value of the [Thread.CurrentThread.CurrentCulture](<xref:System.Threading.Thread.CurrentCulture>) property.

The following example retrieves both property values, compares them to show that they are equal, and displays the name of the current culture.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/Current1.cs" id="Snippet1":::

You can get a <xref:System.Globalization.CultureInfo> object that represents the current UI culture in either of two ways:

- By retrieving the value of the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property.

- By retrieving the value of the [Thread.CurrentThread.CurrentUICulture](<xref:System.Threading.Thread.CurrentUICulture>) property.

The following example retrieves both property values, compares them to show that they are equal, and displays the name of the current UI culture.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/CurrentUI1.cs" id="Snippet2":::

### Set the current and current UI cultures

To change the culture and UI culture of a thread, do the following:

1. Instantiate a <xref:System.Globalization.CultureInfo> object that represents that culture by calling a <xref:System.Globalization.CultureInfo> class constructor and passing it the name of the culture. The <xref:System.Globalization.CultureInfo.%23ctor%28System.String%29> constructor instantiates a  <xref:System.Globalization.CultureInfo> object that reflects user overrides if the new culture is the same as the current Windows culture.   The <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29> constructor allows you to specify whether the newly instantiated <xref:System.Globalization.CultureInfo> object reflects user overrides if the new culture is the same as the current Windows culture.

2. Assign the <xref:System.Globalization.CultureInfo> object to the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> or <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property on .NET Core and .NET Framework 4.6 and later versions.

The following example retrieves the current culture. If it is anything other than the French (France) culture, it changes the current culture to French (France). Otherwise, it changes the current culture to French (Luxembourg).

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/Change1.cs" id="Snippet3":::

The following example retrieves the current culture. If it is anything other the Slovenian (Slovenia) culture, it changes the current culture to Slovenian (Slovenia). Otherwise, it changes the current culture to Croatian (Croatia).

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/ChangeUI1.cs" id="Snippet4":::

## Get all cultures

You can retrieve an array of specific categories of cultures or of all the cultures available on the local computer by calling the <xref:System.Globalization.CultureInfo.GetCultures%2A> method. For example, you can retrieve custom cultures, specific cultures, or neutral cultures either alone or in combination.

The following example calls the <xref:System.Globalization.CultureInfo.GetCultures%2A> method twice, first with the <xref:System.Globalization.CultureTypes?displayProperty=nameWithType> enumeration member to retrieve all custom cultures, and then with the <xref:System.Globalization.CultureTypes?displayProperty=nameWithType> enumeration member to retrieve all replacement cultures.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/GetCultures1.cs" id="Snippet5":::

## Culture and threads

When a new application thread is started, its current culture and current UI culture are defined by the current system culture, and not by the current thread culture. The following example illustrates the difference. It sets the current culture and current UI culture of an application thread to the French (France) culture (fr-FR). If the current culture is already fr-FR, the example sets it to the English (United States) culture (en-US). It displays three random numbers as currency values and then creates a new thread, which, in turn, displays three more random numbers as currency values. But as the output from the example shows, the currency values displayed by the new thread do not reflect the formatting conventions of the French (France) culture, unlike the output from the main application thread.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/defaultthread1.cs" id="Snippet1":::

You can set the culture and UI culture of all threads in an application domain by assigning a <xref:System.Globalization.CultureInfo> object that represents that culture to the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> properties. The following example uses these properties to ensure that all threads in the default application domain share the same culture.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/setthreads1.cs" id="Snippet3":::

> [!WARNING]
> Although the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> properties are static members, they define the default culture and default UI culture only for the application domain that is current at the time these property values are set. For more information, see the next section, [Culture and application domains](#culture-and-application-domains).

When you assign values to the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> properties, the culture and UI culture of the threads in the application domain also change if they have not explicitly been assigned a culture. However, these threads reflect the new culture settings only while they execute in the current application domain. If these threads execute in another application domain, their culture becomes the default culture defined for that application domain. As a result, we recommend that you always set the culture of the main application thread, and not rely on the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> properties to change it.

## Culture and application domains

<xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> are static properties that explicitly define a default culture only for the application domain that is current when the property value is set or retrieved. The following example sets the default culture and default UI culture in the default application domain to French (France), and then uses the <xref:System.AppDomainSetup> class and the <xref:System.AppDomainInitializer> delegate to set the default culture and UI culture in a new application domain to Russian (Russia). A single thread then executes two methods in each application domain. Note that the thread's culture and UI culture are not explicitly set; they are derived from the default culture and UI culture of the application domain in which the thread is executing. Note also that the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> properties return the default <xref:System.Globalization.CultureInfo> values of the application domain that is current when the method call is made.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/appdomainex1.cs" id="Snippet1":::

For more information about cultures and application domains, see the "Application Domains and Threads" section in the [Application Domains](../../framework/app-domains/application-domains.md) topic.

## Culture and task-based asynchronous operations

The [task-based asynchronous programming pattern](../../standard/parallel-programming/task-based-asynchronous-programming.md) uses <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects to asynchronously execute delegates on thread pool threads. The specific thread on which a particular task runs is not known in advance, but is determined only at runtime.

For apps that target .NET Framework 4.6 or a later version, culture is part of an asynchronous operation's context. In other words, asynchronous operations by default inherit the values of the <xref:System.Globalization.CultureInfo.CurrentCulture%2A> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> properties of the thread from which they are launched. If the current culture or current UI culture differs from the system culture, the current culture crosses thread boundaries and becomes the current culture of the thread pool thread that is executing an asynchronous operation.

The following example provides a simple illustration. The example defines a <xref:System.Func%601> delegate, `formatDelegate`, that returns some numbers formatted as currency values. The example changes the current system culture to either French (France) or, if French (France) is already the current culture, English (United States). It then:

- Invokes the delegate directly so that it runs synchronously on the main app thread.
- Creates a task that executes the delegate asynchronously on a thread pool thread.
- Creates a task that executes the delegate synchronously on the main app thread by calling the <xref:System.Threading.Tasks.Task.RunSynchronously%2A?displayProperty=nameWithType> method.

As the output from the example shows, when the current culture is changed to French (France), the current culture of the thread from which tasks are invoked asynchronously becomes the current culture for that asynchronous operation.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/csharp/asyncculture1.cs" id="Snippet1":::

<xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture%2A> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A> are per-app domain properties; that is, they establish a default culture for all threads not explicitly assigned a culture in a specific application domain. However, for apps that target .NET Framework 4.6 or later, the culture of the calling thread remains part of an asynchronous task's context even if the task crosses app domain boundaries.

## CultureInfo object serialization

When a <xref:System.Globalization.CultureInfo> object is serialized, all that is actually stored is <xref:System.Globalization.CultureInfo.Name%2A> and <xref:System.Globalization.CultureInfo.UseUserOverride%2A>. It is successfully deserialized only in an environment where that <xref:System.Globalization.CultureInfo.Name%2A> has the same meaning. The following three examples show why this is not always the case:

- If the <xref:System.Globalization.CultureInfo.CultureTypes%2A> property value is <xref:System.Globalization.CultureTypes.InstalledWin32Cultures?displayProperty=nameWithType>, and if that culture was first introduced in a particular version of the Windows operating system, it is not possible to deserialize it on an earlier version of Windows. For example, if a culture was introduced in Windows 10, it cannot be deserialized on Windows 8.

- If the <xref:System.Globalization.CultureInfo.CultureTypes%2A> value is <xref:System.Globalization.CultureTypes.UserCustomCulture?displayProperty=nameWithType>, and the computer on which it is deserialized does not have this user custom culture installed, it is not possible to deserialize it.

- If the <xref:System.Globalization.CultureInfo.CultureTypes%2A> value is <xref:System.Globalization.CultureTypes.ReplacementCultures?displayProperty=nameWithType>, and the computer on which it is deserialized does not have this replacement culture, it deserializes to the same name, but not all of the same characteristics. For example, if `en-US` is a replacement culture on computer A, but not on computer B, and if a <xref:System.Globalization.CultureInfo> object referring to this culture is serialized on computer A and deserialized on computer B, then none of the custom characteristics of the culture are transmitted. The culture deserializes successfully, but with a different meaning.

## Control Panel overrides

The user might choose to override some of the values associated with the current culture of Windows through the regional and language options portion of Control Panel. For example, the user might choose to display the date in a different format or to use a currency other than the default for the culture. In general, your applications should honor these user overrides.

If <xref:System.Globalization.CultureInfo.UseUserOverride%2A> is `true` and the specified culture matches the current culture of Windows, the <xref:System.Globalization.CultureInfo> uses those overrides, including user settings for the properties of the <xref:System.Globalization.DateTimeFormatInfo> instance returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A> property, and the properties of the <xref:System.Globalization.NumberFormatInfo> instance returned by the <xref:System.Globalization.CultureInfo.NumberFormat%2A> property. If the user settings are incompatible with the culture associated with the <xref:System.Globalization.CultureInfo>, for example, if the selected calendar is not one of the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A>, the results of the methods and the values of the properties are undefined.

## Alternate sort orders

Some cultures support more than one sort order. For example:

- The Spanish (Spain) culture has two sort orders: the default international sort order, and the traditional sort order. When you instantiate a <xref:System.Globalization.CultureInfo> object with the `es-ES` culture name, the international sort order is used. When you instantiate a <xref:System.Globalization.CultureInfo> object with the `es-ES-tradnl` culture name, the traditional sort order is used.

- The `zh-CN` (Chinese (Simplified, PRC)) culture supports two sort orders:  by pronunciation (the default) and by stroke count. When you instantiate a <xref:System.Globalization.CultureInfo> object with the `zh-CN` culture name, the default sort order is used. When you instantiate a <xref:System.Globalization.CultureInfo> object with a local identifier of 0x00020804, strings are sorted by stroke count.

The following table lists the cultures that support alternate sort orders and the identifiers for the default and alternate sort orders.

|Culture name|Culture|Default sort name and identifier|Alternate sort name and identifier|
|------------------|-------------|--------------------------------------|----------------------------------------|
|es-ES|Spanish (Spain)|International: 0x00000C0A|Traditional: 0x0000040A|
|zh-TW|Chinese (Taiwan)|Stroke Count: 0x00000404|Bopomofo: 0x00030404|
|zh-CN|Chinese (PRC)|Pronunciation: 0x00000804|Stroke Count: 0x00020804|
|zh-HK|Chinese (Hong Kong SAR)|Stroke Count: 0x00000c04|Stroke Count: 0x00020c04|
|zh-SG|Chinese (Singapore)|Pronunciation: 0x00001004|Stroke Count: 0x00021004|
|zh-MO|Chinese (Macao SAR)|Pronunciation: 0x00001404|Stroke Count: 0x00021404|
|ja-JP|Japanese (Japan)|Default: 0x00000411|Unicode: 0x00010411|
|ko-KR|Korean (Korea)|Default: 0x00000412|Korean Xwansung - Unicode: 0x00010412|
|de-DE|German (Germany)|Dictionary: 0x00000407|Phone Book Sort DIN: 0x00010407|
|hu-HU|Hungarian (Hungary)|Default: 0x0000040e|Technical Sort: 0x0001040e|
|ka-GE|Georgian (Georgia)|Traditional: 0x00000437|Modern Sort: 0x00010437|

## The current culture and UWP apps

In Universal Windows Platform (UWP) apps, the <xref:System.Globalization.CultureInfo.CurrentCulture%2A> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> properties are read-write, just as they are in .NET Framework and .NET Core apps. However, UWP apps recognize a single culture. The <xref:System.Globalization.CultureInfo.CurrentCulture%2A> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> properties map to the first value in the [Windows.ApplicationModel.Resources.Core.ResourceManager.DefaultContext.Languages](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#properties_) collection.

In .NET apps, the current culture is a per-thread setting, and the <xref:System.Globalization.CultureInfo.CurrentCulture%2A> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> properties reflect the culture and UI culture of the current thread only. In UWP apps, the current culture maps to the [Windows.ApplicationModel.Resources.Core.ResourceManager.DefaultContext.Languages](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#properties_) collection, which is a global setting. Setting the <xref:System.Globalization.CultureInfo.CurrentCulture%2A> or <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> property changes the culture of the entire app; culture cannot be set on a per-thread basis.
