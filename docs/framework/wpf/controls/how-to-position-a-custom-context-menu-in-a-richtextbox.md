---
title: "How to: Position a Custom Context Menu in a RichTextBox"
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
  - "custom context menus [WPF], positioning"
  - "positioning custom context menus [WPF]"
  - "RichTextBox control [WPF], positioning custom context menus"
  - "context menus [WPF], positioning"
ms.assetid: bf77c930-a546-4573-9a56-9af345ba189a
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Position a Custom Context Menu in a RichTextBox
This example shows how to position a custom context menu for a <xref:System.Windows.Controls.RichTextBox>.  
  
 When you implement a custom context menu for a **RichTextBox**, you are responsible for handling the placement of the context menu.  By default, a custom context menu is opened at the center of the **RichTextBox**.  
  
## Example  
 To override the default placement behavior, add a listener for the <xref:System.Windows.FrameworkContentElement.ContextMenuOpening> event.  The following example shows how to do this programmatically.  
  
 [!code-csharp[RichTextBox_ContextMenu#_AddListener](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RichTextBox_ContextMenu/CSharp/app.xaml.cs#_addlistener)]
 [!code-vb[RichTextBox_ContextMenu#_AddListener](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/RichTextBox_ContextMenu/VisualBasic/app.xaml.vb#_addlistener)]  
  
## Example  
 The following example shows an implementation the corresponding <xref:System.Windows.FrameworkContentElement.ContextMenuOpening> event listener.  
  
 [!code-csharp[RichTextBox_ContextMenu#_ListenerBody](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RichTextBox_ContextMenu/CSharp/app.xaml.cs#_listenerbody)]
 [!code-vb[RichTextBox_ContextMenu#_ListenerBody](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/RichTextBox_ContextMenu/VisualBasic/app.xaml.vb#_listenerbody)]  
  
## See Also  
 [RichTextBox Overview](../../../../docs/framework/wpf/controls/richtextbox-overview.md)  
 [TextBox Overview](../../../../docs/framework/wpf/controls/textbox-overview.md)
