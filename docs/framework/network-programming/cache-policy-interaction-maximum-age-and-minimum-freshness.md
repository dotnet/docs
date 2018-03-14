---
title: "Cache Policy Interaction—Maximum Age and Minimum Freshness"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "time-based cache policies"
  - "Revalidate policy"
  - "cache [.NET Framework], time-based policies"
  - "freshness of cached resources"
  - "maximum age policy"
  - "minimum freshness policy"
  - "age of cached resources"
ms.assetid: 6567d451-ecec-496c-95a3-a415b99ba52a
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Cache Policy Interaction—Maximum Age and Minimum Freshness
To help ensure that the freshest content is returned to the client application, the interaction of client cache policy and server revalidation requirements always results in the most conservative cache policy. All the examples in this topic illustrate the cache policy for a resource that is cached on January 1 and expires on January 4.  
  
 The following examples illustrate the cache policy that results from the interaction of the maximum age (`maxAge`) and minimum freshness (`minFresh`) values.  
  
-   If the cache policy sets `maxAge` = 2 days and `minFresh` is not specified, the content is revalidated on January 3.  
  
-   If the cache policy sets `maxAge` = 2 days and `minFresh` = 1 day, according to `maxAge`, the content is fresh until January 3. According to `minFresh`, the content is fresh until January 3. Therefore, the content must be revalidated on January 3.  
  
-   If the cache policy sets `maxAge` = 2 days and `minFresh` = 2 days, according to `maxAge`, the content is fresh until January 3. According to `minFresh` the content is fresh until January 2. Therefore, the content must be revalidated on January 2.  
  
## See Also  
 [Cache Management for Network Applications](../../../docs/framework/network-programming/cache-management-for-network-applications.md)  
 [Cache Policy](../../../docs/framework/network-programming/cache-policy.md)  
 [Location-Based Cache Policies](../../../docs/framework/network-programming/location-based-cache-policies.md)  
 [Time-Based Cache Policies](../../../docs/framework/network-programming/time-based-cache-policies.md)  
 [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md)  
 [Cache Policy Interaction—Maximum Age and Maximum Staleness](../../../docs/framework/network-programming/cache-policy-interaction-maximum-age-and-maximum-staleness.md)
