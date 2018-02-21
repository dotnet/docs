---
title: "How to: Install and Uninstall Services"
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
  - "services, uninstalling"
  - "services, installing"
  - "installing Windows Services"
  - "uninstalling applications, Windows Services"
  - "installation, Windows Services"
  - "uninstalling Windows Services"
  - "installutil.exe tool"
ms.assetid: c89c5169-f567-4305-9d62-db31a1de5481
caps.latest.revision: 19
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# How to: Install and Uninstall Services
If you’re developing a Windows Service by using the .NET Framework, you can quickly install your service application by using a command-line utility called InstallUtil.exe. If you’re a developer who wants to release a Windows Service that users can install and uninstall  you should use InstallShield. See [Windows Installer Deployment](http://msdn.microsoft.com/library/121be21b-b916-43e2-8f10-8b080516d2a0).  
  
> [!WARNING]
>  If you want to uninstall a service from your computer, don’t follow the steps in this article. Instead, find out which program or software package installed the service, and then choose **Add/Remove Programs** in Control Panel to uninstall that program. Note that many services are integral parts of Windows; if you remove them, you might cause system instability.  
  
 In order to use the steps in this article, you first need to add a service installer to your Windows Service. See [Walkthrough: Creating a Windows Service Application in the Component Designer](../../../docs/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer.md).  
  
 Windows Service projects cannot be run directly from the Visual Studio development environment by pressing F5. This is because the service in the project must be installed before you can run the project.  
  
> [!TIP]
>  You can launch **Server Explorer** and verify that your service has been installed or uninstalled. For more information, see How to: Access and Initialize Server Explorer-Database Explorer.  
  
### To install your service manually  
  
1.  On the Windows **Start** menu or **Start** screen, choose **Visual Studio** , **Visual Studio Tools**, **Developer Command Prompt**.  
  
     A Visual Studio command prompt appears.  
  
2.  Access the directory where your project's compiled executable file is located.  
  
3.  Run InstallUtil.exe from the command prompt with your project's executable as a parameter:  
  
    ```  
    installutil <yourproject>.exe  
    ```  
  
     If you’re using the Visual Studio command prompt, InstallUtil.exe should be on the system path. If not, you can add it to the path, or use the fully qualified path to invoke it. This tool is installed with the .NET Framework, and its path is `%WINDIR%\Microsoft.NET\Framework[64]\<framework_version>`. For example, for the 32-bit version of the .NET Framework 4 or 4.5.*, if your Windows installation directory is C:\Windows, the path is `C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe`. For the 64-bit version of the .NET Framework 4 or 4.5.\*, the default path is `C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe`.  
  
### To uninstall your service manually  
  
1.  On the Windows **Start** menu or **Start** screen, choose **Visual Studio**, **Visual Studio Tools**, **Developer Command Prompt**.  
  
     A Visual Studio command prompt appears.  
  
2.  Run InstallUtil.exe from the command prompt with your project's output as a parameter:  
  
    ```  
    installutil /u <yourproject>.exe  
    ```  
  
3.  Sometimes, after the executable for a service is deleted, the service might still be present in the registry. In that case, use the command [sc delete](http://technet.microsoft.com/library/cc742045.aspx) to remove the entry for the service from the registry.  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)  
 [How to: Create Windows Services](../../../docs/framework/windows-services/how-to-create-windows-services.md)  
 [How to: Add Installers to Your Service Application](../../../docs/framework/windows-services/how-to-add-installers-to-your-service-application.md)  
 [Installutil.exe (Installer Tool)](../../../docs/framework/tools/installutil-exe-installer-tool.md)
