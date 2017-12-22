---
title: "How To: Write User Settings at Run Time with C#"
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
  - "application settings [Windows Forms], run time"
  - "application settings [Windows Forms], writing user settings"
  - "application settings [Windows Forms], C#"
ms.assetid: 9d061c7d-b33b-470f-a36d-edccb1d6f9a3
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How To: Write User Settings at Run Time with C# #
Settings that are application-scoped are read-only, and can only be changed at design time or by altering the .config file in between application sessions. Settings that are user-scoped, however, can be written at run time just as you would change any property value. The new value persists for the duration of the application session. You can persist the changes to the settings between application sessions by calling the Save method.  
  
### How To: Write and Persist User Settings at Run Time with C#  
  
1.  Access the setting and assign it a new value as shown in this example:  
  
    ```  
    // C#  
    Properties.Settings.Default.myColor = Color.AliceBlue;  
    ```  
  
2.  If you want to persist the changes to the settings between application sessions, call the Save method as shown in this example:  
  
    ```  
    // C#  
    Properties.Settings.Default.Save();  
    ```  
  
     User settings are saved in a file within a subfolder of the user’s local hidden application data folder.  
  
## See Also  
 [Using Application Settings and User Settings](../../../../docs/framework/winforms/advanced/using-application-settings-and-user-settings.md)  
 [How To: Read Settings at Run Time With C#](../../../../docs/framework/winforms/advanced/how-to-read-settings-at-run-time-with-csharp.md)  
 [Application Settings Overview](../../../../docs/framework/winforms/advanced/application-settings-overview.md)
