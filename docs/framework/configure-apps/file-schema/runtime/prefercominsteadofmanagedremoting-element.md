---
title: "&lt;PreferComInsteadOfManagedRemoting&gt; Element"
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
  - "<PreferComInsteadOfManagedRemoting> element"
  - "PreferComInsteadOfManagedRemoting element"
ms.assetid: a279a42a-c415-4e79-88cf-64244ebda613
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;PreferComInsteadOfManagedRemoting&gt; Element
Specifies whether the runtime will use COM interop instead of remoting for all calls across application domain boundaries.  
  
 \<configuration>  
\<runtime>  
\<PreferComInsteadOfManagedRemoting>  
  
## Syntax  
  
```xml  
<PreferComInsteadOfManagedRemoting enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Indicates whether the runtime will use COM interop instead of remoting across application domain boundaries.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|The runtime will use remoting across application domain boundaries. This is the default.|  
|`true`|The runtime will use COM interop across application domain boundaries.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 When you set the `enabled` attribute to `true`, the runtime behaves as follows:  
  
-   The runtime does not call [IUnknown::QueryInterface](http://go.microsoft.com/fwlink/?LinkID=144867) for an [IManagedObject](../../../../../docs/framework/unmanaged-api/hosting/imanagedobject-interface.md) interface when an [IUnknown](http://go.microsoft.com/fwlink/?LinkId=148003) interface enters the domain through a COM interface. Instead, it constructs a [Runtime Callable Wrapper](../../../../../docs/framework/interop/runtime-callable-wrapper.md) (RCW) around the object.  
  
-   The runtime returns E_NOINTERFACE when it receives a `QueryInterface` call for an [IManagedObject](../../../../../docs/framework/unmanaged-api/hosting/imanagedobject-interface.md) interface for any [COM Callable Wrapper](../../../../../docs/framework/interop/com-callable-wrapper.md) (CCW) that has been created in this domain.  
  
 These two behaviors ensure that all calls over COM interfaces between managed objects across application domain boundaries use COM and COM interop instead of remoting.  
  
## Example  
 The following example shows how to specify that the runtime should use COM interop across isolation boundaries:  
  
```xml  
<configuration>  
  <runtime>  
    <PreferComInsteadOfManagedRemoting enabled="true"/>  
  </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
