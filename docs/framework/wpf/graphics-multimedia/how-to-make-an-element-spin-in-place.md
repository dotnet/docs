---
title: "How to: Make an Element Spin in Place"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "graphics [WPF], spinning elements"
  - "spinning elements [WPF]"
ms.assetid: 1f011976-8b07-4c31-9faf-019e0ddaa24c
---
# How to: Make an Element Spin in Place
This example shows how to make an element spin by using a <xref:System.Windows.Media.RotateTransform> and a <xref:System.Windows.Media.Animation.DoubleAnimation>.  
  
 The following example applies the <xref:System.Windows.Media.RotateTransform> to the <xref:System.Windows.UIElement.RenderTransform%2A> property of the element. The example uses a <xref:System.Windows.Media.Animation.DoubleAnimation> to animate the <xref:System.Windows.Media.RotateTransform.Angle%2A> of the <xref:System.Windows.Media.RotateTransform>. To make the element spin in place, the example sets the <xref:System.Windows.UIElement.RenderTransformOrigin%2A> property of the element to the point (0.5, 0.5).  
  
## Example  
 [!code-xaml[transformanimations_snip#11](~/samples/snippets/xaml/VS_Snippets_Wpf/transformanimations_snip/XAML/RotateAboutCenterExample.xaml#11)]  
  
 For the complete sample, which includes more transformation examples, see [2-D Transforms Sample](https://go.microsoft.com/fwlink/?LinkID=158252).  
  
## See also

- [Animation Overview](animation-overview.md)
- [Transforms Overview](transforms-overview.md)
