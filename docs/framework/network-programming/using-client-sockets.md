---
title: "Using Client Sockets"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application protocols, sockets"
  - "sending data, sockets"
  - "data requests, sockets"
  - "requesting data from Internet, sockets"
  - "receiving data, sockets"
  - "Socket class, client sockets"
  - "protocols, sockets"
  - "Internet, sockets"
  - "sockets, client sockets"
  - "client sockets"
ms.assetid: 81de9f59-8177-4d98-b25d-43fc32a98383
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Using Client Sockets
Before you can initiate a conversation through a <xref:System.Net.Sockets.Socket>, you must create a data pipe between your application and the remote device. Although other network address families and protocols exist, this example shows how to create a TCP/IP connection to a remote service.  
  
 TCP/IP uses a network address and a service port number to uniquely identify a service. The network address identifies a specific device on the network; the port number identifies the specific service on that device to connect to. The combination of network address and service port is called an endpoint, which is represented in the .NET Framework by the <xref:System.Net.EndPoint> class. A descendant of **EndPoint** is defined for each supported address family; for the IP address family, the class is <xref:System.Net.IPEndPoint>.  
  
 The <xref:System.Net.Dns> class provides domain-name services to applications that use TCP/IP Internet services. The <xref:System.Net.Dns.Resolve%2A> method queries a DNS server to map a user-friendly domain name (such as "host.contoso.com") to a numeric Internet address (such as 192.168.1.1). **Resolve** returns an <xref:System.Net.IPHostEntry> that contains a list of addresses and aliases for the requested name. In most cases, you can use the first address returned in the <xref:System.Net.IPHostEntry.AddressList%2A> array. The following code gets an <xref:System.Net.IPAddress> containing the IP address for the server host.contoso.com.  
  
```vb  
Dim ipHostInfo As IPHostEntry = Dns.Resolve("host.contoso.com")  
Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)  
```  
  
```csharp  
IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");  
IPAddress ipAddress = ipHostInfo.AddressList[0];  
```  
  
 The Internet Assigned Numbers Authority (Iana) defines port numbers for common services (for more information, see www.iana.org/assignments/port-numbers). Other services can have registered port numbers in the range 1,024 to 65,535. The following code combines the IP address for host.contoso.com with a port number to create a remote endpoint for a connection.  
  
```vb  
Dim ipe As New IPEndPoint(ipAddress, 11000)  
```  
  
```csharp  
IPEndPoint ipe = new IPEndPoint(ipAddress,11000);  
```  
  
 After determining the address of the remote device and choosing a port to use for the connection, the application can attempt to establish a connection with the remote device. The following example uses an existing **IPEndPoint** to connect to a remote device and catches any exceptions that are thrown.  
  
```vb  
Try  
    s.Connect(ipe)  
Catch ae As ArgumentNullException  
    Console.WriteLine("ArgumentNullException : {0}", _  
        ae.ToString())  
Catch se As SocketException  
    Console.WriteLine("SocketException : {0}", se.ToString())  
Catch e As Exception  
    Console.WriteLine("Unexpected exception : {0}", e.ToString())  
End Try  
```  
  
```csharp  
try {  
    s.Connect(ipe);  
} catch(ArgumentNullException ae) {  
    Console.WriteLine("ArgumentNullException : {0}", ae.ToString());  
} catch(SocketException se) {  
    Console.WriteLine("SocketException : {0}", se.ToString());  
} catch(Exception e) {  
    Console.WriteLine("Unexpected exception : {0}", e.ToString());  
}  
```  
  
## See Also  
 [Using a Synchronous Client Socket](../../../docs/framework/network-programming/using-a-synchronous-client-socket.md)  
 [Using an Asynchronous Client Socket](../../../docs/framework/network-programming/using-an-asynchronous-client-socket.md)  
 [How to: Create a Socket](../../../docs/framework/network-programming/how-to-create-a-socket.md)  
 [Sockets](../../../docs/framework/network-programming/sockets.md)
