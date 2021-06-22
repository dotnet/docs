---
description: "Learn more about: System.ServiceModel.Channels.TcpConnectError"
title: "System.ServiceModel.Channels.TcpConnectError"
ms.date: "03/30/2017"
ms.assetid: 22d93797-072e-405d-a3e0-5c519ddf290b
---
# System.ServiceModel.Channels.TcpConnectError

The TCP connect operation failed.  
  
## Description  

 This warning level trace indicates a failure to connect to a TCP endpoint. This could happen if the remote endpoint is not responding at a given IP address and port. This trace can be ignored if subsequent attempts to connect to other valid IP addresses (such as IPv4 or IPv6 addresses, or other IP addresses representing a given hostname) succeed. The exception within this trace can reveal additional information about the error.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
