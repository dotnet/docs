---
title: "How To: Change the Value of a Setting Between Application Sessions"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application settings [Windows Forms], changing"
  - "application settings [Windows Forms], between application sessions"
ms.assetid: 1a85911f-97b2-476c-930b-83379edd890c
---
# How To: Change the Value of a Setting Between Application Sessions
At times, you might want to change the value of a setting between application sessions after the application has been compiled and deployed. For example, you might want to change a connection string to point to the correct database location. Since design-time tools are not available after the application has been compiled and deployed, you must change the setting value manually in the file.  
  
### To Change the Value of a Setting Between Application Sessions  
  
1. Using Microsoft Notepad or some other text or XML editor, open the .config file associated with your application.  
  
2. Locate the entry for the setting you want to change. It should look similar to the example presented below.  
  
    ```xml  
    <setting name="Setting1" serializeAs="String" >  
       <value>My Setting Value</value>  
    </setting>  
    ```  
  
3. Type a new value for your setting and save the file.  
  
## See also

- [Using Application Settings and User Settings](using-application-settings-and-user-settings.md)
- [Application Settings Overview](application-settings-overview.md)
