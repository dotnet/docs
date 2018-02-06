---
title: "Mitigation: WPF Layout"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 805ffd7f-8d1e-427e-a648-601ca8ec37a5
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mitigation: WPF Layout
The layout of WPF controls can change slightly.  
  
## Impact  
 As a result of this change:  
  
-   The width or height of elements may grow or shrink by at most one pixel.  
  
-   The placement of an object can move by at most one pixel.  
  
-   Centered elements can be vertically or horizontally off center by at most one pixel.  
  
 By default, this new layout is enabled only for apps that target the .NET Framework 4.6.  
  
## Mitigation  
 Since this modification tends to eliminate clipping of the right or bottom of WPF controls at high DPIs, apps that target earlier versions of the .NET Framework but are running on the .NET Framework 4.6 can opt into this new behavior by adding the following line to the `<runtime>` section of the app.config file:  
  
```xml  
<AppContextSwitchOverrides value="Switch.MS.Internal.DoNotApplyLayoutRoundingToMarginsAndBorderThickness=false" />  
```  
  
 Apps that target the .NET Framework 4.6 but want WPF controls to render using the previous layout algorithm can do so by adding the following line to the  `<runtime>` section of the app.config file:  
  
```xml  
<AppContextSwitchOverrides value="Switch.MS.Internal.DoNotApplyLayoutRoundingToMarginsAndBorderThickness=true" />  
```  
  
## See Also  
 [Retargeting Changes](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-6.md)
