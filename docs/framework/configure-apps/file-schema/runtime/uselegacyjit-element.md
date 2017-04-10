---
title: "&lt;useLegacyJIT&gt; Element | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c2cf97f0-9262-4f1f-a754-5568b51110ad
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# &lt;useLegacyJIT&gt; Element
Determines whether the common language runtime uses the legacy 64-bit JIT compiler for just-in-time compilation.  
  
 \<configuration>  
 \<runtime>  
\<useLegacyJIT>  
  
## Syntax  
  
```  
  
<useLegacyJIT enabled=0|1 />  
  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime uses the legacy 64-bit JIT compiler.|  
  
### enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|0|The common language runtime uses the new 64-bit JIT compiler that is included in the .NET Framework 4.6 and later versions.|  
|1|The common language runtime uses the older 64-bit JIT compiler.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
 Starting with the .NET Framework 4.6, the common language runtime by default uses a new 64-bit compiler for just-in-time (JIT) compilation. In some cases, this may result in a difference in behavior from application code that was JIT-compiled by the previous version of the 64-bit JIT compiler. By setting the `enabled` attribute of the `<useLegacyJIT>` element to `1`, you can disable the new 64-bit JIT compiler and instead compile your app by using the legacy 64-bit JIT compiler.  
  
> [!NOTE]
>  The `<useLegacyJIT>` element affects 64-bit JIT compilation only. Compilation with the 32-bit JIT compiler is unaffected.  
  
 Instead of using an configuration file setting, you can enable the legacy 64-bit JIT compiler in two other ways:  
  
-   By setting the following environment variable:  
  
    ```  
    COMPLUS_useLegacyJit=1  
    ```  
  
     The environment variable has global scope. That is, it affects all applications run on the machine. If set, it can be overridden by the application configuration file setting.  
  
-   By adding a `REG_DWORD` value to either the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework` or `HKEY_CURRENT_USER\SOFTWARE\Microsoft\.NETFramework` key of the registry. The value is named `useLegacyJit`. If its value is 1, the legacy 64-bit JIT compiler is enabled; if its value is 0, the legacy 64-bit JIT compiler is disabled, and the new compiler is used instead.  
  
     Adding the value to the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework` key affects all apps running on the machine. Adding the value to the `HKEY_CURRENT_USER\SOFTWARE\Microsoft\.NETFramework` key affects all apps run by the current user. (It a machine is configured with multiple user accounts, only apps run by the current user are affected, unless the value is added to the registry keys for other users as well.) Adding the [\<useLegacyJIT>](../../../../../docs/framework/configure-apps/file-schema/runtime/uselegacyjit-element.md) element to a configuration file overrides the registry settings, if they are present.  
  
## Example  
 The following configuration file disables compilation with the new 64-bit JIT compiler and instead uses the legacy 64-bit JIT compiler.  
  
```xml  
  
<?xml version ="1.0"?>  
<configuration>  
   <runtime>  
      <useLegacyJIT enabled="1" />  
   </runtime>  
</configuration>  
  
```  
  
## See Also  
 [\<runtime> Element](../../../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md)   
 [\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)   
 [Mitigation: New 64-bit JIT Compiler](../../../../../docs/framework/migration-guide/mitigation-new-64-bit-jit-compiler.md)