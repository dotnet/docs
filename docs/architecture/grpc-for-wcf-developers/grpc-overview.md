---
title: Overview of gRPC - gRPC for WCF Developers
description: Learn about the set of principles guiding the development of gRPC.
ms.date: 12/14/2021
---

# gRPC overview

After looking at the genesis of both Windows Communication Foundation (WCF) and gRPC in the last chapter, this chapter considers some of the key features of gRPC and how they compare to WCF.

ASP.NET Core 3.0 is the first release of ASP.NET that natively supports gRPC as a first-class citizen, with Microsoft teams contributing to the official .NET implementation of gRPC. It's recommended for building distributed applications with .NET that can interoperate with all other major programming languages and frameworks.

## Key principles

As discussed in chapter 1, Google wanted to use the introduction of HTTP/2 to replace Stubby, its internal, general purpose RPC infrastructure. gRPC, based on Stubby, now can take advantage of standardization and would extend its applicability to mobile computing, the cloud, and the Internet of Things.

To achieve this standardization, the [Cloud Native Computing Foundation (CNCF)](https://www.cncf.io/) established a set of principles that would govern gRPC. The following list shows the most relevant ones, which are primarily concerned with maximizing accessibility and usability:

- **Free and open** – All artifacts should be open source, with licensing that doesn't constrain developers from adopting gRPC.
- **Coverage and simplicity** – gRPC should be available across every popular platform, and simple enough to build on any platform.
- **Interoperability and reach** – It should be possible to use gRPC on any network, regardless of bandwidth or latency, by using widely available network standards.
- **General purpose and performant** – The framework should be usable by as broad a range of use-cases as possible, without compromising performance.
- **Streaming** – The protocol should provide streaming semantics for large datasets or asynchronous messaging.
- **Metadata exchange** – The protocol allows non-business data, such as authentication tokens, to be handled separately from actual business data.
- **Standardized status codes** – The variability of error codes should be reduced to make error handling decisions clearer. Where additional, richer error handling is required, a mechanism should be provided for managing behavior within the metadata exchange.

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](approach.md)
