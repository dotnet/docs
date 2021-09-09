---
title: Globalization config settings
description: Learn about run-time settings that configure globalization aspects of a .NET Core app, for example, how it parses Japanese dates.
ms.date: 05/18/2020
ms.topic: reference
---
# Runtime configuration options for globalization

## Invariant mode

- Determines whether a .NET Core app runs in globalization-invariant mode without access to culture-specific data and behavior.
- If you omit this setting, the app runs with access to cultural data. This is equivalent to setting the value to `false`.
- For more information, see [.NET Core globalization invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Globalization.Invariant` | `false` - access to cultural data<br/>`true` - run in invariant mode |
| **MSBuild property** | `InvariantGlobalization` | `false` - access to cultural data<br/>`true` - run in invariant mode |
| **Environment variable** | `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT` | `0` - access to cultural data<br/>`1` - run in invariant mode |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Globalization.Invariant": true
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <InvariantGlobalization>true</InvariantGlobalization>
  </PropertyGroup>

</Project>
```

## Era year ranges

- Determines whether range checks for calendars that support multiple eras are relaxed or whether dates that overflow an era's date range throw an <xref:System.ArgumentOutOfRangeException>.
- If you omit this setting, range checks are relaxed. This is equivalent to setting the value to `false`.
- For more information, see [Calendars, eras, and date ranges: Relaxed range checks](../../standard/datetime/working-with-calendars.md#calendars-eras-and-date-ranges-relaxed-range-checks).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `Switch.System.Globalization.EnforceJapaneseEraYearRanges` | `false` - relaxed range checks<br/>`true` - overflows cause an exception |
| **Environment variable** | N/A | N/A |

## Japanese date parsing

- Determines whether a string that contains either "1" or "Gannen" as the year parses successfully or whether only "1" is supported.
- If you omit this setting, strings that contain either "1" or "Gannen" as the year parse successfully. This is equivalent to setting the value to `false`.
- For more information, see [Represent dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#represent-dates-in-calendars-with-multiple-eras).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `Switch.System.Globalization.EnforceLegacyJapaneseDateParsing` | `false` - "Gannen" or "1" is supported<br/>`true` - only "1" is supported |
| **Environment variable** | N/A | N/A |

## Japanese year format

- Determines whether the first year of a Japanese calendar era is formatted as "Gannen" or as a number.
- If you omit this setting, the first year is formatted as "Gannen". This is equivalent to setting the value to `false`.
- For more information, see [Represent dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#represent-dates-in-calendars-with-multiple-eras).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `Switch.System.Globalization.FormatJapaneseFirstYearAsANumber` | `false` - format as "Gannen"<br/>`true` - format as number |
| **Environment variable** | N/A | N/A |

## NLS

- Determines whether .NET uses National Language Support (NLS) or International Components for Unicode (ICU) globalization APIs for Windows apps. .NET 5.0 and later versions use ICU globalization APIs by default on Windows 10 May 2019 Update and later versions.
- If you omit this setting, .NET uses ICU globalization APIs by default. This is equivalent to setting the value to `false`.
- For more information, see [Globalization APIs use ICU libraries on Windows](../compatibility/globalization/5.0/icu-globalization-api.md).

| | Setting name | Values | Introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.Globalization.UseNls` | `false` - Use ICU globalization APIs<br/>`true` - Use NLS globalization APIs | .NET 5.0 |
| **Environment variable** | `DOTNET_SYSTEM_GLOBALIZATION_USENLS` | `false` - Use ICU globalization APIs<br/>`true` - Use NLS globalization APIs | .NET 5.0 |

## Predefined cultures

- Configures whether apps can create cultures other than the invariant culture when [globalization-invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) is enabled.
- If you omit this setting, .NET restricts the creation of cultures in globalization-invariant mode. This is equivalent to setting the value to `true`.
- For more information, see [Culture creation and case mapping in globalization-invariant mode](../compatibility/globalization/6.0/culture-creation-invariant-mode.md).

| | Setting name | Values | Introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.Globalization.PredefinedCulturesOnly` | `true` - In globalization-invariant mode, don't allow creation of any culture except the invariant culture.<br/>`false` - Allow creation of any culture. | .NET 6 |
| **MSBuild property** | `PredefinedCulturesOnly` | `true` - In globalization-invariant mode, don't allow creation of any culture except the invariant culture.<br/>`false` - Allow creation of any culture. | .NET 6 |
| **Environment variable** | `DOTNET_SYSTEM_GLOBALIZATION_PREDEFINED_CULTURES_ONLY` | `true` - In globalization-invariant mode, don't allow creation of any culture except the invariant culture.<br/>`false` - Allow creation of any culture. | .NET 6 |
