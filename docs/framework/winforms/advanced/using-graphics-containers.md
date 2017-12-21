---
title: "Using Graphics Containers"
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
  - "graphics [Windows Forms], using containers"
  - "graphics containers"
  - "examples [Windows Forms], graphics containers"
ms.assetid: 74632f91-cefa-4f51-ab7c-f9ac91942caf
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using Graphics Containers
A <xref:System.Drawing.Graphics> object provides methods such as <xref:System.Drawing.Graphics.DrawLine%2A>, <xref:System.Drawing.Graphics.DrawImage%2A>, and <xref:System.Drawing.Graphics.DrawString%2A> for displaying vector images, raster images, and text. A <xref:System.Drawing.Graphics> object also has several properties that influence the quality and orientation of the items that are drawn. For example, the smoothing mode property determines whether antialiasing is applied to lines and curves, and the world transformation property influences the position and rotation of the items that are drawn.  
  
 A <xref:System.Drawing.Graphics> object is associated with a particular display device. When you use a <xref:System.Drawing.Graphics> object to draw in a window, the <xref:System.Drawing.Graphics> object is also associated with that particular window.  
  
 A <xref:System.Drawing.Graphics> object can be thought of as a container because it holds a set of properties that influence drawing and it is linked to device-specific information. You can create a secondary container within an existing <xref:System.Drawing.Graphics> object by calling the <xref:System.Drawing.Graphics.BeginContainer%2A> method of that <xref:System.Drawing.Graphics> object.  
  
## In This Section  
 [Managing the State of a Graphics Object](../../../../docs/framework/winforms/advanced/managing-the-state-of-a-graphics-object.md)  
 Describes how manage the quality settings, clipping area and transformations of a <xref:System.Drawing.Graphics> object.  
  
 [Using Nested Graphics Containers](../../../../docs/framework/winforms/advanced/using-nested-graphics-containers.md)  
 Shows how to use containers to control the state of the <xref:System.Drawing.Graphics> object.
