---
title: "Endpoints: Addresses, Bindings, and Contracts"
description: Learn how all communication with a WCF service occurs through the service endpoints, which provide clients access to the functionality offered by the service.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "endpoints [WCF]"
  - "Windows Communication Foundation [WCF], endpoints"
  - "WCF [WCF], endpoints"
ms.assetid: 9ddc46ee-1883-4291-9926-28848c57e858
---
# Endpoints: Addresses, Bindings, and Contracts

All communication with a Windows Communication Foundation (WCF) service occurs through the *endpoints* of the service. Endpoints provide clients access to the functionality offered by a WCF service.

Each endpoint consists of four properties:

- An address that indicates where the endpoint can be found.

- A binding that specifies how a client can communicate with the endpoint.

- A contract that identifies the operations available.

- A set of behaviors that specify local implementation details of the endpoint.

This topic discusses this endpoint structure and explains how it is represented in the WCF object model.

## The Structure of an Endpoint

Each endpoint consists of the following:

- Address: The address uniquely identifies the endpoint and tells potential consumers of the service where it is located. It is represented in the WCF object model by the <xref:System.ServiceModel.EndpointAddress> class. An <xref:System.ServiceModel.EndpointAddress> class contains:

  - A <xref:System.ServiceModel.EndpointAddress.Uri%2A> property, which represents the address of the service.

  - An <xref:System.ServiceModel.EndpointAddress.Identity%2A> property, which represents the security identity of the service and a collection of optional message headers. The optional message headers are used to provide additional and more detailed addressing information to identify or interact with the endpoint.

  For more information, see [Specifying an Endpoint Address](../specifying-an-endpoint-address.md).

- Binding: The binding specifies how to communicate with the endpoint. This includes:

  - The transport protocol to use (for example, TCP or HTTP).

  - The encoding to use for the messages (for example, text or binary).

  - The necessary security requirements (for example, SSL or SOAP message security).

  For more information, see [WCF Bindings Overview](../bindings-overview.md). A binding is represented in the WCF object model by the abstract base class <xref:System.ServiceModel.Channels.Binding>. For most scenarios, users can use one of the system-provided bindings. For more information, see [System-Provided Bindings](../system-provided-bindings.md).

- Contracts: The contract outlines what functionality the endpoint exposes to the client. A contract specifies:

  - What operations can be called by a client.

  - The form of the message.

  - The type of input parameters or data required to call the operation.

  - What type of processing or response message the client can expect.

  For more information about defining a contract, see [Designing Service Contracts](../designing-service-contracts.md).

- Behaviors: You can use endpoint behaviors to customize the local behavior of the service endpoint. Endpoint behaviors achieve this by participating in the process of building a WCF runtime. An example of an endpoint behavior is the <xref:System.ServiceModel.Description.ServiceEndpoint.ListenUri%2A> property, which allows you to specify a different listening address than the SOAP or Web Services Description Language (WSDL) address. For more information, see [ClientViaBehavior](../diagnostics/wmi/clientviabehavior.md).

## Defining Endpoints

You can specify the endpoint for a service either imperatively using code or declaratively through configuration. For more information, see [How to: Create a Service Endpoint in Configuration](how-to-create-a-service-endpoint-in-configuration.md) and [How to: Create a Service Endpoint in Code](how-to-create-a-service-endpoint-in-code.md).

## In This Section

This section explains the purpose of bindings, endpoints, and addresses; shows how to configure a binding and an endpoint; and demonstrates how to use the `ClientVia` behavior and `ListenUri` property.

[Addresses](endpoint-addresses.md)\
Describes how endpoints are addressed in WCF.

[Bindings](bindings.md)\
Describes how bindings are used to specify the transport, encoding, and protocol details required for clients and services to communicate with each other.

[Contracts](contracts.md)\
Describes how contracts define the methods of a service.

[How to: Create a Service Endpoint in Configuration](how-to-create-a-service-endpoint-in-configuration.md)\
Describes how to create a service endpoint in configuration.

[How to: Create a Service Endpoint in Code](how-to-create-a-service-endpoint-in-code.md)\
Describes how to create a service endpoint in code.

[How to: Use Svcutil.exe to Validate Compiled Service Code](how-to-use-svcutil-exe-to-validate-compiled-service-code.md)\
Describes how to detect errors in service implementations and configurations without hosting the service using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md).

## See also

- [Configuring Services](../configuring-services.md)
- [Extending Bindings](../extending/extending-bindings.md)
