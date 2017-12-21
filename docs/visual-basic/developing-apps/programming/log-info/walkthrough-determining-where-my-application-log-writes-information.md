---
title: "Determining Where My.Application.Log Writes Information (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "My.Log object, output location"
  - "output, application log location"
  - "My.Application.Log object, outpout location"
  - "event logs, determining output location"
  - "application event logs, output location"
  - "applications [Visual Basic], output location"
ms.assetid: 5b70143a-7741-45f2-ae1d-03324a3a4189
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Determining Where My.Application.Log Writes Information (Visual Basic)
The `My.Application.Log` object can write information to several log listeners. The log listeners are configured by the computer's configuration file and can be overridden by an application's configuration file. This topic describes the default settings and how to determine the settings for your application.  
  
 For more information about the default output locations, see [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md).  
  
### To determine the listeners for My.Application.Log  
  
1.  Locate the assembly's configuration file. If you are developing the assembly, you can access the app.config in [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] from the **Solution Explorer**. Otherwise, the configuration file name is the assembly's name appended with ".config", and it is located in the same directory as the assembly.  
  
    > [!NOTE]
    >  Not every assembly has a configuration file.  
  
     The configuration file is an XML file.  
  
2.  Locate the `<listeners>` section, in the `<source>` section with the `name` attribute "DefaultSource", located in the `<sources>` section. The `<sources>` section is located in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
     If these sections do not exist, then the computer's configuration file may configure the `My.Application.Log` log listeners. The following steps describe how to determine what the computer configuration file defines:  
  
    1.  Locate the computer's machine.config file. Typically, it is located in the *SystemRoot\Microsoft.NET\Framework\frameworkVersion\CONFIG* directory, where `SystemRoot` is the operating system directory, and `frameworkVersion` is the version of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)].  
  
         The settings in machine.config can be overridden by an application's configuration file.  
  
         If the optional elements listed below do not exist, you can create them.  
  
    2.  Locate the `<listeners>` section, in the `<source>` section with the `name` attribute "DefaultSource", in the `<sources>` section, in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
         If these sections do not exist, then the `My.Application.Log` has only the default log listeners.  
  
3.  Locate the <`add>` elements in the <`listeners>` section.  
  
     These elements add the named log listeners to `My.Application.Log` source.  
  
4.  Locate the `<add>` elements with the names of the log listeners in the `<sharedListeners>` section, in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
5.  For many types of shared listeners, the listener's initialization data includes a description of where the listener directs the data:  
  
    -   A <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener?displayProperty=nameWithType> listener writes to a file log, as described in the introduction.  
  
    -   A <xref:System.Diagnostics.EventLogTraceListener?displayProperty=nameWithType> listener writes information to the computer event log specified by the `initializeData` parameter. To view an event log, you can use **Server Explorer** or **Windows Event Viewer**. For more information, see [ETW Events in the .NET Framework](../../../../framework/performance/etw-events.md).  
  
    -   The <xref:System.Diagnostics.DelimitedListTraceListener?displayProperty=nameWithType> and <xref:System.Diagnostics.XmlWriterTraceListener?displayProperty=nameWithType> listeners write to the file specified in the `initializeData` parameter.  
  
    -   A <xref:System.Diagnostics.ConsoleTraceListener?displayProperty=nameWithType> listener writes to the command-line console.  
  
    -   For information about where other types of log listeners write information, consult that type's documentation.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>  
 <xref:System.Diagnostics.DefaultTraceListener>  
 <xref:System.Diagnostics.EventLogTraceListener>  
 <xref:System.Diagnostics.DelimitedListTraceListener>  
 <xref:System.Diagnostics.XmlWriterTraceListener>  
 <xref:System.Diagnostics.ConsoleTraceListener>  
 <xref:System.Diagnostics>  
 [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md)  
 [How to: Log Exceptions](../../../../visual-basic/developing-apps/programming/log-info/how-to-log-exceptions.md)  
 [How to: Write Log Messages](../../../../visual-basic/developing-apps/programming/log-info/how-to-write-log-messages.md)  
 [Walkthrough: Changing Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-changing-where-my-application-log-writes-information.md)  
 [ETW Events in the .NET Framework](../../../../framework/performance/etw-events.md)  
 [Troubleshooting: Log Listeners](../../../../visual-basic/developing-apps/programming/log-info/troubleshooting-log-listeners.md)
