---
title: "Significant Traces"
ms.date: "03/30/2017"
ms.assetid: 40a1770e-3b09-4142-b0dd-f9ef73642074
---
# Significant Traces
This topic lists some of the major traces emitted by Windows Communication Foundation (WCF).  
  
## Significant Traces  
  
|Trace|Description|  
|-----------|-----------------|  
|Message log trace|The trace is emitted when a WCF message is logged by the message logging feature when the `System.ServiceModel.MessageLogging` trace source is enabled. Clicking this trace displays the message. There are four configurable logging points for a message: `ServiceLevelSendRequest`, `TransportSend`, `TransportReceive`, `ServiceLevelReceiveRequest`, also indicated by the Message Source attribute in the message log trace.|  
|Message received trace|This trace is emitted when a WCF message is received if the `System.ServiceModel` trace source is enabled at information or verbose level. This trace is necessary to see the message correlation arrow in the activity graph view.|  
|Message sent trace|This trace is emitted when a WCF message is sent if the `System.ServiceModel` trace source is enabled at information or verbose level. This trace is necessary to see the message correlation arrow in the activity graph view.|  
|Get ChannelEndpointElement|This trace is emitted in Construct channel factory, at information level. It provides a description of the endpoint the client is talking to (remote address, binding, contract name).|  
|Get ServiceElement|This trace is emitted in Construct service host, at Information level. It provides a description of the service contract and binding.|  
|SocketConnection create|This trace is emitted in the first Process action performed by the client and in the Receive bytes activity on the service. It provides the local and remote IP addresses. It is emitted at Information level.|
