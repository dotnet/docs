### Only Tls 1.0, 1.1 and 1.2 protocols supported in System.Net.ServicePointManager and System.Net.Security.SslStream

#### Details

Starting with the .NET Framework 4.6, the <xref:System.Net.ServicePointManager> and <xref:System.Net.Security.SslStream> classes are only allowed to use one of the following three protocols: Tls1.0, Tls1.1, or Tls1.2. The SSL3.0 protocol and RC4 cipher are not supported.

#### Suggestion

The recommended mitigation is to upgrade the sever-side app to Tls1.0, Tls1.1, or Tls1.2. If this is not feasible, or if client apps are broken, the <xref:System.AppContext?displayProperty=fullName> class can be used to opt out of this feature in either of two ways:<ol><li>By programmatically setting compat switches on the <xref:System.AppContext?displayProperty=fullName>, as explained [here](https://devblogs.microsoft.com/dotnet/net-announcements-at-build-2015/#dotnet46).
- By adding the following line to the `<runtime>` section of the app.config file:</li></ol><pre><code class="lang-xml">&lt;AppContextSwitchOverrides value=&quot;Switch.System.Net.DontEnableSchUseStrongCrypto=true&quot;/&gt;&#13;&#10;`</pre>



| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.6         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Net.SecurityProtocolType.Ssl3?displayProperty=fullNameWithType>
- <xref:System.Security.Authentication.SslProtocols.None?displayProperty=fullNameWithType>
- <xref:System.Security.Authentication.SslProtocols.Ssl2?displayProperty=fullNameWithType>
- <xref:System.Security.Authentication.SslProtocols.Ssl3?displayProperty=fullNameWithType>

