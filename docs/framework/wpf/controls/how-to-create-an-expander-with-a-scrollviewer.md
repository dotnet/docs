---
title: "How to: Create an Expander with a ScrollViewer"
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
  - "controls [WPF], Expander"
  - "ScrollViewer control [WPF], with Expander control"
  - "Expander control [WPF], creating"
  - "controls [WPF], ScrollViewer"
ms.assetid: 2ad124d2-2406-4157-aaf2-64e067298f01
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create an Expander with a ScrollViewer
This example shows how to create an <xref:System.Windows.Controls.Expander> control that contains complex content, such as an image and text. The example also encloses the content of the <xref:System.Windows.Controls.Expander> in a <xref:System.Windows.Controls.ScrollViewer> control.  
  
## Example  
 The following example shows how to create an <xref:System.Windows.Controls.Expander>. The example uses a <xref:System.Windows.Controls.Primitives.BulletDecorator> control, which contains an image and text, in order to define the <xref:System.Windows.Controls.HeaderedContentControl.Header%2A>. A <xref:System.Windows.Controls.ScrollViewer> control provides a method for scrolling the expanded content.  
  
 Note that the example sets the <xref:System.Windows.FrameworkElement.Height%2A> property on the <xref:System.Windows.Controls.ScrollViewer> instead of on the content. If the <xref:System.Windows.FrameworkElement.Height%2A> is set on the content, the <xref:System.Windows.Controls.ScrollViewer> does not allow the user to scroll the content. The <xref:System.Windows.FrameworkElement.Width%2A> property is set on the <xref:System.Windows.Controls.Expander> control and this setting applies to the <xref:System.Windows.Controls.HeaderedContentControl.Header%2A> and the expanded content.  
  
 [!code-xaml[ExpanderRichContent#CreateExpander](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpanderRichContent/CSharp/Window1.xaml#createexpander)]  
  
 [!code-csharp[ExpanderRichContent#CreateExpanderCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpanderRichContent/CSharp/Window1.xaml.cs#createexpandercode)]  
  
## See Also  
 <xref:System.Windows.Controls.Expander>  
 [Expander Overview](../../../../docs/framework/wpf/controls/expander-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/expander-how-to-topics.md)
