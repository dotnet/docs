### WCF services that use NETTCP with SSL sercurity and MD5 certificate authentication

|   |   |
|---|---|
|Details|The .NET Framework 4.6 adds TLS 1.1 and TLS 1.2 to the WCF SSL default protocol list. When both client and server machines have the .NET Framework 4.6 or later installed, TLS 1.2 is used for negotiation.TLS 1.2 does not support MD5 certificate authentication. As a result, if a customer uses an MD5 certificate, the WCF client will fail to connect to the WCF service.<ul><li>[ ] Quirked // Uses some mechanism to turn the feature on or off, usually using runtime targeting, AppContext or config files. Needs to be turned on automatically for some situations.</li><li>[ ] Build-time break // Causes a break if attempted to recompile</li></ul>|
|Suggestion|You can work around this issue so that a WCF client can connect to a WCF server by doing any of the following:<ul><li>Update the certificate to not use the MD5 algorithm. This is the recommended solution.</li><li>If the binding is not dynamically configured in source code, update the application&#39;s configuration file to use TLS 1.1 or an earlier version of the protocol. This allows you to continue to use a certificate with the MD5 hash algorithm.</li></ul>
<blockquote>
[!WARNING] This workaround is not recommended, since a certificate with the MD5 hash algorithm is considered insecure.</blockquote>
The following configuration file does this:<pre><code>&lt;configuration&gt;<br />&lt;system.serviceModel&gt;<br />&lt;bindings&gt;<br />&lt;netTcpBinding&gt;<br />&lt;binding&gt;<br />&lt;security mode= &quot;None|Transport|Message|TransportWithMessageCredential&quot; &gt;<br />&lt;transport clientCredentialType=&quot;None|Windows|Certificate&quot;<br />protectionLevel=&quot;None|Sign|EncryptAndSign&quot;<br />sslProtocols=&quot;Ssl3|Tls1|Tls11&quot;&gt;<br />&lt;/transport&gt;<br />&lt;/security&gt;<br />&lt;/binding&gt;<br />&lt;/netTcpBinding&gt;<br />&lt;/bindings&gt;<br />&lt;/system.ServiceModel&gt;<br />&lt;/configuration&gt;</code></pre><ul><li>If the binding is dynamically configured in source code, update the <xref:System.ServiceModel.TcpTransportSecurity.SslProtocols?displayProperty=nameWithType> property to use TLS 1.1 (<xref:System.Security.Authentication.SslProtocols.Tls11?displayProperty=nameWithType> or an earlier version of the protocol in the source code.</li></ul>
<blockquote>
[!WARNING] This workaround is not recommended, since a certificate with the MD5 hash algorithm is considered insecure.</blockquote>|
|Scope|Unknown|
|Version|4.6|
|Type|Runtime|

