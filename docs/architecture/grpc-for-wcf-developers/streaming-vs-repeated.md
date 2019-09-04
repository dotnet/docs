---
title: Streaming vs Repeated
description: gRPC for WCF Developers | Streaming vs Repeated
author: markrendle
ms.date: 09/02/2019
---

# Streaming vs Repeated

gRPC services provide two ways of returning data-sets, or lists of objects. The Protocol Buffers message specification uses the `repeated` keyword for declaring lists or arrays of messages within another message. The gRPC service specification uses the `stream` keyword to declare a long-running persistent connection over which multiple messages are sent, and can be processed, individually. The `stream` feature can also be used for long-running temporal data such as notifications or log messages, but this chapter will consider its use for returning a single data-set.

Which you should use depends on various factors, such as the overall size of the data-set, the time taken to create the data-set at either the client or server end, and whether the consumer of the data-set is able to start acting on it as soon as the first item is available, or needs the complete data-set to do anything useful.

## When to use `repeated` fields

For any data-set which is constrained in size and which can be generated in its entirety in a short time&mdash;say, under one second&mdash;you should use a `repeated` field in a regular Protobuf message. For example, building a list of items within an order in an e-commerce system is likely to be very quick and the list will not be very large. Returning a single message with a `repeated` field is an order of magnitude faster than using a `stream`, and incurs less network overhead.

If the client will need all the data before starting to process it, and the data-set is small enough to construct in memory, then consider using a `repeated` field even if the generation of the data-set is slower.

## When to use `stream` methods

Data-sets where the message objects are potentially very large are best transferred using streaming requests or responses. It is more efficient to construct a large object in memory, write it to the network and then free up the resources; this will improve the scalability of your service.

Similarly, data-sets of unconstrained size should be sent over streams to avoid running out of memory while constructing them.

For data-sets where each individual item can be processed separately by the consumer, you should consider using a stream if this means progress can be indicated to the end user, improving the apparent responsiveness of an application, although obviously this should be balanced against the overall performance of the application.

Another scenario where streams can be very useful is where a message is being processed across multiple services. If each service in a chain returns a stream, then the terminal service (the last one in the chain) can start returning messages which can be processed and passed back along the chain to the original requestor, which can either return a stream or aggregate the results into a single response message. This approach lends itself well to patterns like Map/Reduce.

>[!div class="step-by-step"]
<!-->[Next](client-libraries.md)-->
