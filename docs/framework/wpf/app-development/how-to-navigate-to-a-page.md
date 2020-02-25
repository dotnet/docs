---
title: "How to: Navigate to a Page"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "pages [WPF], navigating to"
  - "navigation [WPF], to page"
ms.assetid: 2a556fc0-748b-417f-a58a-0d05a7afb66f
---
# How to: Navigate to a Page
This example illustrates several ways in which a page can be navigated to from a <xref:System.Windows.Navigation.NavigationWindow>.  
  
## Example  
 It is possible for a <xref:System.Windows.Navigation.NavigationWindow> to navigate to a page using one of the following:  
  
- The <xref:System.Windows.Navigation.NavigationWindow.Source%2A> property.  
  
- The <xref:System.Windows.Navigation.NavigationWindow.Navigate%2A> method.  
  
 [!code-csharp[HOWTONavigationSnippets#NavigateToPageCODE](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/MainWindow.xaml.cs#navigatetopagecode)]
 [!code-vb[HOWTONavigationSnippets#NavigateToPageCODE](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTONavigationSnippets/visualbasic/mainwindow.xaml.vb#navigatetopagecode)]  
  
> [!NOTE]
> Uniform resource identifiers (URIs) can be either relative or absolute. For more information, see [Pack URIs in WPF](pack-uris-in-wpf.md).  
  
## See also

- <xref:System.Windows.Controls.Frame>
- <xref:System.Windows.Controls.Page>
- <xref:System.Windows.Navigation.NavigationService>
