---
title: "&lt;defaultHttpCachePolicy&gt; Element (Network Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/requestCaching/defaultHttpCachePolicy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#defaultHttpCachePolicy"
helpviewer_keywords: 
  - "defaultHttpCachePolicy element"
  - "<defaultHttpCachePolicy> element"
ms.assetid: 2c1247d0-39b0-4c12-919a-a925ce075c79
caps.latest.revision: 19
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;defaultHttpCachePolicy&gt; Element (Network Settings)
Describes whether HTTP caching is active and describes the default caching policy.  
  
 \<configuration>  
\<system.net>  
\<requestCaching>  
\<defaultHttpCachePolicy>  
  
## Syntax  
  
```xml  
<defaultHttpCachePolicy  
  policyLevel="BypassCache|Default"  
  minimumFresh="d.hh:mm:ss|minValue|maxValue"  
  maximumAge="d.hh:mm:ss|minValue|maxValue"  
  maximumStale="d.hh:mm:ss|minValue|maxValue"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`maximumAge`|Specifies the maximum time interval before a cached object is marked as expired.|  
|`maximumStale`|Specifies the maximum time past the computed freshness time before a cached object is marked as expired.|  
|`minimumFresh`|Specifies the minimum time for a cached object to be considered fresh.|  
|`policyLevel`|Specifies whether the caching policy is automatic, or whether the cache is bypassed. The default value is `BypassCache`.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[requestCaching](../../../../../docs/framework/configure-apps/file-schema/network/requestcaching-element-network-settings.md)|Controls the caching mechanism for network requests.|  
  
## Remarks  
 The value for the `policyLevel` attribute is either `BypassCache` or `Default`.  
  
 Values for the `maximumAge`, `maximumStale`, and `minimumFresh` elements are either an explicit time interval with a format of *d*.*hh*:*mm*:*ss* (days, hours, minutes, and seconds), or the constants `minValue` or `maxValue`, as appropriate.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example shows how to specify a minimum fresh time of six hours, a maximum age time of two days, and a maximum stale time of four hours.  
  
```xml  
<configuration>  
  <system.net>  
    <requestCaching>  
      <defaultHttpCachePolicy  
        minimumFresh="0.06:00:00"  
        maximumAge="2.00:00:00"  
        maximumStale="0.04:00:00"
      />  
    </requestCaching>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.Cache>  
 <xref:System.Net.WebRequest>  
 <xref:System.Net.Cache.RequestCacheLevel>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
