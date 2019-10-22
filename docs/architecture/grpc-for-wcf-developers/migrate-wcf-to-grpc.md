---
title: Migrate a WCF solution to gRPC - gRPC for WCF Developers
description: How to migrate different types of WCF service to the equivalent in gRPC.
author: markrendle
ms.date: 09/02/2019
---

# Migrate a WCF solution to gRPC

This chapter will look at how to work with ASP.NET Core 3.0 gRPC projects and demonstrate migrating different types of WCF service to the gRPC equivalent:

- Create an ASP.NET Core 3.0 gRPC project.
- Simple Request-Reply operations to gRPC unary RPC.
- One-way operations to gRPC client streaming RPC.
- Full Duplex services to gRPC bidirectional streaming RPC.

There's also a comparison of using streaming services versus repeated fields for returning data sets, and the use of client libraries at the end of the chapter.

The sample WCF application is a minimal stub of a set of stock trading services, using the open-source Inversion of Control (IoC) container library called *Autofac* for dependency injection. It includes three services, one for each WCF service type. The services will be discussed in more detail in the following sections. The solutions can be downloaded from [dotnet-architecture/grpc-for-wcf-developers](https://github.com/dotnet-architecture/grpc-for-wcf-developers) on GitHub. The services use fake data to minimize external dependencies.

The samples include the WCF and gRPC implementations of each service.

>[!div class="step-by-step"]
>[Previous](ws-protocols.md)
>[Next](create-project.md)
