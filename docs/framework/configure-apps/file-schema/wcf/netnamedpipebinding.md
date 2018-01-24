---
title: "&lt;netNamedPipeBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 00a8580b-face-47a4-838d-b9fed48e72df
caps.latest.revision: 29
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;netNamedPipeBinding&gt;
Defines a binding that is secure, reliable, optimized for on-machine cross process communication. By default, it generates a runtime communication stack with WS-ReliableMessaging for reliability, transport security for transfer security, named pipes for message delivery, and binary message encoding.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netNamedPipeBinding>  
  
## Syntax  
  
```xml  
<netNamedPipeBinding>  
   <binding   
      closeTimeout="TimeSpan"  
      hostNameComparisonMode="StrongWildCard/Exact/WeakWildcard"  
      maxBufferPoolSize="Integer"  
      maxBufferSize="Integer"  
      maxConnections="Integer"   
      maxReceivedMessageSize="Integer"  
            name="string"  
      openTimeout="TimeSpan"   
      receiveTimeout="TimeSpan"  
      sendTimeout="TimeSpan"  
      transactionFlow="Boolean"  
      transactionProtocol="OleTransactions/WS-AtomicTransactionOctober2004"  
            transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse"  
      <security mode="None/Transport">  
            <transport  protectionLevel="None/Sign/EncryptAndSign" />  
      </security>  
       <readerQuotas             maxArrayLength="Integer"            maxBytesPerRead="Integer"            maxDepth="Integer"             maxNameTableCharCount="Integer"                     maxStringContentLength="Integer" />   </binding>  
</netNamedPipeBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|closeTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|hostnameComparisonMode|Specifies the HTTP hostname comparison mode used to parse URIs. This attribute is of type `System.ServiceModel.HostnameComparisonMode`, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is `StrongWildcard`, which ignores the hostname in the match.|  
|maxBufferPoolSize|An integer that specifies the maximum buffer pool size for this binding. The default is 524,288 bytes (512 * 1024). Many parts of Windows Communication Foundation (WCF) use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|  
|maxBufferSize|A positive integer that specifies the maximum size, in bytes, of the buffer used to store messages in memory. If the buffer is full, excess data remains in the underlying socket until the buffer has room again. This value cannot be less than `maxReceivedMessageSize` attribute. The default is 65536. For more information, see <xref:System.ServiceModel.Configuration.NetNamedPipeBindingElement.MaxBufferSize%2A>.|  
|maxConnections|An integer that specifies the maximum number of outbound and inbound connections the service will create/accept. Incoming and outgoing connections are counted against a separate limit specified by this attribute.<br /><br /> Inbound connections in excess of the limit are queued until a space below the limit becomes available.<br /><br /> Outbound connections in excess of the limit are queued until a space below the limit becomes available.<br /><br /> The default is 10.|  
|maxReceivedMessageSize|A positive integer that specifies the maximum message size, in bytes, including headers, that can be received on a channel configured with this binding. The sender of a message exceeding this limit will receive a SOAP fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536.|  
|name|A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|openTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|receiveTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|  
|sendTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|transactionFlow|A Boolean value that specifies whether the binding supports flowing WS-Transactions. The default is `false`.|  
|transactionProtocol|Specifies the transaction protocol to be used with this binding. Valid values are<br /><br /> -   OleTransactions<br />-   WS-AtomicTransactionOctober2004<br /><br /> The default is OleTransactions. This attribute is of type <xref:System.ServiceModel.TransactionProtocol>.|  
|transferMode|A <xref:System.ServiceModel.TransferMode> value that specifies whether messages are buffered or streamed or a request or response.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-netnamedpipebinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.NetNamedPipeBindingElement>.|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  
 The `NetNamedPipeBinding` generates a run-time communication stack by default, which uses transport security, named pipes for message delivery, and a binary message encoding. This binding is an appropriate Windows Communication Foundation (WCF) system-provided choice for on-machine communication. It also supports transactions.  
  
 The default configuration for the `NetNamedPipeBinding` is similar to the configuration provided by the `NetTcpBinding`, but it is simpler because the WCF implementation is only meant for on-machine use and consequently there are fewer exposed features. The most notable difference is that the `securityMode` setting only offers the `None` and `Transport` options. SOAP security support is not an included option. The security behavior is configurable using the optional `securityMode` attribute.  
  
## Example  
 The following example demonstrates the netNamedPipeBinding binding, which provides cross-process communication on the same machine. Named pipes do not work across machines.  
  
 The binding is specified in the configuration files for the client and service. The binding type is specified in the `binding` attribute of the `<endpoint>` element. If you want to configure the netNamedPipeBinding binding and change some of its settings, you must define a binding configuration. The endpoint must reference the binding configuration by name with a `bindingConfiguration` attribute. In this example, the binding configuration is named Binding1.  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service name="Microsoft.ServiceModel.Samples.CalculatorService"  
               behaviorConfiguration="CalculatorServiceBehavior">  
        <host>  
          <baseAddresses>  
            <add baseAddress="http://localhost:8000/ServiceModelSamples/service"/>  
          </baseAddresses>  
        </host>  
        <!-- this endpoint is exposed at the base address provided by host: net.pipe://localhost/ServiceModelSamples/service  -->  
        <endpoint address="net.pipe://localhost/ServiceModelSamples/service"  
                  binding="netNamedPipeBinding"  
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />  
        <!-- the mex endpoint is exposed at http://localhost:8000/ServiceModelSamples/service/mex -->  
        <endpoint address="mex"  
                  binding="mexHttpBinding"  
                  contract="IMetadataExchange" />  
      </service>  
    </services>  
  
    <bindings>  
      <netNamedPipeBinding>  
        <binding   
                 closeTimeout="00:01:00"  
                 openTimeout="00:01:00"   
                 receiveTimeout="00:10:00"   
                 sendTimeout="00:01:00"  
                 transactionFlow="false"   
                 transferMode="Buffered"   
                 transactionProtocol="OleTransactions"  
                 hostNameComparisonMode="StrongWildcard"   
                 maxBufferPoolSize="524288"  
                 maxBufferSize="65536"   
                 maxConnections="10"   
                 maxReceivedMessageSize="65536">  
          <security mode="Transport">  
            <transport protectionLevel="EncryptAndSign" />  
          </security>  
        </binding>  
      </netNamedPipeBinding>  
    </bindings>  
  
    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="CalculatorServiceBehavior">  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="False" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.NetNamedPipeBindingElement>  
 <xref:System.ServiceModel.NetNamedPipeBinding>  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)
