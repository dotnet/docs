---
description: "Learn more about: Custom Bindings"
title: "Custom Bindings"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Communication Foundation, endpoints"
  - "Windows Communication Foundation, configuration"
ms.assetid: 58532b6d-4eea-4a4f-854f-a1c8c842564d
---
# Custom Bindings

You can use the <xref:System.ServiceModel.Channels.CustomBinding> class when one of the system-provided bindings does not meet the requirements of your service. All bindings are constructed from an ordered set of binding elements. Custom bindings can be built from a set of system-provided binding elements or can include user-defined custom binding elements. You can use custom binding elements, for example, to enable the use of new transports or encoders at a service endpoint. For working examples, see [Custom Binding Samples](/previous-versions/dotnet/netframework-3.5/ms751479(v=vs.90)). For more information, see [\<customBinding>](../../configure-apps/file-schema/wcf/custombinding.md).

## Construction of a Custom Binding

A custom binding is constructed using the <xref:System.ServiceModel.Channels.CustomBinding.%23ctor%2A> constructor from a collection of binding elements that are "stacked" in a specific order:

- At the top is an optional <xref:System.ServiceModel.Channels.TransactionFlowBindingElement> class that allows flowing transactions.

- Next is an optional <xref:System.ServiceModel.Channels.ReliableSessionBindingElement> class that provides a session and ordering mechanisms as defined in the WS-ReliableMessaging specification. A session can cross SOAP and transport intermediaries.

- Next is an optional <xref:System.ServiceModel.Channels.SecurityBindingElement> class that provides security features such as authorization, authentication, protection, and confidentiality.

- Next is an optional <xref:System.ServiceModel.Channels.CompositeDuplexBindingElement> class that provides the ability to have two way duplex communication with a transport protocol that does not support duplex communication natively, such as HTTP.

- Next is an optional <xref:System.ServiceModel.Channels.OneWayBindingElement>) class that provides one-way communication.

- Next is an optional stream security binding element which can be one of the following.

  - <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement>

  - <xref:System.ServiceModel.Channels.WindowsStreamSecurityBindingElement>

- Next is a required message encoding binding element. You can use your own message encoder or one of the three message encoding bindings:

  - <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>

  - <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>

  - <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement>

At the bottom is a required transport element. You can use your own transport or one of the following transport binding elements Windows Communication Foundation (WCF) provides:

- <xref:System.ServiceModel.Channels.TcpTransportBindingElement>

- <xref:System.ServiceModel.Channels.HttpTransportBindingElement>

- <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>

- <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>

- <xref:System.ServiceModel.Channels.PeerTransportBindingElement>

- <xref:System.ServiceModel.Channels.MsmqTransportBindingElement>

- <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBindingElement>

- <xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement>

The following table summarizes the options for each layer.

|Layer|Options|Required|
|-----------|-------------|--------------|
|Transactions|<xref:System.ServiceModel.Channels.TransactionFlowBindingElement>|No|
|Reliability|<xref:System.ServiceModel.Channels.ReliableSessionBindingElement>|No|
|Security|<xref:System.ServiceModel.Channels.SecurityBindingElement>|No|
|Encoding|Text, binary, Message Transmission Optimization Mechanism (MTOM), custom|Yes|
|Transport|TCP, HTTP, HTTPS, named pipes (also known as IPC), Peer-to-Peer (P2P), Message Queuing (also known as MSMQ), Custom|Yes|

In addition, you can define your own binding elements and insert them between any of the preceding defined layers.

## See also

- [Endpoint Creation Overview](../endpoint-creation-overview.md)
- [Using Bindings to Configure Services and Clients](../using-bindings-to-configure-services-and-clients.md)
- [System-Provided Bindings](../system-provided-bindings.md)
- [How to: Customize a System-Provided Binding](how-to-customize-a-system-provided-binding.md)
- [\<customBinding>](../../configure-apps/file-schema/wcf/custombinding.md)
- [Custom Binding](../samples/custom-binding.md)
