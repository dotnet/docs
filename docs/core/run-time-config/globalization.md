---
title: Globalization config settings
description: Learn about run-time settings for configuring globalization aspects of an app, for example, how it parses Japanese dates.
ms.date: 11/13/2019
ms.topic: reference
---
# Run-time configuration options for globalization

## Invariant mode

- Determines whether a .NET Core app runs in globalization invariant mode without access to culture-specific data and behavior or whether it has access to cultural data.
- The default is to run the app with access to cultural data (value = `false`).
- For more information, see [.NET Core Globalization Invariant Mode](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.Globalization.Invariant" | true - no access to cultural data<br/><br/>false - access to cultural data | | |

## Era year ranges

- Determines whether range checks for calendars that support multiple eras are relaxed or whether dates that overflow an era's date range throw an <xref:System.ArgumentOutOfRangeException>.
- The default value is that range check are relaxed (value = `false`).
- For more information, see [Calendars, eras, and date ranges: Relaxed range checks](../../standard/datetime/working-with-calendars.md#calendars-eras-and-date-ranges-relaxed-range-checks).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "Switch.System.Globalization.EnforceJapaneseEraYearRange" | true - overflows cause an exception<br/><br/>false - relaxed range checks | | |

## Japanese date parsing

- Determines whether a string that contains either "1" or "Gannen" as the year parses successfully or whether only "1" is supported.
- The default value is to parse strings that contain either "1" or "Gannen" as the year (value = `false`).
- For more information, see [Represent dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#represent-dates-in-calendars-with-multiple-eras).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "Switch.System.Globalization.EnforceLegacyJapaneseDateParsing" | true - only "1" is supported<br/><br/>false - "Gannen" or "1" is supported | | |

## Japanese year format

- Determines whether the first year of a Japanese calendar era is formatted as "gannen" or as a number.
- The default is to format the first year as "gannen" (value = `false`).
- For more information, see [Represent dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#represent-dates-in-calendars-with-multiple-eras).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "Switch.System.Globalization.FormatJapaneseFirstYearAsANumber" | true - format as number<br/><br/>false - format as "gannen" | | |
