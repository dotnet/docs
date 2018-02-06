---
title: "Overview of Graphics"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "graphics [Windows Forms], using managed interface"
  - "graphics [Windows Forms], about graphics"
ms.assetid: a602aef8-a8c8-4c36-9816-74e7bad96a68
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Overview of Graphics
[!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] is an application programming interface (API) that forms the subsystem of the Microsoft Windows operating system. [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] is responsible for displaying information on screens and printers. As its name suggests, [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] is the successor to [!INCLUDE[ndptecgdi](../../../../includes/ndptecgdi-md.md)], the Graphics Device Interface included with earlier versions of Windows.  
  
## Managed Class Interface  
 The [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] API is exposed through a set of classes deployed as managed code. This set of classes is called the *managed class interface* to [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)]. The following namespaces make up the managed class interface:  
  
-   <xref:System.Drawing>  
  
-   <xref:System.Drawing.Drawing2D>  
  
-   <xref:System.Drawing.Imaging>  
  
-   <xref:System.Drawing.Text>  
  
-   <xref:System.Drawing.Printing>  
  
 With a Graphics Device Interface, such as [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)], you can display information on a screen or printer without having to be concerned about the details of a particular display device. The programmer makes calls to methods provided by [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] classes. Those methods, in turn, make the appropriate calls to specific device drivers. [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] insulates the application from the graphics hardware. It is this insulation that enables a programmer to create device-independent applications.  
  
## See Also  
 [Graphics Overview](../../../../docs/framework/winforms/advanced/graphics-overview-windows-forms.md)
