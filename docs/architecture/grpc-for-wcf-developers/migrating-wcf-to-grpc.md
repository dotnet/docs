---
title: Migrating from WCF to gRPC
description: gRPC for WCF Developers | How to migrate different types of WCF service to gRPC
author: markrendle
ms.date: 09/02/2019
---

# Migrating from WCF to gRPC

This chapter will look at how to convert different types of WCF service to the gRPC equivalent.

- Simple Request-Reply operations to gRPC Unary RPC
- One-way operations to gRPC Client Streaming RPC
- Full Duplex services to gRPC Bi-directional Streaming RPC

The sample WCF application is a minimal stub of set of Stock trading services, using the open-source IoC container library *Autofac* for dependency injection. It includes three services, one for each WCF service type. The services will be discussed in more detail in the following sections. The solution can be downloaded from [GitHub](https://github.com/somewhere/TraderSysWCF). The data for the services is faked to minimize external dependencies.

The completed gRPC application is available [here](https://github.com/somewhere/TraderSysGRPC).

>[!div class="step-by-step"]
<!-->[Next](create-grpc-project.md)-->
