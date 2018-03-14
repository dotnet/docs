---
title: "Socket Performance Enhancements in Version 3.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 225aa5f9-c54b-4620-ab64-5cd100cfd54c
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Socket Performance Enhancements in Version 3.5
The <xref:System.Net.Sockets.Socket?displayProperty=nameWithType> class has been enhanced in Version 3.5 for use by applications that use asynchronous network I/O to achieve the highest performance. A series of new classes have been added as part of a set of enhancements to the <xref:System.Net.Sockets.Socket> class that provide an alternative asynchronous pattern that can be used by specialized high-performance socket applications. These enhancements were specifically designed for network server applications that require high performance. An application can use the enhanced asynchronous pattern exclusively, or only in targeted hot areas of their application (when receiving large amounts of data, for example).  
  
## Class Enhancements  
 The main feature of these enhancements is the avoidance of the repeated allocation and synchronization of objects during high-volume asynchronous socket I/O. The Begin/End design pattern currently implemented by the <xref:System.Net.Sockets.Socket> class for asynchronous socket I/O requires a <xref:System.IAsyncResult?displayProperty=nameWithType> object be allocated for each asynchronous socket operation.  
  
 In the new <xref:System.Net.Sockets.Socket> class enhancements, asynchronous socket operations are described by reusable <xref:System.Net.Sockets.SocketAsyncEventArgs?displayProperty=nameWithType> class objects allocated and maintained by the application. High-performance socket applications know best the amount of overlapped socket operations that must be sustained. The application can create as many of the <xref:System.Net.Sockets.SocketAsyncEventArgs> objects that it needs. For example, if a server application needs to have 15 socket accept operations outstanding at all times to support incoming client connection rates, it can allocate 15 reusable <xref:System.Net.Sockets.SocketAsyncEventArgs> objects in advance for that purpose.  
  
 The pattern for performing an asynchronous socket operation with this class consists of the following steps:  
  
1.  Allocate a new <xref:System.Net.Sockets.SocketAsyncEventArgs> context object, or get a free one from an application pool.  
  
2.  Set properties on the context object to the operation about to be performed (the callback delegate method and data buffer, for example).  
  
3.  Call the appropriate socket method (xxxAsync) to initiate the asynchronous operation.  
  
4.  If the asynchronous socket method (xxxAsync) returns true in the callback, query the context properties for completion status.  
  
5.  If the asynchronous socket method (xxxAsync) returns false in the callback, the operation completed synchronously. The context properties may be queried for the operation result.  
  
6.  Reuse the context for another operation, put it back in the pool, or discard it.  
  
 The lifetime of the new asynchronous socket operation context object is determined by references in the application code and asynchronous I/O references. It is not necessary for the application to retain a reference to an asynchronous socket operation context object after it is submitted as a parameter to one of the asynchronous socket operation methods. It will remain referenced until the completion callback returns. However it is advantageous for the application to retain the reference to the context object so that it can be reused for a future asynchronous socket operation.  
  
## See Also  
 <xref:System.Net.Sockets.Socket?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.SendPacketsElement?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.SocketAsyncEventArgs?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.SocketAsyncOperation?displayProperty=nameWithType>  
 [Network Programming Samples](../../../docs/framework/network-programming/network-programming-samples.md)  
 [Socket Performance Technology Sample](http://go.microsoft.com/fwlink/?LinkID=179570)
