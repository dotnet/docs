### DataObject.GetData now retrieves data as UTF-8

|   |   |
|---|---|
|Details|For apps that target the .NET Framework 4 or that run on the .NET Framework 4.5.1 or earlier versions, <code>DataObject.GetData</code> retrieves HTML-formatted data as an ASCII string. As a result, non-ASCII characters (characters whose ASCII codes are greater than 0x7F) are represented by two random characters.<p/>For apps that target the .NET Framework 4.5 or later and run on the .NET Framework 4.5.2, <code>DataObject.GetData</code> retrieves HTML-formatted data as UTF-8, which represents characters greater than 0x7F correctly.|
|Suggestion|If you implemented a workaround for the encoding problem with HTML-formatted strings (for example, by explicitly encoding the HTML string retrieved from the Clipboard by passing it to <xref:System.Text.UTF8Encoding.GetString(System.Byte[],System.Int32,System.Int32)?displayProperty=name>) and you're retargeting your app from version 4 to 4.5, that workaround should be removed.If the old behavior is needed for some reason, the app can target the .NET Framework 4.0 to get that behavior.|
|Scope|Edge|
|Version|4.5.2|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Windows.DataObject.GetData(System.String)?displayProperty=nameWithType></li><li><xref:System.Windows.DataObject.GetData(System.Type)?displayProperty=nameWithType></li><li><xref:System.Windows.DataObject.GetData(System.String,System.Boolean)?displayProperty=nameWithType></li></ul>|
