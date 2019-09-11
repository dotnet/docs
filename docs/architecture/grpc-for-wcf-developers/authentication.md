---
title: Security in gRPC applications - gRPC for WCF developers
description: Overview of call and channel authentication and authorization in gRPC
author: markrendle
ms.date: 09/02/2019
---

# Security in gRPC applications

## NOTE ON WCF AUTHENTICATION

## gRPC authentication

gRPC authentication works on two levels. Call-level authentication is usually handled using tokens which are applied in metadata when the call is made. Channel-level authentication uses a client certificate which is applied at the connection level, and can also include call-level authentication credentials to be applied to every call on the channel automatically. You can use either or both of these mechanisms to secure your service.

The ASP.NET Core implementation of gRPC supports authentication using most of the standard authentication mechanisms:

- Call authentication
  - Azure Active Directory
  - IdentityServer
  - JWT Bearer Token
  - OAuth 2.0
  - OpenID Connect
  - WS-Federation
- Channel authentication
  - Client Certificate

The call authentication methods are all based on *tokens*; the only real difference is how the token is generated and the libraries used to validate the tokens in the ASP.NET Core service.

For more information see the [Authentication and authorization documentation on Microsoft Docs](https://docs.microsoft.com/aspnet/core/grpc/authn-and-authz?view=aspnetcore-3.0).

> [!NOTE]
> When using gRPC over an SSL/TLS encrypted connection, all traffic between clients and servers is already encrypted, even if you don't use channel-level authentication.

This chapter will show how to apply call credentials and channel credentials to a gRPC service, and how to use credentials from a .NET Core gRPC client to authenticate with the service.

>[!div class="step-by-step"]
<!-->[Next](call-credentials.md)-->
