---
title: "How to: Use Named Pipes for Network Interprocess Communication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "message-based communication [.NET Framework], named pipes"
  - "named pipes [.NET Framework]"
  - "pipes [.NET Framework]"
  - "multiple connections via named pipes"
  - "network communications [.NET Framework], named pipes"
  - "impersonation [.NET Framework], named pipes"
  - "full duplex communcation [.NET Framework], named pipes"
ms.assetid: 4e4d7e64-9f1b-4026-98f7-20488ac7b42b
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Use Named Pipes for Network Interprocess Communication
Named pipes provide interprocess communication between a pipe server and one or more pipe clients. They offer more functionality than anonymous pipes, which provide interprocess communication on a local computer. Named pipes support full duplex communication over a network and multiple server instances, message-based communication, and client impersonation, which enables connecting processes to use their own set of permissions on remote servers.  
  
 To implement name pipes, use the <xref:System.IO.Pipes.NamedPipeServerStream> and <xref:System.IO.Pipes.NamedPipeClientStream> classes.  
  
## Example  
 The following example demonstrates how to create a named pipe by using the <xref:System.IO.Pipes.NamedPipeServerStream> class. In this example, the server process creates four threads. Each thread can accept a client connection. The connected client process then supplies the server with a file name. If the client has sufficient permissions, the server process opens the file and sends its contents back to the client.  
  
 [!code-cpp[System.IO.Pipes.NamedPipeServerStream_ImpersonationSample1#01](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.IO.Pipes.NamedPipeServerStream_ImpersonationSample1/cpp/program.cpp#01)]
 [!code-csharp[System.IO.Pipes.NamedPipeServerStream_ImpersonationSample1#01](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.Pipes.NamedPipeServerStream_ImpersonationSample1/cs/Program.cs#01)]
 [!code-vb[System.IO.Pipes.NamedPipeServerStream_ImpersonationSample1#01](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.Pipes.NamedPipeServerStream_ImpersonationSample1/vb/program.vb#01)]  
  
## Example  
 The following example shows the client process, which uses the <xref:System.IO.Pipes.NamedPipeClientStream> class. The client connects to the server process and sends a file name to the server. The example uses impersonation, so the identity that is running the client application must have permission to access the file. The server then sends the contents of the file back to the client. The file contents are then displayed to the console.  
  
 [!code-csharp[System.IO.Pipes.NamedPipeClientStream_ImpersonationSample1#01](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.Pipes.NamedPipeClientStream_ImpersonationSample1/cs/Program.cs#01)]
 [!code-vb[System.IO.Pipes.NamedPipeClientStream_ImpersonationSample1#01](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.Pipes.NamedPipeClientStream_ImpersonationSample1/vb/program.vb#01)]  
  
## Robust Programming  
 The client and server processes in this example are intended to run on the same computer, so the server name provided to the <xref:System.IO.Pipes.NamedPipeClientStream> object is `"."`. If the client and server processes were on separate computers, `"."` would be replaced with the network name of the computer that runs the server process.  
  
## See Also  
 <xref:System.Security.Principal.TokenImpersonationLevel>  
 <xref:System.IO.Pipes.NamedPipeServerStream.GetImpersonationUserName%2A>  
 [Pipes](../../../docs/standard/io/pipe-operations.md)  
 [How to: Use Anonymous Pipes for Local Interprocess Communication](../../../docs/standard/io/how-to-use-anonymous-pipes-for-local-interprocess-communication.md)
