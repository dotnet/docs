---
title: "How to: Enable Visual Styles in a Hybrid Application"
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
  - "hybrid applications [WPF interoperability]"
  - "visual styles [Windows Forms]"
ms.assetid: 95de9b9c-d804-405c-b2d1-49a88c1e0fe1
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Enable Visual Styles in a Hybrid Application
This topic shows how to enable [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)] visual styles on a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control hosted in a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]-based application.  
  
 If your application calls the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> method, most of your [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls will automatically use visual styles when your application is run on [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)]. For more information, see [Rendering Controls with Visual Styles](../../../../docs/framework/winforms/controls/rendering-controls-with-visual-styles.md).  
  
 For a complete code listing of the tasks illustrated in this topic, see [Enabling Visual Styles in a Hybrid Application Sample](http://go.microsoft.com/fwlink/?LinkID=159986).  
  
## Enabling Windows Forms Visual Styles  
  
#### To enable Windows Forms visual styles  
  
1.  Create a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] Application project named `HostingWfWithVisualStyles`.  
  
2.  In Solution Explorer, add references to the following assemblies.  
  
    -   WindowsFormsIntegration  
  
    -   System.Windows.Forms  
  
3.  In the Toolbox, double-click the <xref:System.Windows.Controls.Grid> icon to place a <xref:System.Windows.Controls.Grid> element on the design surface.  
  
4.  In the Properties window, set the values of the <xref:System.Windows.FrameworkElement.Height%2A> and <xref:System.Windows.FrameworkElement.Width%2A> properties to **Auto**.  
  
5.  In Design view or XAML view, select the <xref:System.Windows.Window>.  
  
6.  In the Properties window, click the **Events** tab.  
  
7.  Double-click the <xref:System.Windows.FrameworkElement.Loaded> event.
  
8.  In MainWindow.xaml.vb or MainWindow.xaml.cs, insert the following code to handle the <xref:System.Windows.FrameworkElement.Loaded> event.  
  
     [!code-csharp[HostingWfWithVisualStyles#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HostingWfWithVisualStyles/CSharp/HostingWfWithVisualStyles/Window1.xaml.cs#11)]
     [!code-vb[HostingWfWithVisualStyles#11](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/HostingWfWithVisualStyles/VisualBasic/HostingWfWithVisualStyles/Window1.xaml.vb#11)]  
  
9. Press F5 to build and run the application.  
  
     The [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control is painted with visual styles.  
  
## Disabling Windows Forms Visual Styles  
 To disable visual styles, simply remove the call to the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> method.  
  
#### To disable Windows Forms visual styles  
  
1.  Open MainWindow.xaml.vb or MainWindow.xaml.cs in the Code Editor.  
  
2.  Comment out the call to the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> method.  
  
3.  Press F5 to build and run the application.  
  
     The [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control is painted with the default system style.  
  
## See Also  
 <xref:System.Windows.Forms.Application.EnableVisualStyles%2A>  
 <xref:System.Windows.Forms.VisualStyles>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Rendering Controls with Visual Styles](../../../../docs/framework/winforms/controls/rendering-controls-with-visual-styles.md)  
 [Walkthrough: Hosting a Windows Forms Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-control-in-wpf.md)
