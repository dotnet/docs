---
title: "&lt;ws2007HttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8586ecc9-bdaa-44d6-8d4d-7038e4ea1741
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;ws2007HttpBinding&gt;
Defines an interoperable binding that provides support for the correct versions of the <xref:System.ServiceModel.WSHttpBinding.Security%2A>, <xref:System.ServiceModel.ReliableSession>, and <xref:System.ServiceModel.WSHttpBindingBase.TransactionFlow%2A> binding elements.  
  
 \<system.serviceModel>  
\<bindings>  
\<ws2007HttpBinding>  
  
## Syntax  
  
```xml  
<ws2007HttpBinding>  
    <binding   
        allowCookies="Boolean"  
        bypassProxyOnLocal="Boolean"  
        closeTimeout="TimeSpan"  
        hostNameComparisonMode="StrongWildCard/Exact/WeakWildcard"  
        maxBufferPoolSize="integer"  
        maxReceivedMessageSize="Integer"  
        messageEncoding="Text/Mtom"   
                name="string"  
        openTimeout="TimeSpan"   
        proxyAddress="URI"  
        receiveTimeout="TimeSpan"  
        sendTimeout="TimeSpan"  
  
textEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding"  
        transactionFlow="Boolean"  
        useDefaultWebProxy="Boolean">  
        <reliableSession ordered="Boolean"  
           inactivityTimeout="TimeSpan"  
           enabled="Boolean" />  
        <security mode="Message/None/Transport/TransportWithCredential">  
           <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"  
                proxyCredentialType="Basic/Digest/None/Ntlm/Windows"  
                realm="string"   
                                />  
          <message clientCredentialType ="Certificate/IssuedToken/None/UserName/Windows"  
           negotiateServiceCredential="Boolean"  
           algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
           establishSecurityContext="Boolean"   
           negotiateServiceCredential="Boolean"/>  
        </security>  
       <readerQuotas             maxArrayLength="Integer"            maxBytesPerRead="Integer"            maxDepth="Integer"             maxNameTableCharCount="Integer"                     maxStringContentLength="Integer" />    </binding>  
</ws2007HttpBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`allowCookies`|A value that indicates whether the client accepts cookies and propagates them on future requests. The default is `false`.<br /><br /> You can use this property when you interact with ASP.NET Web services (ASMX) that use cookies. This ensures that cookies that the server returns are automatically copied to all future client requests for that service.|  
|`bypassProxyOnLocal`|A value that indicates whether to bypass the proxy server for local addresses. The default is `false`.|  
|`closeTimeout`|A <xref:System.TimeSpan> value that specifies the time interval for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`hostnameComparisonMode`|Specifies the HTTP hostname comparison mode used to parse Uniform Resource Identifiers (URIs). This attribute is of type <xref:System.ServiceModel.HostNameComparisonMode>, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is <xref:System.ServiceModel.HostNameComparisonMode.StrongWildcard>, which ignores the hostname in the match.|  
|`maxBufferPoolSize`|The maximum buffer pool size for this binding. The default is 524,288 bytes (512 × 1,024). Many parts of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] use buffers. Creating and destroying buffers each time they are used is expensive, as is garbage collection for buffers. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool when you are done. This avoids the overhead in creating and destroying buffers.|  
|`maxReceivedMessageSize`|The maximum message size, in bytes, including headers, which a channel configured with this binding, can receive. The sender of a message exceeding this limit receives a SOAP fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536.|  
|`messageEncoding`|Defines the encoder used to encode the message. Valid values include the following:<br /><br /> -   `Text`: Use a text message encoder.<br />-   `Mtom`: Use a Message Transmission Organization Mechanism 1.0 (MTOM) encoder.<br /><br /> The default is `Text`.<br /><br /> This attribute is of type <xref:System.ServiceModel.WSMessageEncoding>.|  
|`name`|The configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|`openTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`proxyAddress`|A URI that specifies the address of the HTTP proxy. If `useSystemWebProxy` is `true`, this setting must be `null`. The default is `null`.|  
|`receiveTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`sendTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`textEncoding`|Specifies the character set encoding to use for emitting messages on the binding. Valid values include the following:<br /><br /> -   `UnicodeFffeTextEncoding`: Unicode Big Endian encoding.<br />-   `Utf16TextEncoding`: 16-bit encoding.<br />-   `Utf8TextEncoding`: 8-bit encoding.<br /><br /> The default is `Utf8TextEncoding`.<br /><br /> This attribute is of type <xref:System.Text.Encoding>.|  
|`transactionFlow`|A value that specifies whether the binding supports flowing WS-Transactions. The default is `false`.|  
|`useDefaultWebProxy`|A value that specifies whether the system’s auto-configured HTTP proxy is used. The default is `true`.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-wshttpbinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.WSHttpSecurityElement>.|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that endpoints configured with this binding can process. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
|[reliableSession](http://msdn.microsoft.com/library/9c93818a-7dfa-43d5-b3a1-1aafccf3a00b)|Specifies whether reliable sessions are established between channel endpoints.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  
 The `WS2007HttpBinding` adds a system-provided binding similar to `WSHttpBinding` but uses the Organization for the Advancement of Structured Information Standards (OASIS) standard versions of the ReliableSession, Security, and TransactionFlow protocols. No changes to the object model or default settings are required when using this binding.  
  
## Example  
  
```xml  
<configuration>  
    <system.ServiceModel>  
        <bindings>  
            <ws2007HttpBinding>  
                <binding   
                    closeTimeout="00:00:10"  
                    openTimeout="00:00:20"   
                    receiveTimeout="00:00:30"  
                    sendTimeout="00:00:40"  
                    bypassProxyOnLocal="false"  
                    transactionFlow="false"   
                    hostNameComparisonMode="WeakWildcard"  
                    maxReceivedMessageSize="1000"  
                    messageEncoding="Mtom"   
                    proxyAddress="http://www.contoso.com"  
                    textEncoding="utf-16"  
                    useDefaultWebProxy="false">  
                    <reliableSession ordered="false"  
                         inactivityTimeout="00:02:00"  
                         enabled="true" />  
                    <security mode="Transport">  
                         <transport clientCredentialType="Digest"  
                            proxyCredentialType="None"  
                            realm="someRealm" />  
                         <message clientCredentialType="Windows"  
                            negotiateServiceCredential="false"  
                            algorithmSuite="Aes128"   
                            defaultProtectionLevel="None" />  
                    </security>  
                </binding>  
           </ws2007HttpBinding>  
        </bindings>  
    </system.ServiceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.WS2007HttpBinding>  
 <xref:System.ServiceModel.Configuration.WS2007HttpBindingElement>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
