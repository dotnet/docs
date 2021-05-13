---
title: "System-provided bindings"
description: "Learn about all of the system-provided Windows Communication Foundation (WCF) bindings."
ms.date: "06/05/2018"
helpviewer_keywords: 
  - "bindings [WCF], system-provided"
ms.topic: reference
---
# System-provided bindings

Bindings specify the communication mechanism to use when talking to an endpoint and indicate how to connect to an endpoint. A binding contains the following elements:

- The protocol stack determines the security, reliability, and context flow settings to use for messages that are sent to the endpoint.

- The transport determines the underlying transport protocol to use when sending messages to the endpoint, for example, TCP or HTTP.

- The encoding determines the wire encoding to use for messages that are sent to the endpoint. For example, text/XML, binary, or Message Transmission Optimization Mechanism (MTOM).

 This article presents all of the system-provided Windows Communication Foundation (WCF) bindings. If none of these bindings meets the exact criteria for your application, you can create a custom binding. For more information about creating custom bindings, see [Custom Bindings](./extending/custom-bindings.md).

 A secure and interoperable binding that supports the WS-Federation protocol enables organizations that are in a federation to efficiently authenticate and authorize users.

> [!IMPORTANT]
> Always select a binding that includes security. By default, all bindings except the [\<basicHttpBinding>](../configure-apps/file-schema/wcf/basichttpbinding.md) element have security enabled. If you do not select a secure binding or disable security, be sure to protect your data in some other manner, such as storing in a secured data center or on an isolated network.

> [!IMPORTANT]
> Never use duplex contracts with bindings that do not support security or that have security disabled unless you secure the data by some other means.

The following bindings ship with WCF:

|Binding|Configuration Element|Description|
|-------------|---------------------------|-----------------|
|<xref:System.ServiceModel.BasicHttpBinding>|[\<basicHttpBinding>](../configure-apps/file-schema/wcf/basichttpbinding.md)|A binding that is suitable for communicating with WS-Basic Profile-conformant Web services, for example, ASP.NET Web services (ASMX)-based services. This binding uses HTTP as the transport and text/XML as the default message encoding.|
|<xref:System.ServiceModel.WSHttpBinding>|[\<wsHttpBinding>](../configure-apps/file-schema/wcf/wshttpbinding.md)|A secure and interoperable binding that is suitable for non-duplex service contracts.|
|<xref:System.ServiceModel.WSDualHttpBinding>|[\<wsDualHttpBinding>](../configure-apps/file-schema/wcf/wsdualhttpbinding.md)|A secure and interoperable binding that is suitable for duplex service contracts or communication through SOAP intermediaries.|
|<xref:System.ServiceModel.WSFederationHttpBinding>|[\<wsFederationHttpBinding>](../configure-apps/file-schema/wcf/wsfederationhttpbinding.md)|A secure and interoperable binding that supports the WS-Federation protocol, which enables organizations that are in a federation to efficiently authenticate and authorize users.|
|<xref:System.ServiceModel.NetHttpBinding>|[\<netHttpBinding>](../configure-apps/file-schema/wcf/nethttpbinding.md)|A binding designed for consuming HTTP or WebSocket services that uses binary encoding by default.|
|<xref:System.ServiceModel.NetHttpsBinding>|[\<netHttpsBinding>](../configure-apps/file-schema/wcf/nethttpsbinding.md)|A secure binding designed for consuming HTTP or WebSocket services that uses binary encoding by default.|
|<xref:System.ServiceModel.NetTcpBinding>|[\<netTcpBinding>](../configure-apps/file-schema/wcf/nettcpbinding.md)|A secure and optimized binding suitable for cross-machine communication between WCF applications.|
|<xref:System.ServiceModel.NetNamedPipeBinding>|[\<netNamedPipeBinding>](../configure-apps/file-schema/wcf/netnamedpipebinding.md)|A secure, reliable, optimized binding that is suitable for on-machine communication between WCF applications.|
|<xref:System.ServiceModel.NetMsmqBinding>|[\<netMsmqBinding>](../configure-apps/file-schema/wcf/netmsmqbinding.md)|A queued binding that is suitable for cross-machine communication between WCF applications.|
|<xref:System.ServiceModel.NetPeerTcpBinding>|[\<netPeerTcpBinding>](../configure-apps/file-schema/wcf/netpeertcpbinding.md)|A binding that enables secure, multiple machine communication.|
|<xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>|[\<msmqIntegrationBinding>](../configure-apps/file-schema/wcf/msmqintegrationbinding.md)|A binding that is suitable for cross-machine communication between a WCF application and existing Message Queuing applications.|
|<xref:System.ServiceModel.BasicHttpContextBinding>|[\<basicHttpContextBinding>](../configure-apps/file-schema/wcf/basichttpcontextbinding.md)|A binding suitable for communicating with WS-Basic Profile conformant Web services that enables HTTP cookies to be used to exchange context.|
|<xref:System.ServiceModel.NetTcpContextBinding>|[\<netTcpContextBinding>](../configure-apps/file-schema/wcf/nettcpcontextbinding.md)|A secure and optimized binding suitable for cross-machine communication between WCF applications that enables SOAP headers to be used to exchange context.|
|<xref:System.ServiceModel.WebHttpBinding>|[\<webHttpBinding>](../configure-apps/file-schema/wcf/webhttpbinding.md)|A binding used to configure endpoints for WCF Web services that are exposed through HTTP requests instead of SOAP messages.|
|<xref:System.ServiceModel.WSHttpContextBinding>|[\<wsHttpContextBinding>](../configure-apps/file-schema/wcf/wshttpcontextbinding.md)|A secure and interoperable binding suitable for non-duplex service contracts that enables SOAP headers to be used to exchange context.|
|<xref:System.ServiceModel.UdpBinding>|[\<udpBinding>](../configure-apps/file-schema/wcf/udpbinding.md)|A binding to use when sending a burst of simple messages to a large number of clients simultaneously.|

 The following table shows the features of each of the system-provided bindings. The bindings are found in the table columns; the features are listed in the rows and described in a second table. The following table provides a key for the binding abbreviations used. To select a binding, determine which column satisfies all of the row features you need.

