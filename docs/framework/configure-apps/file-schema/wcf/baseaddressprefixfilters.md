---
title: "&lt;baseAddressPrefixFilters&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8cab2a9a-c51f-4283-bb60-2ad0c274fd46
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;baseAddressPrefixFilters&gt;
Represents a collection of configuration elements that specify pass through filters, which provide a mechanism to pick the appropriate Internet Information Services (IIS) bindings when hosting the [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] application in IIS.  
  
> [!WARNING]
>  \<baseAddressPrefixFilters> does not recognize "localhost", use the fully qualified machine name instead.  
  
 \<system.ServiceModel>  
\<ServiceHostingEnvironment>  
  
## Syntax  
  
```xml  
<serviceHostingEnvironment>  
     <baseAddressPrefixFilters>  
        <add prefix="string"/>  
     </baseAddressPrefixFilters>  
</serviceHostingEnvironment>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/wcf/add-of-baseaddressprefixfilter.md)|Adds a configuration element that specifies a prefix filter for the base addresses used by the service host.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceHostingEnvironment>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md)|Defines the type the service hosting environment instantiates for a particular transport.|  
  
## Remarks  
 A prefix filter provides a way for shared hosting providers to specify which URIs are to be used by the service. It enables shared hosts to host multiple applications with different base addresses for the same scheme on the same site.  
  
 IIS Web sites are containers for virtual applications which contain virtual directories. The application in a site can be accessed through one or more IIS bindings. IIS bindings provide two pieces of information: binding protocol and binding information. Binding protocol (for example, HTTP) defines the scheme over which communication occurs, and binding information (for example, IP Address, Port, Hostheader) contains data used to access the site.  
  
 IIS supports specifying multiple IIS bindings for each site, which results in multiple base addresses for each scheme. Because a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service hosted under a site allows binding to only one base address for each scheme, you can use the prefix filter feature to pick the required base address of the hosted service. The incoming base addresses, supplied by IIS, are filtered based on the optional prefix list filter.  
  
 For example, your site can contain the following base addresses.  
  
```  
http://testl.fabrikam.com/Service.svc  
http://test2.fabrikam.com/Service.svc  
```  
  
 You can use the following configuration file to specify a prefix filter at the appdomain level.  
  
```xml  
<system.serviceModel>  
  <serviceHostingEnvironment>  
     <baseAddressPrefixFilters>  
        <add prefix="net.tcp://test1.fabrikam.com:8000"/>  
        <add prefix="http://test2.fabrikam.com:9000"/>  
    </baseAddressPrefixFilters>  
  </serviceHostingEnvironment>  
</system.serviceModel>  
```  
  
 In this example, `net.tcp://test1.fabrikam.com:8000` and `http://test2.fabrikam.com:9000` are the only base addresses for their respective schemes, which are allowed to be passed through.  
  
 By default, when prefix is not specified, all addresses are passed through. Specifying the prefix only allows the matching base address for that scheme to be passed through.  
  
> [!NOTE]
>  The filter does not support any wildcards. In addition, the baseAddresses supplied by IIS may have addresses bound to other schemes not present in the `baseAddressPrefixFilters` list. These addresses are not filtered out.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BaseAddressPrefixFilterElementCollection>  
 <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection>  
 <xref:System.ServiceModel.ServiceHostingEnvironment>  
 [Hosting](../../../../../docs/framework/wcf/feature-details/hosting.md)
