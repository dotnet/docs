---
title: "Writing Projects Targeting the .NET Framework 3.0 and 3.5 in Visual Studio 2010"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 81858ab7-763c-4eac-83fe-d7205e5c4c98
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Writing Projects Targeting the .NET Framework 3.0 and 3.5 in Visual Studio 2010
You can use [!INCLUDE[vs2010](../../../includes/vs2010-md.md)] to create projects that target the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] version 3.0 or 3.5. This topic describes how to do this.  
  
> [!NOTE]
>  When adding activities, make sure that the desired version of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] is set. Changing the target version of the workflow after activities are added will cause the workflow to fail validation.  
  
> [!WARNING]
>  Opening existing workflows in [!INCLUDE[vs2010](../../../includes/vs2010-md.md)] that have .Net Framework 3.5 activities will cause an error at `this.SetValue()`. In order to open projects created with previous versions of the .Net Framework, first open a blank workflow in the designer and add a .Net Framework 3.5 activity.  
  
## To create a .NET Framework  3.0 or 3.5 project with Visual Studio 2010  
  
1.  Open [!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  
  
2.  Select **File**, **New**, **Project**.  
  
3.  In the drop-down list at the top of the dialog box, select the desired version of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)].  
  
## To upgrade the targeted version of the .NET Framework  
  
1.  Right-click the project in Solution Explorer, and select **Properties**.  
  
2.  In the **Target Framework** drop-down list, select the desired version.
