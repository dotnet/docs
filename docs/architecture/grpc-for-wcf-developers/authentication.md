---
title: Authentication and Authorization
description: gRPC for WCF Developers | Authentication and Authorization
author: markrendle
ms.date: 09/02/2019
---

# Authentication and authorization

gRPC authentication works on two levels. Channel-level authentication is based on SSL/TLS certificates and is applied when the channel is opened. Call-level authentication is handled using tokens which are applied in metadata when the call is made. You can use either or both of these mechanisms to secure your service.

> [!NOTE]
> Because gRPC uses HTTP/2, which requires SSL/TLS, all traffic between clients and servers is already encrypted, even if you don't use channel-level authentication.

## Channel credentials

>[!div class="step-by-step"]
<!-->[Next](channel-credentials.md)-->
