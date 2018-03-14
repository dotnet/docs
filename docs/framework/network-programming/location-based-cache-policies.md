---
title: "Location-Based Cache Policies"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Cache If Available policy"
  - "reload policy"
  - "location-based cache policies"
  - "Cache Only policy"
  - "local cache"
  - "intermediate cache"
  - "No Cache No Store policy"
  - "cache [.NET Framework], location-based policies"
  - "Revalidate policy"
  - "freshness of cached resources"
  - "Cache Or Next Cache Only policy"
  - "Refresh policy"
ms.assetid: e41d7f1a-0a6a-4dee-97d1-c6a8b6a07fc2
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Location-Based Cache Policies
A location-based cache policy defines the freshness of valid cached entries based on where the requested resource can be taken from. A cached resource is valid if using it does not does not violate server-specified revalidation requirements. A location-based cache policy is created programmatically by using a <xref:System.Net.Cache.RequestCachePolicy> or <xref:System.Net.Cache.HttpRequestCachePolicy> class constructor. The type of location-based policy is passed to the constructor using a <xref:System.Net.Cache.RequestCacheLevel> or <xref:System.Net.Cache.HttpRequestCacheLevel> enumeration value. For code examples that create location-based cache policies, see [How to: Set a Location-Based Cache Policy for an Application](../../../docs/framework/network-programming/how-to-set-a-location-based-cache-policy-for-an-application.md). The following sections explain each type of location-based cache policy for Hypertext Transfer Protocol (http and https) resources.  
  
## Cache If Available Policy  
 If a valid requested resource is in the local cache, the cached resource is used; otherwise, the request for the resource is sent to the server. If the requested resource is available in any cache between the client and the server, the request can be satisfied by an intermediate cache.  
  
## Cache Only Policy  
 If a valid requested resource is in the local cache, the cached resource is used. When this cache policy level is specified, a <xref:System.Net.WebException> exception is thrown if the item is not in the local cache.  
  
## Cache Or Next Cache Only Policy  
 If a valid requested resource is in the local cache or an intermediate cache on the local area network, the cached resource is used. Otherwise, a <xref:System.Net.WebException> exception is thrown. In the HTTP caching protocol, this is achieved using the only-if-cached cache control directive.  
  
## No Cache No Store Policy  
 A requested resource is never used from any cache and is never placed in any cache. If a requested resource is present in the local cache, it is removed. This policy level indicates to intermediate caches that they should also remove the resource. In the HTTP caching protocol, this is achieved using the no-store cache control directive.  
  
## Refresh Policy  
 A requested resource can be used if it is obtained from the server or found in a cache other than the local cache. Before the request can be satisfied by an intermediate cache, that cache must revalidate its cached entry with the server. In the HTTP caching protocol, this is achieved using the max-age = 0 cache control directive and the no-cache Pragma header.  
  
## Reload Policy  
 Requested resources must be obtained from the server. The response might be saved in the local cache. In the HTTP caching protocol, this is achieved using the no-cache cache control directive and the no-cache Pragma header.  
  
## Revalidate Policy  
 Compares the copy of the resource in the cache with the copy on the server. If the copy on the server is newer, it is used to satisfy the request and replaces the copy in the cache. If the copy in the cache is the same as the server copy, the cached copy is used. In the HTTP caching protocol, this is achieved using a conditional request.  
  
## See Also  
 [Cache Management for Network Applications](../../../docs/framework/network-programming/cache-management-for-network-applications.md)  
 [Cache Policy](../../../docs/framework/network-programming/cache-policy.md)  
 [Time-Based Cache Policies](../../../docs/framework/network-programming/time-based-cache-policies.md)  
 [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md)  
 [\<requestCaching> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/requestcaching-element-network-settings.md)
