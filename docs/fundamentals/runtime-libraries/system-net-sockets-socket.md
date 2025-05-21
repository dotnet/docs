---
title: System.Net.Sockets.Socket class
description: Learn about the System.Net.Sockets.Socket class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Net.Sockets.Socket class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Net.Sockets.Socket> class provides a rich set of methods and properties for network communications. The <xref:System.Net.Sockets.Socket> class allows you to perform both synchronous and asynchronous data transfer using any of the communication protocols listed in the <xref:System.Net.Sockets.ProtocolType> enumeration.

The <xref:System.Net.Sockets.Socket> class follows the .NET naming pattern for asynchronous methods. For example, the synchronous <xref:System.Net.Sockets.Socket.Receive%2A> method corresponds to the asynchronous <xref:System.Net.Sockets.Socket.ReceiveAsync%2A> variants.

Use the following methods for synchronous operation mode:

- If you are using a connection-oriented protocol such as TCP, your server can listen for connections using the <xref:System.Net.Sockets.Socket.Listen%2A> method. The <xref:System.Net.Sockets.Socket.Accept%2A> method processes any incoming connection requests and returns a <xref:System.Net.Sockets.Socket> that you can use to communicate data with the remote host. Use this returned <xref:System.Net.Sockets.Socket> to call the <xref:System.Net.Sockets.Socket.Send%2A> or <xref:System.Net.Sockets.Socket.Receive%2A> method. Call the <xref:System.Net.Sockets.Socket.Bind%2A> method prior to calling the <xref:System.Net.Sockets.Socket.Listen%2A> method if you want to specify the local IP address and port number. Use a port number of zero if you want the underlying service provider to assign a free port for you. If you want to connect to a listening host, call the <xref:System.Net.Sockets.Socket.Connect%2A> method. To communicate data, call the <xref:System.Net.Sockets.Socket.Send%2A> or <xref:System.Net.Sockets.Socket.Receive%2A> method.
- If you are using a connectionless protocol such as UDP, you do not need to listen for connections at all. Call the <xref:System.Net.Sockets.Socket.ReceiveFrom%2A> method to accept any incoming datagrams. Use the <xref:System.Net.Sockets.Socket.SendTo%2A> method to send datagrams to a remote host.

To process communications asynchronously, use the following methods:

- If you are using a connection-oriented protocol such as TCP, use <xref:System.Net.Sockets.Socket.ConnectAsync%2A> to connect with a listening host. Use <xref:System.Net.Sockets.Socket.SendAsync%2A> or <xref:System.Net.Sockets.Socket.ReceiveAsync%2A> to communicate data asynchronously. Incoming connection requests can be processed using <xref:System.Net.Sockets.Socket.AcceptAsync%2A>.
- If you are using a connectionless protocol such as UDP, you can use <xref:System.Net.Sockets.Socket.SendToAsync%2A> to send datagrams, and <xref:System.Net.Sockets.Socket.ReceiveFromAsync%2A>to receive datagrams.

If you perform multiple asynchronous operations on a socket, they do not necessarily complete in the order in which they are started.

When you are finished sending and receiving data, use the <xref:System.Net.Sockets.Socket.Shutdown%2A> method to disable the <xref:System.Net.Sockets.Socket>. After calling <xref:System.Net.Sockets.Socket.Shutdown%2A>, call the <xref:System.Net.Sockets.Socket.Close%2A> method to release all resources associated with the <xref:System.Net.Sockets.Socket>.

The <xref:System.Net.Sockets.Socket> class allows you to configure your <xref:System.Net.Sockets.Socket> using the <xref:System.Net.Sockets.Socket.SetSocketOption%2A> method. Retrieve these settings using the <xref:System.Net.Sockets.Socket.GetSocketOption%2A> method.
