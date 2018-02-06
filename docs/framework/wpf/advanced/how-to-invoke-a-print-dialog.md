---
title: "How to: Invoke a Print Dialog"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "invoking print dialogs [WPF]"
  - "print dialogs [WPF], invoking"
ms.assetid: e3a2c84c-74fe-45a4-8501-5813f9dbfed2
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Invoke a Print Dialog
To provide the ability to print from you application, you can simply create and open a <xref:System.Windows.Controls.PrintDialog> object.  
  
## Example  
 The <xref:System.Windows.Controls.PrintDialog> control provides a single entry point for [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)], configuration, and [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] job submission. The control is easy to use and can be instantiated by using [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] markup or code. The following example demonstrates how to instantiate and open the control in code and how to print from it. It also shows how to ensure that the dialog will give the user the option of setting a specific range of pages. The example code assumes that there is a file FixedDocumentSequence.xps in the root of the C: drive.  
  
 [!code-csharp[printdialog#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PrintDialog/CSharp/Window1.xaml.cs#1)]
 [!code-vb[printdialog#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PrintDialog/visualbasic/window1.xaml.vb#1)]  
  
 Once the dialog is open, users will be able to select from the printers installed on their computer. They will also have the option of selecting the [Microsoft XPS Document Writer](http://go.microsoft.com/fwlink/?LinkId=147319) to create an [!INCLUDE[TLA#tla_xps](../../../../includes/tlasharptla-xps-md.md)] file instead of printing.  
  
> [!NOTE]
>  The <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType> control of [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)], which is discussed in this topic, should not be confused with the <xref:System.Windows.Forms.PrintDialog?displayProperty=nameWithType> component of [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)].  
  
 Strictly speaking, you can use the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A> method without ever opening the dialog. In that sense, the control can be used as an unseen printing component. But for performance reasons, it would be better to use either the <xref:System.Printing.PrintQueue.AddJob%2A> method or one of the many <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter>. For more about this, see [Programmatically Print XPS Files](../../../../docs/framework/wpf/advanced/how-to-programmatically-print-xps-files.md) and .  
  
## See Also  
 <xref:System.Windows.Controls.PrintDialog>  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)  
 [Microsoft XPS Document Writer](http://go.microsoft.com/fwlink/?LinkId=147319)
