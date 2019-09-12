---
title: Migrate a WCF solution to gRPC - gRPC for WCF Developers
description: How to migrate different types of WCF service to the equivalent in gRPC
author: markrendle
ms.date: 09/02/2019
---

# Migrate a WCF solution to gRPC

This chapter will look at how to work with ASP.NET Core 3.0 gRPC projects, and demonstrate migrating different types of WCF service to the gRPC equivalent.

- Create an ASP.NET Core 3.0 gRPC project
- Simple Request-Reply operations to gRPC unary RPC
- One-way operations to gRPC client streaming RPC
- Full Duplex services to gRPC bi-directional Streaming RPC

There is also a comparison of using streaming services vs repeated fields for returning data sets, and the use of client libraries at the end of the chapter.

The sample WCF application is a minimal stub of a set of Stock trading services, using the open-source IoC container library *Autofac* for dependency injection. It includes three services, one for each WCF service type. The services will be discussed in more detail in the following sections. The solution can be downloaded from [GitHub](https://github.com/somewhere/TraderSysWCF). The data for the services is faked to minimize external dependencies.

The completed gRPC application is available [here](https://github.com/somewhere/TraderSysGRPC).

>[!div class="step-by-step"]
<!-->[Next](create-grpc-project.md)-->
