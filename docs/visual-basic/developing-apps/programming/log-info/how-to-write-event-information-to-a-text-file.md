---
title: "How to: Write Event Information to a Text File (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "event logs [Visual Studio], writing event information"
  - "text files [Visual Basic], writing event information to a text file"
  - "events [Visual Basic], writing event information to a text file"
ms.assetid: 9ca7cc03-bf99-4933-9e5e-61ee28e9a6b4
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Write Event Information to a Text File (Visual Basic)
You can use the `My.Application.Log` and `My.Log` objects to log information about events that occur in your application. This example shows how to use the `My.Application.Log.WriteEntry` method to log tracing information to a log file.  
  
### To add and configure the file log listener  
  
1.  Right-click app.config in **Solution Explorer** and choose **Open**.  
  
     \- or -  
  
     If there is no app.config file:  
  
    1.  On the **Project** menu, choose **Add New Item**.  
  
    2.  From the **Add New Item** dialog box, choose **Application Configuration File**.  
  
    3.  Click **Add**.  
  
2.  Locate the `<listeners>` section in the application configuration file.  
  
     You will find the \<listeners> section in the \<source> section with the name attribute "DefaultSource", which is nested under the \<system.diagnostics> section, which is nested under the top-level \<configuration> section.  
  
3.  Add this element to that `<listeners>` section:  
  
    ```xml  
    <add name="FileLogListener" />  
    ```  
  
4.  Locate the `<sharedListeners>` section in the `<system.diagnostics>` section, nested under the top-level `<configuration>` section.  
  
5.  Add this element to that `<sharedListeners>` section:  
  
    ```xml  
    <add name="FileLogListener"   
        type="Microsoft.VisualBasic.Logging.FileLogTraceListener,   
              Microsoft.VisualBasic, Version=8.0.0.0, Culture=neutral,   
              PublicKeyToken=b03f5f7f11d50a3a"  
        initializeData="FileLogListenerWriter"  
        location="Custom"  
        customlocation="c:\temp\" />  
    ```  
  
     Change the value of the `customlocation` attribute to the log directory.  
  
    > [!NOTE]
    >  To set the value of a listener property, use an attribute that has the same name as the property, with all letters in the name lowercase. For example, the `location` and `customlocation` attributes set the values of the <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.Location%2A> and <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.CustomLocation%2A> properties.  
  
### To write event information to the file log  
  
-   Use the `My.Application.Log.WriteEntry` or `My.Application.Log.WriteException` method to write information to the file log. For more information, see [How to: Write Log Messages](../../../../visual-basic/developing-apps/programming/log-info/how-to-write-log-messages.md) and [How to: Log Exceptions](../../../../visual-basic/developing-apps/programming/log-info/how-to-log-exceptions.md).  
  
     After you configure the file log listener for an assembly, it receives all messages that `My.Application.Log` writes from that assembly.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>  
 <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A>  
 <xref:Microsoft.VisualBasic.Logging.Log.WriteException%2A>  
 [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md)  
 [How to: Log Exceptions](../../../../visual-basic/developing-apps/programming/log-info/how-to-log-exceptions.md)
