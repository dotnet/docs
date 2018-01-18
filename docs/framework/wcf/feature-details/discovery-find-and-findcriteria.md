---
title: "Discovery Find and FindCriteria"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 99016fa4-1778-495b-b4cc-0e22fbec42c6
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery Find and FindCriteria
A discovery find operation is initiated by a client to discover one or more services and is one of the main actions in discovery. Performing a find sends a WS-Discovery Probe message over the network. Services that match the criteria specified reply with WS-Discovery ProbeMatch messages. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] discovery messages, see the [WS-Discovery specification](http://go.microsoft.com/fwlink/?LinkID=122347).  
  
## DiscoveryClient  
 The <xref:System.ServiceModel.Discovery.DiscoveryClient> class provides the mechanism to perform find operations and makes performing discovery client operations easy. It contains a <xref:System.ServiceModel.Discovery.DiscoveryClient.Find%2A> method, which performs a (blocking) synchronous find, and a <xref:System.ServiceModel.Discovery.DiscoveryClient.FindAsync%2A> method, which initiates a non-blocking asynchronous find. Both methods take a <xref:System.ServiceModel.Discovery.FindCriteria> parameter, and provide results to the user through a <xref:System.ServiceModel.Discovery.FindResponse> object.  
  
## FindCriteria  
 <xref:System.ServiceModel.Discovery.FindCriteria> has several properties, which can be grouped into search criteria, which specify what services you are looking for, and find termination criteria (how long the search should last). A <xref:System.ServiceModel.Discovery.FindCriteria> can contain multiple search criteria. By default, the service has to match all of the components otherwise it does not consider itself a matching service. If you want to find services that only match some of the criteria, you can implement custom find logic on the service or you can use multiple queries.  
  
 Search criteria include:  
  
-   <xref:System.ServiceModel.Discovery.Configuration.ContractTypeNameElement> - Optional. The contract name of the service being searched for and the criteria typically used when searching for a service. If more than one contract name is specified, only service endpoints matching ALL contracts reply. Note that in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] an endpoint can only support one contract.  
  
-   <xref:System.ServiceModel.Discovery.Configuration.ScopeElement> - Optional. Scopes are absolute URIs that are used to categorize individual service endpoints. You may want to use this in scenarios where multiple endpoints expose the same contract and you want a way to search for a subset of the endpoints. If more than one scope is specified, only service endpoints matching ALL scopes reply.  
  
-   <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchBy%2A> - Specifies the matching algorithm to use while matching the scopes in the Probe message with that of the endpoint. There are five supported scope-matching rules:  
  
    -   <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchByExact?displayProperty=nameWithType> does a basic case-sensitive string comparison.  
  
    -   <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchByPrefix?displayProperty=nameWithType> matches by segments separated by "/". A search for http://contoso/building1 matches a service with scope http://contoso/building/floor1. Note that it does not match http://contoso/building100 because the last two segments do not match.  
  
    -   <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchByLdap?displayProperty=nameWithType> matches scopes by segments using an LDAP URL.  
  
    -   <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchByUuid?displayProperty=nameWithType> matches scopes exactly using a UUID string.  
  
    -   <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchByNone?displayProperty=nameWithType> matches only those services that do not specify a scope.  
  
     If a scope-matching rule is not specified, <xref:System.ServiceModel.Discovery.FindCriteria.ScopeMatchByPrefix> is used.  
  
 Termination criteria include:  
  
1.  <xref:System.ServiceModel.Discovery.FindCriteria.Duration%2A> - The maximum time to wait for replies from services on the network. The default duration is 20 seconds.  
  
2.  <xref:System.ServiceModel.Discovery.FindCriteria.MaxResults%2A> - The maximum number of replies to wait for. If <xref:System.ServiceModel.Discovery.FindCriteria.MaxResults%2A> replies are received before <xref:System.ServiceModel.Discovery.FindCriteria.Duration%2A> has elapsed, the find operation ends.  
  
## FindResponse  
 <xref:System.ServiceModel.Discovery.FindResponse> has an <xref:System.ServiceModel.Discovery.FindResponse.Endpoints%2A> collection property that contains any replies sent by matching services on the network. If no services replied, the collection is empty. If one or more services replied, each reply is stored in an <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> object, which contains the address, contract, and some additional information about the service.  
  
 The following example shows how to perform a find operation in code.  
  
```  
// Create DiscoveryClient  
DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());  
  
// Create FindCriteria  
FindCriteria findCriteria = new FindCriteria(typeof(IPrinterService));  
findCriteria.Scopes.Add(new Uri("http://www.contoso.com/building1/floor1"));  
findCriteria.Duration = TimeSpan.FromSeconds(10);   
  
// Find ICalculatorService endpoints              
FindResponse findResponse = discoveryClient.Find(findCriteria);  
  
Console.WriteLine("Found {0} ICalculatorService endpoint(s).", findResponse.Endpoints.Count)  
```  
  
## See Also  
 [WCF Discovery Overview](../../../../docs/framework/wcf/feature-details/wcf-discovery-overview.md)  
 [Using the Discovery Client Channel](../../../../docs/framework/wcf/feature-details/using-the-discovery-client-channel.md)  
 [Discovery with Scopes](../../../../docs/framework/wcf/samples/discovery-with-scopes-sample.md)  
 [Asynchronous Find](../../../../docs/framework/wcf/samples/asynchronous-find-sample.md)  
 [Basic](../../../../docs/framework/wcf/samples/basic-sample.md)
