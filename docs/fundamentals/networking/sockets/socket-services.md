---
title: Use Socket to send and receive data
description: Learn how the Socket class exposes socket network communication functionality in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/22/2022
helpviewer_keywords:
  - "application protocols, sockets"
  - "sending data, sockets"
  - "data requests, sockets"
  - "asynchronous client sockets"
  - "Socket class, asynchronous client sockets"
  - "requesting data from Internet, sockets"
  - "sockets, asynchronous client sockets"
  - "receiving data, sockets"
  - "protocols, sockets"
  - "Internet, sockets"
  - "client sockets"
---

# Use Socket to send and receive data

Before you can use a socket to communicate with remote devices, the socket must be initialized with protocol and network address information. The constructor for the <xref:System.Net.Sockets.Socket> class has parameters that specify the address family, socket type, and protocol type that the socket uses to make connections. When connecting a client socket to a server socket, the client will use an `IPEndPoint` object to specify the network address of the server.

[!INCLUDE [ip-endpoint](../includes/ip-endpoint.md)]

## Create a `Socket` client

:::code language="csharp" source="../snippets/socket/socket-client/Program.cs" id="socketclient":::

The preceding C# code:

- Instantiates a new `Socket` object with a given `endPoint` instances address family, the <xref:System.Net.Sockets.SocketType.Stream?displayProperty=nameWithType>, and <xref:System.Net.Sockets.ProtocolType.Tcp?displayProperty=nameWithType>.
- Calls the <xref:System.Net.Sockets.Socket.ConnectAsync%2A?displayProperty=nameWithType> method with the `endPoint` instance as an argument.
- In a `while` loop:

  - Encodes and sends a message to the server using <xref:System.Net.Sockets.Socket.SendAsync%2A?displayProperty=nameWithType>.
  - Writes the sent message to the console.
  - Initializes a buffer to receive data from the server using <xref:System.Net.Sockets.Socket.ReceiveAsync%2A?displayProperty=nameWithType>.
  - When the `response` is an acknowledgment, it is written to the console and the loop is exited.

## Create a `Socket` server

:::code language="csharp" source="../snippets/socket/socket-server/Program.cs" id="socketserver":::

The preceding C# code:

- Instantiates a new `Socket` object with a given `endPoint` instances address family, the <xref:System.Net.Sockets.SocketType.Stream?displayProperty=nameWithType>, and <xref:System.Net.Sockets.ProtocolType.Tcp?displayProperty=nameWithType>.
- The `listener` calls the <xref:System.Net.Sockets.Socket.Bind%2A?displayProperty=nameWithType> method with the `endPoint` instance as an argument to associate the socket with the network address.
- The <xref:System.Net.Sockets.Socket.Listen?displayProperty=nameWithType> method is called to listen for incoming connections.
- The `listener` calls the <xref:System.Net.Sockets.Socket.AcceptAsync%2A?displayProperty=nameWithType> method to accept an incoming connection on the `handler` socket.
- In a `while` loop:

  - Calls <xref:System.Net.Sockets.Socket.ReceiveAsync%2A?displayProperty=nameWithType> to receive data from the client.
  - When the data is received, it's decoded and written to the console.
  - If the `response` message ends with `<|EOM|>`, an acknowledgment is sent to the client using the <xref:System.Net.Sockets.Socket.SendAsync%2A?displayProperty=nameWithType>.

## See also

- [Sockets in .NET](sockets-overview.md)
- [Networking in .NET](../overview.md)
