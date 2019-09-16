### Unicode standard version 8.0 categories now supported

|   |   |
|---|---|
|Details|In .NET Framework 4.6.2, Unicode data has been upgraded from Unicode Standard version 6.3 to version 8.0.  When requesting Unicode character categories in .NET Framework 4.6.2, some results might not match the results in previous .NET Framework versions.  This change mostly affects Cherokee syllables and New Tai Lue vowels signs and tone marks.|
|Suggestion|Review code and remove/change logic that depends on hard-coded Unicode character categories.|
|Scope|Minor|
|Version|4.6.2|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Char.GetUnicodeCategory(System.Char)?displayProperty=nameWithType></li><li><xref:System.Globalization.CharUnicodeInfo.GetUnicodeCategory(System.Char)?displayProperty=nameWithType></li><li><xref:System.Globalization.CharUnicodeInfo.GetUnicodeCategory(System.String,System.Int32)?displayProperty=nameWithType></li></ul>|
