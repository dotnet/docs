---
title: Use TcpClient and TcpListener
description: Learn how to use the TcpClient class to create a socket to request and receive data using TCP in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/24/2022
helpviewer_keywords: 
  - "protocols, TCP"
  - "network resources, TCP"
  - "sending data, TCP"
  - "TCP"
  - "TcpClient class, about TcpClient class"
  - "application protocols, TCP"
  - "receiving data, TCP"
  - "TcpListener class, about TcpListener class"
  - "Socket class, about Socket class"
  - "data requests, TCP"
  - "requesting data from Internet, TCP"
  - "Internet, TCP"
---

# TCP overview

> [!IMPORTANT]
> The <xref:System.Net.Sockets.Socket> class is highly recommended for advanced users, instead of `TcpClient` and `TcpListener`.

To work with Transmission Control Protocol (TCP), you have two options: either use <xref:System.Net.Sockets.Socket> for maximum control and performance, or use the <xref:System.Net.Sockets.TcpClient> and <xref:System.Net.Sockets.TcpListener> helper classes. <xref:System.Net.Sockets.TcpClient> and <xref:System.Net.Sockets.TcpListener> are built on top of the <xref:System.Net.Sockets.Socket?displayProperty=nameWithType> class and take care of the details of transferring data for ease of use.

The protocol classes use the underlying `Socket` class to provide simple access to network services without the overhead of maintaining state information or knowing the details of setting up protocol-specific sockets. To use asynchronous `Socket` methods, you can use the asynchronous methods supplied by the <xref:System.Net.Sockets.NetworkStream> class. To access features of the `Socket` class not exposed by the protocol classes, you must use the `Socket` class.

`TcpClient` and `TcpListener` represent the network using the `NetworkStream` class. You use the <xref:System.Net.Sockets.TcpClient.GetStream%2A> method to return the network stream, and then call the stream's <xref:System.Net.Sockets.NetworkStream.ReadAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Sockets.NetworkStream.WriteAsync%2A?displayProperty=nameWithType> methods. The `NetworkStream` does not own the protocol classes' underlying socket, so closing it does not affect the socket.

## Use `TcpClient` and `TcpListener`

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

## Advanced TCP control with `Socket` class

`TcpListener` and `TcpClient` classes internal implementation relies on the `Socket` class. This means you can do everything with `Socket` that you can do with `TcpClient` and `TcpListener`.

### Create a client `Socket`

`TcpClient`'s default constructor tries to create a [_dual-stack socket_](<xref:System.Net.Sockets.Socket.DualMode>) via `[new Socket(SocketType, ProtocolType)](xref:System.Net.Sockets.Socket)` constructor, if [IPv6 is supported (Socket.OSSupportsIPv6 == true)](<xref:System.Net.Sockets.Socket.OSSupportsIPv6>). Otherwise, it fallbacks to IPv4 socket. Consider the following TCP client code:

```csharp
var client = new TcpClient();
```

The preceding TCP client code is functionally equivalent to the following socket code:

```csharp
var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
```

One of `TcpClient`'s constructor takes `AddressFamily` enum as a parameter. You can pass three different enum values to this constructor, otherwise, it throws an <xref:System.ArgumentException>. Valid enums are:

- `[AddressFamily.InterNetwork](xref:System.Net.Sockets.AddressFamily.InterNetwork)`: for IPv4 socket.
- `[AddressFamily.InterNetworkV6](xref:System.Net.Sockets.AddressFamily.InterNetworkV6)`: for IPv6 socket.
- `[AddressFamily.Unknown](xref:System.Net.Sockets.AddressFamily.Unknown)`: for dual-stack socket (by default, this enum value is used).

Consider the following TCP client code:

```csharp
var client = new TcpClient(AddressFamily.InterNetwork);
```

The preceding TCP client code is functionally equivalent to the following socket code:

```csharp
var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```

Other `TcpClient`'s constructor takes an <xref:System.Net.IPEndPoint> class as a parameter. This constructor accepts an `AddressFamily` from <xref:System.Net.IPEndPoint.AddressFamily> property and creates a `Socket`. As part of this, it calls <xref:System.Net.Sockets.Socket.Bind%2A> on the underlying `Socket` member with the given <xref:System.Net.IPEndPoint> argument. Consider the following TCP client code:

```csharp
// Example IPEndPoint object
var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
var client = new TcpClient(ep);
```

The preceding TCP client code is functionally equivalent to the following socket code:

```csharp
// Example IPEndPoint object
var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
var socket = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(ep);
```

Another `TcpClient` constructor overload accepts a `hostname` and `port` as parameters, the difference from the default constructor is that this constructor tries to connect to the given `hostname` and `port`. Consider the following TCP client code:

```csharp
var client = new TcpClient("www.example.com", 80);
```

The preceding TCP client code is functionally equivalent to the following socket code:

```csharp
var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
socket.Connect("www.example.com", 80);
```

## See also

- [Use Sockets to send and receive data over TCP](socket-services.md)
- [Networking in .NET](../overview.md)
- <xref:System.Net.Sockets.Socket>
- <xref:System.Net.Sockets.TcpClient>
- <xref:System.Net.Sockets.TcpListener>
- <xref:System.Net.Sockets.NetworkStream>
