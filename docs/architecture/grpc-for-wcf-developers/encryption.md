---
title: Encryption and network security - gRPC for WCF Developers
description: Some notes on network security and encryption in gRPC
author: markrendle
ms.date: 09/02/2019
---

# Encryption and network security

WCF's network security model is extensive and complex, including transport-level security using HTTPS or TLS-over-TCP, and message-level security using the WS-Security specification to encrypt individual messages.

gRPC massively simplifies secure networking by leaving it up to the underlying HTTP/2 implementation, which can be secured using regular SSL/TLS certificates.

Web browsers insist on using SSL/TLS connections for HTTP/2, but most programmatic clients, including .NET's `HttpClient`, can use HTTP/2 over unencrypted connections. `HttpClient` *does* require encryption by default, but you can override this using an AppContext switch.

```csharp
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
```

For public APIs, you should always use SSL/TLS connections and provide valid certificates for your services from a proper SSL authority. [LetsEncrypt](https://letsencrypt.org) provide free, automated SSL certificates, and most hosting infrastructure today supports the LetsEncrypt standard with common plug-ins or extensions.

For internal services across a corporate network, you should still consider using SSL/TLS to secure network traffic to and from your gRPC services.

Communication between microservices in a cluster like Kubernetes or Docker Swarm is generally automatically encrypted by the container networking layer, so implementing SSL/TLS in services running exclusively in such a cluster is not necessary. There will be more on this in the "Service Mesh" section of the next chapter.

>[!div class="step-by-step"]
<!-->[Next](grpc-in-production.md)-->
