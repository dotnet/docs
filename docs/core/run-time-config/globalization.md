---
title: Globalization config settings
description: Learn about run-time settings that configure globalization aspects of a .NET Core app, for example, how it parses Japanese dates.
ms.date: 11/27/2019
ms.topic: reference
---
# Run-time configuration options for globalization

## Invariant mode

- Determines whether a .NET Core app runs in globalization invariant mode without access to culture-specific data and behavior or whether it has access to cultural data.
- Default: Run the app with access to cultural data (`false`).
- For more information, see [.NET Core globalization invariant mode](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Globalization.Invariant` | `false` - access to cultural data<br/>`true` - run in invariant mode |
| **Environment variable** | `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT` | `0` - access to cultural data<br/>`1` - run in invariant mode |

## Era year ranges

- Determines whether range checks for calendars that support multiple eras are relaxed or whether dates that overflow an era's date range throw an <xref:System.ArgumentOutOfRangeException>.
- Default: Range checks are relaxed (`false`).
- For more information, see [Calendars, eras, and date ranges: Relaxed range checks](../../standard/datetime/working-with-calendars.md#calendars-eras-and-date-ranges-relaxed-range-checks).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `Switch.System.Globalization.EnforceJapaneseEraYearRanges` | `false` - relaxed range checks<br/>`true` - overflows cause an exception |
| **Environment variable** | N/A | N/A |

## Japanese date parsing

- Determines whether a string that contains either "1" or "Gannen" as the year parses successfully or whether only "1" is supported.
- Default: Parse strings that contain either "1" or "Gannen" as the year (`false`).
- For more information, see [Represent dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#represent-dates-in-calendars-with-multiple-eras).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `Switch.System.Globalization.EnforceLegacyJapaneseDateParsing` | `false` - "Gannen" or "1" is supported<br/>`true` - only "1" is supported |
| **Environment variable** | N/A | N/A |

## Japanese year format

- Determines whether the first year of a Japanese calendar era is formatted as "Gannen" or as a number.
- Default: Format the first year as "Gannen" (`false`).
- For more information, see [Represent dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#represent-dates-in-calendars-with-multiple-eras).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `Switch.System.Globalization.FormatJapaneseFirstYearAsANumber` | `false` - format as "Gannen"<br/>`true` - format as number |
| **Environment variable** | N/A | N/A |
