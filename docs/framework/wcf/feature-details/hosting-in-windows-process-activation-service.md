---
title: "Hosting in Windows Process Activation Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "hosting services [WCF], WAS"
ms.assetid: d2b9d226-15b7-41fc-8c9a-cb651ac20ecd
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting in Windows Process Activation Service
The Windows Process Activation Service (WAS) manages the activation and lifetime of the worker processes that contain applications that host [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services. The WAS process model generalizes the [!INCLUDE[iis601](../../../../includes/iis601-md.md)] process model for the HTTP server by removing the dependency on HTTP. This allows [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services to use both HTTP and non-HTTP protocols, such as Net.TCP, in a hosting environment that supports message-based activation and offers the ability to host a large number of applications on a given machine.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] building a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that runs in the WAS hosting environment, see [How to: Host a WCF Service in WAS](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-was.md).  
  
 The WAS process model provides several features that enable applications to be hosted in a way that is more robust, more manageable, and that uses resources efficiently:  
  
-   Message-based activation of applications and worker process applications start and stop dynamically in response to incoming work items that arrive using HTTP and non-HTTP network protocols.  
  
-   Robust application and worker process recycling to maintain the health of running applications.  
  
-   Centralized application configuration and management.  
  
-   Allows applications to take advantage of the IIS process model without requiring the deployment footprint of a full IIS installation.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] WAS features, see [IIS 7.0 Beta: IIS 7.0 Web Administration](../../../../docs/framework/wcf/feature-details/hosting-in-windows-process-activation-service.md).  
  
 [Windows Server AppFabric](http://go.microsoft.com/fwlink/?LinkId=196496) works with [!INCLUDE[iisver](../../../../includes/iisver-md.md)] and Windows Process Activation Service (WAS) to provide a rich application hosting environment for NET4 WCF and WF services. These benefits include process life-cycle management, process recycling, shared hosting, rapid failure protection, process orphaning, on-demand activation, and health monitoring. For detailed information, see [AppFabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=196494) and [AppFabric Hosting Concepts](http://go.microsoft.com/fwlink/?LinkId=196495).  
  
## Elements of the WAS Addressing Model  
 Applications have Uniform Resource Identifier (URI) addresses, which are the code units whose lifetime and execution environment are managed by the server. A single WAS server instance can be home to many different applications. Servers organize applications into groups called *sites*. Within a site, applications are arranged in a hierarchical manner that reflects the structure of the URIs that serve as their external addresses.  
  
 Application addresses have two parts: a base URI prefix and an application-specific, relative address (path), which provide the external address for an application when joined together. The base URI prefix is constructed from the site binding and is used for all the applications under the site. Application addresses are then constructed by taking application-specific path fragments (such as, "/applicationOne") and appending them to the base URI prefix (for example, "net.tcp://localhost") to arrive at the full application URI.  
  
 The following table illustrates several possible addressing scenarios for WAS sites with both HTTP and non-HTTP site bindings.  
  
|Scenario|Site bindings|Application path|Base application URIs|  
|--------------|-------------------|----------------------|---------------------------|  
|HTTP Only|http: *:80:\*|/appTwo|http://localhost/appTwo/|  
|Both HTTP and Non-HTTP|http: *:80:\*<br /><br /> net.tcp: 808:\*|/appTwo|http://localhost/appTwo/<br />net.tcp://localhost/appTwo/|  
|Non-HTTP only|net.pipe: *|/appThree|net.pipe://appThree/|  
  
 Services and resources within an application can also be addressed. Within an application, application resources are addressed relative to the base application path. For example, assume that a site on a machine name contoso.com has site bindings for both the HTTP and Net.TCP protocols. Also assume that the site contains one application located at /Billing, which exposes a service at GetOrders.svc. Then, if the GetOrders.svc service exposed an endpoint with a relative address of SecureEndpoint, the service endpoint would be exposed at the following two URIs:  
  
 http://contoso.com/Billing/GetOrders.svc/SecureEndpoint  
net.tcp://contoso.com/Billing/GetOrders.svc/SecureEndpoint  
  
## The WAS Runtime  
 Applications are organized into sites for the purposes of addressing and management. At run time, applications are also grouped together into application pools. An application pool can house many different applications from many different sites. All of the applications inside an application pool share a common set of run-time characteristics. For example, they all run under the same version of the common language runtime (CLR) and they all share a common process identity. Each application pool corresponds to an instance of a worker process (w3wp.exe). Each managed application running inside of a shared application pool is isolated from other applications by means of a CLR AppDomain.  
  
## See Also  
 [WAS Activation Architecture](../../../../docs/framework/wcf/feature-details/was-activation-architecture.md)  
 [Configuring WAS for Use with WCF](../../../../docs/framework/wcf/feature-details/configuring-the-wpa--service-for-use-with-wcf.md)  
 [How to: Install and Configure WCF Activation Components](../../../../docs/framework/wcf/feature-details/how-to-install-and-configure-wcf-activation-components.md)  
 [How to: Host a WCF Service in WAS](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-was.md)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
