---
title: "Pipe Operations in .NET"
description: "Learn about pipe operations in .NET. Pipes provide a means for interprocess communication. There are two kinds of pipes: anonymous pipes and named pipes."
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "pipes [.NET]"
  - "pipe operations [.NET]"
  - "interprocess communication [.NET], pipes"
  - "I/O [.NET], pipes"
ms.assetid: 7b964ebd-7a4f-4d28-8194-7841f9e4c702
ms.topic: article
---
# Pipe Operations in .NET

Pipes provide a means for interprocess communication. There are two types of pipes:  
  
- Anonymous pipes.  
  
     Anonymous pipes provide interprocess communication on a local computer. Anonymous pipes require less overhead than named pipes but offer limited services. Anonymous pipes are one-way and cannot be used over a network. They support only a single server instance. Anonymous pipes are useful for communication between threads, or between parent and child processes where the pipe handles can be easily passed to the child process when it is created.  
  
     In .NET, you implement anonymous pipes by using the <xref:System.IO.Pipes.AnonymousPipeServerStream> and <xref:System.IO.Pipes.AnonymousPipeClientStream> classes.  
  
     See [How to: Use Anonymous Pipes for Local Interprocess Communication](how-to-use-anonymous-pipes-for-local-interprocess-communication.md).  
  
- Named pipes.  
  
     Named pipes provide interprocess communication between a pipe server and one or more pipe clients. Named pipes can be one-way or duplex. They support message-based communication and allow multiple clients to connect simultaneously to the server process using the same pipe name. Named pipes also support impersonation, which enables connecting processes to use their own permissions on remote servers.  
  
     In .NET, you implement named pipes by using the <xref:System.IO.Pipes.NamedPipeServerStream> and <xref:System.IO.Pipes.NamedPipeClientStream> classes.  
  
     See [How to: Use Named Pipes for Network Interprocess Communication](how-to-use-named-pipes-for-network-interprocess-communication.md).  
  
## See also

- [File and Stream I/O](index.md)
- [How to: Use Anonymous Pipes for Local Interprocess Communication](how-to-use-anonymous-pipes-for-local-interprocess-communication.md)
- [How to: Use Named Pipes for Network Interprocess Communication](how-to-use-named-pipes-for-network-interprocess-communication.md)
