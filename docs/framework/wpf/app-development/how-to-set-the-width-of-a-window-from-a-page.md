---
title: "How to: Set the Width of a Window from a Page"
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
  - "width of windows [WPF], setting from a page"
  - "windows [WPF], setting width from a page"
  - "pages [WPF], setting window width from"
ms.assetid: 31601c92-7889-472a-b07e-bf675ad21c92
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Width of a Window from a Page
This example illustrates how to set the width of the window from a <xref:System.Windows.Controls.Page>.  
  
## Example  
 A <xref:System.Windows.Controls.Page> can set the width of its host window by setting <xref:System.Windows.Controls.Page.WindowWidth%2A>. This property allows the <xref:System.Windows.Controls.Page> to not have explicit knowledge of the type of window that hosts it.  
  
> [!NOTE]
>  To set the width of a window using <xref:System.Windows.Controls.Page.WindowWidth%2A>, a <xref:System.Windows.Controls.Page> must be the child of a window.  
  
 [!code-xaml[HOWTONavigationSnippets#SetPageWindowWidthXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/SetWindowWidthPage.xaml#setpagewindowwidthxaml)]
