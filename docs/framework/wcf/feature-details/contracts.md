---
title: "Contracts"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WCF [WCF], contracts"
  - "contracts [WCF]"
  - "Windows Communication Foundation [WCF], contracts"
ms.assetid: c8364183-4ac1-480b-804a-c5e6c59a5d7d
---
# Contracts
This section shows you how to define and implement Windows Communication Foundation (WCF)contracts. A service contract specifies what an endpoint communicates to the outside world. At a more concrete level, it is a statement about a set of specific messages organized into basic message exchange patterns (MEPs), such as request/reply, one-way, and duplex. If a service contract is a logically related set of message exchanges, a service operation is a single message exchange. For example, a `Hello` operation must obviously accept one message (so the caller can announce the greeting) and may or may not return a message (depending upon the courtesy of the operation).  
  
 For more information about contracts and other core WCF concepts, see [Fundamental Windows Communication Foundation Concepts](../../../../docs/framework/wcf/fundamental-concepts.md). This topic focuses on understanding service contracts. For more information about how to build clients that use service contracts to connect to services, see [WCF Client Overview](../../../../docs/framework/wcf/wcf-client-overview.md). For more information about client channels, the client architecture, and other client issues, see [Clients](../../../../docs/framework/wcf/feature-details/clients.md).  
  
## Overview  
 This topic provides a high-level conceptual orientation to designing and implementing WCF services. Subtopics provide more detailed information about the specifics of designing and implementation. Before designing and implementing your WCF application, it is recommended that you:  
  
-   Understand what a service contract is, how it works, and how to create one.  
  
-   Understand that contracts state minimum requirements that run-time configuration or the hosting environment may not support.  
  
## Service Contracts  
 A service contract is a statement that provides information about:  
  
-   The grouping of operations in a service.  
  
-   The signature of the operations in terms of messages exchanged.  
  
-   The data types of these messages.  
  
-   The location of the operations.  
  
-   The specific protocols and serialization formats that are used to support successful communication with the service.  
  
 For example, a purchase order contract might have a `CreateOrder` operation that accepts an input of order information types and returns success or failure information, including an order identifier. It might also have a `GetOrderStatus` operation that accepts an order identifier and returns order status information. A service contract of this sort would specify:  
  
-   That the purchase order contract consisted of `CreateOrder` and `GetOrderStatus` operations.  
  
-   That the operations have specified input messages and output messages.  
  
-   The data that these messages can carry.  
  
-   Categorical statements about the communication infrastructure necessary to successfully process the messages. For example, these details include whether and what forms of security are required to establish successful communication.  
  
 To convey this kind of information to applications on other platforms (including non-Microsoft platforms), XML service contracts are publicly expressed in standard XML formats, such as [Web Services Description Language (WSDL)](https://go.microsoft.com/fwlink/?LinkId=87004) and [XML Schema (XSD)](https://go.microsoft.com/fwlink/?LinkId=87005), among others. Developers for many platforms can use this public contract information to create applications that can communicate with the service, both because they understand the language of the specification and because those languages are designed to enable interoperation by describing the public forms, formats, and protocols that the service supports. For more information about how WCF handles this kind of information, see [Metadata](../../../../docs/framework/wcf/feature-details/metadata.md).  
  
 Contracts can be expressed many ways, however, and while WSDL and XSD are excellent languages to describe services in an accessible way, they are difficult languages to use directly—in any case, they are merely descriptions of a service, not service contract implementations. Therefore, WCF applications use managed attributes, interfaces, and classes both to define the structure of and to implement a service.  
  
 The resulting contract defined in managed types can be converted (also called *exported*) as metadata—WSDL and XSD—when needed by clients or other service implementers, especially on other platforms. The result is a straightforward programming model that can be described using public metadata to any client application. The details of the underlying SOAP messages, such as the transportation and security-related information, can be left to WCF, which automatically performs the necessary conversions to and from the service contract type system to the XML type system.  
  
 For more information about designing contracts, see [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md). For more information about implementing contracts, see [Implementing Service Contracts](../../../../docs/framework/wcf/implementing-service-contracts.md).  
  
 In addition, WCF also provides the ability to develop service contracts entirely at the message level. For more information about developing service contracts at the message level, see [Using Message Contracts](../../../../docs/framework/wcf/feature-details/using-message-contracts.md). For more information about developing services in non-SOAP XML, see [Interoperability with POX Applications](../../../../docs/framework/wcf/feature-details/interoperability-with-pox-applications.md).  
  
### Understanding the Hierarchy of Requirements  
 A service contract groups the operations; specifies the MEP, message types, and data types those messages carry; and indicates categories of run-time behavior an implementation must have to support the contract (for example, it may require that messages be encrypted and signed). The service contract itself, however, does not specify precisely how these requirements are met, only that they must be. What type of encryption or how a message is signed is up to the implementation and configuration of a compliant service.  
  
 Notice the way that the contract requires certain things of the service contract implementation and the run-time configuration to add behavior. The set of requirements that must be met to expose a service for use builds on the preceding set of requirements. If a contract makes requirements of the implementation, an implementation can require yet more of the configuration and bindings that enable the service to run. Finally, the host application must also support any requirements that the service configuration and bindings add.  
  
 This additive requirement process is important to keep in mind while designing, implementing, configuring, and hosting your Windows Communication Foundation (WCF) service application. For example, the contract can specify that it needs to support a session. If so, then you must configure the binding to support that contractual requirement, or the service implementation will not work. Or if your service requires Integrated Windows authentication and is hosted in Internet Information Services (IIS), the Web application in which the service resides must have Integrated Windows authentication turned on and anonymous support turned off. For more information about the features and impact of the different service host application types, see [Hosting](../../../../docs/framework/wcf/feature-details/hosting.md).  
  
## See also
- [Endpoints: Addresses, Bindings, and Contracts](../../../../docs/framework/wcf/feature-details/endpoints-addresses-bindings-and-contracts.md)
- [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md)
- [Implementing Service Contracts](../../../../docs/framework/wcf/implementing-service-contracts.md)
