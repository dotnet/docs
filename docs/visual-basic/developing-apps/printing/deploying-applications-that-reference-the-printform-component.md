---
title: "Deploying applications that reference the PrintForm component (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "PrintForm component [Visual Basic], deploying"
ms.assetid: b595ea44-a712-4625-a761-190c64f59bbe
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Deploying applications that reference the PrintForm component (Visual Basic)
If you want to deploy an application that references the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component, the component must be installed on the destination computer.  
  
 The PowerPack controls are no longer included in Visual Studio, but you can download them from the [Download Center](http://www.microsoft.com/en-us/download/details.aspx?id=25169).  
  
## Installing the PrintForm as a prerequisite  
 To successfully deploy an application, you must also deploy all components that are referenced by the application. The process of installing prerequisite components is known as *bootstrapping*.  
  
 When the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is installed on your development computer, a Microsoft Visual Basic Power Packs bootstrapper package is added to the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] bootstrapper directory. This package is then available when you follow the procedures for adding prerequisites for either [!INCLUDE[ndptecclick](~/includes/ndptecclick-md.md)] or Windows Installer deployment.  
  
 By default, bootstrapped components are deployed from the same location as the installation package. Alternatively, you can choose to deploy the components from a URL or file share location from which users can download them as necessary.  
  
> [!NOTE]
>  To install bootstrapped components, the user might need administrative or similar user permissions on the computer. For [!INCLUDE[ndptecclick](~/includes/ndptecclick-md.md)] applications, this means that the user will need administrative permissions to install the application, regardless of the security level specified by the application. After the application is installed, the user can run the application without administrative permissions.  
  
 During installation, users will be prompted to install the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component if it is not present on the destination computer.  
  
 As an alternative to bootstrapping, you can pre-deploy the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component by using an electronic software distribution system like Microsoft Systems Management Server.  
  
## See also  
 [How to: Install Prerequisites with a ClickOnce Application](/visualstudio/deployment/how-to-install-prerequisites-with-a-clickonce-application)  
 [PrintForm Component](../../../visual-basic/developing-apps/printing/printform-component.md)
