---
title: Encryption and network security - gRPC for WCF Developers
description: Some notes on network security and encryption in gRPC
ms.date: 09/02/2019
---

# Encryption and network security

WCF's network security model is extensive and complex, including transport-level security using HTTPS or TLS-over-TCP, and message-level security using the WS-Security specification to encrypt individual messages.

gRPC leaves secure networking to the underlying HTTP/2 protocol, which can be secured using regular TLS certificates.

Web browsers insist on using TLS connections for HTTP/2, but most programmatic clients, including .NET's `HttpClient`, can use HTTP/2 over unencrypted connections. `HttpClient` *does* require encryption by default, but you can override this using an <xref:System.AppContext> switch.

```csharp
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
```

For public APIs, you should always use TLS connections and provide valid certificates for your services from a proper SSL authority. [LetsEncrypt](https://letsencrypt.org) provide free, automated SSL certificates, and most hosting infrastructure today supports the LetsEncrypt standard with common plug-ins or extensions.

For internal services across a corporate network, you should still consider using TLS to secure network traffic to and from your gRPC services.

Communication between microservices in a cluster like Kubernetes or Docker Swarm is in general automatically encrypted by the container networking layer, so implementing TLS in services running exclusively in such a cluster isn't necessary. There will be more on this subject in the "Service Mesh" section of the next chapter.

If you need to use explicit TLS between services running in Kubernetes, consider using an in-cluster Certificate Authority and a Certificate Manager Controller like [cert-manager](https://docs.cert-manager.io/en/latest/) to assign automatically certificates to services at deployment time.

>[!div class="step-by-step"]
>[Previous](channel-credentials.md)
>[Next](grpc-in-production.md)
