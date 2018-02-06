---
title: "How to: Print a Windows Form"
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
  - "Windows Forms, printing"
  - "printing [Windows Forms]"
  - "printing a form"
  - "printing [Windows Forms], printing a form"
ms.assetid: c8dff5f8-f56a-4c07-ae31-64643b31f8fc
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Print a Windows Form
As part of the development process, you typically will want to print a copy of your Windows Form. The following code example shows how to print a copy of the current form by using the <xref:System.Drawing.Graphics.CopyFromScreen%2A> method.  
  
## Example  
 [!code-csharp[System.Drawing.Graphics.CopyFromScreen#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.Graphics.CopyFromScreen/CS/Form1.cs#1)]
 [!code-vb[System.Drawing.Graphics.CopyFromScreen#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.Graphics.CopyFromScreen/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This is a complete code example that contains a `Main` method.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   You do not have permission to access the printer.  
  
-   There is no printer installed.  
  
## .NET Framework Security  
 In order to run this code example, you must have permission to access the printer you use with your computer.  
  
## See Also  
 <xref:System.Drawing.Printing.PrintDocument>  
 [How to: Render Images with GDI+](../../../../docs/framework/winforms/advanced/how-to-render-images-with-gdi.md)  
 [How to: Print Graphics in Windows Forms](../../../../docs/framework/winforms/advanced/how-to-print-graphics-in-windows-forms.md)
