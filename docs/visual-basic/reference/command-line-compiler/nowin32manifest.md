---
description: "Learn more about: -nowin32manifest (Visual Basic)"
title: "-nowin32manifest"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "/nowin32manifest compiler option [Visual Basic]"
  - "nowin32manifest compiler option [Visual Basic]"
  - "-nowin32manifest compiler option [Visual Basic]"
ms.assetid: c0528aae-83b3-4425-99f0-19448e9843e3
---
# -nowin32manifest (Visual Basic)

Instructs the compiler not to embed any application manifest into the executable file.  
  
## Syntax  
  
```console  
-nowin32manifest  
```  
  
## Remarks  

 When this option is used, the application will be subject to virtualization on Windows Vista unless you provide an application manifest in a Win32 Resource file or during a later build step. For more information about virtualization, see [ClickOnce Deployment on Windows Vista](/visualstudio/deployment/clickonce-deployment-on-windows-vista).  
  
 For more information about manifest creation, see [-win32manifest (Visual Basic)](win32manifest.md).  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic)
