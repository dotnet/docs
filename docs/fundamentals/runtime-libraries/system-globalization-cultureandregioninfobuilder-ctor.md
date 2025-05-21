---
title: System.Globalization.CultureAndRegionInfoBuilder constructor
description: Learn about the System.Globalization.CultureAndRegionInfoBuilder constructor.
ms.date: 01/24/2024
ms.topic: article
---
# System.Globalization.CultureAndRegionInfoBuilder constructor

[!INCLUDE [context](includes/context.md)]

This article pertains to the <xref:System.Globalization.CultureAndRegionInfoBuilder.%23ctor(System.String,System.Globalization.CultureAndRegionModifiers)> constructor.

The `cultureName` parameter specifies the name of the new <xref:System.Globalization.CultureAndRegionInfoBuilder> object.

The `flags` parameter is used for a <xref:System.Globalization.CultureAndRegionModifiers> value that specifies whether the new <xref:System.Globalization.CultureAndRegionInfoBuilder> object is a new custom culture, or replaces an existing neutral culture, specific culture, or Windows locale.

If the `cultureName` parameter specifies an existing .NET culture, registered custom culture, or culture generated from a Windows locale, the <xref:System.Globalization.CultureAndRegionInfoBuilder.%23ctor%2A> constructor automatically populates the new <xref:System.Globalization.CultureAndRegionInfoBuilder> object with culture and country/region information.

Populate the new <xref:System.Globalization.CultureAndRegionInfoBuilder> object with culture and country/region information by invoking the <xref:System.Globalization.CultureAndRegionInfoBuilder.LoadDataFromCultureInfo%2A> and <xref:System.Globalization.CultureAndRegionInfoBuilder.LoadDataFromRegionInfo%2A> methods.

## Custom culture names

The preferred format of the `cultureName` parameter for a new, custom culture is "[`prefix`-]`language`[-`region`][-`suffix`[`…`]]", where the `language` component is required and the `prefix`, `region`, and `suffix` components are optional. The maximum length of each component is 8 characters and the maximum length of the entire `cultureName` parameter is 84 characters.

The `prefix` component is the Internet Assigned Numbers Authority (IANA) identification. Specify "i-" or "I-" for culture names registered with the IANA, or "x-" or "X-" for culture names reserved for private use. Otherwise, the prefix is not required. For more information, see RFC 4646, "Tags for the Identification of Languages."

The `language` component of the `cultureName` parameter specifies a lowercase two-letter code derived from ISO 639-1, and `region` specifies an uppercase two-letter code derived from ISO 3166. For example, en-US stands for English as spoken in the United States. The absence of the `region` component signifies a neutral culture.

A `cultureName` that is the same as the name of a culture included with .NET signifies a replacement (override) culture. The values that can be assigned to the properties of a replacement culture are limited. For more information about such limitations, see the exceptions for each property.

The application uses the `suffix` component to distinguish similar cultures. For example, two companies, ABC and XYZ, create and share a new ASP.NET Web service to promote their products in different markets around the world. The Web pages for the service display information such as the regional logo and local telephone number of each company depending on the user's culture. The culture-specific content for each Web page is in separate resource files identified by culture name and qualified by company name. For example, resource files for the en-US and ja-JP cultures are named en-US-ABC, en-US-XYZ, ja-JP-ABC, and ja-JP-XYZ. The "ABC" and "XYZ" suffixes enable the Web service to use the same application logic to display different market-specific information.

The `suffix` component can consist of subcomponents, where each subcomponent is delimited by a hyphen and the maximum length of each subcomponent is 8 characters. For example, if "en-US-honda-cars" is the `cultureName` parameter, "-honda-cars" is the `suffix` component.
