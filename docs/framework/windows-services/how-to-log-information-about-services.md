---
title: "How to: Log Information About Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "AutoLog property"
  - "services, logging information"
  - "Windows Service applications, logging information about"
  - "event logs, service applications"
  - "application event logs, service applications"
  - "logs, service applications"
ms.assetid: c0d8140f-c055-4d8e-a2e0-37358a550116
caps.latest.revision: 17
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# How to: Log Information About Services
By default, all Windows Service projects have the ability to interact with the Application event log and write information and exceptions to it. You use the <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> property to indicate whether you want this functionality in your application. By default, logging is turned on for any service you create with the Windows Service project template. You can use a static form of the <xref:System.Diagnostics.EventLog> class to write service information to a log without having to create an instance of an <xref:System.Diagnostics.EventLog> component or manually register a source.  
  
 The installer for your service automatically registers each service in your project as a valid source of events with the Application log on the computer where the service is installed, when logging is turned on. The service logs information each time the service is started, stopped, paused, resumed, installed, or uninstalled. It also logs any failures that occur. You do not need to write any code to write entries to the log when using the default behavior; the service handles this for you automatically.  
  
 If you want to write to an event log other than the Application log, you must set the <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> property to `false`, create your own custom event log within your services code, and register your service as a valid source of entries for that log. You must then write code to record entries to the log whenever an action you're interested in occurs.  
  
> [!NOTE]
>  If you use a custom event log and configure your service application to write to it, you must not attempt to access the event log before setting the service's <xref:System.ServiceProcess.ServiceBase.ServiceName%2A> property in your code. The event log needs this property's value to register your service as a valid source of events.  
  
### To enable default event logging for your service  
  
-   Set the <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> property for your component to `true`.  
  
    > [!NOTE]
    >  By default, this property is set to `true`. You do not need to set this explicitly unless you are building more complex processing, such as evaluating a condition and then setting the <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> property based on the result of that condition.  
  
### To disable event logging for your service  
  
-   Set the <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> property for your component to `false`.  
  
     [!code-csharp[VbRadconService#17](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#17)]
     [!code-vb[VbRadconService#17](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#17)]  
  
### To set up logging to a custom log  
  
1.  Set the <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> property to `false`.  
  
    > [!NOTE]
    >  You must set <xref:System.ServiceProcess.ServiceBase.AutoLog%2A> to false in order to use a custom log.  
  
2.  Set up an instance of an <xref:System.Diagnostics.EventLog> component in your Windows Service application.  
  
3.  Create a custom log by calling the <xref:System.Diagnostics.EventLog.CreateEventSource%2A> method and specifying the source string and the name of the log file you want to create.  
  
4.  Set the <xref:System.Diagnostics.EventLog.Source%2A> property on the <xref:System.Diagnostics.EventLog> component instance to the source string you created in step 3.  
  
5.  Write your entries by accessing the <xref:System.Diagnostics.EventLog.WriteEntry%2A> method on the <xref:System.Diagnostics.EventLog> component instance.  
  
     The following code shows how to set up logging to a custom log.  
  
    > [!NOTE]
    >  In this code example, an instance of an <xref:System.Diagnostics.EventLog> component is named `eventLog1` (`EventLog1` in Visual Basic). If you created an instance with another name in step 2, change the code accordingly.  
  
     [!code-csharp[VbRadconService#14](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#14)]
     [!code-vb[VbRadconService#14](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#14)]  
    [!code-csharp[VbRadconService#15](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#15)]
    [!code-vb[VbRadconService#15](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#15)]  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)
