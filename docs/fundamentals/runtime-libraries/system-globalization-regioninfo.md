---
title: System.Globalization.RegionInfo class
description: Learn more about the System.Globalization.RegionInfo class.
ms.date: 12/28/2023
ms.topic: concept-article
---
# <xref:System.Globalization.RegionInfo> class

[!INCLUDE [context](includes/context.md)]

Unlike the <xref:System.Globalization.CultureInfo> class, the <xref:System.Globalization.RegionInfo> class does not represent user preferences and does not depend on the user's language or culture.

## Names associated with a RegionInfo object

The name of a <xref:System.Globalization.RegionInfo> object is one of the two-letter codes defined in ISO 3166 for country/region. Case is not significant. The <xref:System.Globalization.RegionInfo.Name>, <xref:System.Globalization.RegionInfo.TwoLetterISORegionName>, and <xref:System.Globalization.RegionInfo.ThreeLetterISORegionName> properties return the appropriate codes in uppercase. For the current list of <xref:System.Globalization.RegionInfo> names, see [ISO 3166: Country codes](https://www.iso.org/iso-3166-country-codes.html).

## Instantiate a RegionInfo object

To instantiate a <xref:System.Globalization.RegionInfo> object, you pass the <xref:System.Globalization.RegionInfo.%23ctor(System.String)> constructor either a two-letter region name, such as "US" for the United States, or the name of a specific culture, such as "en-US" for English (United States). However, we recommend that you use a specific culture name instead of a two-letter region name, because a <xref:System.Globalization.RegionInfo> object is not completely language-independent. Several <xref:System.Globalization.RegionInfo> properties, including <xref:System.Globalization.RegionInfo.DisplayName>, <xref:System.Globalization.RegionInfo.NativeName>, and <xref:System.Globalization.RegionInfo.CurrencyNativeName>, depend on culture names.

The following example illustrates the difference in <xref:System.Globalization.RegionInfo> property values for three objects that represent Belgium. The first is instantiated from a region name (`BE`) only, while the second and third are instantiated from culture names (`fr-BE` for French (Belgium) and `nl-BE` for Dutch (Belgium), respectively). The example uses reflection to retrieve the property values of each <xref:System.Globalization.RegionInfo> object.

:::code language="csharp" source="./snippets/System.Globalization/RegionInfo/csharp/propertyvalues1.cs" id="Snippet2":::

In scenarios such as the following, use culture names instead of country/region names when you instantiate a <xref:System.Globalization.RegionInfo> object:

- When the language name is of primary importance. For example, for the `es-US` culture name, you'll probably want your application to display "Estados Unidos" instead of "United States". Using the country/region name (`US`) alone yields "United States" regardless of the language, so you should work with the culture name instead.

- When script differences must be considered. For example, the country/region `AZ` deals with Azerbaijani cultures that have the names `az-Latn-AZ` and `az-Cyrl-AZ`, and the Latin and Cyrillic scripts can be very different for this country/region.

- When maintenance of detail is important. The values returned by <xref:System.Globalization.RegionInfo> members can differ depending on whether the <xref:System.Globalization.RegionInfo> object was instantiated by using a culture name or a region name. For example, the following table lists the differences in return values when a <xref:System.Globalization.RegionInfo> object is instantiated by using the "US" region, the "en-US" culture, and the "es-US" culture.

  | Member                                                    | "US"            | "en-US"         | "es-US"           |
  |-----------------------------------------------------------|-----------------|-----------------|-------------------|
  | <xref:System.Globalization.RegionInfo.CurrencyNativeName> | `US Dollar`     | `US Dollar`     | `Dólar de EE.UU.` |
  | <xref:System.Globalization.RegionInfo.Name>               | `US`            | `en-US`         | `es-US`           |
  | <xref:System.Globalization.RegionInfo.NativeName>         | `United States` | `United States` | `Estados Unidos`  |
  | <xref:System.Globalization.RegionInfo.ToString%2A>        | `US`            | `en-US`         | `es-US`           |
