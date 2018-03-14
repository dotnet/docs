---
title: "Integrating with COM Applications Overview"
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
  - "COM [WCF], integration overview"
ms.assetid: 02c5697f-6e2e-47d6-b715-f3a28aebfbd5
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Integrating with COM Applications Overview
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides the managed code developer with a rich environment for creating connected applications. However, if you have a substantial investment in unmanaged COM-based code and do not want to migrate, you can still integrate [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Web services directly into your existing code by using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service moniker. The service moniker can be used from a wide range of COM-based development environments, such as Office VBA, Visual Basic 6.0, or Visual C++ 6.0.  
  
> [!NOTE]
>  The service moniker uses a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] communication channel for all communication. The security and identity mechanisms for that channel differ from those used in standard COM and DCOM proxies. In addition, because the service moniker uses a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] communication channel the default timeout period is one minute for all calls.  
  
 The service moniker is used with the `GetObject` function to provide the unmanaged developer with a strongly-typed, COM-specific approach for calling [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Web services. This requires a local, COM-visible definition of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Web service contract and the binding that is to be used. Like other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients, the service moniker must construct a typed channel to the service, though this channel construction occurs transparently to the COM programmer on the first method call.  
  
 In common with other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients, when using the moniker, applications specify the address, binding and contract to communicate with a service. The contract can be specified in one of the following ways:  
  
-   Typed contract – the contract is registered as a COM visible type on the client machine.  
  
-   WSDL contract – the contract is supplied in the form of a WSDL document.  
  
-   MEX contract – the contract is retrieved at runtime from a Metadata Exchange (MEX) endpoint.  
  
## Parameters Supported by the Service Moniker  
 The following table shows the parameters that are supported by the service moniker.  
  
|Parameter|Description|  
|---------------|-----------------|  
|`address`|URL location of the service.|  
|`binding`|Binding section name from the application configuration.|  
|`bindingConfiguration`|Named binding instance from within the named binding section.|  
|`contract`|Interface identifier (IID) that represents the service contract or the contract name (from MEX).|  
|`wsdl`|WSDL document that provides an alternative form of contract definition.|  
|`spnIdentity`|Server principal name (SPN) identity to be used to communicate with the service.|  
|`upnIdentity`|User principal name (UPN) identity to be used to communicate with the service.|  
|`dnsIdentity`|DNS identity to be used to communicate with the service.|  
|`mexAddress`|URL location of the Metadata Exchange (MEX) endpoint of the service.|  
|`mexBinding`|Binding section name from the application configuration to connect with the MEX endpoint.|  
|`mexBindingConfiguration`|Named binding instance from within the named binding section to connect with the MEX endpoint.|  
|`bindingNamespace`|Namespace of the binding section name from the retrieved MEX.|  
|`contractNamespace`|Namespace of the contract from the retrieved MEX.|  
|`mexSpnIdentity`|Server principal name (SPN) identity to be used to communicate with the MEX endpoint.|  
|`mexUpnIdentity`|User principal name (UPN) identity to be used to communicate with the MEX endpoint.|  
|`mexDnsIdentity`|DNS identity to be used to communicate with the MEX endpoint.|  
|`serializer`|Specify the use of either the "xml" or "datacontract" serializer.|  
  
> [!NOTE]
>  Even when used with entirely COM-based clients, the service moniker requires [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and the supporting .NET Framework 2.0 to be installed on the client computer. It is also critical that client applications that use the service moniker load the appropriate version of the .NET Framework runtime. When using the moniker within Office applications, a configuration file may be required to ensure that the correct framework version is loaded. For example, with Excel, the following text should be placed in a file called Excel.exe.config in the same directory as the Excel.exe file:  
>   
>  `<?xml version="1.0" encoding="utf-8"?>`  
>   
>  `<configuration xmlns=` `http://schemas.microsoft.com/.NetConfiguration/v2.0` `>`  
>   
>  `<startup>`  
>   
>  `<requiredRuntime version="v2.0.50727" />`  
>   
>  `</startup>`  
>   
>  `</configuration>`  
  
## See Also  
 [How to: Register and Configure a Service Moniker](../../../../docs/framework/wcf/feature-details/how-to-register-and-configure-a-service-moniker.md)
