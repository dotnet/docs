---
description: "Learn more about: How to: Set the Default Time-Based Cache Policy for an Application"
title: "How to: Set the Default Time-Based Cache Policy for an Application"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "time-based cache policies"
  - "cache [.NET Framework], time-based policies"
  - "default time-based cache policy"
ms.assetid: 6bfce066-a2e7-4add-a05e-85c12ec9f07f
---
# How to: Set the Default Time-Based Cache Policy for an Application

The default time-based cache policy allows an application to have its cache behavior defined by the headers sent with the cached resource and the cache behavior defined in sections 13 and 14 of RFC 2616, available at [Internet Engineering Task Force (IETF)](https://www.ietf.org/) website. This is the appropriate cache behavior for most applications.  
  
### To set the default automatic policy for an application  
  
1. Create a default time-based policy object.  
  
2. Set the policy object as the default for the application domain.  
  
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
  
## See also

- [Cache Management for Network Applications](cache-management-for-network-applications.md)
- [Cache Policy](cache-policy.md)
- [Location-Based Cache Policies](location-based-cache-policies.md)
- [Time-Based Cache Policies](time-based-cache-policies.md)
- [\<requestCaching> Element (Network Settings)](../configure-apps/file-schema/network/requestcaching-element-network-settings.md)
