### WCF binding with the TransportWithMessageCredential security mode

|   |   |
|---|---|
|Details|Beginning in the .NET Framework 4.6.1, WCF binding that uses the TransportWithMessageCredential security mode can be setup to receive messages with unsigned &quot;to&quot; headers for asymmetric security keys.By default, unsigned &quot;to&quot; headers will continue to be rejected in .NET 4.6.1. They will only be accepted if an application opts into this new mode of operation using the Switch.System.ServiceModel.AllowUnsignedToHeader configuration switch.Because this is an opt-in feature, it should not affect the behavior of existing apps.|
|Suggestion|Because this is an opt-in feature, it should not affect the behavior of existing apps. To control whether the new behavior is used or not, use the following configuration setting:<pre><code>&lt;runtime&gt;<br />&lt;AppContextSwitchOverrides value=&quot;Switch.System.ServiceModel.AllowUnsignedToHeader=true&quot; /&gt;<br />&lt;/runtime&gt;</code></pre>|
|Scope|Transparent|
|Version|4.6.1|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.ServiceModel.BasicHttpSecurityMode.TransportWithMessageCredential?displayProperty=fullName></li><li><xref:System.ServiceModel.BasicHttpsSecurityMode.TransportWithMessageCredential?displayProperty=fullName></li><li><xref:System.ServiceModel.SecurityMode.TransportWithMessageCredential?displayProperty=fullName></li><li><xref:System.ServiceModel.WSFederationHttpSecurityMode.TransportWithMessageCredential?displayProperty=fullName></li></ul>|

