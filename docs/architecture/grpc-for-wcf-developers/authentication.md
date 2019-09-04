---
title: Authentication and Authorization
description: gRPC for WCF Developers | Authentication and Authorization
author: markrendle
ms.date: 09/02/2019
---

# Authentication and authorization

gRPC authentication works on two levels. Call-level authentication is usually handled using tokens which are applied in metadata when the call is made. Channel-level authentication adds Client Certificate authentication which is applied at the connection level, and can also include call-level authentication credentials to be applied to every call on the channel automatically. You can use either or both of these mechanisms to secure your service.

The ASP.NET Core implementation of gRPC supports authentication using most of the standard authentication mechanisms:

- Azure Active Directory
- Client Certificate
- IdentityServer
- JWT Token
- OAuth 2.0
- OpenID Connect
- WS-Federation

For more information see the [Authentication and authorization documentation on Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/grpc/authn-and-authz?view=aspnetcore-3.0).

> [!NOTE]
> When using gRPC over an SSL/TLS encrypted connection, all traffic between clients and servers is already encrypted, even if you don't use channel-level authentication.

## Channel credentials

>[!div class="step-by-step"]
<!-->[Next](channel-credentials.md)-->
