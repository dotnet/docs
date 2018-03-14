---
title: "Using a Synchronous Server Socket"
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
  - "synchronous server sockets"
  - "sending data, sockets"
  - "data requests, sockets"
  - "requesting data from Internet, sockets"
  - "server sockets"
  - "receiving data, sockets"
  - "Socket class, synchronous server sockets"
  - "protocols, sockets"
  - "sockets, synchronous server sockets"
  - "Internet, sockets"
ms.assetid: d1ce882e-653e-41f5-9289-844ec855b804
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Using a Synchronous Server Socket
Synchronous server sockets suspend the execution of the application until a connection request is received on the socket. Synchronous server sockets are not suitable for applications that make heavy use of the network in their operation, but they can be suitable for simple network applications.  
  
 After a <xref:System.Net.Sockets.Socket> is set to listen on an endpoint using the <xref:System.Net.Sockets.Socket.Bind%2A> and <xref:System.Net.Sockets.Socket.Listen%2A> methods, it is ready to accept incoming connection requests using the <xref:System.Net.Sockets.Socket.Accept%2A> method. The application is suspended until a connection request is received when the **Accept** method is called.  
  
 When a connection request is received, **Accept** returns a new **Socket** instance that is associated with the connecting client. The following example reads data from the client, displays it on the console, and echoes the data back to the client. The **Socket** does not specify any messaging protocol, so the string "\<EOF>" marks the end of the message data. It assumes that a **Socket** named `listener` has been initialized and bound to an endpoint.  
  
```vb  
Console.WriteLine("Waiting for a connection...")  
Dim handler As Socket = listener.Accept()  
Dim data As String = Nothing  
  
While True  
    bytes = New Byte(1024) {}  
    Dim bytesRec As Integer = handler.Receive(bytes)  
    data += Encoding.ASCII.GetString(bytes, 0, bytesRec)  
    If data.IndexOf("<EOF>") > - 1 Then  
        Exit While  
    End If  
End While  
  
Console.WriteLine("Text received : {0}", data)  
  
Dim msg As Byte() = Encoding.ASCII.GetBytes(data)  
handler.Send(msg)  
handler.Shutdown(SocketShutdown.Both)  
handler.Close()  
```  
  
```csharp  
Console.WriteLine("Waiting for a connection...");  
Socket handler = listener.Accept();  
String data = null;  
  
while (true) {  
    bytes = new byte[1024];  
    int bytesRec = handler.Receive(bytes);  
    data += Encoding.ASCII.GetString(bytes,0,bytesRec);  
    if (data.IndexOf("<EOF>") > -1) {  
        break;  
    }  
}  
  
Console.WriteLine( "Text received : {0}", data);  
  
byte[] msg = Encoding.ASCII.GetBytes(data);  
handler.Send(msg);  
handler.Shutdown(SocketShutdown.Both);  
handler.Close();  
```  
  
## See Also  
 [Using an Asynchronous Server Socket](../../../docs/framework/network-programming/using-an-asynchronous-server-socket.md)  
 [Synchronous Server Socket Example](../../../docs/framework/network-programming/synchronous-server-socket-example.md)  
 [Listening with Sockets](../../../docs/framework/network-programming/listening-with-sockets.md)
