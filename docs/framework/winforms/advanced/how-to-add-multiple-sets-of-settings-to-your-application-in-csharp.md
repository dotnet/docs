---
title: "How To: Add Multiple Sets of Settings To Your Application in C#"
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
  - "application settings [Windows Forms], multiple sets"
  - "application settings [Windows Forms], C#"
ms.assetid: 45007ac6-cf07-4be7-bc38-3f0ef962faf9
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How To: Add Multiple Sets of Settings To Your Application in C# #
In some cases, you might want to have multiple sets of settings in an application. For example, if you are developing an application where a particular group of settings is expected to change frequently, it might be wise to separate them all into a single file so that the file can be replaced wholesale, leaving other settings unaffected. Visual Studio allows you to add multiple sets of settings to your project. Additional sets of settings can be accessed via the Properties.Settings object.  
  
### To Add an Additional Set of Setting to your Application  
  
1.  From the **Project** menu, choose **Add New Item**. The **Add New Item** dialog box opens.  
  
2.  In the **Add New Item** dialog box, select **Settings File**, type in a name for the file, and click **Add** to add a new settings file to your solution.  
  
3.  In **Solution Explorer**, drag the new Settings file into the **Properties** folder. This allows your new settings to be available in code.  
  
4.  Add and use settings in this file as you would any other settings file. You can access this group of settings via the Properties.Settings object.  
  
## See Also  
 [Using Application Settings and User Settings](../../../../docs/framework/winforms/advanced/using-application-settings-and-user-settings.md)  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)
