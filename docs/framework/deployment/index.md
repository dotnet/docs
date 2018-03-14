---
title: "Deploying the .NET Framework and Applications"
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
  - "deploying applications [.NET Framework], packaging"
  - "deploying applications [.NET Framework]"
  - "deploying applications [.NET Framework], features"
  - "deploying applications [.NET Framework], distribution"
  - ".NET Framework, deploying"
  - ".NET Framework application deployment"
ms.assetid: 238d8284-6042-4a38-a7f6-1ee8efd719da
caps.latest.revision: 56
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deploying the .NET Framework and Applications
This article helps you get started deploying the .NET Framework with your application. Most of the information is intended for developers, OEMs, and enterprise administrators. Users who want to install the .NET Framework on their computers should read [Installing the .NET Framework](~/docs/framework/install/index.md).  
  
## Key Deployment Resources  
 Use the following links to other MSDN topics for specific information about deploying and servicing the .NET Framework.  
  
 **Setup and deployment**  
  
-   General installer and deployment information:  
  
    -   Installer options:  
  
        -   [Web installer](~/docs/framework/install/guide-for-developers.md#to-install-or-download-the-net-framework-redistributable)  
  
        -   [Offline installer](~/docs/framework/install/guide-for-developers.md#to-install-or-download-the-net-framework-redistributable)  
  
    -   Installation modes:  
  
        -   [Silent installation](../../../docs/framework/deployment/deployment-guide-for-developers.md#chaining_custom)  
  
        -   [Displaying a UI](../../../docs/framework/deployment/deployment-guide-for-developers.md#chaining_default)  
  
    -   [Reducing system restarts during .NET Framework 4.5 installations](../../../docs/framework/deployment/reducing-system-restarts.md)  
  
    -   [Troubleshoot blocked .NET Framework installations and uninstallations](~/docs/framework/install/troubleshoot-blocked-installations-and-uninstallations.md)  
  
-   Deploying the .NET Framework with a client application (for developers):  
  
    -   [Using InstallShield](../../../docs/framework/deployment/deployment-guide-for-developers.md#installshield-deployment) in a setup and deployment project  
  
    -   [Using a Visual Studio ClickOnce application](../../../docs/framework/deployment/deployment-guide-for-developers.md#clickonce-deployment)  
  
    -   [Creating a WiX installation package](../../../docs/framework/deployment/deployment-guide-for-developers.md#wix)  
  
    -   [Using a custom installer](../../../docs/framework/deployment/deployment-guide-for-developers.md#chaining)  
  
    -   [Additional information](../../../docs/framework/deployment/deployment-guide-for-developers.md) for developers  
  
-   Deploying the .NET Framework (for OEMs and administrators):  
  
    -   [Windows Assessment and Deployment Kit (ADK)](http://go.microsoft.com/fwlink/p/?LinkId=254976)  
  
    -   [Administrator's guide](../../../docs/framework/deployment/guide-for-administrators.md)  
  
 **Servicing**  
  
-   For general information, see the [.NET Framework blog](http://go.microsoft.com/fwlink/p/?LinkId=254977)  
  
-   [Detecting versions](../../../docs/framework/migration-guide/how-to-determine-which-versions-are-installed.md)  
  
-   [Detecting service packs and updates](../../../docs/framework/migration-guide/how-to-determine-which-net-framework-updates-are-installed.md)  
  
## Features That Simplify Deployment  
 The .NET Framework provides a number of basic features that make it easier to deploy your applications:  
  
-   No-impact applications.  
  
     This feature provides application isolation and eliminates DLL conflicts. By default, components do not affect other applications.  
  
-   Private components by default.  
  
     By default, components are deployed to the application directory and are visible only to the containing application.  
  
-   Controlled code sharing.  
  
     Code sharing requires you to explicitly make code available for sharing instead of being the default behavior.  
  
-   Side-by-side versioning.  
  
     Multiple versions of a component or application can coexist, you can choose which versions to use, and the common language runtime enforces versioning policy.  
  
-   XCOPY deployment and replication.  
  
     Self-described and self-contained components and applications can be deployed without registry entries or dependencies.  
  
-   On-the-fly updates.  
  
     Administrators can use hosts, such as ASP.NET, to update program DLLs, even on remote computers.  
  
-   Integration with the Windows Installer.  
  
     Advertisement, publishing, repair, and install-on-demand are all available when deploying your application.  
  
-   Enterprise deployment.  
  
     This feature provides easy software distribution, including using Active Directory.  
  
-   Downloading and caching.  
  
     Incremental downloads keep downloads smaller, and components can be isolated for use only by the application for low-impact deployment.  
  
-   Partially trusted code.  
  
     Identity is based on the code instead of the user, and no certificate dialog boxes appear.  
  
## Packaging and Distributing .NET Framework Applications  
 Some of the packaging and deployment information for the .NET Framework is described in other sections of the documentation. Those sections provide information about the self-describing units called [assemblies](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md), which require no registry entries, [strong-named assemblies](../../../docs/framework/app-domains/strong-named-assemblies.md), which ensure name uniqueness and prevent name spoofing, and [assembly versioning](../../../docs/framework/app-domains/assembly-versioning.md), which addresses many of the problems associated with DLL conflicts. The following sections provide information about packaging and distributing .NET Framework applications.  
  
### Packaging  
 The .NET Framework provides the following options for packaging applications:  
  
-   As a single assembly or as a collection of assemblies.  
  
     With this option, you simply use the .dll or .exe files as they were built.  
  
-   As cabinet (CAB) files.  
  
     With this option, you compress files into .cab files to make distribution or download less time consuming.  
  
-   As a Windows Installer package or in other installer formats.  
  
     With this option, you create .msi files for use with the Windows Installer, or you package your application for use with some other installer.  
  
### Distribution  
 The .NET Framework provides the following options for distributing applications:  
  
-   Use XCOPY or FTP.  
  
     Because common language runtime applications are self-describing and require no registry entries, you can use XCOPY or FTP to simply copy the application to an appropriate directory. The application can then be run from that directory.  
  
-   Use code download.  
  
     If you are distributing your application over the Internet or through a corporate intranet, you can simply download the code to a computer and run the application there.  
  
-   Use an installer program such as Windows Installer 2.0.  
  
     Windows Installer 2.0 can install, repair, or remove .NET Framework assemblies in the global assembly cache and in private directories.  
  
### Installation Location  
 To determine where to deploy your application's assemblies so they can be found by the runtime, see [How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md).  
  
 Security considerations can also affect how you deploy your application. Security permissions are granted to managed code according to where the code is located. Deploying an application or component to a location where it receives little trust, such as the Internet, limits what the application or component can do. For more information about deployment and security considerations, see [Code Access Security Basics](../../../docs/framework/misc/code-access-security-basics.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)|Describes how the common language runtime determines which assembly to use to fulfill a binding request.|  
|[Best Practices for Assembly Loading](../../../docs/framework/deployment/best-practices-for-assembly-loading.md)|Discusses ways to avoid problems of type identity that can lead to <xref:System.InvalidCastException>, <xref:System.MissingMethodException>, and other errors.|  
|[Reducing System Restarts During .NET Framework 4.5 Installations](../../../docs/framework/deployment/reducing-system-restarts.md)|Describes the Restart Manager, which prevents reboots whenever possible, and explains how applications that install the .NET Framework can take advantage of it.|  
|[Deployment Guide for Administrators](../../../docs/framework/deployment/guide-for-administrators.md)|Explains how a system administrator can deploy the .NET Framework and its system dependencies across a network by using System Center Configuration Manager (SCCM).|  
|[Deployment Guide for Developers](../../../docs/framework/deployment/deployment-guide-for-developers.md)|Explains how developers can install .NET Framework on their users' computers with their applications.|  
|[Deploying Applications, Services, and Components](/visualstudio/deployment/deploying-applications-services-and-components)|Discusses deployment options in Visual Studio, including instructions for publishing an application using the ClickOnce and Windows Installer technologies.| 
|[Publishing ClickOnce Applications](/visualstudio/deployment/publishing-clickonce-applications)|Describes how to package a Windows Forms application and deploy it with ClickOnce to client computers on a network.|  
|[Packaging and Deploying Resources](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md)|Describes the hub and spoke model that the .NET Framework uses to package and deploy resources; covers resource naming conventions, fallback process, and packaging alternatives.|  
|[Deploying an Interop Application](../../../docs/framework/interop/deploying-an-interop-application.md)|Explains how to ship and install interop applications, which typically include a .NET Framework client assembly, one or more interop assemblies representing distinct COM type libraries, and one or more registered COM components.|  
|[How to: Get Progress from the .NET Framework 4.5 Installer](../../../docs/framework/deployment/how-to-get-progress-from-the-dotnet-installer.md)|Describes how to silently launch and track the .NET Framework setup process while showing your own view of the setup progress.|  
  
## See Also  
 [Development Guide](../../../docs/framework/development-guide.md)
