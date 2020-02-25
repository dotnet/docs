---
title: "How to: Make a Freezable Read-Only"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Freezable objects [WPF], making read-only"
ms.assetid: 6c544b7d-d3c9-4736-aa90-4b8728234ccb
---
# How to: Make a Freezable Read-Only
This example shows how to make a <xref:System.Windows.Freezable> read-only by calling its <xref:System.Windows.Freezable.Freeze%2A> method.  
  
 You cannot freeze a <xref:System.Windows.Freezable> object if any one of the following conditions is `true` about the object:  
  
- It has animated or data bound properties.  
  
- It has properties that are set by a dynamic resource. For more information about dynamic resources, see the [XAML Resources](../../../desktop-wpf/fundamentals/xaml-resources-define.md).  
  
- It contains <xref:System.Windows.Freezable> sub-objects that cannot be frozen.  
  
 If these conditions are `false` for your <xref:System.Windows.Freezable> object and you do not intend to modify it, consider freezing it to gain performance benefits.  
  
## Example  
 The following example freezes a <xref:System.Windows.Media.SolidColorBrush>, which is a type of <xref:System.Windows.Freezable> object.  
  
 [!code-csharp[freezablesample_procedural#FreezeExample1](~/samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#freezeexample1)]
 [!code-vb[freezablesample_procedural#FreezeExample1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#freezeexample1)]  
  
 For more information about <xref:System.Windows.Freezable> objects, see the [Freezable Objects Overview](freezable-objects-overview.md).  
  
## See also

- <xref:System.Windows.Freezable>
- <xref:System.Windows.Freezable.CanFreeze%2A>
- <xref:System.Windows.Freezable.Freeze%2A>
- [Freezable Objects Overview](freezable-objects-overview.md)
- [How-to Topics](base-elements-how-to-topics.md)
