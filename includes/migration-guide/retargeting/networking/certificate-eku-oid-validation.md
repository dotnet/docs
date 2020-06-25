### Certificate EKU OID validation

#### Details

Starting with .NET Framework 4.6, the <xref:System.Net.Security.SslStream> or <xref:System.Net.ServicePointManager> classes perform enhanced key use (EKU) object identifier (OID) validation. An enhanced key usage (EKU) extension is a collection of object identifiers (OIDs) that indicate the applications that use the key. EKU OID validation uses remote certificate callbacks to ensure that the remote certificate has the correct OIDs for the intended purpose.

#### Suggestion

If this change is undesirable, you can disable certificate EKU OID validation by adding the following switch to the [\<AppContextSwitchOverrides>](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) in the [`](~/docs/framework/configure-apps/file-schema/runtime/runtime-element.md) of your app configuration file:

<pre><code class="lang-xml">&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides&#13;&#10;value=&quot;Switch.System.Net.DontCheckCertificateEKUs=true&quot; /&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;`</pre>

 <blockquote> [!IMPORTANT] This setting is provided for backward compatibility only. Its use is otherwise not recommended.</blockquote> 

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.6         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Net.Security.SslStream?displayProperty=fullNameWithType>
- <xref:System.Net.ServicePointManager?displayProperty=fullNameWithType>
- <xref:System.Net.Http.HttpClient?displayProperty=fullNameWithType>
- <xref:System.Net.Mail.SmtpClient?displayProperty=fullNameWithType>
- <xref:System.Net.HttpWebRequest?displayProperty=fullNameWithType>
- <xref:System.Net.FtpWebRequest?displayProperty=fullNameWithType>

