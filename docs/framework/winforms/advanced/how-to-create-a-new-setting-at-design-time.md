---
title: "How To: Create a New Setting at Design Time"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "application settings [Windows Forms], design time"
  - "application settings [Windows Forms], creating"
ms.assetid: c5d60a66-6507-462f-a81f-e3bc0a804e16
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How To: Create a New Setting at Design Time
You can create a new setting at design time by using the Settings designer. The Settings designer is a grid-style interface that allows you to create new settings and specify properties for those settings. You must specify Name, Value, Type and Scope for your new settings. Once a setting is created, it is accessible in code.  
  
### To create a new setting at design time in C#  
  
1.  In **Solution Explorer**, expand the **Properties** node of your project.  
  
2.  Double-click the .settings file in which you want to add a new setting. The default name for this file is Settings.settings.  
  
3.  In the Settings designer, set the Name, Value, Type, and Scope for your setting. Each row represents a single setting.  
  
### To create a new setting at design time in Visual Basic  
  
1.  In **Solution Explorer**, right-click your project node and choose **Properties**.  
  
2.  In the **Properties** page, select the **Settings** tab.  
  
3.  In the Settings designer, set the Name, Value, Type, and Scope for your setting. Each row represents a single setting.  
  
## See Also  
 [Using Application Settings and User Settings](../../../../docs/framework/winforms/advanced/using-application-settings-and-user-settings.md)  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)  
 [How To: Change the Value of an Existing Setting at Design Time](../../../../docs/framework/winforms/advanced/how-to-change-the-value-of-an-existing-setting-at-design-time.md)
