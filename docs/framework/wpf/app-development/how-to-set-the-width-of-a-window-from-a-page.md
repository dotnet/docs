---
title: "How to: Set the Width of a Window from a Page"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "width of windows [WPF], setting from a page"
  - "windows [WPF], setting width from a page"
  - "pages [WPF], setting window width from"
ms.assetid: 31601c92-7889-472a-b07e-bf675ad21c92
---
# How to: Set the Width of a Window from a Page
This example illustrates how to set the width of the window from a <xref:System.Windows.Controls.Page>.  
  
## Example  
 A <xref:System.Windows.Controls.Page> can set the width of its host window by setting <xref:System.Windows.Controls.Page.WindowWidth%2A>. This property allows the <xref:System.Windows.Controls.Page> to not have explicit knowledge of the type of window that hosts it.  
  
> [!NOTE]
> To set the width of a window using <xref:System.Windows.Controls.Page.WindowWidth%2A>, a <xref:System.Windows.Controls.Page> must be the child of a window.  
  
 [!code-xaml[HOWTONavigationSnippets#SetPageWindowWidthXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/SetWindowWidthPage.xaml#setpagewindowwidthxaml)]
