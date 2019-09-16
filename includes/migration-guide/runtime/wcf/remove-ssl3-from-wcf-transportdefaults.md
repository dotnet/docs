### Remove Ssl3 from the WCF TransportDefaults

|   |   |
|---|---|
|Details|When using NetTcp with transport security and a credential type of certificate, the SSL 3 protocol is no longer a default protocol used for negotiating a secure connection. In most cases there should be no impact to existing apps as TLS 1.0 has always been included in the protocol list for NetTcp. All existing clients should be able to negotiate a connection using at least TLS1.0.|
|Suggestion|If Ssl3 is required, use one of the following configuration mechanisms to add Ssl3 to the list of negotiated protocols.<ul><li><xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols></li><li><xref:System.ServiceModel.TcpTransportSecurity.SslProtocols></li><li>[<](~/docs/framework/configure-apps/file-schema/wcf/transport-of-nettcpbinding.md)</li><li>[&lt;sslStreamSecurity&gt; section of &lt;customBinding&gt;]~/docs/framework/configure-apps/file-schema/wcf/sslstreamsecurity.md)</li></ul>|
|Scope|Edge|
|Version|4.6.2|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols?displayProperty=nameWithType></li><li><xref:System.ServiceModel.TcpTransportSecurity.SslProtocols?displayProperty=nameWithType></li></ul>|
