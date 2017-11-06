### Deserialization of MailMessage objects serialized under the .NET Framework 4.5 may fail

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.5, <code>T:System.Web.Mail.MailMessage</code> objects can include non-ASCII characters. In the .NET Framework 4, only ASCII characters are supported. <code>T:System.Web.Mail.MailMessage</code> objects that contain non-ASCII characters and that are serialized under the .NET Framework 4.5 or later cannot be deserialized under the .NET Framework 4.|
|Suggestion|Ensure that your code provides exception handling when deserializing a <code>T:System.Web.Mail.MailMessage</code> object.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Web.Mail.MailMessage?displayProperty=nameWithType></li></ul>|