|Binding|Interoperability|Security (Default)|Session<br />(Default)|Transactions|Duplex|Encoding (Default)|Streaming<br />(Default)|
|-------------|----------------------|--------------------------|-----------------------------|------------------|------------|--------------------------|-------------------------------|
|<xref:System.ServiceModel.BasicHttpBinding>|Basic Profile 1.1|(None), Transport, Message, Mixed|(None)|(None)|n/a|Text, (MTOM)|Yes<br />(buffered)|
|<xref:System.ServiceModel.WSHttpBinding>|WS|Transport, (Message), Mixed|(None), Reliable Session, Security Session|(None), Yes|n/a|(Text), MTOM|No|
|<xref:System.ServiceModel.WSDualHttpBinding>|WS|(Message), None|(Reliable Session), Security Session|(None), Yes|Yes|(Text), MTOM|No|
|<xref:System.ServiceModel.WSFederationHttpBinding>|WS-Federation|(Message), Mixed, None|(None), Reliable Session, Security Session|(None), Yes|No|(Text), MTOM|No|
|<xref:System.ServiceModel.NetHttpBinding>|.NET|(None), Transport, Message, TransportWithMessageCredential, TransportCredentialOnly|See note below|None|See note below|(Binary), Text, MTOM|Yes (buffered)|
|<xref:System.ServiceModel.NetHttpsBinding>|.NET|(Transport), TransportWithMessageCredential|See note below|None|See note below|(Binary), Text, MTOM|Yes<br />(buffered)|
|<xref:System.ServiceModel.NetTcpBinding>|.NET|(Transport), Message, None, Mixed|(Transport), Reliable Session, Security Session|(None), Yes|Yes|Binary|Yes<br />(buffered)|
|<xref:System.ServiceModel.NetNamedPipeBinding>|.NET|(Transport), None|None, (Transport)|(None), Yes|Yes|Binary|Yes<br />(buffered)|
|<xref:System.ServiceModel.NetMsmqBinding>|.NET|Message, (Transport), None|(None), Transport|None, (Yes)|No|Binary|No|
|<xref:System.ServiceModel.NetPeerTcpBinding>|Peer|(Transport)|(None)|(None)|Yes||No|
|<xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>|MSMQ|(Transport)|(None)|None, (Yes)|n/a|n/a|No|
|<xref:System.ServiceModel.BasicHttpContextBinding>|Basic Profile 1.1|(None), Transport, Message, Mixed|(None)|(None)|n/a|Text, (MTOM)|Yes<br />(buffered)|
|<xref:System.ServiceModel.NetTcpContextBinding>|.NET|(Transport), Message, None, Mixed|(Transport), Reliable Session, Security Session|(None), Yes|Yes|Binary|Yes<br />(buffered)|
|<xref:System.ServiceModel.WSHttpContextBinding>|WS|Transport, (Message), Mixed|(None), Reliable Session, Security Session|(None), Yes|n/a|Text, (MTOM)|No|
|<xref:System.ServiceModel.UdpBinding> <br /><br /> **Note:**  Interoperability can be achieved by implementing the standard SOAP-over-UDP spec which this binding implements.|.NET|(None)|(None)|(None)|n/a|(Text)|No|

