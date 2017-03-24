---
title: "Deploying Applications That Reference Power Packs Controls (Visual Studio) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Power Packs, deploying"
ms.assetid: f2230f53-a745-4731-89e6-033943faa209
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Deploying Applications That Reference Power Packs Controls (Visual Studio)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

If you want to deploy an application that references the Power Packs controls (<xref:Microsoft.VisualBasic.PowerPacks.LineShape>, <xref:Microsoft.VisualBasic.PowerPacks.OvalShape>, <xref:Microsoft.VisualBasic.PowerPacks.RectangleShape>, or <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>), the controls must be installed on the destination computer.  
  
## Installing the Power Packs Controls as a Prerequisite  
 To successfully deploy an application, you must also deploy all components that are referenced by the application. The process of installing prerequisite components is known as *bootstrapping*.  
  
 When [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] is installed on your development computer, a Power Packs bootstrapper package is added to the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] bootstrapper directory. This package is then available when you follow the procedures for adding prerequisites for either [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] or Windows Installer deployment.  
  
 By default, bootstrapped components are deployed from the same location as the installation package. Alternatively, you can choose to deploy the components from a URL or file share location from which users can download them as necessary.  
  
> [!NOTE]
>  To install bootstrapped components, the user might need administrative or similar user permissions on the computer. For [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] applications, this means that the user will need administrative permissions to install the application, regardless of the security level specified by the application. After the application is installed, the user can run the application without administrative permissions.  
  
 During installation, users will be prompted to install the Power Packs controls if they are not present on the destination computer.  
  
 As an alternative to bootstrapping, you can pre-deploy the Power Packs controls by using an electronic software distribution system such as Microsoft Systems Management Server.  
  
## See Also  
 [How to: Install Prerequisites in Windows Installer Deployment](http://msdn.microsoft.com/en-us/653fc868-2486-429c-b75e-2f9d0c7f6619)   
 [How to: Install Prerequisites with a ClickOnce Application](../Topic/How%20to:%20Install%20Prerequisites%20with%20a%20ClickOnce%20Application.md)   
 [Not in Build: Choosing a Deployment Strategy](http://msdn.microsoft.com/en-us/ecd632d8-063c-4028-b785-81bba045107b)   
 [Visual Basic Power Packs Controls](../../../visual-basic/developing-apps/windows-forms/power-packs-controls.md)