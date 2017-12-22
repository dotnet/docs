---
title: "How to: Start Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Service applications, starting"
  - "services, starting"
ms.assetid: 9ea77955-2d96-4c3d-913c-14db7604cdad
caps.latest.revision: 16
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# How to: Start Services
After a service is installed, it must be started. Starting calls the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method on the service class. Usually, the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method defines the useful work the service will perform. After a service starts, it remains active until it is manually paused or stopped.  
  
 Services can be set up to start automatically or manually. A service that starts automatically will be started when the computer on which it is installed is rebooted or first turned on. A user must start a service that starts manually.  
  
> [!NOTE]
>  By default, services created with [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] are set to start manually.  
  
 There are several ways you can manually start a service — from **Server Explorer**, from the **Services Control Manager**, or from code using a component called the <xref:System.ServiceProcess.ServiceController>.  
  
 You set the <xref:System.ServiceProcess.ServiceInstaller.StartType%2A> property on the <xref:System.ServiceProcess.ServiceInstaller> class to determine whether a service should be started manually or automatically.  
  
### To specify how a service should start  
  
1.  After creating your service, add the necessary installers for it. For more information, see [How to: Add Installers to Your Service Application](../../../docs/framework/windows-services/how-to-add-installers-to-your-service-application.md).  
  
2.  In the designer, click the service installer for the service you are working with.  
  
3.  In the **Properties** window, set the <xref:System.ServiceProcess.ServiceInstaller.StartType%2A> property to one of the following:  
  
    |To have your service install|Set this value|  
    |----------------------------------|--------------------|  
    |When the computer is restarted|**Automatic**|  
    |When an explicit user action starts the service|**Manual**|  
  
    > [!TIP]
    >  To prevent your service from being started at all, you can set the <xref:System.ServiceProcess.ServiceInstaller.StartType%2A> property to **Disabled**. You might do this if you are going to reboot a server several times and want to save time by preventing the services that would normally start from starting up.  
  
    > [!NOTE]
    >  These and other properties can be changed after your service is installed.  
  
     There are several ways you can start a service that has its <xref:System.ServiceProcess.ServiceInstaller.StartType%2A> process set to **Manual** — from **Server Explorer**, from the **Windows Services Control Manager**, or from code. It is important to note that not all of these methods actually start the service in the context of the **Services Control Manager**; **Server Explorer** and programmatic methods of starting the service actually manipulate the controller.  
  
### To manually start a service from Server Explorer  
  
1.  In **Server Explorer**, add the server you want if it is not already listed. For more information, see How to: Access and Initialize Server Explorer-Database Explorer.  
  
2.  Expand the **Services** node, and then locate the service you want to start.  
  
3.  Right-click the name of the service, and click **Start**.  
  
### To manually start a service from Services Control Manager  
  
1.  Open the **Services Control Manager** by doing one of the following:  
  
    -   In Windows XP and 2000 Professional, right-click **My Computer** on the desktop, and then click **Manage**. In the dialog box that appears, expand the **Services and Applications** node.  
  
         \- or -  
  
    -   In Windows Server 2003 and Windows 2000 Server, click **Start**, point to **Programs**, click **Administrative Tools**, and then click **Services**.  
  
        > [!NOTE]
        >  In Windows NT version 4.0, you can open this dialog box from **Control Panel**.  
  
     You should now see your service listed in the **Services** section of the window.  
  
2.  Select your service in the list, right-click it, and then click **Start**.  
  
### To manually start a service from code  
  
1.  Create an instance of the <xref:System.ServiceProcess.ServiceController> class, and configure it to interact with the service you want to administer.  
  
2.  Call the <xref:System.ServiceProcess.ServiceController.Start%2A> method to start the service.  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)  
 [How to: Create Windows Services](../../../docs/framework/windows-services/how-to-create-windows-services.md)  
 [How to: Add Installers to Your Service Application](../../../docs/framework/windows-services/how-to-add-installers-to-your-service-application.md)
