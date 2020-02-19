---
title: Streaming services vs. repeated fields - gRPC for WCF Developers
description: Compare repeated fields to streaming services as ways of passing collections of data with gRPC.
ms.date: 09/02/2019
---

# gRPC streaming services versus repeated fields

gRPC services provide two ways of returning datasets, or lists of objects. The Protocol Buffers message specification uses the `repeated` keyword for declaring lists or arrays of messages within another message. The gRPC service specification uses the `stream` keyword to declare a long-running persistent connection over which multiple messages are sent, and can be processed, individually. The `stream` feature can also be used for long-running temporal data such as notifications or log messages, but this chapter will consider its use for returning a single dataset.

Which you should use depends on various factors, such as the overall size of the dataset, the time it took to create the dataset at either the client or server end, and whether the consumer of the dataset can start acting on it as soon as the first item is available, or needs the complete dataset to do anything useful.

## When to use `repeated` fields

For any dataset that is constrained in size and that can be generated in its entirety in a short time—say, under one second—you should use a `repeated` field in a regular Protobuf message. For example, in an e-commerce system, to build a list of items within an order is probably quick and the list won't be very large. Returning a single message with a `repeated` field is an order of magnitude faster than using a `stream` and incurs less network overhead.

If the client needs all the data before starting to process it and the dataset is small enough to construct in memory, then consider using a `repeated` field even if the actual creation of the dataset in memory on the server is slower.

## When to use `stream` methods

Datasets where the message objects are potentially very large are best transferred using streaming requests or responses. It's more efficient to construct a large object in memory, write it to the network and then free up the resources. This approach will improve the scalability of your service.

Similarly, datasets of unconstrained size should be sent over streams to avoid running out of memory while constructing them.

For datasets where each individual item can be processed separately by the consumer, you should consider using a stream if it means that progress can be indicated to the end user. This could improve the apparent responsiveness of an application, although this should be balanced against the overall performance of the application.

Another scenario where streams can be useful is where a message is being processed across multiple services. If each service in a chain returns a stream, then the terminal service (that is, the last one in the chain) can start returning messages that can be processed and passed back along the chain to the original requestor, which can either return a stream or aggregate the results into a single response message. This approach lends itself well to patterns like Map/Reduce.

>[!div class="step-by-step"]
>[Previous](migrate-duplex-services.md)
>[Next](client-libraries.md)
