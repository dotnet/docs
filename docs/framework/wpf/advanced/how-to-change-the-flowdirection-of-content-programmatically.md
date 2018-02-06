---
title: "How to: Change the FlowDirection of Content Programmatically"
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
  - "FlowDirection property [WPF], changing programmatically"
  - "documents [WPF], changing FlowDirection property programmatically"
ms.assetid: 02f5a8ba-f8c0-4e5a-84b9-4c5bf12922a2
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the FlowDirection of Content Programmatically
This example shows how to programmatically change the <xref:System.Windows.FrameworkElement.FlowDirection%2A> property of a <xref:System.Windows.Controls.FlowDocumentReader>.  
  
## Example  
 Two <xref:System.Windows.Controls.Button> elements are created, each representing one of the possible values of <xref:System.Windows.FlowDirection>. When a button is clicked, the associated property value is applied to the contents of a <xref:System.Windows.Controls.FlowDocumentReader> named `tf1`.  The property value is also written to a <xref:System.Windows.Controls.TextBlock> named `txt1`.  
  
 [!code-xaml[FlowDirectionSnippets#_FlowDirectionXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDirectionSnippets/CSharp/Window1.xaml#_flowdirectionxaml)]  
  
## Example  
 The events associated with the button clicks defined above are handled in a [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)] code-behind file.  
  
 [!code-csharp[FlowDirectionSnippets#_FlowDirection](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDirectionSnippets/CSharp/Window1.xaml.cs#_flowdirection)]
 [!code-vb[FlowDirectionSnippets#_FlowDirection](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FlowDirectionSnippets/VisualBasic/Window1.xaml.vb#_flowdirection)]
