---
title: "How to: Use Named Pipes for Network Interprocess Communication"
description: See two examples of using named pipes for interprocess communication between a pipe server and one or more pipe clients in a network.
ms.date: "11/14/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "message-based communication [.NET], named pipes"
  - "named pipes [.NET]"
  - "pipes [.NET]"
  - "multiple connections via named pipes"
  - "network communications [.NET], named pipes"
  - "impersonation [.NET], named pipes"
  - "full duplex communication [.NET], named pipes"
---
# How to: Use named pipes for network interprocess communication

Named pipes provide interprocess communication between a pipe server and one or more pipe clients. They offer more functionality than anonymous pipes, which provide interprocess communication on a local computer. Named pipes support full duplex communication over a network and multiple server instances, message-based communication, and client impersonation. The permissions used for impersonation depend on the platform.

> [!CAUTION]
> On Windows, <xref:System.IO.Pipes.NamedPipeServerStream.RunAsClient*> impersonates the client using its access token, including group membership. On Linux and macOS, the method changes only the effective user ID to the client's user ID. The server process keeps its effective group ID and supplementary groups, so file access checks might grant access through server groups that the client lacks, or deny access that depends on the client's groups. The effective user ID change affects all threads in the process, not just the calling thread.
>
> Don't rely on `RunAsClient` alone as an authorization boundary on Linux and macOS. Consider all relevant authorization scopes, including groups and capabilities, and explicitly authorize operations before acting on client-supplied input, such as a file path. The server example in this article doesn't perform those authorization checks.

> [!IMPORTANT]
> .NET on Linux and macOS uses Unix Domain Sockets (UDS) for the implementation of these APIs.

> [!NOTE]
> Starting in .NET 11, when you create a <xref:System.IO.Pipes.NamedPipeServerStream> with <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> on Linux and macOS, the underlying socket file is set to mode `0600` (owner read/write only) at bind time. Previously, the socket file inherited permissions from the process umask. For more information, see [NamedPipeServerStream with PipeOptions.CurrentUserOnly tightens Unix socket file permissions](../../core/compatibility/core-libraries/11/namedpipeserverstream-unix-permissions.md).

 To implement name pipes, use the <xref:System.IO.Pipes.NamedPipeServerStream> and <xref:System.IO.Pipes.NamedPipeClientStream> classes.

## Example 1

 The following example demonstrates how to create a named pipe by using the <xref:System.IO.Pipes.NamedPipeServerStream> class. In this example, the server process creates four threads. Each thread can accept a client connection. The connected client process then supplies the server with a file name. The server process attempts to open the file and send its contents back to the client.

 [!code-csharp[System.IO.Pipes.NamedPipeServerStream_ImpersonationSample1#01](./snippets/how-to-use-named-pipes-for-network-interprocess-communication/csharp/NamedPipeServerStream_ImpersonationSample/Program.cs#01)]
 [!code-vb[System.IO.Pipes.NamedPipeServerStream_ImpersonationSample1#01](./snippets/how-to-use-named-pipes-for-network-interprocess-communication/vb/NamedPipeServerStream_ImpersonationSample/program.vb#01)]

## Example 2

 The following example shows the client process, which uses the <xref:System.IO.Pipes.NamedPipeClientStream> class. The client connects to the server process and sends a file name to the server. The server then sends the contents of the file back to the client, subject to the impersonation behavior described in the caution above. The file contents are then displayed to the console.

 [!code-csharp[System.IO.Pipes.NamedPipeClientStream_ImpersonationSample1#01](./snippets/how-to-use-named-pipes-for-network-interprocess-communication/csharp/NamedPipeClientStream_ImpersonationSample/Program.cs#01)]
 [!code-vb[System.IO.Pipes.NamedPipeClientStream_ImpersonationSample1#01](./snippets/how-to-use-named-pipes-for-network-interprocess-communication/vb//NamedPipeClientStream_ImpersonationSample/program.vb#01)]

## Robust Programming

 The client and server processes in this example are intended to run on the same computer, so the server name provided to the <xref:System.IO.Pipes.NamedPipeClientStream> object is `"."`. If the client and server processes were on separate computers, `"."` would be replaced with the network name of the computer that runs the server process.

## See also

- <xref:System.Security.Principal.TokenImpersonationLevel>
- <xref:System.IO.Pipes.NamedPipeServerStream.GetImpersonationUserName*>
- [Pipes](pipe-operations.md)
- [How to: Use Anonymous Pipes for Local Interprocess Communication](how-to-use-anonymous-pipes-for-local-interprocess-communication.md)
