### Default value of ServicePointManager.SecurityProtocol is SecurityProtocolType.System.Default

|   |   |
|---|---|
|Details|Starting with apps that target the .NET Framework 4.7, the default value of the <xref:System.Net.ServicePointManager.SecurityProtocol?displayProperty=fullName> property is <xref:System.Net.SecurityProtocolType.SystemDefault?displayProperty=fullName>. This change allows .NET Framework networking APIs based on SslStream (such as FTP, HTTPS, and SMTP) to inherit the default security protocols from the operating system instead of using hard-coded values defined by the .NET Framework. The default varies by operating system and any custom configuration performed by the system administrator. For information on the default SChannel protocol in each version of the Windows operating system, see <a href="https://msdn.microsoft.com/library/windows/desktop/mt808159.aspx">Protocols in TLS/SSL (Schannel SSP)</a>.For applications that target an earlier version of the .NET Framework, the default value of the <xref:System.Net.ServicePointManager.SecurityProtocol?displayProperty=fullName> property depends on the version of the .NET Framework targeted. See <a href="../../../../framework/migration-guide/retargeting/index.md">Retargeting Changes in the .NET Framework 4.6</a> for more information.|
|Suggestion|This change affects applications that target the .NET Framework 4.7 or later versions.If you prefer to use a defined protocol rather than relying on the system default, you can explicitly set the value of the  <xref:System.Net.ServicePointManager.SecurityProtocol?displayProperty=fullName> property.|
|Scope|Minor|
|Version|4.7|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Net.ServicePointManager.SecurityProtocol?displayProperty=fullName></li></ul>|

