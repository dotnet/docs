---
title: "Mitigation: Default AuthorizationContext | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6cfeee63-b148-429a-a7e6-6fe9b0cb7610
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Mitigation: Default AuthorizationContext
The implementation of the <xref:System.IdentityModel.Policy.AuthorizationContext> returned by a call to the <xref:System.IdentityModel.Policy.AuthorizationContext.CreateDefaultAuthorizationContext%28System.Collections.Generic.IList%7BSystem.IdentityModel.Policy.IAuthorizationPolicy%7D%29> with a `null``authorizationPolicies` argument has changed its implementation in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)].  
  
## Impact  
 In rare cases, WCF apps that use custom authentication may see behavioral differences.  
  
## Mitigation  
 You can restore the previous behavior in either of two ways:  
  
-   Recompile your app to target an earlier version of the .NET Framework than 4.6. For IIS-hosted services, use the `<httpRuntime targetFramework="x.x" />` element to target an earlier version of the .NET Framework.  
  
-   Add the following line to the `<appSettings>` section of your app.config file:  
  
    ```  
    <add key="appContext.SetSwitch:Switch.System.IdentityModel.EnableCachedEmptyDefaultAuthorizationContext" value="true" />  
    ```  
  
## See Also  
 [Retargeting Changes](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-6.md)