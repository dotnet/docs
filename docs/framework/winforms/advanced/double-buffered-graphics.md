---
title: "Double Buffered Graphics"
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
  - "double buffering"
  - "graphics [Windows Forms], double-buffered"
  - "flicker [Windows Forms], reducing with double buffering"
  - "examples [Windows Forms], double-buffered graphics"
ms.assetid: 4f6fef99-0972-436e-9d73-0167e4033f71
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Double Buffered Graphics
Flicker is a common problem when programming graphics. Graphics operations that require multiple complex painting operations can cause the rendered images to appear to flicker or have an otherwise unacceptable appearance. To address these problems, the .NET Framework provides access to double buffering.  
  
 Double buffering uses a memory buffer to address the flicker problems associated with multiple paint operations. When double buffering is enabled, all paint operations are first rendered to a memory buffer instead of the drawing surface on the screen. After all paint operations are completed, the memory buffer is copied directly to the drawing surface associated with it. Because only one graphics operation is performed on the screen, the image flickering associated with complex painting operations is eliminated.  
  
## Default Double Buffering  
 The easiest way to use double buffering in your applications is to use the default double buffering for forms and controls that is provided by the .NET Framework. You can enable default double buffering for your Windows Forms and authored Windows controls by setting the <xref:System.Windows.Forms.Control.DoubleBuffered%2A> property to `true` or by using the <xref:System.Windows.Forms.Control.SetStyle%2A> method. For more information, see [How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls](../../../../docs/framework/winforms/advanced/how-to-reduce-graphics-flicker-with-double-buffering-for-forms-and-controls.md).  
  
## Manually Managing Buffered Graphics  
 For more advanced double buffering scenarios, such as animation or advanced memory management, you can use the .NET Framework classes to implement your own double-buffering logic. The class responsible for allocating and managing individual graphics buffers is the <xref:System.Drawing.BufferedGraphicsContext> class. Every application domain has its own default <xref:System.Drawing.BufferedGraphicsContext> instance that manages all of the default double buffering for that application. In most cases there will be only one application domain per application, so there is generally one default <xref:System.Drawing.BufferedGraphicsContext> per application. Default <xref:System.Drawing.BufferedGraphicsContext> instances are managed by the <xref:System.Drawing.BufferedGraphicsManager> class. You can retrieve a reference to the default <xref:System.Drawing.BufferedGraphicsContext> instance by calling the <xref:System.Drawing.BufferedGraphicsManager.Current%2A>. You can also create a dedicated <xref:System.Drawing.BufferedGraphicsContext> instance, which can improve performance for graphically intensive applications. For information on how to create a <xref:System.Drawing.BufferedGraphicsContext> instance, see [How to: Manually Manage Buffered Graphics](../../../../docs/framework/winforms/advanced/how-to-manually-manage-buffered-graphics.md).  
  
## Manually Displaying Buffered Graphics  
 You can use an instance of the <xref:System.Drawing.BufferedGraphicsContext> class to create graphics buffers by calling the <xref:System.Drawing.BufferedGraphicsContext.Allocate%2A?displayProperty=nameWithType>, which returns an instance of the <xref:System.Drawing.BufferedGraphics> class. A <xref:System.Drawing.BufferedGraphics> object manages a memory buffer that is associated with a rendering surface, such as a form or control.  
  
 After it is instantiated, the <xref:System.Drawing.BufferedGraphics> class manages rendering to an in-memory graphics buffer. You can render graphics to the memory buffer through the <xref:System.Drawing.BufferedGraphics.Graphics%2A>, which exposes a <xref:System.Drawing.Graphics> object that directly represents the memory buffer. You can paint to this <xref:System.Drawing.Graphics> object just as you would to a <xref:System.Drawing.Graphics> object that represents a drawing surface. After all the graphics have been drawn to the buffer, you can use the <xref:System.Drawing.BufferedGraphics.Render%2A?displayProperty=nameWithType> to copy the contents of the buffer to the drawing surface on the screen.  
  
 For more information on using the <xref:System.Drawing.BufferedGraphics> class, see [Manually Rendering Buffered Graphics](../../../../docs/framework/winforms/advanced/how-to-manually-render-buffered-graphics.md). For more information on rendering graphics, see [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)  
  
## See Also  
 <xref:System.Drawing.BufferedGraphics>  
 <xref:System.Drawing.BufferedGraphicsContext>  
 <xref:System.Drawing.BufferedGraphicsManager>  
 [How to: Manually Render Buffered Graphics](../../../../docs/framework/winforms/advanced/how-to-manually-render-buffered-graphics.md)  
 [How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls](../../../../docs/framework/winforms/advanced/how-to-reduce-graphics-flicker-with-double-buffering-for-forms-and-controls.md)  
 [How to: Manually Manage Buffered Graphics](../../../../docs/framework/winforms/advanced/how-to-manually-manage-buffered-graphics.md)  
 [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)
