---
title: "How to: Create a Resizable Windows Form for Data Entry"
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
  - "cpp"
helpviewer_keywords: 
  - "TableLayoutPanel control [Windows Forms]"
  - "layout [Windows Forms], resizing"
  - "forms [Windows Forms], creating resizable"
  - "Windows Forms, resizable"
ms.assetid: babdf198-404c-485d-a914-ed370c6ecd99
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Resizable Windows Form for Data Entry
A good layout responds well to changes in the dimensions of its parent form. You can use the <xref:System.Windows.Forms.TableLayoutPanel> control to arrange the layout of your form to resize and position your controls in a consistent way as the form's dimensions change. The <xref:System.Windows.Forms.TableLayoutPanel> control is also useful when changes in the contents of your controls cause changes in the layout. The process covered in this procedure can be done within the Visual Studio environment.  Also see [Walkthrough: Creating a Resizable Windows Form for Data Entry](http://msdn.microsoft.com/library/991eahec\(v=vs.110\)).  
  
## Example  
 The following example demonstrates how to use a <xref:System.Windows.Forms.TableLayoutPanel> control to build a layout that responds well when the user resizes the form. It also demonstrates a layout that responds well to localization.  
  
 [!code-cpp[System.Windows.Forms.TableLayoutPanel.DataEntryForm#1](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.TableLayoutPanel.DataEntryForm/cpp/basicdataentryform.cpp#1)]
 [!code-csharp[System.Windows.Forms.TableLayoutPanel.DataEntryForm#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.TableLayoutPanel.DataEntryForm/CS/basicdataentryform.cs#1)]
 [!code-vb[System.Windows.Forms.TableLayoutPanel.DataEntryForm#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.TableLayoutPanel.DataEntryForm/VB/basicdataentryform.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 <xref:System.Windows.Forms.FlowLayoutPanel>  
 <xref:System.Windows.Forms.TableLayoutPanel>  
 [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)  
 [How to: Design a Windows Forms Layout that Responds Well to Localization](../../../../docs/framework/winforms/controls/how-to-design-a-windows-forms-layout-that-responds-well-to-localization.md)  
 [Microsoft Windows User Experience, Official Guidelines for User Interface Developers and Designers. Redmond, WA: Microsoft Press, 1999. (USBN: 0-7356-0566-1)](http://www.microsoft.com/mspress/southpacific/books/book11588.htm)
