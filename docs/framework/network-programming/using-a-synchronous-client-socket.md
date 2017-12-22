---
title: "Using a Synchronous Client Socket"
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
  - "synchronous client sockets"
  - "Socket class, synchronous client sockets"
  - "receiving data, sockets"
  - "sockets, synchronous client sockets"
  - "protocols, sockets"
  - "Internet, sockets"
  - "client sockets"
ms.assetid: 945d00c6-7202-466c-9df9-140b84156d43
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Using a Synchronous Client Socket
A synchronous client socket suspends the application program while the network operation completes. Synchronous sockets are not suitable for applications that make heavy use of the network for their operation, but they can enable simple access to network services for other applications.  
  
 To send data, pass a byte array to one of the <xref:System.Net.Sockets.Socket> class's send-data methods (<xref:System.Net.Sockets.Socket.Send%2A> and <xref:System.Net.Sockets.Socket.SendTo%2A>). The following example encodes a string into a byte array buffer using the <xref:System.Text.Encoding.ASCII%2A?displayProperty=nameWithType> property and then transmits the buffer to the network device using the **Send** method. The **Send** method returns the number of bytes sent to the network device.  
  
```vb  
Dim msg As Byte() = _  
    System.Text.Encoding.ASCII.GetBytes("This is a test.")  
Dim bytesSent As Integer = s.Send(msg)  
```  
  
```csharp  
byte[] msg = System.Text.Encoding.ASCII.GetBytes("This is a test");  
int bytesSent = s.Send(msg);  
```  
  
 The **Send** method removes the bytes from the buffer and queues them with the network interface to be sent to the network device. The network interface might not send the data immediately, but it will send it eventually, as long as the connection is closed normally with the <xref:System.Net.Sockets.Socket.Shutdown%2A> method.  
  
 To receive data from a network device, pass a buffer to one of the **Socket** class's receive-data methods (<xref:System.Net.Sockets.Socket.Receive%2A> and <xref:System.Net.Sockets.Socket.ReceiveFrom%2A>). Synchronous sockets will suspend the application until bytes are received from the network or until the socket is closed. The following example receives data from the network and then displays it on the console. The example assumes that the data coming from the network is ASCII-encoded text. The **Receive** method returns the number of bytes received from the network.  
  
```vb  
Dim bytes(1024) As Byte  
Dim bytesRec = s.Receive(bytes)  
Console.WriteLine("Echoed text = {0}", _  
    System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRec))  
```  
  
```csharp  
byte[] bytes = new byte[1024];  
int bytesRec = s.Receive(bytes);  
Console.WriteLine("Echoed text = {0}",  
    System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRec));  
```  
  
 When the socket is no longer needed, you need to release it by calling the <xref:System.Net.Sockets.Socket.Shutdown%2A> method and then calling the **Close** method. The following example releases a **Socket**. The <xref:System.Net.Sockets.SocketShutdown> enumeration defines constants that indicate whether the socket should be closed for sending, for receiving, or for both.  
  
```vb  
s.Shutdown(SocketShutdown.Both)  
s.Close()  
```  
  
```csharp  
s.Shutdown(SocketShutdown.Both);  
s.Close();  
```  
  
## See Also  
 [Using an Asynchronous Client Socket](../../../docs/framework/network-programming/using-an-asynchronous-client-socket.md)  
 [Listening with Sockets](../../../docs/framework/network-programming/listening-with-sockets.md)  
 [Synchronous Client Socket Example](../../../docs/framework/network-programming/synchronous-client-socket-example.md)
