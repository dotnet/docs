---
description: "Learn more about: Local Channel"
title: "Local Channel"
ms.date: "03/30/2017"
ms.assetid: fa1917a4-f701-4e82-a439-14a16282c7cc
---
# Local Channel

Local Channel is a Windows Communication Foundation (WCF) transport channel that is used for communication within the same application domain. This is useful for scenarios where the client and the service are running in the same application domain and the overhead of the typical WCF channel stack (serialization and deserialization of messages) must be avoided.

## Discussion

The [LocalChannel sample](https://github.com/dotnet/samples/tree/main/framework/wcf) consists of two project files:

- **LocalChannel**: The programmatic representation of the local channel within the current application domain. In this project, the sending component places the message in an in-memory queue and the receiving component de-queues the message to receive it.

- **ClientAndService**: This project hosts a service in a console application and then runs a client to call the service from within the same application domain.

The local channel design skips both the channel stack and the serialization process to increase speed. The local transport channel is implemented using a queue to transport service calls from the client to the service and to return back the value to the client. Rather than serializing parameters and return values, the sample copies the objects.

#### To set up, build, and run the sample

1. Build and run the LocalChannel solution.

2. The service host is started and the client calls the service using the local channel. A console window appears to display the results of the service call.
