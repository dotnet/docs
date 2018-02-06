---
title: "Transport: WSE 3.0 TCP Interoperability"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5f7c3708-acad-4eb3-acb9-d232c77d1486
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transport: WSE 3.0 TCP Interoperability
The WSE 3.0 TCP Interoperability Transport sample demonstrates how to implement a TCP duplex session as a custom [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] transport. It also demonstrates how you can use the extensibility of the channel layer to interface over the wire with existing deployed systems. The following steps show how to build this custom [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transport:  
  
1.  Starting with a TCP socket, create client and server implementations of <xref:System.ServiceModel.Channels.IDuplexSessionChannel> that use DIME Framing to delineate message boundaries.  
  
2.  Create a channel factory that connects to a WSE TCP service and sends framed messages over the client <xref:System.ServiceModel.Channels.IDuplexSessionChannel>s.  
  
3.  Create a channel listener to accept incoming TCP connections and produce corresponding channels.  
  
4.  Ensure that any network-specific exceptions are normalized to the appropriate derived class of <xref:System.ServiceModel.CommunicationException>.  
  
5.  Add a binding element that adds the custom transport to a channel stack. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Adding a Binding Element].  
  
## Creating IDuplexSessionChannel  
 The first step in writing the WSE 3.0 TCP Interoperability Transport is to create an implementation of <xref:System.ServiceModel.Channels.IDuplexSessionChannel> on top of a <xref:System.Net.Sockets.Socket>. `WseTcpDuplexSessionChannel` derives from <xref:System.ServiceModel.Channels.ChannelBase>. The logic of sending a message consists of two main pieces: (1) Encoding the message into bytes, and (2) framing those bytes and sending them on the wire.  
  
 `ArraySegment<byte> encodedBytes = EncodeMessage(message);`  
  
 `WriteData(encodedBytes);`  
  
 In addition, a lock is taken so that the Send() calls preserve the IDuplexSessionChannel in-order guarantee, and so that calls to the underlying socket are synchronized correctly.  
  
 `WseTcpDuplexSessionChannel` uses a <xref:System.ServiceModel.Channels.MessageEncoder> for translating a <xref:System.ServiceModel.Channels.Message> to and from byte[]. Because it is a transport, `WseTcpDuplexSessionChannel` is also responsible for applying the remote address that the channel was configured with. `EncodeMessage` encapsulates the logic for this conversion.  
  
 `this.RemoteAddress.ApplyTo(message);`  
  
 `return encoder.WriteMessage(message, maxBufferSize, bufferManager);`  
  
 Once the <xref:System.ServiceModel.Channels.Message> is encoded into bytes, it must be transmitted on the wire. This requires a system for defining message boundaries. WSE 3.0 uses a version of [DIME](http://go.microsoft.com/fwlink/?LinkId=94999) as its framing protocol. `WriteData` encapsulates the framing logic to wrap a byte[] into a set of DIME records.  
  
 The logic for receiving messages is very similar. The main complexity is handling the fact that a socket read can return less bytes than were requested. To receive a message, `WseTcpDuplexSessionChannel` reads bytes off the wire, decodes the DIME framing, and then uses the <xref:System.ServiceModel.Channels.MessageEncoder> for turning the byte[] into a <xref:System.ServiceModel.Channels.Message>.  
  
 The base `WseTcpDuplexSessionChannel` assumes that it receives a connected socket. The base class handles socket shutdown. There are three places that interface with socket closure:  
  
-   OnAbort -- close the socket ungracefully (hard close).  
  
-   On[Begin]Close -- close the socket gracefully (soft close).  
  
-   session.CloseOutputSession -- shutdown the outbound data stream (half close).  
  
## Channel Factory  
 The next step in writing the TCP transport is to create an implementation of <xref:System.ServiceModel.Channels.IChannelFactory> for client channels.  
  
-   `WseTcpChannelFactory` derives from <xref:System.ServiceModel.Channels.ChannelFactoryBase>\<IDuplexSessionChannel>. It is a factory that overrides `OnCreateChannel` to produce client channels.  
  
 `protected override IDuplexSessionChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)`  
  
 `{`  
  
 `return new ClientWseTcpDuplexSessionChannel(encoderFactory, bufferManager, remoteAddress, via, this);`  
  
 `}`  
  
-   `ClientWseTcpDuplexSessionChannel` adds logic to the base `WseTcpDuplexSessionChannel` to connect to a TCP server at `channel.Open` time. First the hostname is resolved to an IP address, as shown in the following code.  
  
 `hostEntry = Dns.GetHostEntry(Via.Host);`  
  
-   Then the hostname is connected to the first available IP address in a loop, as shown in the following code.  
  
 `IPAddress address = hostEntry.AddressList[i];`  
  
 `socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);`  
  
 `socket.Connect(new IPEndPoint(address, port));`  
  
-   As part of the channel contract, any domain-specific exceptions are wrapped, such as `SocketException` in <xref:System.ServiceModel.CommunicationException>.  
  
## Channel Listener  
 The next step in writing the TCP transport is to create an implementation of <xref:System.ServiceModel.Channels.IChannelListener> for accepting server channels.  
  
-   `WseTcpChannelListener` derives from <xref:System.ServiceModel.Channels.ChannelListenerBase>\<IDuplexSessionChannel> and overrides On[Begin]Open and On[Begin]Close to control the lifetime of its listen socket. In OnOpen, a socket is created to listen on IP_ANY. More advanced implementations can create a second socket to listen on IPv6 as well. They can also allow the IP address to be specified in the hostname.  
  
 `IPEndPoint localEndpoint = new IPEndPoint(IPAddress.Any, uri.Port);`  
  
 `this.listenSocket = new Socket(localEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);`  
  
 `this.listenSocket.Bind(localEndpoint);`  
  
 `this.listenSocket.Listen(10);`  
  
 When a new socket is accepted, a server channel is initialized with this socket. All the input and output is already implemented in the base class, so this channel is responsible for initializing the socket.  
  
## Adding a Binding Element  
 Now that the factories and channels are built, they must be exposed to the ServiceModel runtime through a binding. A binding is a collection of binding elements that represents the communication stack associated with a service address. Each element in the stack is represented by a binding element.  
  
 In the sample, the binding element is `WseTcpTransportBindingElement`, which derives from <xref:System.ServiceModel.Channels.TransportBindingElement>. It supports <xref:System.ServiceModel.Channels.IDuplexSessionChannel> and overrides the following methods to build the factories associated with our binding.  
  
 `public IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)`  
  
 `{`  
  
 `return (IChannelFactory<TChannel>)(object)new WseTcpChannelFactory(this, context);`  
  
 `}`  
  
 `public IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)`  
  
 `{`  
  
 `return (IChannelListener<TChannel>)(object)new WseTcpChannelListener(this, context);`  
  
 `}`  
  
 It also contains members for cloning the `BindingElement` and returning our scheme (wse.tcp).  
  
## The WSE TCP Test Console  
 Test code for using this sample transport is available in TestCode.cs. The following instructions show how to set up the WSE `TcpSyncStockService` sample.  
  
 The test code creates a custom binding that uses MTOM as the encoding and `WseTcpTransport` as the transport. It also sets up the AddressingVersion to be conformant with WSE 3.0, as shown in the following code.  
  
 `CustomBinding binding = new CustomBinding();`  
  
 `MtomMessageEncodingBindingElement mtomBindingElement = new MtomMessageEncodingBindingElement();`  
  
 `mtomBindingElement.MessageVersion = MessageVersion.Soap11WSAddressingAugust2004;`  
  
 `binding.Elements.Add(mtomBindingElement);`  
  
 `binding.Elements.Add(new WseTcpTransportBindingElement());`  
  
 It consists of two tests—one test sets up a typed client using code generated from the WSE 3.0 WSDL. The second test uses [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] as both the client and the server by sending messages directly on top of the channel APIs.  
  
 When running the sample, the following output is expected.  
  
 Client:  
  
```  
Calling soap://stockservice.contoso.com/wse/samples/2003/06/TcpSyncStockService  
  
Symbol: FABRIKAM  
        Name: Fabrikam, Inc.  
        Last Price: 120  
  
Symbol: CONTOSO  
        Name: Contoso Corp.  
        Last Price: 50.07  
Press enter.  
  
Received Action: http://SayHello  
Received Body: to you.  
Hello to you.  
Press enter.  
  
Received Action: http://NotHello  
Received Body: to me.  
Press enter.  
```  
  
 Server:  
  
```  
Listening for messages at soap://stockservice.contoso.com/wse/samples/2003/06/TcpSyncStockService  
  
Press any key to exit when done...  
  
Request received.  
Symbols:  
        FABRIKAM  
        CONTOSO  
```  
  
#### To set up, build, and run the sample  
  
1.  To run this sample, you must have WSE 3.0 and the WSE `TcpSyncStockService` sample installed. You can download [WSE 3.0 from MSDN](http://go.microsoft.com/fwlink/?LinkId=95000).  
  
> [!NOTE]
>  Because WSE 3.0 is not supported on [!INCLUDE[lserver](../../../../includes/lserver-md.md)], you cannot install or run the `TcpSyncStockService` sample on that operating system.  
  
1.  Once you install the `TcpSyncStockService` sample, do the following:  
  
    1.  Open the `TcpSyncStockService` in Visual Studio (Note that the TcpSyncStockService sample is installed with WSE 3.0. It is not part of this sample's code).  
  
    2.  Set the StockService project as the start up project.  
  
    3.  Open StockService.cs in the StockService project and comment out the [Policy] attribute on the `StockService` class. This disables security from the sample. While [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can interoperate with WSE 3.0 secure endpoints, security is disabled to keep this sample focused on the custom TCP transport.  
  
    4.  Press F5 to start the `TcpSyncStockService`. The service starts in a new console window.  
  
    5.  Open this TCP transport sample in Visual Studio.  
  
    6.  Update the "hostname" variable in TestCode.cs to match the machine name running the `TcpSyncStockService`.  
  
    7.  Press F5 to start the TCP transport sample.  
  
    8.  The TCP transport test client starts in a new console. The client requests stock quotes from the service and then displays the results in its console window.  
  
## See Also
