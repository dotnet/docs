---
title: "Deploying applications that reference Power Packs controls (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Power Packs, deploying"
ms.assetid: f2230f53-a745-4731-89e6-033943faa209
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Deploying applications that reference Power Packs controls (Visual Studio)
If you want to deploy an application that references the Power Packs controls (<xref:Microsoft.VisualBasic.PowerPacks.LineShape>, <xref:Microsoft.VisualBasic.PowerPacks.OvalShape>, <xref:Microsoft.VisualBasic.PowerPacks.RectangleShape>, or <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>), the controls must be installed on the destination computer.  
  
## Installing the Power Packs controls as a prerequisite  
 To successfully deploy an application, you must also deploy all components that are referenced by the application. The process of installing prerequisite components is known as *bootstrapping*.  
  
 When [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] is installed on your development computer, a Power Packs bootstrapper package is added to the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] bootstrapper directory. This package is then available when you follow the procedures for adding prerequisites for either [!INCLUDE[ndptecclick](~/includes/ndptecclick-md.md)] or Windows Installer deployment.  
  
 By default, bootstrapped components are deployed from the same location as the installation package. Alternatively, you can choose to deploy the components from a URL or file share location from which users can download them as necessary.  
  
> [!NOTE]
>  To install bootstrapped components, the user might need administrative or similar user permissions on the computer. For [!INCLUDE[ndptecclick](~/includes/ndptecclick-md.md)] applications, this means that the user will need administrative permissions to install the application, regardless of the security level specified by the application. After the application is installed, the user can run the application without administrative permissions.  
  
 During installation, users will be prompted to install the Power Packs controls if they are not present on the destination computer.  
  
 As an alternative to bootstrapping, you can pre-deploy the Power Packs controls by using an electronic software distribution system such as Microsoft Systems Management Server.  
  
## See also  
 [How to: Install Prerequisites with a ClickOnce Application](/visualstudio/deployment/how-to-install-prerequisites-with-a-clickonce-application)  
 [Visual Basic Power Packs Controls](../../../visual-basic/developing-apps/windows-forms/power-packs-controls.md)
