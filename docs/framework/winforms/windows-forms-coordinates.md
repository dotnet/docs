---
title: "Windows Forms Coordinates"
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
  - "Windows Forms coordinates"
  - "screen coordinates"
  - "client coordinates"
  - "coordinates [Windows Forms], Windows Forms"
ms.assetid: cc06e61f-43b6-4408-a676-2542dcfcd96e
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms Coordinates
The coordinate system for a Windows Form is based on device coordinates, and the basic unit of measure when drawing in Windows Forms is the device unit (typically, the pixel). Points on the screen are described by x- and y-coordinate pairs, with the x-coordinates increasing to the right and the y-coordinates increasing from top to bottom. The location of the origin, relative to the screen, will vary depending on whether you are specifying screen or client coordinates.  
  
## Screen Coordinates  
 A Windows Forms application specifies the position of a window on the screen in screen coordinates. For screen coordinates, the origin is the upper-left corner of the screen. The full position of a window is often described by a <xref:System.Drawing.Rectangle> structure containing the screen coordinates of two points that define the upper-left and lower-right corners of the window.  
  
## Client Coordinates  
 A Windows Forms application specifies the position of points in a form or control using client coordinates. The origin for client coordinates is the upper-left corner of the client area of the control or form. Client coordinates ensure that an application can use consistent coordinate values while drawing in a form or control, regardless of the position of the form or control on the screen.  
  
 The dimensions of the client area are also described by a <xref:System.Drawing.Rectangle> structure that contains client coordinates for the area. In all cases, the upper-left coordinate of the rectangle is included in the client area, while the lower-right coordinate is excluded. Graphics operations do not include the right and lower edges of a client area. For example the <xref:System.Drawing.Graphics.FillRectangle%2A> method will fill up to the right and lower edge of the specified rectangle, but will not include these edges.  
  
## Mapping From One Type of Coordinate to Another  
 Occasionally, you may need to map from screen coordinates to client coordinates. You can easily accomplish this by using the <xref:System.Windows.Forms.Control.PointToClient%2A> and <xref:System.Windows.Forms.Control.PointToScreen%2A> methods available in the <xref:System.Windows.Forms.Control> class. For example, the <xref:System.Windows.Forms.Control.MousePosition%2A> property of <xref:System.Windows.Forms.Control> is reported in screen coordinates, but you may want to convert these to client coordinates.  
  
## See Also  
 <xref:System.Windows.Forms.Control.PointToClient%2A>  
 <xref:System.Windows.Forms.Control.PointToScreen%2A>
