---
title: "How to: Use a Grid for Automatic Layout"
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
  - "grids [WPF], automatic layout"
  - "automatic layout [WPF], grid use"
ms.assetid: ab9de407-e0c1-4047-bdf0-24951bf73879
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use a Grid for Automatic Layout
This example describes how to use a grid in the automatic layout approach to creating a localizable application.  
  
 Localization of a [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] can be a time consuming process. Often localizers need to re-size and reposition elements in addition to translating text. In the past each language that a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] was adapted for required adjustment. Now with the capabilities of [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] you can design elements that reduce the need for adjustment. The approach to writing applications that can be more easily re-sized and repositioned is called `auto layout`.  
  
 The following [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] example demonstrates using a grid to position some buttons and text. Notice that the height and width of the cells are set to `Auto`; therefore the cell that contains the button with an image adjusts to fit the image. Because the <xref:System.Windows.Controls.Grid> element can adjust to its content it can be useful when taking the automatic layout approach to designing applications that can be localized.  
  
## Example  
 The following example shows how to use a grid.  
  
 [!code-xaml[LocalizationGrid#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LocalizationGrid/CS/Pane1.xaml#1)]  
  
 The following graphic shows the output of the code sample.  
  
 ![Grid example](../../../../docs/framework/wpf/advanced/media/glob-grid.png "glob_grid")  
Grid  
  
## See Also  
 [Use Automatic Layout Overview](../../../../docs/framework/wpf/advanced/use-automatic-layout-overview.md)  
 [Use Automatic Layout to Create a Button](../../../../docs/framework/wpf/advanced/how-to-use-automatic-layout-to-create-a-button.md)