> [!IMPORTANT]
> <xref:System.ServiceModel.NetHttpBinding> is a binding designed for consuming HTTP or WebSocket services and uses binary encoding by default. <xref:System.ServiceModel.NetHttpBinding> detects whether it's used with a request-reply contract or duplex contract and changes its behavior to match; it uses HTTP for request-reply and WebSockets for duplex. This behavior can be overridden using the <xref:System.ServiceModel.Channels.WebSocketTransportUsage> binding setting: WhenDuplex - This is the default value and behaves as described above. Never - This prevents WebSockets from being used. Attempting to use a duplex contract with this setting results in an exception. Always - This forces WebSockets to be used even for request-reply contracts. NetHttpBinding supports reliable sessions in both HTTP mode and WebSocket mode. In WebSocket mode sessions are provided by the transport.

 The following table explains the features listed in the previous table.

|Feature|Description|
|-------------|-----------------|
|Interoperability Type|Names the protocol or technology with which the binding ensures interoperation.|
|Security|Specifies how the channel is secured:<br />- None: The SOAP message isn't secured and the client isn't authenticated.<br />- Transport: Security requirements are satisfied at the transport layer.<br />- Message: Security requirements are satisfied at the message layer.<br />- Mixed: Claims are carried in the message; integrity and confidentiality requirements are satisfied by the transport layer.|
|Session|Specifies whether this binding supports session contracts.|
|Transactions|Specifies whether transactions are enabled.|
|Duplex|Specifies whether duplex contracts are supported. Note that this feature requires support for Sessions in the binding.|
|Encoding|Specifies the wire format of the message. Allowable values include:<br />- Text: for example UTF-8.<br />- Binary<br />- Message Transmission Optimization Mechanism (MTOM): A method for efficiently encoding binary XML elements within the context of a SOAP envelope.|
|Streaming|Specifies whether streaming is supported for incoming and outgoing messages. Use the `TransferMode` property on the binding to set the value. The allowable values include:<br />- <xref:System.ServiceModel.TransferMode.Buffered>: The request and response messages are both buffered.<br />- <xref:System.ServiceModel.TransferMode.Streamed>: The request and response messages are both streamed.<br />- <xref:System.ServiceModel.TransferMode.StreamedRequest>: The request message is streamed and the response message is buffered.<br />- <xref:System.ServiceModel.TransferMode.StreamedResponse>: The request message is buffered and the response message is streamed.|

## See also

- [Endpoint Creation Overview](endpoint-creation-overview.md)
- [Using Bindings to Configure Services and Clients](using-bindings-to-configure-services-and-clients.md)
- [Basic WCF Programming](basic-wcf-programming.md)
