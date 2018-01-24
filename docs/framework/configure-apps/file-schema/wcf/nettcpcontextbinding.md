---
title: "&lt;netTcpContextBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1d4715e1-5fff-4c3d-a226-18f21d0b30c4
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;netTcpContextBinding&gt;
Specifies a context for the <xref:System.ServiceModel.NetTcpBinding> that requires that the protection level be signed. The contextExchangeMechanism for NetTcpContextBinding is SOAPHeader.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netTcpContextBinding>  
  
## Syntax  
  
```xml  
<netTcpContextBinding>  
   <binding   
      closeTimeout="TimeSpan"  
            contextProtectionLevel="EncryptAndSign/None/Sign"  
      hostNameComparisonMode="StrongWildCard/Exact/WeakWildcard"  
      listenBacklog="Integer"  
      maxBufferPoolSize="integer"  
      maxBufferSize="Integer"  
      maxConnections="Integer"   
      maxReceivedMessageSize="Integer"  
            name="string"  
      openTimeout="TimeSpan"  
      portSharingEnabled="Boolean"  
      receiveTimeout="TimeSpan"  
      sendTimeout="TimeSpan"  
      transactionFlow="Boolean"   
      transactionProtocol="OleTransactions/WSAtomicTransactionOctober2004"   
            transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse"  
  
      <reliableSession ordered="Boolean"  
            inactivityTimeout="TimeSpan"  
            enabled="Boolean" />  
      <security mode="Message/None/Transport/TransportWithCredential">  
           <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"  
                proxyCredentialType="Basic/Digest/None/Ntlm/Windows"  
                realm="string"   
                defaultClientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"  
                defaultProxyCredentialType="Basic/Digest/None/Ntlm/Windows"  
                defaultRealm="string" />  
          <message clientCredentialType="Certificate/IssuedToken/None/UserName/Windows"  
           algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
           establishSecurityContext="Boolean"   
           negotiateServiceCredential="Boolean"/>  
       </security>  
       <readerQuotas             maxArrayLength="Integer"            maxBytesPerRead="Integer"            maxDepth="Integer"             maxNameTableCharCount="Integer"                     maxStringContentLength="Integer" />   </binding>  
</netTcpContextBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|closeTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|contextProtectionLevel|A valid <xref:System.Net.Security.ProtectionLevel> value that specifies the desired protection level of the SOAP header used to propagate the context information.  The default value is `Sign`.|  
|hostnameComparisonMode|Specifies the HTTP hostname comparison mode used to parse URIs. This attribute is of type `System.ServiceModel.HostnameComparisonMode`, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is `StrongWildcard`, which ignores the hostname in the match.|  
|listenBacklog|A positive integer that specifies the maximum number of channels waiting to be accepted on the listener. Connections in excess of this limit are queued until space below the limit becomes available. The `connectionTimeout` attribute limits the time a client will wait to be connected before throwing a connection exception. The default is 10.|  
|maxBufferPoolSize|An integer that specifies the maximum buffer pool size for this binding. The default is 512 * 1024 bytes. Many parts of Windows Communication Foundation (WCF) use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|  
|maxBufferSize|A positive integer that specifies the maximum size, in bytes, of the buffer used to store messages in memory. If the buffer is full, excess data remains in the underlying socket until the buffer has room again. This value cannot be less than `maxReceivedMessageSize` attribute. The default is 65536. For more information, see <xref:System.ServiceModel.Configuration.NetNamedPipeBindingElement.MaxBufferSize%2A>.|  
|maxConnections|An integer that specifies the maximum number of outbound and inbound connections the service will create/accept. Incoming and outgoing connections are counted against a separate limit specified by this attribute.<br /><br /> Inbound connections in excess of the limit are queued until a space below the limit becomes available.<br /><br /> Outbound connections in excess of the limit are queued until a space below the limit becomes available.<br /><br /> The default is 10.|  
|maxReceivedMessageSize|A positive integer that specifies the maximum message size, in bytes, including headers, that can be received on a channel configured with this binding. The sender of a message exceeding this limit will receive a SOAP fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536.|  
|name|A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|openTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|portSharingEnabled|A Boolean value that specifies whether TCP port sharing is enabled for this connection. If this is `false`, each binding uses its own exclusive port. This setting is relevant only to services, because clients are not affected.|  
|receiveTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|  
|sendTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|transactionFlow|A Boolean value that specifies whether the binding supports flowing WS-Transactions. The default is `false`.|  
|transactionProtocol|Specifies the transaction protocol to be used with this binding. Valid values are<br /><br /> -   OleTransactions<br />-   WSAtomicTransactionOctober2004<br /><br /> The default is OleTransactions. This attribute is of type <xref:System.ServiceModel.TransactionProtocol>.|  
|transferMode|A <xref:System.ServiceModel.TransferMode> value that specifies whether messages are buffered or streamed or a request or response.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-nettcpbinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.NetTcpSecurityElement>.|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
|[reliableSession](http://msdn.microsoft.com/library/9c93818a-7dfa-43d5-b3a1-1aafccf3a00b)|Specifies if reliable sessions are established between channel endpoints.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## See Also  
 <xref:System.ServiceModel.NetTcpBinding>  
 <xref:System.ServiceModel.NetTcpContextBinding>  
 <xref:System.ServiceModel.Configuration.NetTcpContextBindingElement>  
 <xref:System.ServiceModel.Channels.ContextBindingElement>  
 [\<netTcpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
