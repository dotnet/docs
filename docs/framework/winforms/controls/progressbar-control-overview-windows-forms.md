---
title: "ProgressBar Control Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "ProgressBar"
helpviewer_keywords: 
  - "ProgressBar control [Windows Forms], about ProgressBar control"
  - "progress controls [Windows Forms], about progress controls"
ms.assetid: a05d9cba-3a6a-4f8f-94b8-8ec12799fb80
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ProgressBar Control Overview (Windows Forms)
> [!IMPORTANT]
>  The <xref:System.Windows.Forms.ToolStripProgressBar> control replaces and adds functionality to the <xref:System.Windows.Forms.ProgressBar> control; however, the <xref:System.Windows.Forms.ProgressBar> control is retained for both backward compatibility and future use, if you choose.  
  
 The Windows Forms <xref:System.Windows.Forms.ProgressBar> control indicates the progress of a process by displaying an appropriate number of rectangles arranged in a horizontal bar. When the process is complete, the bar is filled. Progress bars are commonly used to give the user an idea of how long to wait for a process to complete; for instance, when a large file is being loaded.  
  
> [!NOTE]
>  The <xref:System.Windows.Forms.ProgressBar> control can only be oriented horizontally on the form.  
  
## Key Properties and Methods  
 The key properties of the <xref:System.Windows.Forms.ProgressBar> control are <xref:System.Windows.Forms.ProgressBar.Value%2A>, <xref:System.Windows.Forms.ProgressBar.Minimum%2A>, and <xref:System.Windows.Forms.ProgressBar.Maximum%2A>. The <xref:System.Windows.Forms.ProgressBar.Minimum%2A> and <xref:System.Windows.Forms.ProgressBar.Maximum%2A> properties set the maximum and minimum values the progress bar can display. The <xref:System.Windows.Forms.ProgressBar.Value%2A> property represents the progress that has been made toward completing the operation. Because the bar displayed in the control is composed of blocks, the value displayed by the <xref:System.Windows.Forms.ProgressBar> control only approximates the <xref:System.Windows.Forms.ProgressBar.Value%2A> property's current value. Based on the size of the <xref:System.Windows.Forms.ProgressBar> control, the <xref:System.Windows.Forms.ProgressBar.Value%2A> property determines when to display the next block.  
  
 The most common way to update the current progress value is to write code to set the <xref:System.Windows.Forms.ProgressBar.Value%2A> property. In the example of loading a large file, you might set the maximum to the size of the file in kilobytes. For example, if the <xref:System.Windows.Forms.ProgressBar.Maximum%2A> property is set to 100, the <xref:System.Windows.Forms.ProgressBar.Minimum%2A> property is set to 10, and the <xref:System.Windows.Forms.ProgressBar.Value%2A> property is set to 50, 5 rectangles will be displayed. This is half of the number that can be displayed.  
  
 However, there are other ways to modify the value displayed by the <xref:System.Windows.Forms.ProgressBar> control, aside from setting the <xref:System.Windows.Forms.ProgressBar.Value%2A> property directly. The <xref:System.Windows.Forms.ProgressBar.Step%2A> property can be used to specify a value to increment the <xref:System.Windows.Forms.ProgressBar.Value%2A> property by. Then, calling the <xref:System.Windows.Forms.ProgressBar.PerformStep%2A> method will increment the value. To vary the increment value, you can use the <xref:System.Windows.Forms.ProgressBar.Increment%2A> method and specify a value with which to increment the <xref:System.Windows.Forms.ProgressBar.Value%2A> property.  
  
 Another control that graphically informs the user about a current action is the <xref:System.Windows.Forms.StatusBar> control.  
  
> [!IMPORTANT]
>  The <xref:System.Windows.Forms.StatusStrip> and <xref:System.Windows.Forms.ToolStripStatusLabel> controls replace and add functionality to the <xref:System.Windows.Forms.StatusBar> and <xref:System.Windows.Forms.StatusBarPanel> controls; however, the <xref:System.Windows.Forms.StatusBar> and <xref:System.Windows.Forms.StatusBarPanel> controls are retained for both backward compatibility and future use, if you choose.  
  
## See Also  
 <xref:System.Windows.Forms.ProgressBar>  
 [ProgressBar Control](../../../../docs/framework/winforms/controls/progressbar-control-windows-forms.md)
