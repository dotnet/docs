---
title: "How to: Animate Material Properties in a 3-D Scene"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Material properties [WPF], animating in 3-D scenes"
  - "animation [WPF], Material properties in 3-D scenes"
  - "3-D scenes [WPF], animating Material properties"
ms.assetid: 229fd6eb-7401-4992-b0c9-8b28de230c0f
---
# How to: Animate Material Properties in a 3-D Scene
This example shows how to animate the <xref:System.Windows.Media.Brush.Opacity%2A> property of the <xref:System.Windows.Media.Media3D.Material> applied to a 3-D model.  
  
 The following code example defines the <xref:System.Windows.Media.LinearGradientBrush> used as the <xref:System.Windows.Media.Media3D.Material> applied to the 3D object.  
  
 [!code-xaml[Animation3DGallery_snip#AnimateMaterialExampleInline1](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/AnimateMaterialExample.xaml#animatematerialexampleinline1)]  
  
 The <xref:System.Windows.Media.Brush.Opacity%2A> property of this <xref:System.Windows.Media.LinearGradientBrush> is animated using the code example below.  
  
 [!code-xaml[Animation3DGallery_snip#AnimateMaterialExampleInline2](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/AnimateMaterialExample.xaml#animatematerialexampleinline2)]  
  
## Example  
 The following code shows the entire sample.  
  
 [!code-xaml[Animation3DGallery_snip#AnimateMaterialExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/AnimateMaterialExample.xaml#animatematerialexamplewholepage)]  
  
## See also

- [Create a 3-D Scene](how-to-create-a-3-d-scene.md)
- [3-D Graphics Overview](3-d-graphics-overview.md)
