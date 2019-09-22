---
title: Security in gRPC applications - gRPC for WCF developers
description: Overview of call and channel authentication and authorization in gRPC.
author: markrendle
ms.date: 09/02/2019
---

# Security in gRPC applications

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

In any real-world scenario, securing applications and services is essential. Security covers three key areas: encrypting network traffic to prevent it from being intercepted by bad actors; authenticating clients and servers to establish identity and trust; and authorizing clients to control access to systems and apply permissions based on identity.

> [!NOTE]
> **Authentication** is concerned with establishing the identity of a client or server. **Authorization** is concerned with determining whether a client has permission to access a resource or issue a command.

This chapter will cover the facilities for authentication and authorization in gRPC for ASP.NET Core, and discuss network security using TLS encrypted connections.

## WCF authentication and authorization

In WCF, authentication and authorization were handled in different ways depending on the transports and bindings being used. WCF supported various WS-\* security standards, as well as Windows authentication for HTTP services running in IIS or NetTCP services between Windows systems.

## gRPC authentication and authorization

gRPC authentication and authorization works on two levels. Call-level authentication/authorization is usually handled using tokens that are applied in metadata when the call is made. Channel-level authentication uses a client certificate that is applied at the connection level, and can also include call-level authentication/authorization credentials to be applied to every call on the channel automatically. You can use either or both of these mechanisms to secure your service.

The ASP.NET Core implementation of gRPC supports authentication and authorization using most of the standard ASP.NET Core mechanisms:

- Call authentication
  - Azure Active Directory
  - IdentityServer
  - JWT Bearer Token
  - OAuth 2.0
  - OpenID Connect
  - WS-Federation
- Channel authentication
  - Client Certificate

The call authentication methods are all based on *tokens*. The only real difference is how the token is generated and the libraries that are used to validate the tokens in the ASP.NET Core service.

For more information, see the [Authentication and authorization documentation on Microsoft Docs](https://docs.microsoft.com/aspnet/core/grpc/authn-and-authz?view=aspnetcore-3.0).

> [!NOTE]
> When using gRPC over a TLS-encrypted HTTP/2 connection, all traffic between clients and servers is encrypted, even if you don't use channel-level authentication.

This chapter will show how to apply call credentials and channel credentials to a gRPC service, and how to use credentials from a .NET Core gRPC client to authenticate with the service.

>[!div class="step-by-step"]
>[Previous](client-libraries.md)
>[Next](call-credentials.md)
