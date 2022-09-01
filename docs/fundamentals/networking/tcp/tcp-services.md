---
title: Use TcpClient and TcpListener
description: Learn how the TcpClient and TcpListener classes handle TCP communication in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/24/2022
helpviewer_keywords:
  - "requesting data from Internet, TCP"
  - "receiving data, TCP"
  - "TcpClient class, about TcpClient class"
  - "data requests, TCP"
  - "application protocols, TCP"
  - "network resources, TCP"
  - "sending data, TCP"
  - "TCP"
  - "protocols, TCP"
  - "Internet, TCP"
---

# Use TcpClient and TcpListener

The <xref:System.Net.Sockets.TcpClient> class requests data from an internet resource using TCP. The methods and properties of `TcpClient` abstract the details for creating a <xref:System.Net.Sockets.Socket> for requesting and receiving data using TCP. Because the connection to the remote device is represented as a stream, data can be read and written with .NET Framework stream-handling techniques.

The TCP protocol establishes a connection with a remote endpoint and then uses that connection to send and receive data packets. TCP is responsible for ensuring that data packets are sent to the endpoint and assembled in the correct order when they arrive.

[!INCLUDE [ip-endpoint](../includes/ip-endpoint.md)]

## Create a `TcpClient`

The `TcpClient` class provides TCP services at a higher level of abstraction than the `Socket` class. `TcpClient` is used to create a client connection to a remote host. Knowing how to get an `IPEndPoint`, let's assume you have an `IPAddress` to pair with your desired port number. The following example demonstrates setting up a `TcpClient` to connect to a time server on TCP port 13:

:::code language="csharp" source="../snippets/tcp/tcp-client/Program.cs" id="tcpclient":::

The preceding C# code:

- Creates an `IPEndPoint` from a known `IPAddress` and port.
- Instantiate a new `TcpClient` object.
- Connects the `client` to the remote TCP time server on port 13 using <xref:System.Net.Sockets.TcpClient.ConnectAsync%2A?displayProperty=nameWithType>.
- Uses a <xref:System.Net.Sockets.NetworkStream> to read data from the remote host.
- Declares a read buffer of `1_024` bytes.
- Reads data from the `stream` into the read buffer.
- Writes the results as a string to the console.

Since the client knows that the message is small, the entire message can be read into the read buffer in one operation. With larger messages, or messages with an indeterminate length, the client should use the buffer more appropriately and read in a `while` loop.

> [!IMPORTANT]
> When sending and receiving messages, the <xref:System.Text.Encoding> should be known ahead of time to both server and client. For example, if the server communicates using <xref:System.Text.ASCIIEncoding> but the client attempts to use <xref:System.Text.UTF8Encoding>, the messages will be malformed.

## Create a `TcpListener`

The <xref:System.Net.Sockets.TcpListener> type is used to monitor a TCP port for incoming requests and then create either a `Socket` or a `TcpClient` that manages the connection to the client. The <xref:System.Net.Sockets.TcpListener.Start%2A> method enables listening, and the <xref:System.Net.Sockets.TcpListener.Stop%2A> method disables listening on the port. The <xref:System.Net.Sockets.TcpListener.AcceptTcpClientAsync%2A> method accepts incoming connection requests and creates a `TcpClient` to handle the request, and the <xref:System.Net.Sockets.TcpListener.AcceptSocketAsync%2A> method accepts incoming connection requests and creates a `Socket` to handle the request.

The following example demonstrates creating a network time server using a `TcpListener` to monitor TCP port 13. When an incoming connection request is accepted, the time server responds with the current date and time from the host server.

:::code language="csharp" source="../snippets/tcp/tcp-listener/Program.cs" id="tcplistener":::

The preceding C# code:

- Creates an `IPEndPoint` with <xref:System.Net.IPAddress.Any?displayProperty=nameWithType> and port.
- Instantiate a new `TcpListener` object.
- Calls the <xref:System.Net.Sockets.TcpListener.Start%2A> method to start listening on the port.
- Uses a `TcpClient` from the <xref:System.Net.Sockets.TcpListener.AcceptTcpClientAsync%2A> method to accept incoming connection requests.
- Encodes the current date and time as a string message.
- Uses a <xref:System.Net.Sockets.NetworkStream> to write data to the connected client.
- Writes the sent message to the console.
- Finally, calls the <xref:System.Net.Sockets.TcpListener.Stop%2A> method to stop listening on the port.

## See also

- [TCP in .NET](tcp-overview.md)
- [Networking in .NET](../overview.md)
- <xref:System.Net.Sockets.TcpClient>
- <xref:System.Net.Sockets.TcpListener>
- <xref:System.Net.Sockets.NetworkStream>
