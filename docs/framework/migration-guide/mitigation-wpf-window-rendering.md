---
title: "Mitigation: WPF Window Rendering"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 28ed6bf8-141b-4b73-a4e3-44a99fae5084
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mitigation: WPF Window Rendering
In the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] running on Windows 8 and above, the entire window is rendered without clipping when it extends outside of single display in a multi-monitor scenario.  
  
## Impact  
 In general, rendering an entire window across multiple monitors without clipping is the expected behavior. However, on Windows 7 and earlier versions, WPF windows are clipped when they extend beyond a single display because rendering a portion of the window on the second monitor has a significant performance impact.  
  
 The precise impact of rendering WPF windows across monitors on Windows 8 and above is not precisely quantifiable since it depends on a large number of factors. In some cases, it may still produce an undesirable impact on performance, particularly for users who run graphics-intensive applications and have windows straddling monitors. In other cases, you may simply want a consistent behavior across .NET Framework versions.  
  
## Mitigation  
 You can disable this change and revert to the previous behavior of clipping a WPF window when it extends beyond a single display. There are two ways to do this:  
  
-   By adding the `<EnableMultiMonitorDisplayClipping>` element to the `<appSettings>` section of your application configuration file, you can disable or enable this behavior on apps running on Windows 8 or later. For example, the following configuration section disables rendering without clipping:  
  
    ```xml  
    <appSettings>  
        <add key="EnableMultiMonitorDisplayClipping" value="true"/>  
      </appSettings>  
    ```  
  
     The `<EnableMultiMonitorDisplayClipping>` configuration setting can have either of two values:  
  
    -   `true`, to enable clipping of windows to monitor bounds during rendering.  
  
    -   `false`, to disable clipping of windows to monitor bounds during rendering.  
  
-   By setting the <xref:System.Windows.CoreCompatibilityPreferences.EnableMultiMonitorDisplayClipping%2A> property to `true` at app startup.  
  
## See Also  
 [Runtime Changes](../../../docs/framework/migration-guide/runtime-changes-in-the-net-framework-4-6.md)
