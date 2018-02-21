---
title: "How to: Set the Title of a Window from a Page"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "windows [WPF], setting title from a page"
  - "title of window [WPF], setting from a page"
  - "pages [WPF], setting window title from"
ms.assetid: fecf0d19-3eb6-4f8c-a44f-ff1b6f2b34b3
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Title of a Window from a Page
This example shows how to set the title of the window in which a <xref:System.Windows.Controls.Page> is hosted.  
  
## Example  
 A page can change the title of the window that is hosting it by setting the <xref:System.Windows.Controls.Page.WindowTitle%2A> property, like so:  
  
 [!code-xaml[HOWTONavigationSnippets#SetPageWindowTitleXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/SetWindowTitlePage.xaml#setpagewindowtitlexaml)]  
  
> [!NOTE]
>  Setting the <xref:System.Windows.Controls.Page.Title%2A> property of a page does not change the value of the window title. Instead, <xref:System.Windows.Controls.Page.Title%2A> specifies the name of a page entry in navigation history.
