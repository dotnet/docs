---
title: "Hosting in a Windows Service Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f4199998-27f3-4dd9-aee4-0a4addfa9f24
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting in a Windows Service Application
Windows services (formerly known as Windows NT services) provide a process model particularly suited to applications that must live in a long-running executable and do not display any form of user interface. The process lifetime of a Windows service application is managed by the service control manager (SCM), which allows you to start, stop, and pause Windows service applications. You can configure a Windows service process to start automatically when the computer starts, making it a suitable hosting environment for "always on" applications. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] Windows service applications, see [Windows Service Applications](http://go.microsoft.com/fwlink/?LinkId=89450).  
  
 Applications that host long-running [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services share many characteristics with Windows services. In particular, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services are long-running server executables that do not interact directly with the user and therefore do not implement any form of user interface. As such, hosting [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services inside of a Windows service application is one option for building robust, long-running, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications.  
  
 Often, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] developers must decide whether to host their [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application inside of a Windows service application or inside of the Internet Information Services (IIS) or Windows Process Activation Service (WAS) hosting environment. You should consider using Windows service applications under the following conditions:  
  
-   Your application requires explicit activation. For example, you should use Windows services when your application must start automatically when the server starts instead of being dynamically started in response to the first incoming message.  
  
-   The process that hosts your application must remain running once started. Once started, a Windows service process remains running unless explicitly shut down by a server administrator using the service control manager. Applications hosted in IIS or WAS may be started and stopped dynamically to make optimal use of system resources. Applications that require explicit control over the lifetime of their hosting process should use Windows services instead of IIS or WAS.  
  
-   Your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service must run on Windows Server 2003 and use transports other than HTTP. On Windows Server 2003, the [!INCLUDE[iis601](../../../../includes/iis601-md.md)] hosting environment is restricted to HTTP communication only. Windows service applications are not subject to this restriction and can use any transport [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports, including net.tcp, net.pipe, and net.msmq.  
  
### To host WCF inside of a Windows service application  
  
1.  Create a Windows service application. You can write Windows service applications in managed code using the classes in the <xref:System.ServiceProcess> namespace. This application must include one class that inherits from <xref:System.ServiceProcess.ServiceBase>.  
  
2.  Link the lifetime of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services to the lifetime of the Windows service application. Typically, you want [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in a Windows service application to become active when the hosting service starts, stop listening for messages when the hosting service is stopped, and shut down the hosting process when the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service encounters an error. This can be accomplished as follows:  
  
    -   Override <xref:System.ServiceProcess.ServiceBase.OnStart%28System.String%5B%5D%29> to open one or more instances of <xref:System.ServiceModel.ServiceHost>. A single Windows service application can host multiple [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that start and stop as a group.  
  
    -   Override <xref:System.ServiceProcess.ServiceBase.OnStop%2A> to call <xref:System.ServiceModel.Channels.CommunicationObject.Closed> on the <xref:System.ServiceModel.ServiceHost> any running [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that were started during <xref:System.ServiceProcess.ServiceBase.OnStart%28System.String%5B%5D%29>.  
  
    -   Subscribe to the <xref:System.ServiceModel.Channels.CommunicationObject.Faulted> event of <xref:System.ServiceModel.ServiceHost> and use the <xref:System.ServiceProcess.ServiceController> class to shut down the Windows service application in case of error.  
  
     Windows service applications that host [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services are deployed and managed in the same way as Windows service applications that do not make use of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## See Also  
 <xref:System.ServiceProcess>  
 [Walkthrough: Creating a Windows Service Application in the Component Designer](http://go.microsoft.com/fwlink/?LinkId=94875)  
 [How to: Host a WCF Service in a Managed Windows Service](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-a-managed-windows-service.md)  
 [Windows Service Host](../../../../docs/framework/wcf/samples/windows-service-host.md)  
 [Service Application Programming Architecture](http://go.microsoft.com/fwlink/?LinkId=94876)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
