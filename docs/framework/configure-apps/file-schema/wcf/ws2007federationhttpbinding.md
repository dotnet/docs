---
description: "Learn more about: <ws2007FederationHttpBinding>"
title: "<ws2007FederationHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 9af4ec79-cdef-457e-9dca-09d5eb821594
---

# \<ws2007FederationHttpBinding>

A secure and interoperable binding that derives from [\<wsFederationHttpBinding>](wsfederationhttpbinding.md) and supports federated security.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<ws2007FederationHttpBinding>**  
  
## Syntax

```xml
<ws2007FederationHttpBinding>
  <binding bypassProxyOnLocal="Boolean"
           closeTimeout="TimeSpan"
           hostNameComparisonMode="StrongWildcard/Exact/WeakWildcard"
           maxBufferPoolSize="integer"
           maxReceivedMessageSize="integer"
           messageEncoding="Text/Mtom"
           name="string"
           openTimeout="TimeSpan"
           privacyNoticeAt="Uri"
           privacyNoticeVersion="Integer"
           proxyAddress="Uri"
           receiveTimeout="TimeSpan"
           sendTimeout="TimeSpan"
           textEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding"
           transactionFlow="Boolean"
           useDefaultWebProxy="Boolean">
    <security mode="None/Message/TransportWithMessageCredential">
      <message negotiateServiceCredential="Boolean"
               algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
               issuedTokenType="string"
               issuedKeyType="SymmetricKey/PublicKey">
      </message>
    </security>
    <reliableSession ordered="Boolean"
                     inactivityTimeout="TimeSpan"
                     enabled="Boolean" />
    <readerQuotas maxArrayLength="Integer"
                  maxBytesPerRead="Integer"
                  maxDepth="Integer"
                  maxNameTableCharCount="Integer"
                  maxStringContentLength="Integer" />
  </binding>
</ws2007FederationHttpBinding>
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`bypassProxyOnLocal`|A value that indicates whether to bypass the proxy server for local addresses. The default is `false`.|
|`closeTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|
|`hostNameComparisonMode`|Specifies the HTTP hostname comparison mode used to parse URIs. This attribute is of type <xref:System.ServiceModel.HostNameComparisonMode>, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is <xref:System.ServiceModel.HostNameComparisonMode.StrongWildcard>, which ignores the hostname in the match.|
|`maxBufferPoolSize`|The maximum buffer pool size for this binding. The default is 524,288 bytes (512 * 1024). Many parts of Windows Communication Foundation (WCF) use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|
|`maxReceivedMessageSize`|The maximum message size, in bytes, including headers, that can be received on a channel configured with this binding. The sender of a message that exceeds this limit receives a SOAP fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536.|
|`messageEncoding`|Defines the encoder used to encode the message. Valid values include the following:<br /><br /> -   Text: Use a text message encoder.<br />-   Mtom: Use a Message Transmission Organization Mechanism 1.0 (MTOM) encoder.<br /><br /> The default is Text.<br /><br /> This attribute is of type <xref:System.ServiceModel.WSMessageEncoding>.|
|`name`|The configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with .NET Framework 4, bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../wcf/samples/simplified-configuration-for-wcf-services.md).|
|`openTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|
|`privacyNoticeAt`|A URI at which the privacy notice is located.|
|`privacyNoticeVersion`|The version of the current privacy notice.|
|`proxyAddress`|A URI that specifies the address of the HTTP proxy. If `useDefaultWebProxy` is `true`, this setting must be `null`. The default is `null`.|
|`receiveTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|
|`sendTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|
|`textEncoding`|Sets the character set encoding to be used for emitting messages on the binding. Valid values include the following:<br /><br /> -   BigEndianUnicode: Unicode Big Endian encoding.<br />-   Unicode: 16-bit encoding.<br />-   UTF8: 8-bit encoding.<br /><br /> The default is UTF8. This attribute is of type <xref:System.Text.Encoding>.|
|`transactionFlow`|A value that specifies whether the binding supports flowing WS-Transactions. The default is `false`.|
|`useDefaultWebProxy`|A value that indicates whether the system’s auto-configured HTTP proxy is used. The proxy address must be `null` (that is, not set) if this attribute is `true`. The default is `true`.|

### Child Elements

|Element|Description|
|-------------|-----------------|
|[\<security>](security-of-wsfederationhttpbinding.md)|Defines the security settings for the message. This element is of type <xref:System.ServiceModel.Configuration.WSFederationHttpSecurityElement>.|
|[\<readerQuotas>](/previous-versions/dotnet/netframework-4.0/ms731325(v=vs.100))|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|
|[\<reliableSession>](/previous-versions/ms731375(v=vs.90))|Specifies whether reliable sessions are established between channel endpoints.|

### Parent Elements

|Element|Description|
|-------------|-----------------|
|[\<bindings>](bindings.md)|This element holds a collection of standard and custom bindings.|

## Remarks

Federation is the ability to share identities across multiple enterprises or trust domains for authentication and authorization. It uses the WS-Trust protocol to map the identity representation from one trust domain to another. Federated HTTP binding supports SOAP security as well as mixed-mode security, but it does not support transport security. Services configured with this binding must use the HTTP transport. For more information, see [\<wsFederationHttpBinding>](wsfederationhttpbinding.md).

## Example

```xml
<configuration>
  <system.ServiceModel>
    <bindings>
      <ws2007FederationHttpBinding>
        <binding bypassProxyOnLocal="false"
                 transactionFlow="false"
                 hostNameComparisonMode="WeakWildcard"
                 maxReceivedMessageSize="1000"
                 messageEncoding="Mtom"
                 proxyAddress="http://www.contoso.com"
                 textEncoding="Utf16TextEncoding"
                 useDefaultWebProxy="false">
          <reliableSession ordered="false"
                           inactivityTimeout="00:02:00"
                           enabled="true" />
          <security mode="None">
            <message negotiateServiceCredential="false"
                     algorithmSuite="Aes128"
                     issuedTokenType="http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1"
                     issuedKeyType="PublicKey">
              <issuer address="http://localhost/Sts" />
            </message>
          </security>
        </binding>
      </ws2007FederationBinding>
    </bindings>
  </system.ServiceModel>
</configuration>
```

## See also

- <xref:System.ServiceModel.WS2007FederationHttpBinding>
- <xref:System.ServiceModel.Configuration.WS2007FederationHttpBindingElement>
- [\<wsFederationHttpBinding>](wsfederationhttpbinding.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
