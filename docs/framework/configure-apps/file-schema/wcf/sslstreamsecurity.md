---
description: "Learn more about: <sslStreamSecurity>"
title: "<sslStreamSecurity>"
ms.date: "03/30/2017"
ms.assetid: 430a378b-a742-4858-8a12-9f9b235fd627
---
# `<sslStreamSecurity>`

Represents a custom binding element that supports channel security using an SSL stream.

[`<configuration>`](../configuration-element.md)\
&nbsp;&nbsp;[`<system.serviceModel>`](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[`<bindings>`](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[`<customBinding>`](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`<binding>`\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`<sslStreamSecurity>`

## Syntax

```xml
<sslStreamSecurity requireClientCertificate="Boolean"
                   sslProtocols="Ssl3|Tls|Tls11|Tls12" />
```

> [!IMPORTANT]
> The syntax shows the full historical enum surface for the `sslProtocols` attribute. For new configurations, don't enable `Ssl3`, `Tls`, or `Tls11`. Prefer OS defaults, or limit the configuration to modern TLS versions supported by your target platform. For more information, see [Transport Layer Security (TLS) best practices with the .NET Framework](../../../network-programming/tls.md).

## Attributes and Elements

 The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|requireClientCertificate|A Boolean value that specifies if a client certificate is required for this binding. The default is `false`.|
|sslProtocols|A SslProtocols enum flag value that specifies which SslProtocols are supported. The default is Ssl3&#124;Tls&#124;Tls11&#124;Tls12. This historical default exists for compatibility and isn't recommended for new configurations.|

### Child Elements

 None.

### Parent Elements

|Element|Description|
|-------------|-----------------|
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|

## See also

- <xref:System.ServiceModel.Configuration.SslStreamSecurityElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement>
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
