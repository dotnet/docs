---
title: "Cache Policy Interaction—Maximum Age and Maximum Staleness"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "maximum staleness"
  - "freshness of cached resources"
  - "time, cached resources"
  - "maximum age policy"
  - "staleness of cached resources"
  - "age of cached resources"
ms.assetid: 7f775925-89a1-4956-ba90-c869c1749a94
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Cache Policy Interaction—Maximum Age and Maximum Staleness
To help ensure that the freshest content is returned to the client application, the interaction of client cache policy and server revalidation requirements always results in the most conservative cache policy. All the examples in this topic illustrate the cache policy for a resource that is cached on January 1 and expires on January 4.  
  
 In the following examples, the maximum staleness value (`maxStale`) is used in conjunction with a maximum age (`maxAge`):  
  
-   If the cache policy sets `maxAge` = 5 days and does not specify a `maxStale` value, according to the `maxAge` value, the content is usable until January 6. However, according to the server's revalidation requirements, the content expires on January 4. Because the content expiration date is more conservative (sooner), it takes precedence over the `maxAge` policy. Therefore, the content expires on January 4 and must be revalidated even though its maximum age has not been reached.  
  
-   If the cache policy sets `maxAge` = 5 days and `maxStale` = 3 days, according to the `maxAge` value, the content is usable until January 6. According to the `maxStale` value, the content is usable until January 7. Therefore, the content gets revalidated on January 6.  
  
-   If the cache policy sets `maxAge` = 5 days and `maxStale` = 1 day, according to the `maxAge` value, the content is usable until January 6. According to the `maxStale` value, the content is usable until January 5. Therefore, the content gets revalidated on January 5.  
  
 When the maximum age is less than the content expiration date, the more conservative caching behavior always prevails and the maximum staleness value has no effect. The following examples illustrate the effect of setting a maximum staleness (`maxStale`) value when the maximum age (`maxAge`) is reached before the content expires:  
  
-   If the cache policy sets `maxAge` = 1 day and does not specify a value for `maxStale` value, the content is revalidated on January 2 even though it has not expired.  
  
-   If the cache policy sets `maxAge` = 1 day and `maxStale` = 3 days, the content is revalidated on January 2 to enforce the more conservative policy setting.  
  
-   If the cache policy sets `maxAge` = 1 day and `maxStale` = 1 day, the content is revalidated on January 2.  
  
## See Also  
 [Cache Management for Network Applications](../../../docs/framework/network-programming/cache-management-for-network-applications.md)  
 [Cache Policy](../../../docs/framework/network-programming/cache-policy.md)  
 [Location-Based Cache Policies](../../../docs/framework/network-programming/location-based-cache-policies.md)  
 [Time-Based Cache Policies](../../../docs/framework/network-programming/time-based-cache-policies.md)  
 [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md)  
 [Cache Policy Interaction—Maximum Age and Minimum Freshness](../../../docs/framework/network-programming/cache-policy-interaction-maximum-age-and-minimum-freshness.md)
