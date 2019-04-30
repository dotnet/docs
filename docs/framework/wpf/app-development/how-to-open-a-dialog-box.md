---
title: "How to: Open a Dialog Box"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "opening dialog boxes [WPF]"
  - "dialog boxes [WPF], opening"
ms.assetid: 6b1557d2-da98-4ef4-9f68-4089f04ab9ea
---
# How to: Open a Dialog Box
This example shows how to open a dialog box.  
  
## Example  
 A dialog box is a window that is opened by instantiating <xref:System.Windows.Window> and calling the <xref:System.Windows.Window.ShowDialog%2A> method. <xref:System.Windows.Window.ShowDialog%2A> opens a window and doesn't return until the new dialog box has been closed. This type of window is also known as a *modal* window, and restricts user input.  
  
 [!code-csharp[HOWTOWindowManagementSnippets#OpenNewDialogBoxCODE](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOWindowManagementSnippets/CSharp/MainWindow.xaml.cs#opennewdialogboxcode)]
 [!code-vb[HOWTOWindowManagementSnippets#OpenNewDialogBoxCODE](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOWindowManagementSnippets/visualbasic/mainwindow.xaml.vb#opennewdialogboxcode)]  
  
## .NET Framework Security  
 Calling <xref:System.Windows.Window.ShowDialog%2A> requires permission to use all windows and user input events without restriction.  
  
## See also

- [Return a Dialog Box Result](how-to-return-a-dialog-box-result.md)
