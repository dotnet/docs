---
title: "How to: Override the Panel OnRender Method"
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
f1_keywords: 
  - "overriding OnRender method"
  - "Panel control, overriding OnRender method"
  - "OnRender method"
  - "controls, Panel, overriding OnRender method"
helpviewer_keywords: 
  - "overriding OnRender method of Panel control [WPF]"
  - "OnRender method [WPF], overriding"
  - "Panel control [WPF], overriding OnRender method"
ms.assetid: 57397834-a085-4e36-90ab-416fad98f341
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Override the Panel OnRender Method
This example shows how to override the <xref:System.Windows.Controls.Panel.OnRender%2A> method of <xref:System.Windows.Controls.Panel> in order to add custom graphical effects to a layout element.  
  
## Example  
 Use the <xref:System.Windows.Controls.Panel.OnRender%2A> method in order to add graphical effects to a rendered panel element. For example, you can use this method to add custom border or background effects. A <xref:System.Windows.Media.DrawingContext> object is passed as an argument, which provides methods for drawing shapes, text, images, or videos. As a result, this method is useful for customization of a panel object.  
  
 [!code-csharp[LightWeightCustomPanel#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LightWeightCustomPanel/CSharp/OffsetPanel.cs#1)]
 [!code-vb[LightWeightCustomPanel#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/LightWeightCustomPanel/visualbasic/offsetpanel.vb#1)]  
  
## See Also  
 <xref:System.Windows.Controls.Panel>  
 [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md)  
 [Custom Radial Panel Sample](http://go.microsoft.com/fwlink/?LinkID=159982)  
 [How-to Topics](../../../../docs/framework/wpf/controls/panel-how-to-topics.md)
