---
title: TCP in .NET
description: Learn how to use the TcpClient class to create a socket to request and receive data using TCP in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/19/2022
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

To establish a TCP connection, you must know the address of the network device hosting the service you need and you must know the TCP port that the service uses to communicate. The Internet Assigned Numbers Authority (IANA) defines port numbers for common services. For more information, see [Service name and transport protocol port number registry](https://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml). Services not on the IANA list can have port numbers in the range `1,024` to `65,535`.

The following example demonstrates setting up a `TcpClient` to connect to a time server on TCP port 13:

// CODE

<xref:System.Net.Sockets.TcpListener> is used to monitor a TCP port for incoming requests and then create either a **Socket** or a **TcpClient** that manages the connection to the client. The <xref:System.Net.Sockets.TcpListener.Start%2A> method enables listening, and the <xref:System.Net.Sockets.TcpListener.Stop%2A> method disables listening on the port. The <xref:System.Net.Sockets.TcpListener.AcceptTcpClient%2A> method accepts incoming connection requests and creates a **TcpClient** to handle the request, and the <xref:System.Net.Sockets.TcpListener.AcceptSocket%2A> method accepts incoming connection requests and creates a **Socket** to handle the request.

The following example demonstrates creating a network time server using a **TcpListener** to monitor TCP port 13. When an incoming connection request is accepted, the time server responds with the current date and time from the host server.

// CODE