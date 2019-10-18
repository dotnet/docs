---
title: "Configuring WCF services"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "configuration [WCF]"
ms.assetid: beac771e-f28e-4f84-9ff1-ad9251c726d3
---
# Configuring WCF services

Once you have designed and implemented your service contract, you are ready to configure your service. This is where you define and customize how your service is exposed to clients, including specifying the address where it can be found, the transport and message encoding it uses to send and receive messages, and the type of security it requires.  
  
 Configuration as used here includes all the ways, imperatively in code or by using a configuration file, in which you can define and customize the various aspects of a service, such as specifying its endpoint addresses, the transports used, and its security schemes. In practice, writing configuration is a major part of programming WCF applications.  
  
## In This Section  
 [Simplified Configuration](simplified-configuration.md)  
 Starting with [!INCLUDE[netfx40_long](../../../includes/netfx40-long-md.md)], WCF comes with a new default configuration model that simplifies WCF configuration requirements. If you do not provide any WCF configuration for a particular service, the runtime automatically configures your service with default endpoints, bindings, and behaviors.  
  
 [Configuring Services Using Configuration Files](configuring-services-using-configuration-files.md)  
 A Windows Communication Foundation (WCF) service is configurable using the .NET Framework configuration technology. Most commonly, XML elements are added to the Web.config file for an Internet Information Services (IIS) site that hosts a WCF service. The elements allow you to change details, such as the endpoint addresses (the actual addresses used to communicate with the service) on a machine-by-machine basis.  
  
 [Bindings](bindings.md)  
 In addition, WCF includes several system-provided common configurations in the form of bindings that allow you to quickly select the most basic features for how a client and service communicate, such as the transports, security, and message encodings used.  
  
 [Endpoints](endpoints.md)  
 All communication with a WCF service occurs through the *endpoints* of the service. Endpoints contain the contract, the configuration information that is specified in the bindings, and the addresses that indicate where to find the service or where to obtain information about the service.  
  
 [Securing Services](securing-services.md)  
 Using WCF and existing security mechanisms, you can implement confidentiality, integrity, authentication, and authorization into any service. You can also audit for security successes and failures.  
  
 [Creating WS-I Basic Profile 1.1 Interoperable Services](./creating-ws-i-basic-profile-1-1-interoperable-services.md)  
 The requirements for deploying a service that is interoperable with services and clients on any other platform or operating system are outlined in the WS-I Basic Profile 1.1 specification.  
  
## Reference  
 <xref:System.ServiceModel>  
  
 <xref:System.ServiceModel.Channels>  
  
 <xref:System.ServiceModel.Description>  
  
## Related Sections  
 [Basic Programming Lifecycle](basic-programming-lifecycle.md)  
  
 [Designing and Implementing Services](designing-and-implementing-services.md)  
  
 [Hosting Services](hosting-services.md)  
  
 [Building Clients](building-clients.md)  
  
 [Introduction to Extensibility](introduction-to-extensibility.md)  
  
 [Administration and Diagnostics](./diagnostics/index.md)  
  
## See also

- [Basic WCF Programming](basic-wcf-programming.md)
- [Conceptual Overview](conceptual-overview.md)
- [WCF Feature Details](./feature-details/index.md)
