---
title: Overview of gRPC - gRPC for WCF Developers
description: The set of principles guiding the development of gRPC.
author: markrendle
ms.date: 09/02/2019
---

# gRPC overview

Chapter 1 looked at the genesis of both WCF and gRPC. This chapter will consider some of the key features of gRPC and how they compare to WCF.

ASP.NET Core 3.0 is the first release of ASP.NET that natively supports gRPC as a first-class citizen, with the implementation contributed to the gRPC core project by Microsoft teams. It is recommended as the best approach for building distributed applications with .NET that can inter-operate with all other major programming languages and frameworks.

## Key principles

As discussed in Chapter one, Google wanted to utilize the introduction of HTTP/2 to rework Stubby, their internal, general purpose RPC infrastructure. Stubby, renamed gRPC, would now be able to take advantage of standardization and would extend its applicability to mobile computing, the Cloud and the Internet of Things.

In order to achieve this, the [Cloud Native Computing Foundation (CNCF)](https://www.cncf.io/) established a set of principles which would govern gRPC. The most relevant ones are covered below and are mainly concerned with maximizing access and usability.

- **Free and Open** – All artifacts should be open source with licensing that does not constrain developers from adopting gRPC.
- **Coverage and simplicity** – should be available across every popular platform and simple enough to build on any platform.
- **Interoperability and Reach** – it should be possible to use gRPC over any system, however slow, using widely available network standards.
- **General purpose and performant** – the framework should be usable by as broad a range of use-cases as possible without compromising performance.
- **Streaming** – provide streaming semantics for large data-sets or asynchronous messaging.
- **Metadata exchange** – allow non-business data, such as authentication tokens, to be handled separately from actual business data.
- **Standardized status codes** – reduce the variability of error codes to make error handling decisions clearer and, where additional richer error handling is required, ensure there is a mechanism for managing this within the metadata exchange.

>[!div class="step-by-step"]
<!-->[Next](approach.md)-->
