---
title: "Configuration-Based Activation in IIS and WAS"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6a927e1f-b905-4ee5-ad0f-78265da38238
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuration-Based Activation in IIS and WAS
Normally when hosting a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service under Internet Information Services (IIS) or Windows Process Activation Service (WAS), you must provide a .svc file. The .svc file contains the name of the service and an optional custom service host factory. This additional file adds manageability overhead. The configuration-based activation feature removes the requirement to have a .svc file and therefore the associated overhead.  
  
## Configuration-Based Activation  
 Configuration-based activation takes the metadata that used to be placed in the .svc file and places it in the Web.config file. Within the<`serviceHostingEnvironment`> element there is a <`serviceActivations`> element. Within the <`serviceActivations`> element are one or more <`add`> elements, one for each hosted service. The <`add`> element contains attributes that let you set the relative address for the service and the service type or a service host factory. The following configuration example code shows how this section is used.  
  
> [!NOTE]
>  Each <`add`> element must specify a service or a factory attribute. Specifying both service and factory attributes is allowed.  
  
```xml  
<serviceHostingEnvironment>  
  <serviceActivations>  
    <add relativeAddress="MyServiceAddress" service="Service" factory="MyServiceHostFactory"/>  
  </serviceActivations>  
</serviceHostingEnvironment>  
```  
  
 With this in the Web.config file, you can place the service source code in the App_Code directory of the application or a complied assembly in the Bin directory of the application.  
  
> [!NOTE]
>  -   When using configuration-based activation, inline code in .svc files is not supported.  
> -   The `relativeAddress` attribute must be set to a relative address such as "\<sub-directory>/service.svc" or "~/\<sub-directory/service.svc".  
> -   A configuration exception is thrown if you register a relative address that does not have a known extension associated with WCF.  
> -   The relative address specified is relative to the root of the virtual application.  
> -   Due to the hierarchical model of configuration, the registered relative addresses at machine and site level are inherited by virtual applications.  
> -   Registrations in a configuration file take precedence over settings in a .svc, .xamlx, .xoml, or other file.  
> -   Any ‘\’ (backslashes) in a URI sent to IIS/WAS are automatically converted to a ‘/’ (forward slash). If a relative address is added that contains a ‘\’ and you send IIS a URI that uses the relative address, the backslash is converted to a forward slash and IIS cannot match it to the relative address. IIS sends out trace information that indicates that there are no matches found.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection.ServiceActivations%2A>  
 [Hosting Services](../../../../docs/framework/wcf/hosting-services.md)  
 [Hosting Workflow Services Overview](../../../../docs/framework/wcf/feature-details/hosting-workflow-services-overview.md)  
 [\<serviceHostingEnvironment>](../../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
