---
title: WCF endpoints and gRPC methods - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# WCF endpoints and gRPC methods

In WCF you write your application code in a class and decorate methods with the `OperationContract` attribute, or declare an interface for the service and add `OperationContract` attributes to the interface.

Chapter 3 showed that Protobuf message definitions are used to generate data classes. Service and method declarations are used to generate base classes that you inherit from to implement the service. You just declare the methods to be implemented in the .proto file, and the compiler generates a base class with virtual methods you must override.

## OperationContract properties

The `OperationContract` attribute has properties to control or refine how it works. gRPC methods don’t offer this type of control. The following table sets out those `OperationContract` properties and how the functionality they specify is (or isn’t) dealt with in gRPC.

| `OperationContract` property | gRPC                                             |
| ---------------------------- | ------------------------------------------------ |
| Action                       | SOAP-related, no meaning in gRPC                 |
| AsyncPattern                 | All gRPC service methods return Tasks            |
| HasProtectionLevel           | No message encryption; encryption handled at the transport layer (TLS over HTTP/2) |
| IsInitiating                 | See gRPC Streaming                               |
| IsOneWay                     | One-way gRPC methods return Empty results        |
| IsTerminating                | See gRPC Streaming                               |
| Name                         | SOAP-related, no meaning in gRPC                 |
| ProtectionLevel              | No message encryption; encryption handled at the transport layer (TLS over HTTP/2) |
| ReplyAction                  | SOAP-related, no meaning in gRPC                 |

See [chapter 6](authentication.md) for more information on gRPC security and encryption.

>[!div class="step-by-step"]
<!-->[Next](wcf-bindings.md)-->
