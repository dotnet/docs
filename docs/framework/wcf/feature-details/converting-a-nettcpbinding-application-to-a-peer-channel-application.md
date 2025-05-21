---
description: "Learn more about: Converting a NetTcpBinding Application to a Peer Channel Application"
title: "Converting a NetTcpBinding Application to a Peer Channel Application"
ms.date: "03/30/2017"
ms.assetid: d4137292-a923-4b8f-8594-42276f2d3ce2
ms.topic: concept-article
---
# Converting a NetTcpBinding Application to a Peer Channel Application

You can create connections between clients using the WinFX by using bindings that describe the parameters of the connection. Converting a .NET Framework application to use peer-to-peer connections requires a binding that supports this technology when making client connections. Peer Channel provides a binding called <xref:System.ServiceModel.NetPeerTcpBinding>, which you can use in a similar way to the <xref:System.ServiceModel.NetTcpBinding>. Key differences include specifying a resolver service and defining security settings.  
  
 If an application is using the default resolver and security settings, converting a normal client/server-based application to use Peer Channel entails changing the name of the binding from "NetTcpBinding" to "NetPeerTcpBinding" in the application’s configuration file—you do not have to change the application code base.  
  
## See also

- [Building a Peer Channel Application](building-a-peer-channel-application.md)
- [System-Provided Bindings](../system-provided-bindings.md)
