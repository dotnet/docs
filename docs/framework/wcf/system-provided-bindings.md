---
title: "System-Provided Bindings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "bindings [WCF], system-provided"
ms.assetid: 2c243746-45ce-4588-995e-c17126a579a6
caps.latest.revision: 60
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System-Provided Bindings
Bindings specify the communication mechanism to use when talking to an endpoint and indicate how to connect to an endpoint. A binding contains the following elements:  
  
-   The protocol stack determines the security, reliability, and context flow settings to use for messages that are sent to the endpoint.  
  
-   The transport determines the underlying transport protocol to use when sending messages to the endpoint, for example, TCP or HTTP.  
  
-   The encoding determines the wire encoding to use for messages that are sent to the endpoint, for example, text/XML, binary, or Message Transmission Optimization Mechanism (MTOM).  
  
 This topic presents all of the system-provided [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] bindings. If none of these meets the exact criteria for your application, you can create a custom binding. [!INCLUDE[crabout](../../../includes/crabout-md.md)] creating custom bindings, see [Custom Bindings](../../../docs/framework/wcf/extending/custom-bindings.md).  
  
 A secure and interoperable binding that supports the WS-Federation protocol enables organizations that are in a federation to efficiently authenticate and authorize users.  
  
> [!IMPORTANT]
>  Always select a binding that includes security. By default, all bindings except the [\<basicHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md) element have security enabled. If you do not select a secure binding or disable security, be sure to protect your data in some other manner, such as storing in a secured data center or on an isolated network.  
  
> [!IMPORTANT]
>  Never use duplex contracts with bindings that do not support security or that have security disabled unless you secure the data by some other means.  
  
## System-Provided Bindings  
 The following bindings ship with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)].  
  
