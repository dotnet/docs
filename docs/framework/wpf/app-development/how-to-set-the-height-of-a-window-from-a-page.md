---
title: "How to: Set the Height of a Window from a Page"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "windows [WPF], setting height from a page"
  - "pages [WPF], setting window height from"
  - "height of window [WPF], setting from a page"
ms.assetid: 4e4488ff-ab5c-4ee9-81a4-e1addb55c5cc
---
# How to: Set the Height of a Window from a Page
This example illustrates how to set the height of the window from a <xref:System.Windows.Controls.Page>.  
  
## Example  
 A <xref:System.Windows.Controls.Page> can set the height of its host window by setting <xref:System.Windows.Controls.Page.WindowHeight%2A>. This property allows the <xref:System.Windows.Controls.Page> to not have explicit knowledge of the type of window that hosts it.  
  
> [!NOTE]
>  To set the height of a window using <xref:System.Windows.Controls.Page.WindowHeight%2A>, a <xref:System.Windows.Controls.Page> must be the child of a window.  
  
 [!code-xaml[HOWTONavigationSnippets#SetPageWindowHeightXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/SetWindowHeightPage.xaml#setpagewindowheightxaml)]
