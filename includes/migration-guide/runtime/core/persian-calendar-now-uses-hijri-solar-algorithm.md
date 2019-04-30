### Persian calendar now uses the Hijri solar algorithm

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.6, the <xref:System.Globalization.PersianCalendar?displayProperty=name> class uses the Hijri solar algorithm. Converting dates between the <xref:System.Globalization.PersianCalendar?displayProperty=name> and other calendars may produce a slightly different result beginning with the .NET Framework 4.6 for dates earlier than 1800 or later than 2023 (Gregorian).Also, <xref:System.Globalization.PersianCalendar.MinSupportedDateTime?displayProperty=nameWithType> is now <code>March 22, 0622</code> instead of <code>March 21, 0622</code>.|
|Suggestion|Be aware that some early or late dates may be slightly different when using the PersianCalendar in .NET Framework 4.6. Also, when serializing dates between processes which may run on different .NET Framework versions, do not store them as PersianCalendar date strings (since those values may be different).|
|Scope|Minor|
|Version|4.6|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Globalization.PersianCalendar?displayProperty=nameWithType></li></ul>|
