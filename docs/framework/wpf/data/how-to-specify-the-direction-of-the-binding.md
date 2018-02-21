---
title: "How to: Specify the Direction of the Binding"
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
  - "direction of binding [WPF]"
  - "binding direction [WPF]"
  - "data binding [WPF], direction of binding"
ms.assetid: 37334478-028b-4514-86c9-1420709f4818
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Specify the Direction of the Binding
This example shows how to specify whether the binding updates only the binding target (target) property, the binding source (source) property, or both the target property and the source property.  
  
## Example  
 You use the <xref:System.Windows.Data.Binding.Mode%2A> property to specify the direction of the binding. The following enumeration list shows the available options for binding updates:  
  
-   <xref:System.Windows.Data.BindingMode.TwoWay> updates the target property or the property whenever either the target property or the source property changes.  
  
-   <xref:System.Windows.Data.BindingMode.OneWay> updates the target property only when the source property changes.  
  
-   <xref:System.Windows.Data.BindingMode.OneTime> updates the target property only when the application starts or when the <xref:System.Windows.FrameworkElement.DataContext%2A> undergoes a change.  
  
-   <xref:System.Windows.Data.BindingMode.OneWayToSource> updates the source property when the target property changes.  
  
-   <xref:System.Windows.Data.BindingMode.Default> causes the default <xref:System.Windows.Data.Binding.Mode%2A> value of target property to be used.  
  
 For more information, see the <xref:System.Windows.Data.BindingMode> enumeration.  
  
 The following example shows how to set the <xref:System.Windows.Data.Binding.Mode%2A> property.  
  
 [!code-xaml[DirectionalBinding#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DirectionalBinding/CSharp/Page1.xaml#4)]  
  
 To detect source changes (applicable to <xref:System.Windows.Data.BindingMode.OneWay> and <xref:System.Windows.Data.BindingMode.TwoWay> bindings), the source must implement a suitable property change notification mechanism such as <xref:System.ComponentModel.INotifyPropertyChanged>. See [Implement Property Change Notification](../../../../docs/framework/wpf/data/how-to-implement-property-change-notification.md) for an example of an <xref:System.ComponentModel.INotifyPropertyChanged> implementation.  
  
 For <xref:System.Windows.Data.BindingMode.TwoWay> or <xref:System.Windows.Data.BindingMode.OneWayToSource> bindings, you can control the timing of the source updates by setting the <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> property. See <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> for more information.  
  
## See Also  
 <xref:System.Windows.Data.Binding>  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
