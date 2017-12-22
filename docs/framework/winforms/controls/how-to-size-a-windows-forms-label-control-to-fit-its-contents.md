---
title: "How to: Size a Windows Forms Label Control to Fit Its Contents"
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
  - "captions [Windows Forms], sizing"
  - "sizing controls"
  - "size [Windows Forms], controls"
  - "labels [Windows Forms], sizing to fit contents"
  - "Label control [Windows Forms], sizing to fit contents"
ms.assetid: 99648964-63b2-438c-980e-d24103ad602b
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Size a Windows Forms Label Control to Fit Its Contents
The Windows Forms <xref:System.Windows.Forms.Label> control can be single-line or multi-line, and it can be either fixed in size or can automatically resize itself to accommodate its caption. The <xref:System.Windows.Forms.Label.AutoSize%2A> property helps you size the controls to fit larger or smaller captions, which is particularly useful if the caption will change at run time.  
  
### To make a label control resize dynamically to fit its contents  
  
1.  Set its <xref:System.Windows.Forms.Label.AutoSize%2A> property to `true`.  
  
 If <xref:System.Windows.Forms.Label.AutoSize%2A> is set to `false`, the words specified in the <xref:System.Windows.Forms.Label.Text%2A> property will wrap to the next line if possible, but the control will not grow.  
  
## See Also  
 [How to: Create Access Keys with Windows Forms Label Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-with-windows-forms-label-controls.md)  
 [Label Control Overview](../../../../docs/framework/winforms/controls/label-control-overview-windows-forms.md)  
 [Label Control](../../../../docs/framework/winforms/controls/label-control-windows-forms.md)
