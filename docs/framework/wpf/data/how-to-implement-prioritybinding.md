---
title: "How to: Implement PriorityBinding"
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
  - "data binding [WPF], PriorityBinding class"
ms.assetid: d63b65ab-b3e9-4322-9aa8-1450f8d89532
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Implement PriorityBinding
<xref:System.Windows.Data.PriorityBinding> in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] works by specifying a list of bindings. The list of bindings is ordered from highest priority to lowest priority. If the highest priority binding returns a value successfully when it is processed then there is never a need to process the other bindings in the list. It could be the case that the highest priority binding takes a long time to be evaluated, the next highest priority that returns a value successfully will be used until a binding of a higher priority returns a value successfully.  
  
## Example  
 To demonstrate how <xref:System.Windows.Data.PriorityBinding> works, the `AsyncDataSource` object has been created with the following three properties: `FastDP`, `SlowerDP`, and `SlowestDP`.  
  
 The get accessor of `FastDP` returns the value of the `_fastDP` data member.  
  
 The get accessor of `SlowerDP` waits for 3 seconds before returning the value of the `_slowerDP` data member.  
  
 The get accessor of `SlowestDP` waits for 5 seconds before returning the value of the `_slowestDP` data member.  
  
> [!NOTE]
>  This example is for demonstration purposes only. The [!INCLUDE[TLA#tla_net](../../../../includes/tlasharptla-net-md.md)] guidelines recommend against defining properties that are orders of magnitude slower than a field set would be. For more information, see [NIB: Choosing Between Properties and Methods](http://msdn.microsoft.com/library/55825e8f-7e2e-448a-9505-7217cc91b1af).  
  
 [!code-csharp[PriorityBinding#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PriorityBinding/CSharp/Window1.xaml.cs#1)]
 [!code-vb[PriorityBinding#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PriorityBinding/VisualBasic/AsyncDataSource.vb#1)]  
  
 The <xref:System.Windows.Controls.TextBlock.Text%2A> property binds to the above `AsyncDS` using <xref:System.Windows.Data.PriorityBinding>:  
  
 [!code-xaml[PriorityBinding#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PriorityBinding/CSharp/Window1.xaml#2)]  
  
 When the binding engine processes the <xref:System.Windows.Data.Binding> objects, it starts with the first <xref:System.Windows.Data.Binding>, which is bound to the `SlowestDP` property. When this <xref:System.Windows.Data.Binding> is processed, it does not return a value successfully because it is sleeping for 5 seconds, so the next <xref:System.Windows.Data.Binding> element is processed. The next <xref:System.Windows.Data.Binding> does not return a value successfully because it is sleeping for 3 seconds. The binding engine then moves onto the next <xref:System.Windows.Data.Binding> element, which is bound to the `FastDP` property. This <xref:System.Windows.Data.Binding> returns the value "Fast Value". The <xref:System.Windows.Controls.TextBlock> now displays the value "Fast Value".  
  
 After 3 seconds elapses, the `SlowerDP` property returns the value "Slower Value". The <xref:System.Windows.Controls.TextBlock> then displays the value "Slower Value".  
  
 After 5 seconds elapses, the `SlowestDP` property returns the value "Slowest Value". That binding has the highest priority because it is listed first. The <xref:System.Windows.Controls.TextBlock> now displays the value "Slowest Value".  
  
 See <xref:System.Windows.Data.PriorityBinding> for information about what is considered a successful return value from a binding.  
  
## See Also  
 <xref:System.Windows.Data.Binding.IsAsync%2A?displayProperty=nameWithType>  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
