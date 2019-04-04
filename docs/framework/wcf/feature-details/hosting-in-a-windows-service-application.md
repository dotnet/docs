---
title: "Hosting in a Windows Service Application"
ms.date: "03/30/2017"
ms.assetid: f4199998-27f3-4dd9-aee4-0a4addfa9f24
---
# Hosting in a Windows Service Application
Windows services (formerly known as Windows NT services) provide a process model particularly suited to applications that must live in a long-running executable and do not display any form of user interface. The process lifetime of a Windows service application is managed by the service control manager (SCM), which allows you to start, stop, and pause Windows service applications. You can configure a Windows service process to start automatically when the computer starts, making it a suitable hosting environment for "always on" applications. For more information about Windows service applications, see [Windows Service Applications](https://go.microsoft.com/fwlink/?LinkId=89450).  
  
 Applications that host long-running Windows Communication Foundation (WCF) services share many characteristics with Windows services. In particular, WCF services are long-running server executables that do not interact directly with the user and therefore do not implement any form of user interface. As such, hosting WCF services inside of a Windows service application is one option for building robust, long-running, WCF applications.  
  
 Often, WCF developers must decide whether to host their WCF application inside of a Windows service application or inside of the Internet Information Services (IIS) or Windows Process Activation Service (WAS) hosting environment. You should consider using Windows service applications under the following conditions:  
  
-   Your application requires explicit activation. For example, you should use Windows services when your application must start automatically when the server starts instead of being dynamically started in response to the first incoming message.  
  
-   The process that hosts your application must remain running once started. Once started, a Windows service process remains running unless explicitly shut down by a server administrator using the service control manager. Applications hosted in IIS or WAS may be started and stopped dynamically to make optimal use of system resources. Applications that require explicit control over the lifetime of their hosting process should use Windows services instead of IIS or WAS.  
  
-   Your WCF service must run on Windows Server 2003 and use transports other than HTTP. On Windows Server 2003, the [!INCLUDE[iis601](../../../../includes/iis601-md.md)] hosting environment is restricted to HTTP communication only. Windows service applications are not subject to this restriction and can use any transport WCF supports, including net.tcp, net.pipe, and net.msmq.  
  
### To host WCF inside of a Windows service application  
  
1.  Create a Windows service application. You can write Windows service applications in managed code using the classes in the <xref:System.ServiceProcess> namespace. This application must include one class that inherits from <xref:System.ServiceProcess.ServiceBase>.  
  
2.  Link the lifetime of the WCF services to the lifetime of the Windows service application. Typically, you want WCF services hosted in a Windows service application to become active when the hosting service starts, stop listening for messages when the hosting service is stopped, and shut down the hosting process when the WCF service encounters an error. This can be accomplished as follows:  
  
    -   Override <xref:System.ServiceProcess.ServiceBase.OnStart%28System.String%5B%5D%29> to open one or more instances of <xref:System.ServiceModel.ServiceHost>. A single Windows service application can host multiple WCF services that start and stop as a group.  
  
    -   Override <xref:System.ServiceProcess.ServiceBase.OnStop%2A> to call <xref:System.ServiceModel.Channels.CommunicationObject.Closed> on the <xref:System.ServiceModel.ServiceHost> any running WCF services that were started during <xref:System.ServiceProcess.ServiceBase.OnStart%28System.String%5B%5D%29>.  
  
    -   Subscribe to the <xref:System.ServiceModel.Channels.CommunicationObject.Faulted> event of <xref:System.ServiceModel.ServiceHost> and use the <xref:System.ServiceProcess.ServiceController> class to shut down the Windows service application in case of error.  
  
     Windows service applications that host WCF services are deployed and managed in the same way as Windows service applications that do not make use of WCF.  
  
## See also
- <xref:System.ServiceProcess>
- [Walkthrough: Creating a Windows Service Application in the Component Designer](https://go.microsoft.com/fwlink/?LinkId=94875)
- [How to: Host a WCF Service in a Managed Windows Service](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-a-managed-windows-service.md)
- [Windows Service Host](../../../../docs/framework/wcf/samples/windows-service-host.md)
- [Service Application Programming Architecture](https://go.microsoft.com/fwlink/?LinkId=94876)
- [Windows Server App Fabric Hosting Features](https://go.microsoft.com/fwlink/?LinkId=201276)
