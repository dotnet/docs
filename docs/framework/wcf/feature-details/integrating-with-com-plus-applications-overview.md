---
title: "Integrating with COM+ Applications Overview"
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
  - "Windows Communication Foundation, COM+ integration"
  - "WCF, COM+ integration"
ms.assetid: e481e48f-7096-40eb-9f20-7f0098412941
caps.latest.revision: 29
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Integrating with COM+ Applications Overview
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a rich environment for creating distributed applications. If you are already using component-based application logic hosted in COM+, you can use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to extend your existing logic rather than having to rewrite it. A common scenario is when you want to expose existing COM+ or Enterprise Services business logic through Web Services.  
  
 When an interface on a COM+ component is exposed as a Web service, the specification and contract of these services are determined by an automatic mapping that is performed at application initialization time. The following list shows the conceptual model for this mapping:  
  
-   One service is defined for each exposed COM class.  
  
-   The contract for the service is derived directly from the selected component's interface definition with the possibility of method exclusion defined in configuration.  
  
-   The operations in that contract are derived directly from the methods on the component's interface definition.  
  
-   The parameters for those operations are derived directly from the COM interoperability type that corresponds to the component's method parameters.  
  
 Default addresses and transport bindings for the service are provided in a service configuration file, but these can be reconfigured as required.  
  
> [!NOTE]
>  The contracts for the exposed Web services remain constant as long as the COM+ interfaces and configuration remain unchanged. A modification to several interfaces does not automatically update the available services and requires re-running the COM+ Service Model Configuration tool (ComSvcConfig.exe).  
  
 The authentication and authorization requirements of the COM+ application and its components continue to be enforced when used as a Web service.  
  
 If the caller initiates a Web service transaction, components marked as transactional enlist within that transaction scope.  
  
 The following steps are required to expose a COM+ component's interface as a Web service without modifying the component:  
  
1.  Determine whether the COM+ component's interface can be exposed as a Web service.  
  
2.  Select an appropriate hosting mode.  
  
3.  Use the COM+ Service Model Configuration tool (ComSvcConfig.exe) to add a Web service for the interface. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to use ComSvcConfig.exe, see [How to: Use the COM+ Service Model Configuration Tool](../../../../docs/framework/wcf/feature-details/how-to-use-the-com-service-model-configuration-tool.md).  
  
4.  Configure any additional service settings in the application configuration file. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to configure a component, see [How to: Configure COM+ Service Settings](../../../../docs/framework/wcf/feature-details/how-to-configure-com-service-settings.md).  
  
## Supported Interfaces  
 There are some restrictions on the type of interfaces that can be exposed as a Web service. The following types of interfaces are not supported:  
  
-   Interfaces that pass object references as parameters - the following limited object reference approach is described in the Limited Object Reference Support section.  
  
-   Interfaces that pass types that are not compatible with the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] COM interoperability conversions.  
  
-   Interfaces for applications that have application pooling enabled when hosted by COM+.  
  
-   Interfaces of components that are marked as private to the application.  
  
-   COM+ infrastructure interfaces.  
  
-   Interfaces from the system application.  
  
-   Interfaces from Enterprise Services components that have not been added to the global assembly cache.  
  
### Limited Object Reference Support  
 Because a number of deployed COM+ components do use objects by reference parameters, such as returning an ADO Recordset object, COM+ integration includes limited support for object reference parameters. The support is limited to objects that implement the `IPersistStream` COM interface. This includes ADO Recordset objects and can be implemented for application specific COM objects.  
  
 To enable this support, the ComSvcConfig.exe tool provides the **allowreferences** switch that disables the regular method signature parameter and checks that the tool runs to ensure that object reference parameters are not being used. In addition, the object types that you pass as parameters must be named and identified within the <`persistableTypes`> configuration element that is a child of the <`comContract`> element.  
  
 When this feature is used, the COM+ integration service uses the `IPersistStream` interface to serialize or deserialize the object instance. If the object instance does not support `IPersistStream`, an exception is thrown.  
  
 Within a client application, the methods on the <xref:System.ServiceModel.ComIntegration.PersistStreamTypeWrapper> object can be used to pass an object in to a service and similarly to retrieve an object.  
  
> [!NOTE]
>  Due to the custom and platform-specific nature of the serialization approach, this is best suited for use between [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services.  
  
## Selecting the Hosting Mode  
 COM+ exposes Web services in one of the following hosting modes:  
  
-   COM+-hosted  
  
     The Web service is hosted within the application's dedicated COM+ server process (Dllhost.exe). This mode requires the application to be explicitly started before it can receive Web service requests. The COM+ options "Run as an NT Service" or "Leave running when idle" can be used to prevent idle shutdown of the application and its services. This mode provides both Web service and DCOM access to the server application.  
  
-   Web-hosted  
  
     The Web service is hosted within a Web server worker process. This mode does not require COM+ to be active when the initial request is received. If the application is not active when this request is received, it is automatically activated prior to processing the request. This mode also provides both Web service and DCOM access to the server application, but causes a process hop for Web service requests. This typically requires the client to enable impersonation. In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], this can be done with the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> property of the <xref:System.ServiceModel.Security.WindowsClientCredential> class, which is accessed as a property of the generic <xref:System.ServiceModel.ChannelFactory%601> class, as well as the <xref:System.Security.Principal.TokenImpersonationLevel.Impersonation> enumeration value.  
  
-   Web-hosted in-process  
  
     The Web service and the COM+ application logic are hosted within the Web server worker process. This provides automatic activation of the Web-hosted mode without causing a process hop for Web service requests. The disadvantage is that the server application cannot be accessed through DCOM.  
  
### Security Considerations  
 Like other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services, the security settings for the exposed service are administered through configuration settings for the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel. Traditional DCOM security settings such as the DCOM machine-wide permissions settings are not enforced. To enforce COM+ application roles, "component-level access checks" authorization must be enabled for the component.  
  
 The use of a non-secured binding can leave communication open to tampering or information disclosure. To prevent this, it is recommended that you use a secured binding.  
  
 For the COM+-hosted and Web-hosted modes, client applications must permit the server process to impersonate the client user. This can be done in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients by setting the impersonation level to <xref:System.Security.Principal.TokenImpersonationLevel.Impersonation>.  
  
 With Internet Information Services (IIS) or Windows Process Activation Service (WAS) using the HTTP transport, the Httpcfg.exe tool can be used to reserve a transport endpoint address. In other configurations, it is important to protect against rogue services that act as the intended service. To prevent a rogue service from starting at the desired endpoint, the legitimate service can be configured to run as an NT service. This enables the legitimate service to claim the endpoint address prior to any rogue services.  
  
 When exposing a COM+ application with configured COM+ roles as a Web-hosted service, the "Launch IIS Process Account" must be added to one of the application’s roles. This account, typically with the name IWAM_machinename, must be added to enable clean shutdown of objects after use. The account should not be granted any additional permissions.  
  
 The COM+ process recycling features cannot be used on integrated applications. If the application is configured to use process recycling and the components are running in a COM+ hosted process, the service fails to start. This requirement does not include services using the Web-hosted in-process mode because the process recycling settings are not applied.  
  
## See Also  
 [Integrating with COM Applications Overview](../../../../docs/framework/wcf/feature-details/integrating-with-com-applications-overview.md)
