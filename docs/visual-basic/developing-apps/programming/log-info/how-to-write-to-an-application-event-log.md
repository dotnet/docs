---
title: "How to: Write to an Application Event Log (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Computer.EventLog element"
  - "WriteEntry method [Visual Basic]"
  - "My.Computer.EventLog element"
  - "event logs, writing to"
ms.assetid: cadbc8c1-87af-4746-934e-55b79a4f6e2b
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Write to an Application Event Log (Visual Basic)
You can use the `My.Application.Log` and `My.Log` objects to write information about events that occur in your application. This example shows how to configure an event log listener so `My.Application.Log` writes tracing information to the Application event log.  
  
 You cannot write to the Security log. In order to write to the System log, you must be a member of the LocalSystem or Administrator account.  
  
 To view an event log, you can use **Server Explorer** or **Windows Event Viewer**. For more information, see [ETW Events in the .NET Framework](../../../../framework/performance/etw-events.md).  
  
> [!NOTE]
>  Event logs are not supported on Windows 95, Windows 98, or Windows Millennium Edition.  
  
### To add and configure the event log listener  
  
1.  Right-click app.config in **Solution Explorer** and choose **Open**.  
  
     \- or -  
  
     If there is no app.config file,  
  
    1.  On the **Project** menu, choose **Add New Item**.  
  
    2.  From the **Add New Item** dialog box, choose **Application Configuration File**.  
  
    3.  Click **Add**.  
  
2.  Locate the `<listeners>` section in the application configuration file.  
  
     You will find the `<listeners>` section in the `<source>` section with the name attribute "DefaultSource", which is nested under the `<system.diagnostics>` section, which is nested under the top-level `<configuration>` section.  
  
3.  Add this element to that `<listeners>` section:  
  
    ```xml  
    <add name="EventLog"/>  
    ```  
  
4.  Locate the `<sharedListeners>` section, in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
5.  Add this element to that `<sharedListeners>` section:  
  
    ```xml  
    <add name="EventLog"  
        type="System.Diagnostics.EventLogTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  
         initializeData="APPLICATION_NAME"/>  
    ```  
  
     Replace `APPLICATION_NAME` with the name of your application.  
  
    > [!NOTE]
    >  Typically, an application writes only errors to the event log. For information on filtering log output, see [Walkthrough: Filtering My.Application.Log Output](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-filtering-my-application-log-output.md).  
  
### To write event information to the event log  
  
-   Use the `My.Application.Log.WriteEntry` or `My.Application.Log.WriteException` method to write information to the event log. For more information, see [How to: Write Log Messages](../../../../visual-basic/developing-apps/programming/log-info/how-to-write-log-messages.md) and [How to: Log Exceptions](../../../../visual-basic/developing-apps/programming/log-info/how-to-log-exceptions.md).  
  
     After you configure the event log listener for an assembly, it receives all messages that `My.Applcation.Log` writes from that assembly.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>  
 <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A>  
 <xref:Microsoft.VisualBasic.Logging.Log.WriteException%2A>  
 [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md)  
 [How to: Log Exceptions](../../../../visual-basic/developing-apps/programming/log-info/how-to-log-exceptions.md)  
 [Walkthrough: Determining Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-determining-where-my-application-log-writes-information.md)
