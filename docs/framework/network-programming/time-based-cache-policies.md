---
title: "Time-Based Cache Policies"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "time-based cache policies"
  - "cache synchronization date policy"
  - "cache [.NET Framework], time-based policies"
  - "freshness of cached resources"
  - "time, cached resources"
  - "maximum age policy"
  - "synchronization, cache"
  - "staleness of cached resources"
  - "default time-based cache policy"
  - "maximum staleness policy"
  - "content cache policies"
  - "expired content"
  - "minimum freshness policy"
  - "age of cached resources"
ms.assetid: 74f0bcaf-5c95-40c1-9967-f3bbf1d2360a
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Time-Based Cache Policies
A time-based cache policy defines the freshness of cached entries using the time the resource was retrieved, the headers returned with the resource, and the current time. When setting a time-based cache policy, you can either use the <xref:System.Net.Cache.HttpRequestCacheLevel.Default> time-based policy or create a customized time-based policy. When using the default time-based policy for resources obtained using Hypertext Transfer Protocol (HTTP), the exact cache behavior is determined by the headers included in the cached response and by the behaviors specified in sections 13 and 14 of RFC 2616, available at [http://www.ietf.org](http://www.ietf.org/). For a code example that demonstrates setting the default time-based policy for HTTP resources, see [How to: Set the Default Time-Based Cache Policy for an Application](../../../docs/framework/network-programming/how-to-set-the-default-time-based-cache-policy-for-an-application.md). For code examples that demonstrate creating and using cache policies, see [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md).  
  
## Criteria to Determine Freshness of Cached Entries  
 To customize a time-based cache policy, you can specify that one or more of the following criteria be used to determine the freshness of cached entries:  
  
-   Maximum age  
  
-   Maximum staleness  
  
-   Minimum freshness  
  
-   Cache synchronization date  
  
> [!NOTE]
>  Using the default time-based cache policy should not be confused with setting a default cache policy for your application. The default time-based policy is a specific policy that can be used at the request or application level. The default cache policy for your application is a policy (location-based or time-based) that takes effect when no policy is set on a request. For details on setting a default cache policy for your application, see <xref:System.Net.WebRequest.DefaultCachePolicy%2A>.  
  
### Maximum Age  
 The maximum age policy criterion specifies the amount of time a cached copy of a resource can be used. If the cached copy of the resource is older than the amount of time specified, the resource must be revalidated by checking it against the content on the server. If the maximum age would allow the resource to be used after it expires, this criteria is not honored unless a maximum staleness value is also specified.  
  
### Maximum Staleness  
 The maximum staleness policy criterion specifies the length of time after content expiration that the cached copy of the resource can be used. This is the only cache policy criterion that permits resources to be used after they have expired.  
  
### Minimum Freshness  
 The minimum freshness policy criterion specifies the length of time before content expiration that the cached copy of the resource can be used. This policy has the effect of causing a cache entry to expire before its expiration date; therefore, the minimum freshness and maximum staleness settings are mutually exclusive.  
  
## Cache Synchronization Date  
 The cache synchronization date policy criterion determines when a cached copy of a resource must be revalidated by checking it against the content on the server. If the content has changed since the item was cached, it is retrieved from the server, stored in the cache, and returned to the application. If the content has not changed, its timestamp is updated and the application gets the cached content.  
  
 The cache synchronization date allows you to specify an absolute date when cached contents must be revalidated. If a fresh cache entry was last revalidated prior to the cache synchronization date, revalidation with the server still occurs. If the cache entry was revalidated after the cache synchronization date and there are no additional freshness or server revalidation requirements that invalidate the cached entry, the entry from the cache is used. If the cache synchronization date is set to a future date, the entry is revalidated every time it is requested, until the cache synchronization date passes.  
  
 The following topics provide information about the effects of combining time-based cache policy criteria:  
  
-   [Cache Policy Interaction—Maximum Age and Maximum Staleness](../../../docs/framework/network-programming/cache-policy-interaction-maximum-age-and-maximum-staleness.md)  
  
-   [Cache Policy Interaction—Maximum Age and Minimum Freshness](../../../docs/framework/network-programming/cache-policy-interaction-maximum-age-and-minimum-freshness.md)  
  
## See Also  
 [Cache Management for Network Applications](../../../docs/framework/network-programming/cache-management-for-network-applications.md)  
 [Cache Policy](../../../docs/framework/network-programming/cache-policy.md)  
 [Location-Based Cache Policies](../../../docs/framework/network-programming/location-based-cache-policies.md)  
 [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md)  
 [\<requestCaching> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/requestcaching-element-network-settings.md)