|Binding|Configuration Element|Description|  
|-------------|---------------------------|-----------------|  
|<xref:System.ServiceModel.BasicHttpBinding>|[\<basicHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md)|A binding that is suitable for communicating with WS-Basic Profile conformant Web services, for example, ASP.NET Web services (ASMX)-based services. This binding uses HTTP as the transport and text/XML as the default message encoding.|  
|<xref:System.ServiceModel.WSHttpBinding>|[\<wsHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md)|A secure and interoperable binding that is suitable for non-duplex service contracts.|  
|<xref:System.ServiceModel.WSDualHttpBinding>|[\<wsDualHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wsdualhttpbinding.md)|A secure and interoperable binding that is suitable for duplex service contracts or communication through SOAP intermediaries.|  
|<xref:System.ServiceModel.WSFederationHttpBinding>|[\<wsFederationHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wsfederationhttpbinding.md)|A secure and interoperable binding that supports the WS-Federation protocol that enables organizations that are in a federation to efficiently authenticate and authorize users.|  
|<xref:System.ServiceModel.NetHttpBinding>|\<netHttpBinding>|A binding designed for consuming HTTP or WebSocket services that uses binary encoding by default.|  
|<xref:System.ServiceModel.NetHttpsBinding>|\<netHttpsBinding>|A secure binding designed for consuming HTTP or WebSocket services that uses binary encoding by default.|  
|<xref:System.ServiceModel.NetTcpBinding>|[\<netTcpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md)|A secure and optimized binding suitable for cross-machine communication between [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications.|  
|<xref:System.ServiceModel.NetNamedPipeBinding>|[\<netNamedPipeBinding>](../../../docs/framework/configure-apps/file-schema/wcf/netnamedpipebinding.md)|A secure, reliable, optimized binding that is suitable for on-machine communication between [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications.|  
|<xref:System.ServiceModel.NetMsmqBinding>|[\<netMsmqBinding>](../../../docs/framework/configure-apps/file-schema/wcf/netmsmqbinding.md)|A queued binding that is suitable for cross-machine communication between [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications.|  
|<xref:System.ServiceModel.NetPeerTcpBinding>|[\<netPeerTcpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/netpeertcpbinding.md)|A binding that enables secure, multiple machine communication.|  
|<xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>|[\<msmqIntegrationBinding>](../../../docs/framework/configure-apps/file-schema/wcf/msmqintegrationbinding.md)|A binding that is suitable for cross-machine communication between a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] application and existing Message Queuing applications.|  
|<xref:System.ServiceModel.BasicHttpContextBinding>|[\<basicHttpContextBinding>](../../../docs/framework/configure-apps/file-schema/wcf/basichttpcontextbinding.md)|A binding that is suitable for communicating with WS-Basic Profile conformant Web services that enables HTTP cookies to be used to exchange context.|  
|<xref:System.ServiceModel.NetTcpContextBinding>|[\<netTcpContextBinding>](../../../docs/framework/configure-apps/file-schema/wcf/nettcpcontextbinding.md)|A secure and optimized binding suitable for cross-machine communication between [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications that enables SOAP headers to be used to exchange context.|  
|<xref:System.ServiceModel.WebHttpBinding>|[\<webHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/webhttpbinding.md)|A binding used to configure endpoints for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Web services that are exposed through HTTP requests instead of SOAP messages.|  
|<xref:System.ServiceModel.WSHttpContextBinding>|[\<wsHttpContextBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wshttpcontextbinding.md)|A secure and |<xref:System.ServiceModel.UdpBinding>|\<udpBinding>|A binding to use when sending a burst of simple messages to a large number of clients simultaneously.|  
  
 The following table shows the features of each of the system-provided bindings. The bindings are found in the table columns; the features are listed in the rows and described in a second table. The following table provides a key for the binding abbreviations used. To select a binding, determine which column satisfies all of the row features you need.  
  
|Binding|Interoperability|Security (Default)|Session<br /><br /> (Default)|Transactions|Duplex|Encoding (Default)|Streaming<br /><br /> (Default)|  
|-------------|----------------------|--------------------------|-----------------------------|------------------|------------|--------------------------|-------------------------------|  
|<xref:System.ServiceModel.BasicHttpBinding>|Basic Profile 1.1|(None), Transport, Message, Mixed|(None)|(None)|n/a|Text, (MTOM)|Yes<br /><br /> (buffered)|  
|<xref:System.ServiceModel.WSHttpBinding>|WS|Transport, (Message), Mixed|(None), Reliable Session, Security Session|(None), Yes|n/a|(Text), MTOM|No|  
|<xref:System.ServiceModel.WSDualHttpBinding>|WS|(Message), None|(Reliable Session), Security Session|(None), Yes|Yes|(Text), MTOM|No|  
|<xref:System.ServiceModel.WSFederationHttpBinding>|WS-Federation|(Message), Mixed, None|(None), Reliable Session, Security Session|(None), Yes|No|(Text), MTOM|No|  
|<xref:System.ServiceModel.NetHttpBinding>|.NET|(None), Transport, Message, TransportWithMessageCredential, TransportCredentialOnly|See note below|None|See note below|(Binary), Text,MTOM|Yes (buffered)|  
|<xref:System.ServiceModel.NetHttpsBinding>|.NET|(Transport), TransportWithMessageCredential|See note below|None|See note below|(Binary), Text,MTOM|Yes (buffered)|  
|<xref:System.ServiceModel.NetTcpBinding>|.NET|(Transport), Message, None, Mixed|(Transport), Reliable Session, Security Session|(None), Yes|Yes|Binary|Yes<br /><br /> (buffered)|  
|<xref:System.ServiceModel.NetNamedPipeBinding>|.NET|(Transport), None|None, (Transport)|(None), Yes|Yes|Binary|Yes<br /><br /> (buffered)|  
|<xref:System.ServiceModel.NetMsmqBinding>|.NET|Message, (Transport), None|(None), Transport|None, (Yes)|No|Binary|No|  
|<xref:System.ServiceModel.NetPeerTcpBinding>|Peer|(Transport)|(None)|(None)|Yes||No|  
|<xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>|MSMQ|(Transport)|(None)|None, (Yes)|n/a|n/a|No|  
|<xref:System.ServiceModel.BasicHttpContextBinding>|Basic Profile 1.1|(None), Transport, Message, Mixed|(None)|(None)|n/a|Text, (MTOM)|Yes<br /><br /> (buffered)|  
|<xref:System.ServiceModel.NetTcpContextBinding>|.NET|(Transport), Message, None, Mixed|(Transport), Reliable Session, Security Session|(None), Yes|Yes|Binary|Yes<br /><br /> (buffered)|  
|<xref:System.ServiceModel.WSHttpContextBinding>|WS|Transport, (Message), Mixed|(None), Reliable Session, Security Session|(None), Yes|n/a|Text, (MTOM)|No|  
|<xref:System.ServiceModel.UdpBinding>|.NET **Note:**  Interoperability can be achieved by implementing the standard SOAP-over-UDP spec which this binding implements.|(None)|(None)|(None)|n/a|(Text)|No|  
  
> [!IMPORTANT]
>  <xref:System.ServiceModel.NetHttpBinding> is a binding designed for consuming HTTP or WebSocket services and uses binary encoding by default. <xref:System.ServiceModel.NetHttpBinding> will detect whether it is used with a request-reply contract or duplex contract and change its behavior to match - it will use HTTP for request-reply and WebSockets for duplex. This behavior can be overridden using the <!--zz <xref:System.ServiceModel.NetHttpBinding.WebSocketTransportUsage%2A>--> `System.ServiceModel.NetHttpBinding.WebSocketTransportUsage` binding setting:Allowed - This is the default value and behaves as described above.NotAllowed - This prevents WebSockets from being used. Attempting to use a duplex contract with this setting will result in an exception.Required - This forces WebSockets to be used even for request-reply contracts. NetHttpBinding supports reliable sessions in both HTTP mode and WebSocket mode. In WebSocket mode sessions are provided by the transport.  
  
 The following table explains the features listed in the previous table.  
  
|Feature|Description|  
|-------------|-----------------|  
|Interoperability Type|Names the protocol or technology with which the binding ensures interoperation.|  
|Security|Specifies how the channel is secured:<br /><br /> -   None: The SOAP message is not secured and the client is not authenticated.<br />-   Transport: Security requirements are satisfied at the transport layer.<br />-   Message: Security requirements are satisfied at the message layer.<br />-   Mixed: Claims are carried in the message; integrity and confidentiality requirements are satisfied by the transport layer.|  
|Session|Specifies whether this binding supports session contracts.|  
|Transactions|Specifies whether transactions are enabled.|  
|Duplex|Specifies whether duplex contracts are supported. Note that this feature requires support for Sessions in the binding.|  
|Encoding|Specifies the wire format of the message. Allowable values include:<br /><br /> -   Text: for example UTF-8.<br />-   Binary<br />-   Message Transmission Optimization Mechanism (MTOM): A method for efficiently encoding binary XML elements within the context of a SOAP envelope.|  
|Streaming|Specifies whether streaming is supported for incoming and outgoing messages. Use the `TransferMode` property on the binding to set the value. The allowable values include:<br /><br /> -   <xref:System.ServiceModel.TransferMode.Buffered>: The request and response messages are both buffered.<br />-   <xref:System.ServiceModel.TransferMode.Streamed>: The request and response messages are both streamed.<br />-   <xref:System.ServiceModel.TransferMode.StreamedRequest>: The request message is streamed and the response message is buffered.<br />-   <xref:System.ServiceModel.TransferMode.StreamedResponse>: The request message is buffered and the response message is streamed.|  
  
## See Also  
 [Endpoint Creation Overview](../../../docs/framework/wcf/endpoint-creation-overview.md)  
 [Using Bindings to Configure Services and Clients](../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md)  
 [Basic WCF Programming](../../../docs/framework/wcf/basic-wcf-programming.md)
