---
title: "Tutorial: Get started with Windows Communication Foundation applications"
description: This tutorial provides an introduction for creating WCF applications. 
ms.date: 01/18/2019
helpviewer_keywords:
  - "WCF [WCF], get started"
  - "Windows Communication Foundation [WCF], get started"
  - "get started [WCF]"
ms.assetid: df939177-73cb-4440-bd95-092a421516a1
---
# Tutorial: Get started with Windows Communication Foundation applications
The following tutorial articles introduce you to the Windows Communication Foundation (WCF) programming experience. Working through these tutorials gives you an introductory understanding of the steps required to create WCF service and client applications. 

After you work through the sequence of articles in this tutorial, you'll have a running WCF service and a WCF client that calls the service. A service exposes one or more endpoints, each of which exposes one or more service operations. The *endpoint* of a service specifies the following information: 
- An address where you can find the service.
- A binding that contains the information that describes how a client must communicate with the service. 
- A contract that defines the functionality that the service provides to its clients.

The tutorials assume you're using Visual Studio as the development environment. If you're using another development environment, ignore the Visual Studio-specific instructions. 

For sample WCF applications that you can download and run, see [Windows Communication Foundation samples](samples/index.md). For an introduction to the samples, see [Getting started sample](samples/getting-started-sample.md).

For more in-depth information about creating services and clients, see [Basic WCF programming](basic-wcf-programming.md).

## Get started tutorials

The first three tutorials describe how to define a WCF service contract, how to implement it, and how to host it. The service that you create is self-hosted within a console application. You can also host services under Microsoft Internet Information Services (IIS). For more information, see [How to: Host a WCF Service in IIS](feature-details/how-to-host-a-wcf-service-in-iis.md). Although you use code to configure the service in the tutorial, you can also configure services within a configuration file. For more information, see [Configuring services using configuration files](configuring-services-using-configuration-files.md).

- [Tutorial: Define a service contract](how-to-define-a-wcf-service-contract.md)

    Create a WCF contract with a user-defined interface. This contract defines the functionality that the service exposes.

- [Tutorial: Implement a service contract](how-to-implement-a-wcf-contract.md)

    Implement a service contract. After you define a contract, you must implement it with a service class.

- [Tutorial: Host and run a basic service](how-to-host-and-run-a-basic-wcf-service.md)

    Configure an endpoint for the service and how host the service in a console application. For a service to become active, you must configure it and host it within a run-time environment. This environment creates the service and controls its context and lifetime.

The next two tutorials describe how to create, configure, and use a client application to call the operations the service exposes. Services publish metadata that define the information a client application needs to communicate with the service. Visual Studio automates the process of accessing this metadata and uses it to construct and configure the client application for the service. If decide not to use Visual Studio, you can instead use the [ServiceModel Metadata Utility tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) to construct and configure the client application for the service.

- [Tutorial: Create a client](how-to-create-a-wcf-client.md)

    Retrieve metadata that you use to create a WCF client proxy from a WCF service. You retrieve metadata by using Visual Studio to add a service reference. You specify the endpoint that the client uses to access the service.

- [Tutorial: Use a client](how-to-use-a-wcf-client.md)

    Use the WCF client proxy to call service operations.

## Reference

- <xref:System.ServiceModel.ServiceContractAttribute>
- <xref:System.ServiceModel.OperationContractAttribute>

## Related sections

- [Windows Communication Foundation samples](samples/index.md)
- [Basic programming lifecycle](basic-programming-lifecycle.md)

## See also

- [Conceptual overview](conceptual-overview.md)
- [Guide to the documentation](guide-to-the-documentation.md)
- [What is Windows Communication Foundation](whats-wcf.md)
- [WCF feature details](feature-details/index.md)