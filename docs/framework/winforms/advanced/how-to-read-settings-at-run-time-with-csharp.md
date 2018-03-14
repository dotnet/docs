---
title: "How To: Read Settings at Run Time With C#"
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
  - "application settings [Windows Forms], reading"
  - "application settings [Windows Forms], run time"
  - "application settings [Windows Forms], C#"
ms.assetid: dbe8bf09-5e1c-49da-9192-154033d7240b
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How To: Read Settings at Run Time With C# #
You can read both Application-scoped and User-scoped settings at run time via the Properties object. The Properties object exposes all of the default settings for the project via the Properties.Settings.Default member.  
  
### To Read Settings at Run Time with C#  
  
-   Access the appropriate setting via the Properties.Settings.Default member. The following example shows how to assign a setting named `myColor` to a BackColor property. It requires you to have previously created a Settings file containing a setting named `myColor` of type `System.Drawing.Color`. For information about creating a Settings file, see [How To: Create a New Setting at Design Time](../../../../docs/framework/winforms/advanced/how-to-create-a-new-setting-at-design-time.md).  
  
    ```  
    // C#  
    this.BackColor = Properties.Settings.Default.myColor;  
    ```  
  
## See Also  
 [Using Application Settings and User Settings](../../../../docs/framework/winforms/advanced/using-application-settings-and-user-settings.md)  
 [How To: Write User Settings at Run Time with C#](../../../../docs/framework/winforms/advanced/how-to-write-user-settings-at-run-time-with-csharp.md)  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)
