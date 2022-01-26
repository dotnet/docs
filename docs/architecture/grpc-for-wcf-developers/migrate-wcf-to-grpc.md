---
title: Migrate a WCF solution to gRPC - gRPC for WCF developers
description: How to migrate different types of WCF services to the equivalent in gRPC.
ms.date: 12/14/2021
---

# Migrate a WCF solution to gRPC

This chapter will describe how to work with ASP.NET Core 6.0 gRPC projects and demonstrate migrating different types of Windows Communication Foundation (WCF) services to the gRPC equivalent:

- Create an ASP.NET Core 6.0 gRPC project.
- Simple request-reply operations to gRPC unary RPC.
- One-way operations to gRPC client streaming RPC.
- Full-duplex services to gRPC bidirectional streaming RPC.

There's also a comparison of using streaming services versus repeated fields for returning datasets, and there's a discussion of the use of client libraries at the end of the chapter.

The sample WCF application is a minimal stub of a set of stock trading services. It uses the open-source Inversion of Control (IoC) container library called Autofac for dependency injection. It includes three services, one for each WCF service type. The services will be discussed in more detail in the following sections. You can download the solutions from [dotnet-architecture/grpc-for-wcf-developers](https://github.com/dotnet-architecture/grpc-for-wcf-developers) on GitHub. The services use fake data to minimize external dependencies.

The samples include the WCF and gRPC implementations of each service.

>[!div class="step-by-step"]
>[Previous](ws-protocols.md)
>[Next](create-project.md)
