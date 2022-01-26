---
title: Encryption and network security - gRPC for WCF Developers
description: Some notes on network security and encryption in gRPC
ms.date: 12/14/2021
---

# Encryption and network security

The network security model for Windows Communication Foundation (WCF) is extensive and complex. It includes transport-level security by using HTTPS or TLS-over-TCP, and message-level security by using the WS-Security specification to encrypt individual messages.

gRPC leaves secure networking to the underlying HTTP/2 protocol, which you can secure by using TLS certificates.

Web browsers insist on using TLS connections for HTTP/2, but most programmatic clients, including .NET's `HttpClient`, can use HTTP/2 over unencrypted connections.

For public APIs, you should always use TLS connections, and provide valid certificates for your services from a proper SSL authority. [LetsEncrypt](https://letsencrypt.org) provides free, automated SSL certificates, and most hosting infrastructure today supports the LetsEncrypt standard with common plug-ins or extensions.

For internal services across a corporate network, you should still consider using TLS to secure network traffic to and from your gRPC services.

If you need to use explicit TLS between services running in Kubernetes, consider using an in-cluster certificate authority and a certificate manager controller like [cert-manager](https://docs.cert-manager.io/en/latest/). You can then automatically assign certificates to services at deployment time.

>[!div class="step-by-step"]
>[Previous](channel-credentials.md)
>[Next](grpc-in-production.md)
