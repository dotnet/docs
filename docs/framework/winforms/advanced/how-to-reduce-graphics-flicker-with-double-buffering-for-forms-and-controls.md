---
title: "How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "flicker [Windows Forms], reducing in Windows Forms"
  - "graphics [Windows Forms], reducing double-buffered flicker"
ms.assetid: 91083d3a-653f-4f15-a467-0f37b2aa39d6
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls
Double buffering uses a memory buffer to address the flicker problems associated with multiple paint operations. When double buffering is enabled, all paint operations are first rendered to a memory buffer instead of the drawing surface on the screen. After all paint operations are completed, the memory buffer is copied directly to the drawing surface associated with it. Because only one graphics operation is performed on the screen, the image flickering associated with complex painting operations is eliminated.For most applications, the default double buffering provided by the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] will provide the best results. Standard Windows Forms controls are double buffered by default. You can enable default double buffering in your forms and authored controls in two ways. You can either set the <xref:System.Windows.Forms.Control.DoubleBuffered%2A> property to `true`, or you can call the <xref:System.Windows.Forms.Control.SetStyle%2A> method to set the <xref:System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer> flag to `true`. Both methods will enable default double buffering for your form or control and provide flicker-free graphics rendering. Calling the <xref:System.Windows.Forms.Control.SetStyle%2A> method is recommended only for custom controls for which you have written all the rendering code.  
  
 For more advanced double buffering scenarios, such as animation or advanced memory management, you can implement your own double buffering logic. For more information, see [How to: Manually Manage Buffered Graphics](../../../../docs/framework/winforms/advanced/how-to-manually-manage-buffered-graphics.md).  
  
### To reduce flicker  
  
-   Set the <xref:System.Windows.Forms.Control.DoubleBuffered%2A> property to `true`.  
  
     [!code-csharp[System.Windows.Forms.LegacyBufferedGraphics#31](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/CS/Class1.cs#31)]
     [!code-vb[System.Windows.Forms.LegacyBufferedGraphics#31](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/VB/Class1.vb#31)]  
  
 \- or -  
  
-   Call the <xref:System.Windows.Forms.Control.SetStyle%2A> method to set the <xref:System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer> flag to `true`.  
  
     [!code-csharp[System.Windows.Forms.LegacyBufferedGraphics#32](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/CS/Class1.cs#32)]
     [!code-vb[System.Windows.Forms.LegacyBufferedGraphics#32](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/VB/Class1.vb#32)]  
  
## See Also  
 <xref:System.Windows.Forms.Control.DoubleBuffered%2A>  
 <xref:System.Windows.Forms.Control.SetStyle%2A>  
 [Double Buffered Graphics](../../../../docs/framework/winforms/advanced/double-buffered-graphics.md)  
 [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)
