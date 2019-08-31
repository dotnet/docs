---
title: Migrating Duplex Services to gRPC
description: gRPC for WCF Developers | Migrating Duplex Services to gRPC
ms.date: 08/30/2019
---

## Duplex Services

There are multiple ways to use Duplex services in WCF. Some services are initiated by the client and then stream data from the server; other "Full Duplex" services might involve more ongoing two-way communication like the classic "Calculator" example from the WCF documentation. In this chapter we'll take two possible WCF "Stock Ticker" implementations and migrate them to gRPC, one using a Server-streaming RPC, and one a Bi-directional Streaming RPC.

>[!div class="step-by-step"]
<!-->[Next](grpc-overview.md)-->
