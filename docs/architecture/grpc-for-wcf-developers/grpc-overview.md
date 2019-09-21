---
title: Overview of gRPC - gRPC for WCF Developers
description: Learn about the set of principles guiding the development of gRPC.
author: markrendle
ms.date: 09/02/2019
---

# gRPC overview

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

After looking at the genesis of both WCF and gRPC in the last chapter, this chapter will consider some of the key features of gRPC and how they compare to WCF.

ASP.NET Core 3.0 is the first release of ASP.NET that natively supports gRPC as a first-class citizen, with Microsoft teams contributing to the official .NET implementation of gRPC. It's recommended as the best approach for building distributed applications with .NET that can interoperate with all other major programming languages and frameworks.

## Key principles

As discussed in chapter 1, Google wanted to use the introduction of HTTP/2 to rework Stubby, its internal, general purpose RPC infrastructure. Stubby, renamed gRPC, now could take advantage of standardization and would extend its applicability to mobile computing, the cloud, and the Internet of Things.

To achieve this, the [Cloud Native Computing Foundation (CNCF)](https://www.cncf.io/) established a set of principles that would govern gRPC. The following list shows the most relevant ones, which are mainly concerned with maximizing accessibility and usability:

- **Free and open** – all artifacts should be open source with licensing that doesn't constrain developers from adopting gRPC.
- **Coverage and simplicity** – gRPC should be available across every popular platform and simple enough to build on any platform.
- **Interoperability and reach** – it should be possible to use gRPC on any network, regardless of bandwidth or latency, using widely available network standards.
- **General purpose and performant** – the framework should be usable by as broad a range of use-cases as possible without compromising performance.
- **Streaming** – the protocol should provide streaming semantics for large data-sets or asynchronous messaging.
- **Metadata exchange** – the protocol allow non-business data, such as authentication tokens, to be handled separately from actual business data.
- **Standardized status codes** – the variability of error codes should be reduced to make error handling decisions clearer and, where additional richer error handling is required, a mechanism should be provided for managing this within the metadata exchange.

>[!div class="step-by-step"]
<!-->[Next](approach.md)-->
