---
title: "Service Application Programming Architecture"
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
  - "ServiceController components, programming architecture"
  - "ServiceBase class, service states"
  - "Windows Service applications, code model"
  - "services, programming architecture"
  - "ServiceController class"
  - "services, states"
  - "ServiceProcessInstaller class, service application code model"
  - "Windows Service applications, states"
ms.assetid: 83230026-d068-4174-97ff-e264c896eb2f
caps.latest.revision: 15
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# Service Application Programming Architecture
Windows Service applications are based on a class that inherits from the <xref:System.ServiceProcess.ServiceBase?displayProperty=nameWithType> class. You override methods from this class and define functionality for them to determine how your service behaves.  
  
 The main classes involved in service creation are:  
  
-   <xref:System.ServiceProcess.ServiceBase?displayProperty=nameWithType> — You override methods from the <xref:System.ServiceProcess.ServiceBase> class when creating a service and define the code to determine how your service functions in this inherited class.  
  
-   <xref:System.ServiceProcess.ServiceProcessInstaller?displayProperty=nameWithType> and <xref:System.ServiceProcess.ServiceInstaller?displayProperty=nameWithType> —You use these classes to install and uninstall your service.  
  
 In addition, a class named <xref:System.ServiceProcess.ServiceController> can be used to manipulate the service itself. This class is not involved in the creation of a service, but can be used to start and stop the service, pass commands to it, and return a series of enumerations.  
  
## Defining Your Service's Behavior  
 In your service class, you override base class functions that determine what happens when the state of your service is changed in the Services Control Manager. The <xref:System.ServiceProcess.ServiceBase> class exposes the following methods, which you can override to add custom behavior.  
  
|Method|Override to|  
|------------|-----------------|  
|<xref:System.ServiceProcess.ServiceBase.OnStart%2A>|Indicate what actions should be taken when your service starts running. You must write code in this procedure for your service to perform useful work.|  
|<xref:System.ServiceProcess.ServiceBase.OnPause%2A>|Indicate what should happen when your service is paused.|  
|<xref:System.ServiceProcess.ServiceBase.OnStop%2A>|Indicate what should happen when your service stops running.|  
|<xref:System.ServiceProcess.ServiceBase.OnContinue%2A>|Indicate what should happen when your service resumes normal functioning after being paused.|  
|<xref:System.ServiceProcess.ServiceBase.OnShutdown%2A>|Indicate what should happen just prior to your system shutting down, if your service is running at that time.|  
|<xref:System.ServiceProcess.ServiceBase.OnCustomCommand%2A>|Indicate what should happen when your service receives a custom command. For more information on custom commands, see MSDN online.|  
|<xref:System.ServiceProcess.ServiceBase.OnPowerEvent%2A>|Indicate how the service should respond when a power management event is received, such as a low battery or suspended operation.|  
  
> [!NOTE]
>  These methods represent states that the service moves through in its lifetime; the service transitions from one state to the next. For example, you will never get the service to respond to an <xref:System.ServiceProcess.ServiceBase.OnContinue%2A> command before <xref:System.ServiceProcess.ServiceBase.OnStart%2A> has been called.  
  
 There are several other properties and methods that are of interest. These include:  
  
-   The <xref:System.ServiceProcess.ServiceBase.Run%2A> method on the <xref:System.ServiceProcess.ServiceBase> class. This is the main entry point for the service. When you create a service using the Windows Service template, code is inserted in your application's `Main` method to run the service. This code looks like this:  
  
     [!code-csharp[VbRadconService#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#6)]
     [!code-vb[VbRadconService#6](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#6)]  
  
    > [!NOTE]
    >  These examples use an array of type <xref:System.ServiceProcess.ServiceBase>, into which each service your application contains can be added, and then all of the services can be run together. If you are only creating a single service, however, you might choose not to use the array and simply declare a new object inheriting from <xref:System.ServiceProcess.ServiceBase> and then run it. For an example, see [How to: Write Services Programmatically](../../../docs/framework/windows-services/how-to-write-services-programmatically.md).  
  
-   A series of properties on the <xref:System.ServiceProcess.ServiceBase> class. These determine what methods can be called on your service. For example, when the <xref:System.ServiceProcess.ServiceBase.CanStop%2A> property is set to `true`, the <xref:System.ServiceProcess.ServiceBase.OnStop%2A> method on your service can be called. When the <xref:System.ServiceProcess.ServiceBase.CanPauseAndContinue%2A> property is set to `true`, the <xref:System.ServiceProcess.ServiceBase.OnPause%2A> and <xref:System.ServiceProcess.ServiceBase.OnContinue%2A> methods can be called. When you set one of these properties to `true`, you should then override and define processing for the associated methods.  
  
    > [!NOTE]
    >  Your service must override at least <xref:System.ServiceProcess.ServiceBase.OnStart%2A> and <xref:System.ServiceProcess.ServiceBase.OnStop%2A> to be useful.  
  
 You can also use a component called the <xref:System.ServiceProcess.ServiceController> to communicate with and control the behavior of an existing service.  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)  
 [How to: Create Windows Services](../../../docs/framework/windows-services/how-to-create-windows-services.md)
