---
title: "How to: Use Automatic Layout to Create a Button"
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
  - "Button controls [WPF], creating with automatic layout"
  - "automatic layout [WPF], creating buttons"
ms.assetid: 96c206d0-9e77-4784-9d2d-5045aed2021c
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Automatic Layout to Create a Button
This example describes how to use the automatic layout approach to create a button in a localizable application.  
  
 Localization of a [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] can be a time consuming process. Often localizers need to resize and reposition elements in addition to translating text. In the past each language that a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] was adapted for required adjustment. Now with the capabilities of [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] you can design elements that reduce the need for adjustment. The approach to writing applications that can be more easily resized and repositioned is called `automatic layout`.  
  
 The following two [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] examples create applications that instantiate a button; one with English text and one with Spanish text. Notice that the code is the same except for the text; the button adjusts to fit the text.  
  
## Example  
 [!code-xaml[LocalizationBtn_snip#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LocalizationBtn_snip/CS/Pane1.xaml#1)]  
  
 [!code-xaml[LocalizationBtn#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LocalizationBtn/CS/Pane1.xaml#1)]  
  
 The following graphic shows the output of the code samples.  
  
 ![The same button with text in different languages](../../../../docs/framework/wpf/advanced/media/globalizationbutton.png "GlobalizationButton")  
Auto Resizable Button  
  
## See Also  
 [Use Automatic Layout Overview](../../../../docs/framework/wpf/advanced/use-automatic-layout-overview.md)  
 [Use a Grid for Automatic Layout](../../../../docs/framework/wpf/advanced/how-to-use-a-grid-for-automatic-layout.md)
