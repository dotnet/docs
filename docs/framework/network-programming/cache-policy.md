---
title: "Cache Policy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "time-based cache policies"
  - "location-based cache policies"
  - "cache [.NET Framework], policies"
  - "request cache policies"
  - "freshness of cached resources"
  - "content cache policies"
  - "expired content"
ms.assetid: 1a7e04ec-7872-41c2-96c6-52566dcb412b
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Cache Policy
A cache policy defines rules that are used to determine whether a request can be satisfied using a cached copy of the requested resource. Applications specify client cache requirements for freshness, but the effective cache policy is determined by the client cache requirements, the server's content expiration requirements, and the server's revalidation requirements. The interaction of client cache policy and server requirements always results in the most conservative cache policy, to help ensure that the freshest content is returned to the client application.  
  
 Cache policies are either location-based or time-based. A location-based cache policy defines the freshness of cached entries based on where the requested resource can be taken from. A time-based cache policy defines the freshness of cached entries using the time the resource was retrieved, headers returned with the resource, and the current time. Most applications can use the default time-based cache policy, which implements the caching policy specified in RFC 2616, available at [http://www.ietf.org](http://www.ietf.org/).  
  
 The classes described in the following table are used to specify cache policies.  
  
|Class name|Description|  
|----------------|-----------------|  
|<xref:System.Net.Cache.HttpRequestCachePolicy>|Represents location-based and time-based cache policies for resources requested using <xref:System.Net.HttpWebRequest> objects.|  
|<xref:System.Net.Cache.RequestCachePolicy>|Represents location-based cache policies or the <xref:System.Net.Cache.RequestCacheLevel.Default> time-based cache policy for resources requested using <xref:System.Net.WebRequest> objects.|  
|<xref:System.Net.Cache.HttpCacheAgeControl>|Specifies values used to create time-based <xref:System.Net.Cache.HttpRequestCachePolicy> objects.|  
|<xref:System.Net.Cache.HttpRequestCacheLevel>|Specifies values used to create location-based and time-based <xref:System.Net.Cache.HttpRequestCachePolicy> objects.|  
|<xref:System.Net.Cache.RequestCacheLevel>|Specifies values used to create location-based or the <xref:System.Net.Cache.RequestCacheLevel.Default> time-based <xref:System.Net.Cache.RequestCachePolicy> objects.|  
  
 You can define a cache policy for all requests made by your application or for individual requests. When you specify both an application-level cache policy and a request-level cache policy, the request-level policy is used. You can specify an application-level cache policy programmatically or by using the application or machine configuration files. For more information, see [\<requestCaching> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/requestcaching-element-network-settings.md).  
  
 To create a cache policy, you must create a policy object by creating an instance of the <xref:System.Net.Cache.RequestCachePolicy> or <xref:System.Net.Cache.HttpRequestCachePolicy> class. To specify the policy on a request, set the request's <xref:System.Net.WebRequest.CachePolicy%2A> property to the policy object. When setting an application-level policy programmatically, set the <xref:System.Net.HttpWebRequest.DefaultCachePolicy%2A> property to the policy object.  
  
 For code examples that demonstrate creating and using cache policies, see [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md).  
  
## See Also  
 [Cache Management for Network Applications](../../../docs/framework/network-programming/cache-management-for-network-applications.md)  
 [Location-Based Cache Policies](../../../docs/framework/network-programming/location-based-cache-policies.md)  
 [Time-Based Cache Policies](../../../docs/framework/network-programming/time-based-cache-policies.md)  
 [Configuring Caching in Network Applications](../../../docs/framework/network-programming/configuring-caching-in-network-applications.md)
