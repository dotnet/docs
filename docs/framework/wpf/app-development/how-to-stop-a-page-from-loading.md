---
title: "How to: Stop a Page from Loading"
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
  - "pages [WPF], stopping from loading"
  - "methods [WPF], Stoploading"
  - "events [WPF], NavigationStopped"
  - "NavigationStopped properties [WPF]"
  - "stopping pages from loading [WPF]"
  - "loading [WPF], stopping"
ms.assetid: e2b695b0-517e-462c-8ccf-90cc8d6ba864
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Stop a Page from Loading
This example shows how to call the <xref:System.Windows.Navigation.NavigationWindow.StopLoading%2A> method to stop navigation to content before it has finished being downloaded.  
  
## Example  
 <xref:System.Windows.Navigation.NavigationWindow.StopLoading%2A> stops the download of the requested content, and causes the <xref:System.Windows.Navigation.NavigationWindow.NavigationStopped> event to be raised.  
  
 [!code-csharp[HOWTONavigationSnippets#NavigateStopLoadingCODE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/MainWindow.xaml.cs#navigatestoploadingcode)]
 [!code-vb[HOWTONavigationSnippets#NavigateStopLoadingCODE](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTONavigationSnippets/visualbasic/mainwindow.xaml.vb#navigatestoploadingcode)]
