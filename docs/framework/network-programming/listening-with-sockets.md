---
title: "Listening with Sockets"
description: Learn how to create a remote service, where a server socket opens a port on the network and waits for a client to connect to that port.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application protocols, sockets"
  - "sending data, sockets"
  - "sockets, listening with sockets"
  - "data requests, sockets"
  - "requesting data from Internet, sockets"
  - "receiving data, sockets"
  - "protocols, sockets"
  - "listening with sockets"
  - "Internet, sockets"
ms.topic: how-to
---
# Listening with Sockets

Listener or server sockets open a port on the network and then wait for a client to connect to that port. Although other network address families and protocols exist, this example shows how to create remote service for a TCP/IP network.  
  
 The unique address of a TCP/IP service is defined by combining the IP address of the host with the port number of the service to create an endpoint for the service. The <xref:System.Net.Dns> class provides methods that return information about the network addresses supported by the local network device. When the local network device has more than one network address, or if the local system supports more than one network device, the **Dns** class returns information about all network addresses, and the application must choose the proper address for the service. The Internet Assigned Numbers Authority (Iana) defines port numbers for common services; for more information, see [Service Name and Transport Protocol Port Number Registry](https://www.iana.org/assignments/port-numbers). Other services can have registered port numbers in the range 1,024 to 65,535.  
  
 The following example creates an <xref:System.Net.IPEndPoint> for a server by combining the first IP address returned by **Dns** for the host computer with a port number chosen from the registered port numbers range.  
  
```vb  
Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())  
Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)  
Dim localEndPoint As New IPEndPoint(ipAddress, 11000)  
```  
  
```csharp  
IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
IPAddress ipAddress = ipHostInfo.AddressList[0];  
IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);  
```  
  
 After the local endpoint is determined, the <xref:System.Net.Sockets.Socket> must be associated with that endpoint using the <xref:System.Net.Sockets.Socket.Bind%2A> method and set to listen on the endpoint using the <xref:System.Net.Sockets.Socket.Listen%2A> method. **Bind** throws an exception if the specific address and port combination is already in use. The following example demonstrates associating a **Socket** with an **IPEndPoint**.  
  
```vb  
Dim listener As New Socket(ipAddress.AddressFamily, _  
    SocketType.Stream, ProtocolType.Tcp)
listener.Bind(localEndPoint)  
listener.Listen(100)  
```  
  
```csharp  
Socket listener = new Socket(ipAddress.AddressFamily,
    SocketType.Stream, ProtocolType.Tcp);
listener.Bind(localEndPoint);  
listener.Listen(100);  
```  
  
 The **Listen** method takes a single parameter that specifies how many pending connections to the **Socket** are allowed before a server busy error is returned to the connecting client. In this case, up to 100 clients are placed in the connection queue before a server busy response is returned to client number 101.  
  
## See also

- [Using a Synchronous Server Socket](using-a-synchronous-server-socket.md)
- [Using an Asynchronous Server Socket](using-an-asynchronous-server-socket.md)
- [Using Client Sockets](using-client-sockets.md)
- [How to: Create a Socket](how-to-create-a-socket.md)
- [Sockets](sockets.md)
