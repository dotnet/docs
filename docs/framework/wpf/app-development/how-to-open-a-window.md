---
title: "How to: Open a Window"
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
  - "windows [WPF], opening"
  - "opening windows [WPF]"
ms.assetid: 6b91b2bb-fda7-491d-a72e-139dd630a5b0
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Open a Window
This example shows how to open a window.  
  
## Example  
 A window is opened by instantiating <xref:System.Windows.Window> and calling the <xref:System.Windows.Window.Show%2A> method. <xref:System.Windows.Window.Show%2A> opens a window and returns immediately without waiting for the new window to close. This type of window is also known as a *modeless* window, and doesn't restrict user input.  
  
 [!code-csharp[HOWTOWindowManagementSnippets#OpenNewWindowCODE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HOWTOWindowManagementSnippets/CSharp/MainWindow.xaml.cs#opennewwindowcode)]
 [!code-vb[HOWTOWindowManagementSnippets#OpenNewWindowCODE](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOWindowManagementSnippets/visualbasic/mainwindow.xaml.vb#opennewwindowcode)]  
  
## .NET Framework Security  
 Instantiating <xref:System.Windows.Window> requires permission to call unsafe native methods (see <xref:System.Windows.Window.%23ctor%2A>).
