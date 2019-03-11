---
title: "Using Double Buffering"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "graphics [Windows Forms], double buffering"
  - "double buffering"
  - "flicker [Windows Forms], reducing in Windows Forms"
  - "buffering [Windows Forms], double buffering"
ms.assetid: dc484e33-7101-4e4b-ada5-d3c96155fbcd
---
# Using Double Buffering
You can use double-buffered graphics to reduce flicker in your applications that contain complex painting operations. The .NET Framework contains built-in support for double-buffering or you can manage and render graphics manually.  
  
## In This Section  
 [Double Buffered Graphics](double-buffered-graphics.md)  
 Introduces double buffering concept and outlines .NET Framework support.  
  
 [How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls](how-to-reduce-graphics-flicker-with-double-buffering-for-forms-and-controls.md)  
 Demonstrates how to use the default double buffering support in the .NET Framework.  
  
 [How to: Manually Manage Buffered Graphics](how-to-manually-manage-buffered-graphics.md)  
 Shows how to manage double buffering in applications.  
  
 [How to: Manually Render Buffered Graphics](how-to-manually-render-buffered-graphics.md)  
 Demonstrates how to render double-buffered graphics.  
  
## Reference  
 <xref:System.Windows.Forms.Control.SetStyle%2A> ,  
 Control method that enables double buffering.  
  
 <xref:System.Drawing.BufferedGraphicsContext> ,  
 Provides methods for creating graphics buffers.  
  
 <xref:System.Drawing.BufferedGraphicsManager>  
 Provides access to the buffered graphics context for a application domain.
