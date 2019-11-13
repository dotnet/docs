---

---
# Run-time configuration options for dates and times

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | |

runtimeconfig.json:

|"Switch.System.Globalization.EnforceJapaneseEraYearRange"|true &#124; false|Determines whether range checks for calendars that support multiple eras are relaxed (`false`, the default value) or whether dates that overflow an era's date range throw an <xref:System.ArgumentOutOfRangeException> (`true`). For more information, see [Calendars, eras, and date ranges: Relaxed range checks](../../standard/datetime/working-with-calendars.md#calendars-eras-and-date-ranges-relaxed-range-checks).|

|"Switch.System.Globalization.EnforceLegacyJapaneseDateParsing"|true &#124; false|Determines whether a string that contains either "1" or "Gannen" as the year parses successfully (`false`, the default), or whether only "1" is supported (`true`). For more information, see [Representing dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#representing-dates-in-calendars-with-multiple-eras).|

|"Switch.System.Globalization.FormatJapaneseFirstYearAsANumber"|true &#124; false|Determines whether the first year of a Japanese calendar era is formatted as "gannen" (`false`, the default) or as a number. For more information, see [Representing dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#representing-dates-in-calendars-with-multiple-eras).|
