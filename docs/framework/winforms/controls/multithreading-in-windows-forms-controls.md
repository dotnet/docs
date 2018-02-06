---
title: "Multithreading in Windows Forms Controls"
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
  - "BackgroundWorker component"
  - "threading [Windows Forms], controls"
ms.assetid: c311d652-0f26-45fa-bdcc-b1615d73ce4e
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Multithreading in Windows Forms Controls
In many applications, you can make your user interface (UI) more responsive by performing time-consuming operations on another thread. A number of tools are available for multithreading your Windows Forms controls, including the <xref:System.Threading> namespace, the <xref:System.Windows.Forms.Control.BeginInvoke%2A?displayProperty=nameWithType> method, and the `BackgroundWorker` component.  
  
> [!NOTE]
>  The `BackgroundWorker` component replaces and adds functionality to the <xref:System.Threading> namespace and the <xref:System.Windows.Forms.Control.BeginInvoke%2A?displayProperty=nameWithType> method; however, these are retained for both backward compatibility and future use, if you choose. For more information, see [BackgroundWorker Component Overview](../../../../docs/framework/winforms/controls/backgroundworker-component-overview.md).  
  
## In This Section  
 [How to: Make Thread-Safe Calls to Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls.md)  
 Shows how to make thread-safe calls to Windows Forms controls.  
  
 [How to: Use a Background Thread to Search for Files](../../../../docs/framework/winforms/controls/how-to-use-a-background-thread-to-search-for-files.md)  
 Shows how to use the <xref:System.Threading> namespace and the <xref:System.Windows.Forms.Control.BeginInvoke%2A> method to search for files asynchronously.  
  
## Reference  
 <xref:System.ComponentModel.BackgroundWorker>  
 Documents a component that encapsulates a worker thread for asynchronous operations.  
  
 <xref:System.Media.SoundPlayer.LoadAsync%2A>  
 Documents how to load a sound asynchronously.  
  
 <xref:System.Windows.Forms.PictureBox.LoadAsync%2A>  
 Documents how to load an image asynchronously.  
  
## Related Sections  
 [How to: Run an Operation in the Background](../../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)  
 Shows how to perform a time-consuming operation with the <xref:System.ComponentModel.BackgroundWorker> component.  
  
 [BackgroundWorker Component Overview](../../../../docs/framework/winforms/controls/backgroundworker-component-overview.md)  
 Provides topics that describe how to use the <xref:System.ComponentModel.BackgroundWorker> component for asynchronous operations.
