---
title: "Sockets"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application protocols, sockets"
  - "sending data, sockets"
  - "data requests, sockets"
  - "Windows Sockets"
  - "sockets, about sockets"
  - "Socket class, about Socket class"
  - "sockets"
  - "requesting data from Internet, sockets"
  - "network, sockets"
  - "receiving data, sockets"
  - "protocols, sockets"
  - "Internet, sockets"
ms.assetid: 10d22735-bd37-42c1-a2be-c1932f979a7d
---
# Sockets
The <xref:System.Net.Sockets> namespace contains a managed implementation of the Windows Sockets interface. All other network-access classes in the <xref:System.Net> namespace are built on top of this implementation of sockets.  
  
 The .NET Framework <xref:System.Net.Sockets.Socket> class is a managed-code version of the socket services provided by the Winsock32 API. In most cases, the **Socket** class methods simply marshal data into their native Win32 counterparts and handle any necessary security checks.  
  
 The **Socket** class supports two basic modes, synchronous and asynchronous. In synchronous mode, calls to functions that perform network operations (such as <xref:System.Net.Sockets.Socket.Send%2A> and <xref:System.Net.Sockets.Socket.Receive%2A>) wait until the operation completes before returning control to the calling program. In asynchronous mode, these calls return immediately.  
  
## See also

- [How to: Create a Socket](how-to-create-a-socket.md)

- [Using Application Protocols](using-application-protocols.md)
