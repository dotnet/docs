---
title: "&lt;applicationPool&gt; Element (Web Settings)"
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
  - "applicationPool element"
  - "<applicationPool> element"
ms.assetid: 46d1baaa-e343-4639-b70d-2a43a9f62b2a
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;applicationPool&gt; Element (Web Settings)
Specifies configuration settings that are used by ASP.NET to manage process-wide behavior when an ASP.NET application is running in Integrated mode on [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] or a later version.  
  
> [!IMPORTANT]
>  This element and the feature it supports only work if your ASP.NET application is hosted on [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] or later versions.  
  
 \<configuration>  
\<system.web> Element (Web Settings)  
\<applicationPool> Element (Web Settings)  
  
## Syntax  
  
```xml  
<applicationPool   
    maxConcurrentRequestsPerCPU="5000"   
    maxConcurrentThreadsPerCPU="0"   
    requestQueueLimit="5000" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`maxConcurrentRequestsPerCPU`|Specifies how many simultaneous requests ASP.NET allows per CPU.|  
|`maxConcurrentThreadsPerCPU`|Specifies how many simultaneous threads can be running for an application pool for each CPU. This provides an alternative way to control ASP.NET concurrency, because you can limit the number of managed threads that can be used per CPU to serve requests. By default this setting is 0, which means that ASP.NET does not limit the number of threads that can be created per CPU, although the CLR thread pool also limits the number of threads that can be created.|  
|`requestQueueLimit`|Specifies the maximum number of requests that can be queued for ASP.NET in a single process. When two or more ASP.NET applications run in a single application pool, the cumulative set of requests being made to any application in the application pool is subject to this setting.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.web>](../../../../../docs/framework/configure-apps/file-schema/web/system-web-element-web-settings.md)|Contains information about how ASP.NET interacts with a host application.|  
  
## Remarks  
 When you run [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] or a later version in Integrated mode, this element combination lets you configure how ASP.NET manages threads and queues requests when the application is hosted in an IIS application pool. If you run IIS 6 or you run [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] in Classic mode or in ISAPI mode, these settings are ignored.  
  
 The `applicationPool` settings apply to all application pools that run on a particular version of the .NET Framework. The settings are contained in an aspnet.config file. There is a version of this file for versions 2.0 and 4.0 of the .NET Framework. (Versions 3.0 and 3.5 of the .NET Framework share the aspnet.config file with version 2.0.)  
  
> [!IMPORTANT]
>  If you run [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] on [!INCLUDE[win7](../../../../../includes/win7-md.md)], you can configure a separate aspnet.config file for every application pool. This lets you tailor the performance of the threads for each application pool.  
  
 For the `maxConcurrentRequestsPerCPU` setting, the default setting of "5000" in the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)] effectively turns off request throttling that is controlled by ASP.NET, unless you actually have 5000 or more requests per CPU. The default setting depends instead on the CLR thread-pool to automatically manage concurrency per CPU. Applications that make extensive use of asynchronous request processing, or that have many long-running requests blocked on network I/O, will benefit from the increased default limit in the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)]. Setting `maxConcurrentRequestsPerCPU` to zero turns off the use of managed threads for processing ASP.NET requests. When an application runs in an IIS application pool, requests stay on the IIS I/O thread and therefore concurrency is throttled by IIS thread settings.  
  
 The `requestQueueLimit` setting works the same way as the `requestQueueLimit` attribute of the [processModel](http://msdn.microsoft.com/library/4b8fe20e-74c8-4566-b72c-ce5f83c8e32d) element, which is set in the Web.config files for ASP.NET applications. However, the `requestQueueLimit` setting in an aspnet.config file overrides the `requestQueueLimit` setting in a Web.config file. In other words, if both attributes are set (by default, this is true), the `requestQueueLimit` setting in the aspnet.config file takes precedence.  
  
## Example  
 The following example shows how to configure ASP.NET process-wide behavior in the aspnet.config file in the following circumstances:  
  
-   The application is hosted in an [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] application pool.  
  
-   [!INCLUDE[iisver](../../../../../includes/iisver-md.md)] is running in Integrated mode.  
  
-   The application is using the [!INCLUDE[net_v35SP1_short](../../../../../includes/net-v35sp1-short-md.md)] or a later version.  
  
 The values in the example are the default values.  
  
```xml  
<configuration>  
  <system.web>  
    <applicationPool   
        maxConcurrentRequestsPerCPU="5000"  
        maxConcurrentThreadsPerCPU="0"   
        requestQueueLimit="5000" />  
  </system.web>  
</configuration>  
```  
  
## Element Information  
  
|||  
|-|-|  
|Namespace||  
|Schema Name||  
|Validation File||  
|Can be Empty||  
  
## See Also  
 [\<system.web> Element (Web Settings)](../../../../../docs/framework/configure-apps/file-schema/web/system-web-element-web-settings.md)
