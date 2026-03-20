---
title: System.Net.Sockets.Socket class
description: Learn about the System.Net.Sockets.Socket class.
ms.date: 12/31/2023
---
# System.Net.Sockets.Socket class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Net.Sockets.Socket> class provides a rich set of methods and properties for network communications. The <xref:System.Net.Sockets.Socket> class allows you to perform both synchronous and asynchronous data transfer using any of the communication protocols listed in the <xref:System.Net.Sockets.ProtocolType> enumeration.

The <xref:System.Net.Sockets.Socket> class follows the .NET naming pattern for asynchronous methods. For example, the synchronous <xref:System.Net.Sockets.Socket.Receive*> method corresponds to the asynchronous <xref:System.Net.Sockets.Socket.ReceiveAsync*> variants.

Use the following methods for synchronous operation mode:

- If you are using a connection-oriented protocol such as TCP, your server can listen for connections using the <xref:System.Net.Sockets.Socket.Listen*> method. The <xref:System.Net.Sockets.Socket.Accept*> method processes any incoming connection requests and returns a <xref:System.Net.Sockets.Socket> that you can use to communicate data with the remote host. Use this returned <xref:System.Net.Sockets.Socket> to call the <xref:System.Net.Sockets.Socket.Send*> or <xref:System.Net.Sockets.Socket.Receive*> method. Call the <xref:System.Net.Sockets.Socket.Bind*> method prior to calling the <xref:System.Net.Sockets.Socket.Listen*> method if you want to specify the local IP address and port number. Use a port number of zero if you want the underlying service provider to assign a free port for you. If you want to connect to a listening host, call the <xref:System.Net.Sockets.Socket.Connect*> method. To communicate data, call the <xref:System.Net.Sockets.Socket.Send*> or <xref:System.Net.Sockets.Socket.Receive*> method.
- If you are using a connectionless protocol such as UDP, you do not need to listen for connections at all. Call the <xref:System.Net.Sockets.Socket.ReceiveFrom*> method to accept any incoming datagrams. Use the <xref:System.Net.Sockets.Socket.SendTo*> method to send datagrams to a remote host.

To process communications asynchronously, use the following methods:

- If you are using a connection-oriented protocol such as TCP, use <xref:System.Net.Sockets.Socket.ConnectAsync*> to connect with a listening host. Use <xref:System.Net.Sockets.Socket.SendAsync*> or <xref:System.Net.Sockets.Socket.ReceiveAsync*> to communicate data asynchronously. Incoming connection requests can be processed using <xref:System.Net.Sockets.Socket.AcceptAsync*>.
- If you are using a connectionless protocol such as UDP, you can use <xref:System.Net.Sockets.Socket.SendToAsync*> to send datagrams, and <xref:System.Net.Sockets.Socket.ReceiveFromAsync*>to receive datagrams.

If you perform multiple asynchronous operations on a socket, they do not necessarily complete in the order in which they are started.

When you are finished sending and receiving data, use the <xref:System.Net.Sockets.Socket.Shutdown*> method to disable the <xref:System.Net.Sockets.Socket>. After calling <xref:System.Net.Sockets.Socket.Shutdown*>, call the <xref:System.Net.Sockets.Socket.Close*> method to release all resources associated with the <xref:System.Net.Sockets.Socket>.

The <xref:System.Net.Sockets.Socket> class allows you to configure your <xref:System.Net.Sockets.Socket> using the <xref:System.Net.Sockets.Socket.SetSocketOption*> method. Retrieve these settings using the <xref:System.Net.Sockets.Socket.GetSocketOption*> method.
