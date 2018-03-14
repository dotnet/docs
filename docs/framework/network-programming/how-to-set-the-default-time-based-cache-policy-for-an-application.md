---
title: "How to: Set the Default Time-Based Cache Policy for an Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "time-based cache policies"
  - "cache [.NET Framework], time-based policies"
  - "default time-based cache policy"
ms.assetid: 6bfce066-a2e7-4add-a05e-85c12ec9f07f
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Set the Default Time-Based Cache Policy for an Application
The default time-based cache policy allows an application to have its cache behavior defined by the headers sent with the cached resource and the cache behavior defined in sections 13 and 14 of RFC 2616, available at [http://www.ietf.org](http://www.ietf.org/). This is the appropriate cache behavior for most applications.  
  
### To set the default automatic policy for an application  
  
1.  Create a default time-based policy object.  
  
2.  Set the policy object as the default for the application domain.  
  
## Example  
 The two examples in this section produce identical policies.  
  
 The following example creates a default time-based policy and sets it as the default for the application domain.  
  
```csharp  
public static void SetDefaultTimeBasedPolicy ()  
{  
    HttpRequestCachePolicy policy = new HttpRequestCachePolicy ();  
    HttpWebRequest.DefaultCachePolicy = policy ;  
}  
```  
  
```vb  
Public Shared Sub SetDefaultTimeBasedPolicy ()  
    Dim policy = New HttpRequestCachePolicy ()  
    HttpWebRequest.DefaultCachePolicy = policy  
End Sub  
```  
  
 You can also create the default time-based cache policy using the <xref:System.Net.Cache.RequestCachePolicy> class as shown in the following example:  
  
```csharp  
public static void SetDefaultTimeBasedPolicy2()  
{  
    RequestCachePolicy policy = new RequestCachePolicy ();  
    HttpWebRequest.DefaultCachePolicy = policy ;  
}  
```  
  
```vb  
Public Shared Sub SetDefaultTimeBasedPolicy2()  
    Dim policy As New RequestCachePolicy()  
    HttpWebRequest.DefaultCachePolicy = policy  
End Sub  
```  
  
## See Also  
 [Cache Management for Network Applications](../../../docs/framework/network-programming/cache-management-for-network-applications.md)  
 [Cache Policy](../../../docs/framework/network-programming/cache-policy.md)  
 [Location-Based Cache Policies](../../../docs/framework/network-programming/location-based-cache-policies.md)  
 [Time-Based Cache Policies](../../../docs/framework/network-programming/time-based-cache-policies.md)  
 [\<requestCaching> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/requestcaching-element-network-settings.md)
