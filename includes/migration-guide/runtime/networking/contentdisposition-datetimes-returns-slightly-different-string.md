### ContentDisposition DateTimes returns slightly different string

|   |   |
|---|---|
|Details|String representations of <xref:System.Net.Mime.ContentDisposition?displayProperty=name>'s have been updated, beginning in 4.6, to always represent the hour component of a <xref:System.DateTime?displayProperty=name> with two digits. This is to comply with [RFC822](https://www.ietf.org/rfc/rfc0822.txt) and [RFC2822](https://www.ietf.org/rfc/rfc2822.txt). This causes <xref:System.Net.Mime.ContentDisposition.ToString> to return a slightly different string in 4.6 in scenarios where one of the disposition's time elements was before 10:00 AM. Note that ContentDispositions are sometimes serialized via converting them to strings, so any <xref:System.Net.Mime.ContentDisposition.ToString> operations, serialization, or GetHashCode calls should be reviewed.|
|Suggestion|Do not expect that string representations of ContentDispositions from different .NET Framework versions will correctly compare to one another. Convert the strings back to ContentDispositions, if possible, before conducting a comparison.|
|Scope|Minor|
|Version|4.6|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Net.Mime.ContentDisposition.ToString?displayProperty=nameWithType></li><li><xref:System.Net.Mime.ContentDisposition.GetHashCode?displayProperty=nameWithType></li></ul>|
