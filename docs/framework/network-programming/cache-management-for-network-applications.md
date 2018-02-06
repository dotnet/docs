---
title: "Cache Management for Network Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "cache [.NET Framework], network applications"
  - "network resources, caching"
  - "Internet, caching"
ms.assetid: fc258a40-f370-434f-ae09-4a8cb11ddaeb
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Cache Management for Network Applications
This topic and its related subtopics describe caching for resources obtained using the <xref:System.Net.WebClient>, <xref:System.Net.WebRequest>, <xref:System.Net.HttpWebRequest>, and <xref:System.Net.FtpWebRequest> classes.  
  
 A cache provides temporary storage of resources that have been requested by an application. If an application requests the same resource more than once, the resource can be returned from the cache, avoiding the overhead of re-requesting it from the server. Caching can improve application performance by reducing the time required to get a requested resource. Caching can also decrease network traffic by reducing the number of trips to the server. While caching improves performance, it increases the risk that the resource returned to the application is stale, meaning that it is not identical to the resource that would have been sent by the server if caching were not in use.  
  
 Caching may allow unauthorized users or processes to read sensitive data. An authenticated response that is cached may be retrieved from the cache without an additional authorization. If caching is enabled, change to <xref:System.Net.WebRequest.CachePolicy%2A> to <xref:System.Net.Cache.RequestCacheLevel.BypassCache> or <xref:System.Net.Cache.RequestCacheLevel.NoCacheNoStore> to disable caching for this request.  
  
 Due to security concerns, caching is **not** recommended for middle tier scenarios.  
  
## In This Section  
 [Cache Policy](../../../docs/framework/network-programming/cache-policy.md)  
 Explains what a cache policy is and how to define one.  
  
 [Location-Based Cache Policies](../../../docs/framework/network-programming/location-based-cache-policies.md)  
 Defines each type of location-based cache policy available for Hypertext Transfer Protocol (http and https) resources.  
  
 [Time-Based Cache Policies](../../../docs/framework/network-programming/time-based-cache-policies.md)  
 Describes the criteria that can be used to customize a time-based cache policy.  
  
 [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md)  
 Describes how to programmatically create cache policies and requests that use caching.  
  
## Reference  
 <xref:System.Net.Cache>  
 Defines the types and enumerations used to define cache policies for resources obtained using the <xref:System.Net.WebRequest>, <xref:System.Net.HttpWebRequest>, and <xref:System.Net.FtpWebRequest> classes.
