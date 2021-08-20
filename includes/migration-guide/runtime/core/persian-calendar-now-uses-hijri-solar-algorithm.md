### Persian calendar now uses the Hijri solar algorithm

#### Details

Starting with the .NET Framework 4.6, the <xref:System.Globalization.PersianCalendar?displayProperty=fullName> class uses the Hijri solar algorithm. Converting dates between the <xref:System.Globalization.PersianCalendar?displayProperty=fullName> and other calendars may produce a slightly different result beginning with the .NET Framework 4.6 for dates earlier than 1800 or later than 2023 (Gregorian).Also, <xref:System.Globalization.PersianCalendar.MinSupportedDateTime?displayProperty=nameWithType> is now `March 22, 0622` instead of `March 21, 0622`.

#### Suggestion

Be aware that some early or late dates may be slightly different when using the PersianCalendar in .NET Framework 4.6. Also, when serializing dates between processes which may run on different .NET Framework versions, do not store them as PersianCalendar date strings (since those values may be different).

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.6|
|Type|Runtime|

#### Affected APIs

- <xref:System.Globalization.PersianCalendar?displayProperty=nameWithType>

<!--

#### Affected APIs

- `T:System.Globalization.PersianCalendar`

-->
