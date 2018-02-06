---
title: "How to: Add Installers to Your Service Application"
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
  - "Windows Service applications, deploying"
  - "installation components, adding to services"
  - "installers, adding to services"
  - "Windows Service applications, adding installers"
  - "services, adding installers"
  - "ServiceInstaller class, adding installers to services"
  - "ServiceProcessInstaller class, adding installers to services"
ms.assetid: 8b698e9a-b88e-4f44-ae45-e0c5ea0ae5a8
caps.latest.revision: 14
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# How to: Add Installers to Your Service Application
Visual Studio ships installation components that can install resources associated with your service applications. Installation components register an individual service on the system to which it is being installed and let the Services Control Manager know that the service exists. When you work with a service application, you can select a link in the Properties window to automatically add the appropriate installers to your project.  
  
> [!NOTE]
>  Property values for your service are copied from the service class to the installer class. If you update the property values on the service class, they are not automatically updated in the installer.  
  
 When you add an installer to your project, a new class (which, by default, is named `ProjectInstaller`) is created in the project, and instances of the appropriate installation components are created within it. This class acts as a central point for all of the installation components your project needs. For example, if you add a second service to your application and click the Add Installer link, a second installer class is not created; instead, the necessary additional installation component for the second service is added to the existing class.  
  
 You do not need to do any special coding within the installers to make your services install correctly. However, you may occasionally need to modify the contents of the installers if you need to add special functionality to the installation process.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add installers to your service application  
  
1.  In **Solution Explorer**, access **Design** view for the service for which you want to add an installation component.  
  
2.  Click the background of the designer to select the service itself, rather than any of its contents.  
  
3.  With the designer in focus, right-click, and then click **Add Installer**.  
  
     A new class, `ProjectInstaller`, and two installation components, <xref:System.ServiceProcess.ServiceProcessInstaller> and <xref:System.ServiceProcess.ServiceInstaller>, are added to your project, and property values for the service are copied to the components.  
  
4.  Click the <xref:System.ServiceProcess.ServiceInstaller> component and verify that the value of the <xref:System.ServiceProcess.ServiceInstaller.ServiceName%2A> property is set to the same value as the <xref:System.ServiceProcess.ServiceInstaller.ServiceName%2A> property on the service itself.  
  
5.  To determine how your service will be started, click the <xref:System.ServiceProcess.ServiceInstaller> component and set the <xref:System.ServiceProcess.ServiceInstaller.StartType%2A> property to the appropriate value.  
  
    |Value|Result|  
    |-----------|------------|  
    |<xref:System.ServiceProcess.ServiceStartMode.Manual>|The service must be manually started after installation. For more information, see [How to: Start Services](../../../docs/framework/windows-services/how-to-start-services.md).|  
    |<xref:System.ServiceProcess.ServiceStartMode.Automatic>|The service will start by itself whenever the computer reboots.|  
    |<xref:System.ServiceProcess.ServiceStartMode.Disabled>|The service cannot be started.|  
  
6.  To determine the security context in which your service will run, click the <xref:System.ServiceProcess.ServiceProcessInstaller> component and set the appropriate property values. For more information, see [How to: Specify the Security Context for Services](../../../docs/framework/windows-services/how-to-specify-the-security-context-for-services.md).  
  
7.  Override any methods for which you need to perform custom processing.  
  
8.  Perform steps 1 through 7 for each additional service in your project.  
  
    > [!NOTE]
    >  For each additional service in your project, you must add an additional <xref:System.ServiceProcess.ServiceInstaller> component to the project's `ProjectInstaller` class. The <xref:System.ServiceProcess.ServiceProcessInstaller> component added in step three works with all of the individual service installers in the project.  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)  
 [How to: Install and Uninstall Services](../../../docs/framework/windows-services/how-to-install-and-uninstall-services.md)  
 [How to: Start Services](../../../docs/framework/windows-services/how-to-start-services.md)  
 [How to: Specify the Security Context for Services](../../../docs/framework/windows-services/how-to-specify-the-security-context-for-services.md)
