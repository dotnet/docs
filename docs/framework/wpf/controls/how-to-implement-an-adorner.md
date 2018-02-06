---
title: "How to: Implement an Adorner"
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
  - "adorners [WPF], implementing"
ms.assetid: 56ae32b6-0599-455c-b52f-2ff97e6f1ec2
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Implement an Adorner
This example shows a minimal adorner implementation.  
  
## Notes for Implementers  
 It is important to note that adorners do not include any inherent rendering behavior; ensuring that an adorner renders is the responsibility of the adorner implementer.   A common way of implementing rendering behavior is to override the <xref:System.Windows.UIElement.OnRender%2A> method and use one or more <xref:System.Windows.Media.DrawingContext> objects to render the adorner's visuals as needed (as shown in this example).  
  
## Example  
  
### Description  
 A custom adorner is created by implementing a class that inherits from the abstract <xref:System.Windows.Documents.Adorner> class.  The example adorner simply adorns the corners of a <xref:System.Windows.UIElement> with circles by overriding the <xref:System.Windows.UIElement.OnRender%2A> method.  
  
### Code  
 [!code-csharp[Adorners_SimpleCircleAdorner#_SimpleCircleAdornerBody](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/CSharp/Window1.xaml.cs#_simplecircleadornerbody)]
 [!code-vb[Adorners_SimpleCircleAdorner#_SimpleCircleAdornerBody](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/VisualBasic/Window1.xaml.vb#_simplecircleadornerbody)]  
  
## See Also  
 [Adorners Overview](../../../../docs/framework/wpf/controls/adorners-overview.md)
