---
title: WCF endpoints and gRPC methods - gRPC for WCF developers
description: Comparison of WCF endpoints declared with ServiceContract and OperationContract attributes, and gRPC methods declared in Protobuf
ms.date: 09/02/2019
---

# WCF endpoints and gRPC methods

[!INCLUDE [download-alert](includes/download-alert.md)]

In Windows Communication Foundation (WCF), when you're writing your application code, you use one of the following methods:

- You write the application code in a class and decorate methods with the [OperationContract](xref:System.ServiceModel.OperationContractAttribute) attribute.
- You declare an interface for the service and add [OperationContract](xref:System.ServiceModel.OperationContractAttribute) attributes to the interface.

For example, the WCF equivalent of the `greet.proto` Greeter service might be written as follows:

```csharp
[ServiceContract]
public interface IGreeterService
{
    [OperationContract]
    string SayHello(string name);
}
```

Chapter 3 showed that Protobuf message definitions are used to generate data classes. Service and method declarations are used to generate base classes that you inherit from to implement the service. You just declare the methods to be implemented in the `.proto` file, and the compiler generates a base class with virtual methods that you must override.

## OperationContract properties

The [OperationContract](xref:System.ServiceModel.OperationContractAttribute) attribute has properties to control or refine how it works. gRPC methods don't offer this type of control. The following table lists those `OperationContract` properties and describes how the functionality that they specify is (or isn't) dealt with in gRPC:

| `OperationContract` property | gRPC                                             |
| ---------------------------- | ------------------------------------------------ |
| <xref:System.ServiceModel.OperationContractAttribute.Action>             | A URI identifies the operation. gRPC uses the name of `package`, `service`, and `rpc` from the `.proto` file. |
| <xref:System.ServiceModel.OperationContractAttribute.AsyncPattern>       | All gRPC service methods return `Task` objects. |
| <xref:System.ServiceModel.OperationContractAttribute.IsInitiating>       | See the paragraph after this table. |
| <xref:System.ServiceModel.OperationContractAttribute.IsOneWay>           | One-way gRPC methods return `Empty` results or use client streaming. |
| <xref:System.ServiceModel.OperationContractAttribute.IsTerminating>      | See the paragraph after this table. |
| <xref:System.ServiceModel.OperationContractAttribute.Name>               | This property is SOAP related and has no meaning in gRPC. |
| <xref:System.ServiceModel.OperationContractAttribute.ProtectionLevel>    | There's no message encryption. Network encryption is handled at the transport layer (TLS over HTTP/2). |
| <xref:System.ServiceModel.OperationContractAttribute.ReplyAction>        | This property is SOAP related and has no meaning in gRPC. |

The `IsInitiating` property lets you indicate that a method within [ServiceContract](xref:System.ServiceModel.ServiceContractAttribute) can't be the first method called as part of a session. The `IsTerminating` property causes the server to close the session after an operation is called (or the client, if the property is used on a callback client). In gRPC, streams are created by single methods and closed explicitly. See [gRPC streaming](rpc-types.md#grpc-streaming).

For more information on gRPC security and encryption, see [chapter 6](security.md).

>[!div class="step-by-step"]
>[Previous](wcf-services-to-grpc-comparison.md)
>[Next](wcf-bindings.md)
